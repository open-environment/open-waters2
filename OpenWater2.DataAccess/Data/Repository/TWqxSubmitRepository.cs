using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using OpenWater2.DataAccess;
using javax.xml.soap;
using System.Linq;
using net.epacdxnode.test;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Xml;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxSubmitRepository : Repository<TWqxTransactionLog>, ITWqxSubmitRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITOeSysLogRepository _sysLogRepo;
        private readonly ITOeAppSettingsRepository _appSettingsRepo;
        private readonly ITWqxOrganizationRepository _orgRepo;
        private readonly ITWqxUserOrgsRepository _userOrgRepo;
        private readonly ITWqxMonLocRepository _monlocRepo;
        private readonly ITWqxProjectRepository _projRepo;
        private readonly ITWqxActivityRepository _activityRepo;
        private readonly ITWqxTransactionLogRepository _transLogRepo;
        private readonly IOeAppTasksRepository _oeAppTasksRepository;
        private readonly ITWqxBatchSubmitRepository _batchSubmitRepo;
        private readonly ITWqxBatchSubmitTransRepository _batchSubmitTransRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public object RandomString { get; private set; }

        public TWqxSubmitRepository(ApplicationDbContext db,
            ITOeSysLogRepository sysLogRepo,
            ITOeAppSettingsRepository appSettingsRepo,
            ITWqxOrganizationRepository orgRepo,
            ITWqxUserOrgsRepository userOrgRepo,
            ITWqxMonLocRepository monlocRepo,
            ITWqxProjectRepository projRepo,
            ITWqxActivityRepository activityRepo,
            ITWqxTransactionLogRepository transLogRepo,
            IOeAppTasksRepository oeAppTasksRepository,
            ITWqxBatchSubmitRepository batchSubmitRepo,
            ITWqxBatchSubmitTransRepository batchSubmitTransRepo,
            IWebHostEnvironment webHostEnvironment) : base(db)
        {
            _db = db;
            _sysLogRepo = sysLogRepo;
            _appSettingsRepo = appSettingsRepo;
            _orgRepo = orgRepo;
            _userOrgRepo = userOrgRepo;
            _monlocRepo = monlocRepo;
            _projRepo = projRepo;
            _activityRepo = activityRepo;
            _transLogRepo = transLogRepo;
            _oeAppTasksRepository = oeAppTasksRepository;
            _batchSubmitRepo = batchSubmitRepo;
            _batchSubmitTransRepo = batchSubmitTransRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task WQX_BulkMasterSubmitStatusAsync(string OrgID)
        {
            Console.WriteLine("[Status] >> WQX_BulkMasterSubmitStatusAsync called");
            //log start of send
            await _sysLogRepo.InsertT_OE_SYS_LOGAsync("INFO", "Getting submission status for " + OrgID).ConfigureAwait(false);

            //get CDX username, password, and CDX destination URL
            CDXCredentials cred = await GetCDXSubmitCredentials2Async(OrgID).ConfigureAwait(false);

            //make 1 authenticate attempt just to verify. if failed, then exit, send email, and cancel for org
            string authResp = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
            if (string.IsNullOrEmpty(authResp))
            {
                Console.WriteLine("[Status] >> Login failed for supplied NAAS");
                await DisableWQXForOrgAsync(OrgID, "Login failed for supplied NAAS Username and Password for " + OrgID).ConfigureAwait(false);
                return;
            }
            // Get all the pending batches to to get the staus
            List<TWqxBatchSubmit> wqxBatchSubmits = await _batchSubmitRepo.GetPendingWqxBatchesByOrgId4StatusAsync(OrgID).ConfigureAwait(false);
            if(wqxBatchSubmits == null)
            {
                Console.WriteLine("[Status] >> GetPendingWqxBatchesByOrgId4StatusAsync returns null.");
                return;
            }
            Console.WriteLine("[Status] >> Batches: " + wqxBatchSubmits.Count.ToString());
            List<Task> tasks = new List<Task>();
            foreach (TWqxBatchSubmit wqxBatchSubmit in wqxBatchSubmits)
            {
                await ProcessBatchStatusAsync(wqxBatchSubmit, OrgID, cred).ConfigureAwait(false);
            }
        }
        public async Task WQX_BulkMasterAsync(string OrgID)
        {
            Console.WriteLine("[Submission] > WQX_BulkMasterAsync called");
            //log start of send
            await _sysLogRepo.InsertT_OE_SYS_LOGAsync("INFO", "Starting WQX submission for " + OrgID).ConfigureAwait(false);

            //get CDX username, password, and CDX destination URL
            CDXCredentials cred = await GetCDXSubmitCredentials2Async(OrgID).ConfigureAwait(false);

            //make 1 authenticate attempt just to verify. if failed, then exit, send email, and cancel for org
            string authResp = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
            if (string.IsNullOrEmpty(authResp))
            {
                Console.WriteLine("[Submission] > Login failed for supplied NAAS");
                await DisableWQXForOrgAsync(OrgID, "Login failed for supplied NAAS Username and Password for " + OrgID).ConfigureAwait(false);
                return;
            }

            // Call WQXBatchProcess SP to create multiple batches for given OrgID
            string transId = UtilityHelper.RandomString(35, false);

            if (await SP_ProcessBatchAsync(transId, OrgID, 1).ConfigureAwait(false))
            {
                Console.WriteLine("[Submission] > SP_ProcessBatch called");
                // Get all the pending batches to process and submit each
                List<TWqxBatchSubmit> wqxBatchSubmits = await _batchSubmitRepo.GetPendingWqxBatchesByOrgIdAsync(OrgID).ConfigureAwait(false);
                if(wqxBatchSubmits == null)
                {
                    Console.WriteLine("[Submission] > GetPendingWqxBatchesByOrgIdAsync returns null: " + wqxBatchSubmits.Count.ToString());
                    return;
                }
                Console.WriteLine("[Submission] > Batches: " + wqxBatchSubmits.Count.ToString());
                List<Task> tasks = new List<Task>();
                foreach (TWqxBatchSubmit wqxBatchSubmit in wqxBatchSubmits)
                {
                    Console.WriteLine("[Submission] > Process batch Id:" + wqxBatchSubmit.Bsmid.ToString());
                    //Create a task and add to task collection
                    //************************************************************
                    //DO NOT AWAIT HERE, entire task collection will be awaited
                    //after for loop
                    var task = ProcessBatchAsync(wqxBatchSubmit, OrgID, cred);
                    tasks.Add(task);
                    //***********************************************************
                    //tasks.Add(Task.Run(ProcessBatchAsync(wqxBatchSubmit, OrgID, cred).ConfigureAwait(false)));
                    //bool isBatchProcessed = await ProcessBatchAsync(wqxBatchSubmit, OrgID, cred).ConfigureAwait(false);
                }
                await Task.WhenAll(tasks).ConfigureAwait(false);
                Console.WriteLine("[Submission] > WhenAll done");
            }

        }
        private async Task<bool> ProcessBatchStatusAsync(TWqxBatchSubmit wqxBatchSubmit,
                                                    string OrgID,
                                                   CDXCredentials cred)
        {
            string typeText = "Batch";
            int RecordIDX = wqxBatchSubmit.Bsmid;

            //*******AUTHENTICATE*********************************************************************************************************
            string token = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
            Console.WriteLine("[Status] >> Token received..." + token);

            Console.WriteLine("[Status] >> ProcessBatchAsync called for " + RecordIDX);
            bool actResult = false;
            try
            {
                string status = "";

                StatusResponseType gsResp = await GetStatusHelperAsync(cred.NodeURL, token, wqxBatchSubmit.CdxSubmitTransid).ConfigureAwait(false);
                if (gsResp != null)
                {
                    status = gsResp.status.ToString();
                    Console.WriteLine("[Status] >> Received status " + status);
                    //update status of record
                    if (status == "Completed")
                    {
                        await _batchSubmitRepo.InsertOrUpdateBatchSubmitAsync(wqxBatchSubmit.Bsmid,
                                                                    wqxBatchSubmit.CdxSubmitTransid,
                                                                    status,
                                                                    wqxBatchSubmit.SubmitType,
                                                                    OrgID,
                                                                    "N",
                                                                    wqxBatchSubmit.SubmitAttempt ?? 0,
                                                                    wqxBatchSubmit.StatusAttempt ?? 0,
                                                                    wqxBatchSubmit.SubmitDate).ConfigureAwait(false);
                        await _batchSubmitTransRepo.UpdateAllStatusByBMSIDAsync(wqxBatchSubmit.Bsmid,
                                                                          status).ConfigureAwait(false);
                        //UpdateRecordStatus(typeText, RecordIDX, "Y");
                        //All the entries are passed so update it
                        List<TWqxBatchSubmitTrans> batches = await _batchSubmitTransRepo.GetAllByBMSIDAsync(wqxBatchSubmit.Bsmid).ConfigureAwait(false);
                        if(batches == null)
                        {
                            Console.WriteLine("[Status] >> GetAllByBMSIDAsync returns null. ");
                            return false;
                        }
                        foreach (TWqxBatchSubmitTrans batch in batches)
                        {
                            await _batchSubmitTransRepo.InsertOrUpdateBatchSubmitTransAsync(
                                                                batch.Bstid,
                                                                batch.Bsmid,
                                                                batch.TableCd,
                                                                batch.TableIdx,
                                                                batch.TableId,
                                                                "Completed",
                                                                "N").ConfigureAwait(false);
                            await UpdateRecordStatusAsync(typeText, batch.TableIdx.GetValueOrDefault(), "Y").ConfigureAwait(false);
                        }
                        _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, null, wqxBatchSubmit.CdxSubmitTransid, status, OrgID);
                    }
                    else if (status == "Failed")
                    {
                        int submitAttempt = (wqxBatchSubmit.SubmitAttempt ?? 0);
                        int statusAttemp = (wqxBatchSubmit.StatusAttempt ?? 0) + 1;
                        await _batchSubmitRepo.InsertOrUpdateBatchSubmitAsync(wqxBatchSubmit.Bsmid,
                                                                    wqxBatchSubmit.CdxSubmitTransid,
                                                                    status,
                                                                    wqxBatchSubmit.SubmitType,
                                                                    OrgID,
                                                                    "N",
                                                                    submitAttempt,
                                                                    statusAttemp,
                                                                    wqxBatchSubmit.SubmitDate).ConfigureAwait(false);
                        //UpdateRecordStatus(typeText, RecordIDX, "N");

                        int iCount = 0;
                        //*******DOWNLOAD ERROR REPORT ****************************************************************************
                        NodeDocumentType[] dlResp = DownloadHelper(cred.NodeURL, token, "WQX", wqxBatchSubmit.CdxSubmitTransid);
                        foreach (NodeDocumentType ndt in dlResp)
                        {
                            if (ndt.documentName.Contains("Processing"))
                            {
                                Byte[] resp1 = dlResp[iCount].documentContent.Value;
                                string folderPath = Path.Combine(Environment.CurrentDirectory, "TempStatus");
                                if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
                                string fileName = Guid.NewGuid().ToString() + ".zip";
                                string filePath = Path.Combine(folderPath, fileName);
                                if (File.Exists(filePath)) File.Delete(filePath);
                                File.WriteAllBytes(filePath, resp1);
                                string xmlContent = await ReadZipFileAsync(filePath).ConfigureAwait(false);
                                //Try to delete the file
                                try
                                {
                                    File.Delete(filePath);
                                }
                                catch (Exception e)
                                {
                                    //do nothing, or handle this case
                                }
                                
                                if (!string.IsNullOrEmpty(xmlContent))
                                {
                                    XmlDocument document = new XmlDocument();
                                    document.LoadXml(xmlContent);
                                    XmlNode node = document.SelectSingleNode("/ProcessingReport/ProcessingFailures");
                                    if (node.HasChildNodes)
                                    {
                                        foreach (XmlNode childNode in node.ChildNodes)
                                        {
                                            if (childNode.LocalName.ToLower() == "monitoringlocationidentifier")
                                            {
                                                string mlocid = childNode.InnerText;
                                                if (!string.IsNullOrEmpty(mlocid))
                                                {
                                                    await UpdateBatchSubmitTransStatusAsync("MLOC", mlocid, "Failed").ConfigureAwait(false);
                                                    UpdateRecordStatusAsync("MLOC", mlocid, "N");
                                                    
                                                }
                                            }
                                            if (childNode.LocalName.ToLower() == "activityidentifier")
                                            {
                                                string actid = childNode.InnerText;
                                                if (!string.IsNullOrEmpty(actid))
                                                {
                                                    await UpdateBatchSubmitTransStatusAsync("ACT", actid, "Failed").ConfigureAwait(false);
                                                    UpdateRecordStatusAsync("ACT", actid, "N");
                                                }
                                            }
                                            if (childNode.LocalName.ToLower() == "projectidentifier")
                                            {
                                                string projid = childNode.InnerText;
                                                if (!string.IsNullOrEmpty(projid))
                                                {
                                                    await UpdateBatchSubmitTransStatusAsync("PROJ", projid, "Failed").ConfigureAwait(false);
                                                    UpdateRecordStatusAsync("PROJ", projid, "N");
                                                }
                                            }
                                        }
                                    }

                                    // Select a list of nodes
                                    //XmlNodeList nodes = document.SelectNodes("/People/Person");
                                }
                            }
                            if (ndt.documentName.Contains("Validation") || ndt.documentName.Contains("Processing"))
                            {
                                Byte[] resp1 = dlResp[iCount].documentContent.Value;
                                _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", resp1, ndt.documentName, wqxBatchSubmit.CdxSubmitTransid, status, OrgID);
                            }
                            iCount += 1;
                        }

                        //All the remaining entries are passed so update it
                        List<TWqxBatchSubmitTrans> batches = _batchSubmitTransRepo.GetAllByBMSID(wqxBatchSubmit.Bsmid);
                        if(batches != null)
                        {
                            foreach (TWqxBatchSubmitTrans batch in batches)
                            {
                                if (batch.IsInBatchProcess == "Y")
                                {
                                    await _batchSubmitTransRepo.InsertOrUpdateBatchSubmitTransAsync(
                                                                        batch.Bstid,
                                                                        batch.Bsmid,
                                                                        batch.TableCd,
                                                                        batch.TableIdx,
                                                                        batch.TableId,
                                                                        "Completed",
                                                                        "N").ConfigureAwait(false);
                                    await UpdateRecordStatusAsync(typeText, batch.TableIdx.GetValueOrDefault(), "Y").ConfigureAwait(false);
                                }

                            }
                        }
                    }
                    else
                    {
                        await _batchSubmitRepo.InsertOrUpdateBatchSubmitAsync(wqxBatchSubmit.Bsmid,
                                                                    wqxBatchSubmit.CdxSubmitTransid,
                                                                    status,
                                                                    wqxBatchSubmit.SubmitType,
                                                                    OrgID,
                                                                    wqxBatchSubmit.IsBatchInProcess,
                                                                    wqxBatchSubmit.SubmitAttempt ?? 0,
                                                                    wqxBatchSubmit.StatusAttempt ?? 0,
                                                                    DateTime.Now).ConfigureAwait(false);
                    }
                }
                else
                {
                    Console.WriteLine("[Status] >> Status response is null for :" + wqxBatchSubmit.Bsmid);
                }

                //*******GET STATUS * *******************************************************************************************************
                //string status = "";
                //int i = 0;
                //do
                //{
                //    i += 1;
                //    Task.Delay(10000).Wait();
                //    //Thread.Sleep(10000);
                //    StatusResponseType gsResp = await GetStatusHelperAsync(cred.NodeURL, token, wqxBatchSubmit.CdxSubmitTransid).ConfigureAwait(false);
                //    if (gsResp != null)
                //    {
                //        status = gsResp.status.ToString();
                //        //exit if waiting too long
                //        if (i > 30)
                //        {
                //            UpdateRecordStatus(typeText, RecordIDX, "N");
                //            _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, "Timed out while getting status from EPA", wqxBatchSubmit.CdxSubmitTransid, "Failed", OrgID);
                //            return false;
                //        }
                //    }
                //} while (status != "Failed" && status != "Completed");

                ////update status of record
                //if (status == "Completed")
                //{
                //    UpdateRecordStatus(typeText, RecordIDX, "Y");
                //    _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, null, wqxBatchSubmit.CdxSubmitTransid, status, OrgID);
                //}
                //else if (status == "Failed")
                //{
                //    UpdateRecordStatus(typeText, RecordIDX, "N");

                //    int iCount = 0;
                //    //*******DOWNLOAD ERROR REPORT ****************************************************************************
                //    NodeDocumentType[] dlResp = DownloadHelper(cred.NodeURL, token, "WQX", wqxBatchSubmit.CdxSubmitTransid);
                //    foreach (NodeDocumentType ndt in dlResp)
                //    {
                //        if (ndt.documentName.Contains("Validation") || ndt.documentName.Contains("Processing"))
                //        {
                //            Byte[] resp1 = dlResp[iCount].documentContent.Value;
                //            _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", resp1, ndt.documentName, wqxBatchSubmit.CdxSubmitTransid, status, OrgID);
                //        }
                //        iCount += 1;
                //    }
                //}
            }
            catch (Exception e)
            {
                throw;
            }
            return actResult;
        }

        private async Task<int> UpdateBatchSubmitTransStatusAsync(string TableCd, string TableId, string Status)
        {
            
            try
            {
                return await _batchSubmitTransRepo.UpdateBatchSubmitTransAsync(TableCd, TableId, Status).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private async Task<string> ReadZipFileAsync(String filePath)
        {
            String fileContents = "";
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    using (System.IO.Compression.ZipArchive apcZipFile = System.IO.Compression.ZipFile.Open(filePath, System.IO.Compression.ZipArchiveMode.Read))
                    {
                        foreach (System.IO.Compression.ZipArchiveEntry entry in apcZipFile.Entries)
                        {
                            if (entry.Name.ToUpper().EndsWith(".XML"))
                            {
                                System.IO.Compression.ZipArchiveEntry zipEntry = apcZipFile.GetEntry(entry.Name);
                                using (System.IO.StreamReader sr = new System.IO.StreamReader(zipEntry.Open()))
                                {
                                    //read the contents into a string
                                    fileContents = sr.ReadToEnd();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                fileContents = "";
            }
            return fileContents;
        }
        private async Task<bool> ProcessBatchAsync(TWqxBatchSubmit wqxBatchSubmit,
                                                    string OrgID,
                                                    CDXCredentials cred)
        {
            Console.WriteLine("[Submission] > ProcessBatchAsync called...");
            bool actResult = false;
            try
            {
                string typeText = "Batch";
                int RecordIDX = 0;

                //log start of send
                await _sysLogRepo.InsertT_OE_SYS_LOGAsync("INFO", "Starting WQX submission for " + OrgID).ConfigureAwait(false);

                //*******AUTHENTICATE*********************************************************************************************************
                string token = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
                Console.WriteLine("[Submission] > Token received..." + token);
                //*******SUBMIT***************************************************************************************************************
                string requestXml = "";
                Console.WriteLine(
                    System.Threading.Thread.CurrentThread.
                    ManagedThreadId.ToString());
                Console.WriteLine("[Submission] > BSMID:" + wqxBatchSubmit.Bsmid);
                requestXml = SP_GenWQXXML_Single2("", 0, OrgID, wqxBatchSubmit.Bsmid);
                if (string.IsNullOrEmpty(requestXml)) return false;
                byte[] bytes = UtilityHelper.StrToByteArray(requestXml);
                if (bytes == null) return false;
                Console.WriteLine("[Submission] > XML generated");
                StatusResponseType subStatus = await SubmitHelperAsync(cred.NodeURL, token, "WQX", "default", bytes, "submit.xml", DocumentFormatType.XML, "1").ConfigureAwait(false);
                if (subStatus != null)
                {
                    Console.WriteLine("[Submission] > Response received.");
                    Console.WriteLine(subStatus.status.ToString());
                    Console.WriteLine(subStatus.transactionId);
                    await UpdateBatchStatusAsync(wqxBatchSubmit, subStatus).ConfigureAwait(false);
                }
                else
                {
                    Console.WriteLine("[Submission] > Response received.: Failed");
                    subStatus = new StatusResponseType();
                    subStatus.status = TransactionStatusCode.Failed;
                    wqxBatchSubmit.IsBatchInProcess = "N";
                    await UpdateBatchStatusAsync(wqxBatchSubmit, subStatus).ConfigureAwait(false);
                    await _transLogRepo.InsertUpdateWQX_TRANSACTION_LOGAsync(null, typeText, RecordIDX, "I", null, "Unable to submit", null, "Failed", OrgID).ConfigureAwait(false);
                    await DisableWQXForOrgAsync(OrgID, "Submission failed for supplied for " + OrgID).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return actResult;
        }

        private async Task<int> UpdateBatchStatusAsync(TWqxBatchSubmit wqxBatchSubmit, 
                                                        StatusResponseType subStatus)
        {
            int actResult = 0;
            try
            {
                actResult = await _batchSubmitRepo.InsertOrUpdateBatchSubmitAsync(wqxBatchSubmit.Bsmid,
                                                            subStatus.transactionId,
                                                            Enum.GetName(typeof(TransactionStatusCode), subStatus.status),
                                                            wqxBatchSubmit.SubmitType,
                                                            wqxBatchSubmit.OrgId,
                                                            wqxBatchSubmit.IsBatchInProcess,
                                                            wqxBatchSubmit.SubmitAttempt ?? 0,
                                                            wqxBatchSubmit.StatusAttempt ?? 0,
                                                            wqxBatchSubmit.SubmitDate).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                actResult = 0;
            }
            return actResult;
        }

        public async Task WQX_MasterAsync(string OrgID)
        {
            //log start of send

            _sysLogRepo.InsertT_OE_SYS_LOG("INFO", "Starting WQX submission for " + OrgID);

            //get CDX username, password, and CDX destination URL
            CDXCredentials cred = await GetCDXSubmitCredentials2Async(OrgID).ConfigureAwait(false);

            //make 1 authenticate attempt just to verify. if failed, then exit, send email, and cancel for org
            string authResp = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
            if (string.IsNullOrEmpty(authResp))
            {
                await DisableWQXForOrgAsync(OrgID, "Login failed for supplied NAAS Username and Password for " + OrgID).ConfigureAwait(false);
                return;
            }

            //Loop through all pending monitoring locations (including both active and inactive) and submit one at a time
            List<TWqxMonloc> ms = await _monlocRepo.GetWQX_MONLOC(false, OrgID, true);
            foreach (TWqxMonloc m in ms)
                await WQX_Submit_OneByOneAsync("MLOC", m.MonlocIdx, cred.userID, cred.credential, cred.NodeURL, OrgID, m.ActInd).ConfigureAwait(false);

            //Loop through all pending projects and submit one at a time
            List<TWqxProject> ps = _projRepo.GetWQX_PROJECT(false, OrgID, true);
            foreach (TWqxProject p in ps)
                await WQX_Submit_OneByOneAsync("PROJ", p.ProjectIdx, cred.userID, cred.credential, cred.NodeURL, OrgID, p.ActInd).ConfigureAwait(false);

            try
            {
                //Loop through all pending activities and submit one at a time
                List<TWqxActivity> as1 = _activityRepo.GetWQX_ACTIVITY(false, OrgID, null, null, null, null, true, null);
                foreach (TWqxActivity a in as1)
                    await WQX_Submit_OneByOneAsync("ACT", a.ActivityIdx, cred.userID, cred.credential, cred.NodeURL, OrgID, a.ActInd).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", "Exception during activity submit: " + ex.Message.SubStringPlus(1, 200));
            }

        }
        public async Task<CDXCredentials> GetCDXSubmitCredentials2Async(string OrgID)
        {
            //production
            //    NodeURL = "https://cdxnodengn.epa.gov/ngn-enws20/services/NetworkNode2ServiceConditionalMTOM"; //new 2.1
            //    NodeURL = "https://cdxnodengn.epa.gov/ngn-enws20/services/NetworkNode2Service"; //new 2.0
            //test
            //    NodeURL = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2ServiceConditionalMTOM"; //new 2.1
            //    NodeURL = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2Service";  //new 2.0
            //    NodeURL = "https://test.epacdxnode.net/cdx-enws20/services/NetworkNode2ConditionalMtom"; //old 2.1

            var cred = new CDXCredentials();
            try
            {
                cred.NodeURL = await _appSettingsRepo.GetT_OE_APP_SETTINGAsync("CDX Submission URL").ConfigureAwait(false);

                TWqxOrganization org = await _orgRepo.GetWQX_ORGANIZATION_ByIDAsync(OrgID).ConfigureAwait(false);
                if (org != null)
                {
                    if (string.IsNullOrEmpty(org.CdxSubmitterId) == false && string.IsNullOrEmpty(org.CdxSubmitterPwdHash) == false)
                    {
                        cred.userID = org.CdxSubmitterId;
                        cred.credential = new SimpleAES().Decrypt(System.Web.HttpUtility.UrlDecode(org.CdxSubmitterPwdHash).Replace(" ", "+"));
                    }
                    else
                    {
                        cred.userID = await _appSettingsRepo.GetT_OE_APP_SETTINGAsync("CDX Submitter").ConfigureAwait(false);
                        cred.credential = await _appSettingsRepo.GetT_OE_APP_SETTINGAsync("CDX Submitter Password").ConfigureAwait(false);
                    }
                }
            }
            catch { }

            return cred;
        }
        internal async Task<string> AuthHelperAsync(string userID, string credential, string authMethod, string domain, string NodeURL)
        {
            NetworkNodePortType2Client.EndpointConfiguration endpoint =
                new NetworkNodePortType2Client.EndpointConfiguration();

            NetworkNodePortType2Client nn =
                new NetworkNodePortType2Client(endpoint, NodeURL);
            //nn.Url = NodeURL;
            Authenticate auth1 = new Authenticate();
            auth1.userId = userID;
            auth1.credential = credential;
            auth1.authenticationMethod = authMethod;
            auth1.domain = domain;
            try
            {
                AuthenticateResponse1 resp = await nn.AuthenticateAsync(auth1).ConfigureAwait(false);
                return resp.AuthenticateResponse.securityToken;
            }
            catch (SOAPException sExept)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", sExept.Message.Substring(0, 1999));   //logging an authentication failure
                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        private async Task<int> DisableWQXForOrgAsync(string OrgID, string LogMsg)
        {
            int actResult = 0;
            try
            {
                //when done, update status back to stopped
                await _orgRepo.InsertOrUpdateT_WQX_ORGANIZATIONAsync(OrgID, null, null, null, null, null, null, null, null, null, null, false, null, null).ConfigureAwait(false);
                await _sysLogRepo.InsertT_OE_SYS_LOGAsync("WQX_ORG_STOP", LogMsg).ConfigureAwait(false);

                List<TOeUsers> users = await _userOrgRepo.GetWQX_USER_ORGS_AdminsByOrgAsync(OrgID).ConfigureAwait(false);
                foreach (TOeUsers user in users)
                    UtilityHelper.SendEmail(null, user.Email.Split(';').ToList(),
                        null, null, "Open Waters Submit Failure",
                        "Automated submission for " + OrgID +
                        " has been disabled due to a submission failure. Failure details are: " +
                        LogMsg, null, _appSettingsRepo,
                        _sysLogRepo);
            }
            catch (Exception e)
            {
                return 0;
            }
            return actResult;
        }

        public async Task WQX_Submit_OneByOneAsync(string typeText, int RecordIDX, string userID, string credential, string NodeURL, string orgID, bool? InsUpdIndicator)
        {
            try
            {
                //*******AUTHENTICATE*********************************************************************************************************
                string token = await AuthHelperAsync(userID, credential, "Password", "default", NodeURL).ConfigureAwait(false);

                //*******SUBMIT***************************************************************************************************************
                string requestXml = "";
                if (typeText == "All")
                {
                    requestXml = InsUpdIndicator == false ? SP_GenWQXXML_Single_Delete(typeText, RecordIDX) : SP_GenWQXXML_Single2(typeText, RecordIDX, orgID, 0);   //get XML from DB stored procedure
                }
                else
                {
                    requestXml = InsUpdIndicator == false ? SP_GenWQXXML_Single_Delete(typeText, RecordIDX) : SP_GenWQXXML_Single(typeText, RecordIDX);   //get XML from DB stored procedure
                }

                byte[] bytes = UtilityHelper.StrToByteArray(requestXml);
                if (bytes == null) return;


                StatusResponseType subStatus = await SubmitHelperAsync(NodeURL, token, "WQX", "default", bytes, "submit.xml", DocumentFormatType.XML, "1").ConfigureAwait(false);
                if (subStatus != null)
                {
                    //*******GET STATUS********************************************************************************************************
                    string status = "";
                    int i = 0;
                    do
                    {
                        i += 1;
                        Task.Delay(10000).Wait();
                        //Thread.Sleep(10000);
                        StatusResponseType gsResp = await GetStatusHelperAsync(NodeURL, token, subStatus.transactionId).ConfigureAwait(false);
                        if (gsResp != null)
                        {
                            status = gsResp.status.ToString();
                            //exit if waiting too long
                            if (i > 30)
                            {
                                await UpdateRecordStatusAsync(typeText, RecordIDX, "N").ConfigureAwait(false);
                                await _transLogRepo.InsertUpdateWQX_TRANSACTION_LOGAsync(null, typeText, RecordIDX, "I", null, "Timed out while getting status from EPA", subStatus.transactionId, "Failed", orgID).ConfigureAwait(false);
                                return;
                            }
                        }
                    } while (status != "Failed" && status != "Completed");

                    //update status of record
                    if (status == "Completed")
                    {
                        await UpdateRecordStatusAsync(typeText, RecordIDX, "Y").ConfigureAwait(false);
                        await _transLogRepo.InsertUpdateWQX_TRANSACTION_LOGAsync(null, typeText, RecordIDX, "I", null, null, subStatus.transactionId, status, orgID).ConfigureAwait(false);
                    }
                    else if (status == "Failed")
                    {
                        await UpdateRecordStatusAsync(typeText, RecordIDX, "N").ConfigureAwait(false);

                        int iCount = 0;
                        //*******DOWNLOAD ERROR REPORT ****************************************************************************
                        NodeDocumentType[] dlResp = DownloadHelper(NodeURL, token, "WQX", subStatus.transactionId);
                        foreach (NodeDocumentType ndt in dlResp)
                        {
                            if (ndt.documentName.Contains("Validation") || ndt.documentName.Contains("Processing"))
                            {
                                Byte[] resp1 = dlResp[iCount].documentContent.Value;
                                _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", resp1, ndt.documentName, subStatus.transactionId, status, orgID);
                            }
                            iCount += 1;
                        }
                    }
                }
                else
                {
                    _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, "Unable to submit", null, "Failed", orgID);
                    await DisableWQXForOrgAsync(orgID, "Submission failed for supplied for " + orgID).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", "Exception during activity submitType 2");

                //string execption1;
                //if (sExept.Detail != null)
                //    execption1 = sExept.Detail.InnerText;
                //else
                //    execption1 = sExept.Message;
            }

        }

        internal static NodeDocumentType[] DownloadHelper(string NodeURL, string secToken, string dataFlow, string transID)
        {
            try
            {
                NetworkNodePortType2Client.EndpointConfiguration endpoint =
                    new NetworkNodePortType2Client.EndpointConfiguration();
                NetworkNodePortType2Client nn2 =
                    new NetworkNodePortType2Client(endpoint, NodeURL);
                //NetworkNode2 nn = new NetworkNode2();
                //nn.Url = NodeURL;
                Download dl1 = new Download();
                dl1.securityToken = secToken;
                dl1.dataflow = dataFlow;
                dl1.transactionId = transID;
                var response = nn2.DownloadAsync(dl1);
                return response.Result.DownloadResponse1;
                //return nn.Download(dl1);
            }
            catch
            {
                return null;
            }

        }
        internal async Task UpdateRecordStatusAsync(string type, string tableID, string status)
        {
            if (type == "MLOC")
            {
                TWqxMonloc monloc = _monlocRepo.GetFirstOrDefault(m => m.MonlocId == tableID);
                if(monloc != null)
                {
                    await UpdateRecordStatusAsync(type, monloc.MonlocIdx, status).ConfigureAwait(false);
                }
            }
            if (type == "PROJ")
            {
                TWqxProject proj = _projRepo.GetFirstOrDefault(p => p.ProjectId == tableID);
                if(proj != null)
                {
                    await UpdateRecordStatusAsync(type, proj.ProjectIdx, status).ConfigureAwait(false);
                }
            }
            if (type == "ACT")
            {
                TWqxActivity act = _activityRepo.GetFirstOrDefault(a => a.ActivityId == tableID);
                if(act != null)
                {
                    await UpdateRecordStatusAsync(type, act.ActivityIdx, status).ConfigureAwait(false);
                }
            }
        }
        internal async Task UpdateRecordStatusAsync(string type, int RecordIDX, string status)
        {
            if (type == "MLOC")
                await _monlocRepo.InsertOrUpdateWQX_MONLOCAsync(RecordIDX, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null,
                    null, status, null, null, null, null, null, null, null, null, null, null, null, null, DateTime.Now, true, false, "SYSTEM").ConfigureAwait(false);

            if (type == "PROJ")
                _projRepo.InsertOrUpdateWQX_PROJECT(RecordIDX, null, null, null, null, null, null, null, status, System.DateTime.Now, null, false, "SYSTEM");

            if (type == "ACT")
                _activityRepo.UpdateWQX_ACTIVITY_WQXStatus(RecordIDX, status, null, false, "SYSTEM");
        }
        internal async Task<StatusResponseType> SubmitHelperAsync(string NodeURL, string secToken,
            string dataFlow, string flowOperation, byte[] doc, string docName,
            DocumentFormatType docFormat, string docID)
        {
            try
            {
                AttachmentType att1 = new AttachmentType();
                att1.Value = doc;
                NodeDocumentType doc1 = new NodeDocumentType();
                doc1.documentName = docName;
                doc1.documentFormat = docFormat;
                doc1.documentId = docID;
                doc1.documentContent = att1;
                NodeDocumentType[] docArray = new NodeDocumentType[1];
                docArray[0] = doc1;
                Submit sub1 = new Submit();
                sub1.securityToken = secToken;
                sub1.transactionId = "";
                sub1.dataflow = dataFlow;
                sub1.flowOperation = flowOperation;
                sub1.documents = docArray;
                NetworkNodePortType2Client.EndpointConfiguration endpoint
                    = new NetworkNodePortType2Client.EndpointConfiguration();
                NetworkNodePortType2Client nn2 =
                    new NetworkNodePortType2Client(endpoint, NodeURL);
                var response = await nn2.SubmitAsync(sub1).ConfigureAwait(false);
                StatusResponseType statusResponseType =
                    new StatusResponseType();
                statusResponseType.status = response.SubmitResponse1.status;
                statusResponseType.transactionId = response.SubmitResponse1.transactionId;
                return statusResponseType;
                //NetworkNode2 nn = new NetworkNode2();
                //nn.SoapVersion = SoapProtocolVersion.Soap12;
                //nn.Url = NodeURL;
                //return nn.Submit(sub1);
            }
            catch (SOAPException sExept)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("WQX", sExept.Message.SubStringPlus(0, 1999));
                return null;
            }
        }
        //internal string AuthHelper(string userID, string credential, string authMethod, string domain, string NodeURL)
        //{
        //    NetworkNode2.NetworkNodePortType2Client.EndpointConfiguration endpoint
        //        = new NetworkNodePortType2Client.EndpointConfiguration();
        //    NetworkNode2.NetworkNodePortType2Client nn = new NetworkNode2.NetworkNodePortType2Client(endpoint, NodeURL);
        //    // nn.Url = NodeURL;
        //    AuthenticateRequest auth1 = new AuthenticateRequest();
        //    auth1.Authenticate.userId = userID;
        //    auth1.Authenticate.credential = credential;
        //    auth1.Authenticate.authenticationMethod = authMethod;
        //    auth1.Authenticate.domain = domain;
        //    try
        //    {

        //        AuthenticateResponse1 resp = nn.Authenticate(auth1);
        //        return resp.AuthenticateResponse.securityToken;
        //    }
        //    catch (SOAPException sExept)
        //    {
        //        _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", sExept.Message.SubStringPlus(0, 1999));   //logging an authentication failure
        //        return "";
        //    }
        //}

        // *************************** XML GENERATION ********************************
        // ***************************************************************************
        //TODO: Need to verify StoredProcedure call and return value
        public string SP_GenWQXXML_Single(string TypeText, int recordIDX)
        {
            string actResult = "";
            try
            {
                SqlParameter[] @params =
                {
                   new SqlParameter("@ReturnValue", SqlDbType.NVarChar, -1)
                   {Direction = ParameterDirection.Output},
                   new SqlParameter("@TypeText", SqlDbType.VarChar, 4)
                   {Direction = ParameterDirection.Input, Value = TypeText},
                   new SqlParameter("@RecordIDX", SqlDbType.Int)
                   {Direction = ParameterDirection.Input, Value = recordIDX}
                };
                string storedProcName = "GenWQXXML_Single2";
                _db.Database.ExecuteSqlCommand("exec " + storedProcName + " @ReturnValue OUT, @TypeText, @RecordIDX", @params);
                actResult = @params[0].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }
        public async Task<bool> SP_ProcessBatchAsync(string TransId, string OrgId, int ActCount)
        {
            bool actResult = false;

            try
            {
                SqlParameter[] @params =
                {
                   new SqlParameter("@TransId", SqlDbType.VarChar, 100)
                   {Direction = ParameterDirection.Input, Value = TransId},
                   new SqlParameter("@OrgID", SqlDbType.VarChar)
                   {Direction = ParameterDirection.Input, Value = OrgId},
                   new SqlParameter("@ActCount", SqlDbType.Int)
                   {Direction = ParameterDirection.Input, Value = ActCount}
                };
                string storedProcName = "WQXBatchProcess";
                await _db.Database.ExecuteSqlCommandAsync("exec " + storedProcName + " @TransId, @OrgID, @ActCount", @params).ConfigureAwait(false);
                actResult = true;
            }
            catch (Exception ex)
            {
                actResult = false;
            }
            return actResult;
        }
        public string SP_GenWQXXML_Single2(string TypeText, int recordIDX,
                                            string OrgId, int BsmId)
        {
            string actResult = "";
            try
            {
                SqlParameter[] @params =
                {
                   new SqlParameter("@ReturnValue", SqlDbType.NVarChar, -1)
                   {Direction = ParameterDirection.Output},
                   new SqlParameter("@TypeText", SqlDbType.VarChar, 4)
                   {Direction = ParameterDirection.Input, Value = TypeText},
                   new SqlParameter("@RecordIDX", SqlDbType.Int)
                   {Direction = ParameterDirection.Input, Value = recordIDX},
                   new SqlParameter("@OrgId", SqlDbType.VarChar)
                   {Direction = ParameterDirection.Input, Value = OrgId},
                   new SqlParameter("@BSMID", SqlDbType.Int)
                   {Direction = ParameterDirection.Input, Value = BsmId}
                };
                string storedProcName = "GetWQXXML_Single3";
                _db.Database.ExecuteSqlCommand("exec " + storedProcName + " @ReturnValue OUT, @TypeText, @RecordIDX, @OrgId, @BSMID", @params);
                actResult = @params[0].Value.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SP_GenWQXXML_Single2 Error " + ex.Message);
                return "";
            }
            return actResult;
        }
        public string SP_GenWQXXML_Single_Delete(string TypeText, int recordIDX)
        {
            // TODO: STORED PROCEDURE SHOULD RETURN GENERATED XML IN
            // OUTPUT PARAMETER
            string actResult = "";
            try
            {
                SqlParameter[] @params =
                {
                    new SqlParameter("@ReturnValue", SqlDbType.NVarChar, -1)
                   {Direction = ParameterDirection.Output},
                   new SqlParameter("@TypeText", SqlDbType.VarChar, 4)
                   {Direction = ParameterDirection.Input, Value = TypeText},
                   new SqlParameter("@RecordIDX", SqlDbType.Int)
                   {Direction = ParameterDirection.Input, Value = recordIDX}
                };
                string storedProcName = "GenWQXXML_Single_Delete2";
                _db.Database.ExecuteSqlCommand("exec " + storedProcName + " @ReturnValue OUT, @TypeText, @RecordIDX", @params);
                actResult = @params[0].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        internal async Task<StatusResponseType> GetStatusHelperAsync(string NodeURL, string secToken, string transID)
        {
            try
            {
                NetworkNodePortType2Client.EndpointConfiguration endpoint =
                    new NetworkNodePortType2Client.EndpointConfiguration();
                NetworkNodePortType2Client nn2 =
                    new NetworkNodePortType2Client(endpoint, NodeURL);
                //NetworkNode2 nn = new NetworkNode2();
                //nn.Url = NodeURL;
                GetStatus gs1 = new GetStatus();
                gs1.securityToken = secToken;
                gs1.transactionId = transID;
                var response = await nn2.GetStatusAsync(gs1).ConfigureAwait(false);
                StatusResponseType statusResponseType =
                    new StatusResponseType();
                statusResponseType.status = response.GetStatusResponse1.status;
                statusResponseType.transactionId = response.GetStatusResponse1.transactionId;
                return statusResponseType;
                //return nn.GetStatus(gs1);
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> WQX_MasterAllOrgsTaskStatusAsync()
        {
            Console.WriteLine("[Status] >> WQX_MasterAllOrgsTaskStatusAsync called...");
            bool actResult = false;
            try
            {

                //loop through all registered organizations that have pending data to send, and submit pending data for each
                List<string> orgs = await _orgRepo.GetWQX_ORGANIZATION_PendingDataToSubmitStatusAsync().ConfigureAwait(false);
                if(orgs == null)
                {
                    Console.WriteLine("[Status] >> GetWQX_ORGANIZATION_PendingDataToSubmitStatusAsync returns null.");
                    return false;
                }
                Console.WriteLine("[Status] >> Organization Count: " + orgs.Count.ToString());
                foreach (string org in orgs)
                {
                    await WQX_BulkMasterSubmitStatusAsync(org).ConfigureAwait(false);
                }

                //when done, update status back to stopped
                //db_Ref.UpdateT_OE_APP_TASKS("WQXSubmit", "STOPPED", null, "SYSTEM");
                actResult = true;

            }
            catch (Exception e)
            {
                actResult = false;
            }
            return actResult;
        }
        public async Task<bool> WQX_MasterAllOrgsAsync()
        {
            Console.WriteLine("[Submission] > WQX_MasterAllOrgsAsync called...");
            bool actResult = false;
            //TOeAppTasks t = await _oeAppTasksRepository.GetT_OE_APP_TASKS_ByNameAsync("WQXSubmit").ConfigureAwait(false);
            //if (t != null)
            //{
            //Console.WriteLine("GetT_OE_APP_TASKS_ByName called..." + t.TaskStatus);
            //if (t.TaskStatus == "STOPPED")
            //{
            //Console.WriteLine("Task Status is Stopped...");
            //set status to RUNNING so tasks won't execute simultaneously
            //await _oeAppTasksRepository.UpdateT_OE_APP_TASKSAsync("WQXSubmit", "RUNNING", null, "SYSTEM").ConfigureAwait(false);

            //loop through all registered organizations that have pending data to send, and submit pending data for each
            try
            {
                List<string> orgs = await _orgRepo.GetWQX_ORGANIZATION_PendingDataToSubmit2Async().ConfigureAwait(false);
                if(orgs == null)
                {
                    Console.WriteLine("[Submission] > GetWQX_ORGANIZATION_PendingDataToSubmit2Async returns null");
                    return false;
                }
                Console.WriteLine("[Submission] > Organization Count: " + orgs.Count.ToString());
                foreach (string org in orgs)
                {
                    await WQX_BulkMasterAsync(org).ConfigureAwait(false);
                }
                Console.WriteLine("[Submission] > All org processed for submission.");
                //when done, update status back to stopped
                //db_Ref.UpdateT_OE_APP_TASKS("WQXSubmit", "STOPPED", null, "SYSTEM");
                actResult = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("[Submission] > Error:" + e.Message);
                throw;
            }
                    
                //}
                //else
                //{
                //    Console.WriteLine("Task Status is not Stopped, Running...");
                //}
            //}
            //else
            //{
            //    Console.WriteLine("Task not found...");
            //    //db_Ref.InsertT_OE_SYS_LOG("ERROR", "WQX Submission task not found");
            //}
            return actResult;
        }
    }

    public class CDXCredentials
    {
        public string userID { get; set; }
        public string credential { get; set; }
        public string NodeURL { get; set; }
    }
}
