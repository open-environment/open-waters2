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
        public TWqxSubmitRepository(ApplicationDbContext db,
            ITOeSysLogRepository sysLogRepo,
            ITOeAppSettingsRepository appSettingsRepo,
            ITWqxOrganizationRepository orgRepo,
            ITWqxUserOrgsRepository userOrgRepo,
            ITWqxMonLocRepository monlocRepo,
            ITWqxProjectRepository projRepo,
            ITWqxActivityRepository activityRepo,
            ITWqxTransactionLogRepository transLogRepo) : base(db)
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
        }

        public async Task WQX_MasterAsync(string OrgID)
        {
            //log start of send

            _sysLogRepo.InsertT_OE_SYS_LOG("INFO", "Starting WQX submission for " + OrgID);

            //get CDX username, password, and CDX destination URL
            CDXCredentials cred = GetCDXSubmitCredentials2(OrgID);

            //make 1 authenticate attempt just to verify. if failed, then exit, send email, and cancel for org
            string authResp = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
            if (string.IsNullOrEmpty(authResp))
            {
                DisableWQXForOrg(OrgID, "Login failed for supplied NAAS Username and Password for " + OrgID);
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
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", "Exception during activity submit: " + ex.Message.SubStringPlus(1,200));
            }

        }
        public  CDXCredentials GetCDXSubmitCredentials2(string OrgID)
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
                cred.NodeURL = _appSettingsRepo.GetT_OE_APP_SETTING("CDX Submission URL");

                TWqxOrganization org = _orgRepo.GetWQX_ORGANIZATION_ByID(OrgID);
                if (org != null)
                {
                    if (string.IsNullOrEmpty(org.CdxSubmitterId) == false && string.IsNullOrEmpty(org.CdxSubmitterPwdHash) == false)
                    {
                        cred.userID = org.CdxSubmitterId;
                        cred.credential = new SimpleAES().Decrypt(System.Web.HttpUtility.UrlDecode(org.CdxSubmitterPwdHash).Replace(" ", "+"));
                    }
                    else
                    {
                        cred.userID = _appSettingsRepo.GetT_OE_APP_SETTING("CDX Submitter");
                        cred.credential = _appSettingsRepo.GetT_OE_APP_SETTING("CDX Submitter Password");
                    }
                }
            }
            catch { }

            return cred;
        }
        internal async System.Threading.Tasks.Task<string> AuthHelperAsync(string userID, string credential, string authMethod, string domain, string NodeURL)
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
        private void DisableWQXForOrg(string OrgID, string LogMsg)
        {
            //when done, update status back to stopped
            _orgRepo.InsertOrUpdateT_WQX_ORGANIZATION(OrgID, null, null, null, null, null, null, null, null, null, null, false, null, null);
            _sysLogRepo.InsertT_OE_SYS_LOG("WQX_ORG_STOP", LogMsg);

            List<TOeUsers> users = _userOrgRepo.GetWQX_USER_ORGS_AdminsByOrg(OrgID);
            foreach (TOeUsers user in users)
                UtilityHelper.SendEmail(null, user.Email.Split(';').ToList(), 
                    null, null, "Open Waters Submit Failure", 
                    "Automated submission for " + OrgID + 
                    " has been disabled due to a submission failure. Failure details are: " + 
                    LogMsg, null, _appSettingsRepo,
                    _sysLogRepo);
        }

        public async Task WQX_Submit_OneByOneAsync(string typeText, int RecordIDX, string userID, string credential, string NodeURL, string orgID, bool? InsUpdIndicator)
        {
            try
            {
                //*******AUTHENTICATE*********************************************************************************************************
                string token = await AuthHelperAsync(userID, credential, "Password", "default", NodeURL).ConfigureAwait(false);

                //*******SUBMIT***************************************************************************************************************
                string requestXml = InsUpdIndicator == false ? SP_GenWQXXML_Single_Delete(typeText, RecordIDX) : SP_GenWQXXML_Single(typeText, RecordIDX);   //get XML from DB stored procedure
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
                                UpdateRecordStatus(typeText, RecordIDX, "N");
                                _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, "Timed out while getting status from EPA", subStatus.transactionId, "Failed", orgID);
                                return;
                            }
                        }
                    } while (status != "Failed" && status != "Completed");

                    //update status of record
                    if (status == "Completed")
                    {
                        UpdateRecordStatus(typeText, RecordIDX, "Y");
                        _transLogRepo.InsertUpdateWQX_TRANSACTION_LOG(null, typeText, RecordIDX, "I", null, null, subStatus.transactionId, status, orgID);
                    }
                    else if (status == "Failed")
                    {
                        UpdateRecordStatus(typeText, RecordIDX, "N");

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
                    DisableWQXForOrg(orgID, "Submission failed for supplied for " + orgID);
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
        internal void UpdateRecordStatus(string type, int RecordIDX, string status)
        {
            if (type == "MLOC")
                _monlocRepo.InsertOrUpdateWQX_MONLOC(RecordIDX, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, null, null, null, null, null, status, System.DateTime.Now, true, null, "SYSTEM");

            if (type == "PROJ")
                _projRepo.InsertOrUpdateWQX_PROJECT(RecordIDX, null, null, null, null, null, null, null, status, System.DateTime.Now, null, null, "SYSTEM");

            if (type == "ACT")
                _activityRepo.UpdateWQX_ACTIVITY_WQXStatus(RecordIDX, status, null, null, "SYSTEM");
        }
        internal async Task<StatusResponseType> SubmitHelperAsync(string NodeURL, string secToken, string dataFlow, string flowOperation, byte[] doc, string docName, DocumentFormatType docFormat, string docID)
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

    }

    public class CDXCredentials
    {
        public string userID { get; set; }
        public string credential { get; set; }
        public string NodeURL { get; set; }
    }
}
