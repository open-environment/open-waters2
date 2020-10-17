using Microsoft.AspNetCore.Mvc.Rendering;
using net.epacdxnode.test;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxProjectRepository : Repository<TWqxProject>, ITWqxProjectRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITOeAppSettingsRepository _appSettingsRepo;
        private readonly ITWqxOrganizationRepository _orgRepo;
        private readonly ITOeSysLogRepository _sysLogRepo;
        public TWqxProjectRepository(ApplicationDbContext db,
            ITOeAppSettingsRepository appSettingsRepo,
            ITWqxOrganizationRepository orgRepo,
            ITOeSysLogRepository sysLogRepo) : base(db)
        {
            _db = db;
            _appSettingsRepo = appSettingsRepo;
            _orgRepo = orgRepo;
            _sysLogRepo = sysLogRepo;
        }

        public int DeleteT_WQX_PROJECT(int ProjectIDX, string UserID)
        {
            TWqxProject entityToDelete = _db.TWqxProject.Where(p => p.ProjectIdx == ProjectIDX).FirstOrDefault();
            if(entityToDelete != null)
            {
                _db.TWqxProject.Remove(entityToDelete);
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<SelectListItem> GetTWqxProjectsForDropDown()
        {
            return _db.TWqxProject.Select(i => new SelectListItem()
            {
                Text = i.ProjectName,
                Value = i.ProjectId
            });
        }

        public List<TWqxProject> GetWQX_PROJECT(bool ActInd, string OrgID, bool? WQXPending)
        {
            try
            {
                return (from a in _db.TWqxProject
                        where (ActInd ? a.ActInd == true : true)
                        && a.OrgId == OrgID
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        orderby a.ProjectId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxProject GetWQX_PROJECT_ByID(int ProjectIDX)
        {
            return _db.TWqxProject.Where(p => p.ProjectIdx == ProjectIDX).FirstOrDefault();
        }

        public TWqxProject GetWQX_PROJECT_ByIDString(string ProjectID, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxProject
                        where a.ProjectId == ProjectID
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetWQX_PROJECT_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxProject
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateWQX_PROJECT(int? pROJECT_IDX, string oRG_ID, string pROJECT_ID, string pROJECT_NAME, string pROJECT_DESC, string sAMP_DESIGN_TYPE_CD, bool? qAPP_APPROVAL_IND, string qAPP_APPROVAL_AGENCY, string wQX_SUBMIT_STATUS, DateTime? wQX_SUBMIT_DT, bool? aCT_IND, bool? wQX_IND, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxProject a = new TWqxProject();

                if (pROJECT_IDX != null)
                    a = (from c in _db.TWqxProject
                         where c.ProjectIdx == pROJECT_IDX
                         select c).FirstOrDefault();

                if (pROJECT_IDX == null) //insert case
                {
                    a = new TWqxProject();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (pROJECT_ID != null) a.ProjectId = pROJECT_ID;
                if (pROJECT_NAME != null) a.ProjectName = pROJECT_NAME;
                if (pROJECT_DESC != null) a.ProjectDesc = pROJECT_DESC;
                if (sAMP_DESIGN_TYPE_CD != null) a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD;
                if (qAPP_APPROVAL_IND != null) a.QappApprovalInd = qAPP_APPROVAL_IND;
                if (qAPP_APPROVAL_AGENCY != null) a.QappApprovalAgency = qAPP_APPROVAL_AGENCY;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (wQX_SUBMIT_DT != null) a.UpdateDt = wQX_SUBMIT_DT;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxProject.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return a.ProjectIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxProject wqxProject)
        {
            _db.TWqxProject.Update(wqxProject);
            _db.SaveChanges();
        }

        public async Task<ImportStatusModel> WQXImportProjectAsync(string orgID, int userIdx)
        {
            ImportStatusModel actResult = new ImportStatusModel();
            TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
            if(user != null)
            {
                return await WQXImportProjectAsync(orgID, user.UserId).ConfigureAwait(false);
            }
            return actResult;
        }

        public async Task<ImportStatusModel> WQXImportProjectAsync(string orgID, string userId)
        {
            ImportStatusModel actResult = new ImportStatusModel();
            try
            {
                //get CDX username, password, and CDX destination URL
                CDXCredentials cred = GetCDXSubmitCredentials2(orgID);

                //*******AUTHENTICATE***********************************
                string token = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);

                //*******QUERY*****************************************
                if (token.Length > 0)
                {
                    List<net.epacdxnode.test.ParameterType> pars = new List<net.epacdxnode.test.ParameterType>();

                    net.epacdxnode.test.ParameterType p = new net.epacdxnode.test.ParameterType();
                    p.parameterName = "organizationIdentifier";
                    p.Value = orgID;
                    pars.Add(p);

                    net.epacdxnode.test.ResultSetType queryResp = await QueryHelperAsync(cred.NodeURL, token, "WQX", "WQX.GetProjectByParameters_v2.1", null, null, pars).ConfigureAwait(false);
                    XDocument xdoc = XDocument.Parse(queryResp.results.Any[0].InnerXml);
                    var projects = (from project
                                in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}Project")
                                    select new
                                    {
                                        ID = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}ProjectIdentifier") ?? String.Empty,
                                        Name = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}ProjectName") ?? String.Empty,
                                        Desc = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}ProjectDescriptionText") ?? String.Empty,
                                        SamplingDesignType = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}SamplingDesignTypeCode") ?? String.Empty,
                                        QAPPInd = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}QAPPApprovedIndicator") ?? String.Empty,
                                        QAPPAgency = (string)project.Element("{http://www.exchangenetwork.net/schema/wqx/2}QAPPApprovalAgencyName") ?? String.Empty,
                                    });

                    //loop through retrieved data and insert into temp table
                    if (projects != null)
                    {
                        foreach (var project in projects)
                        {
                            int Succ = InsertOrUpdateWQX_IMPORT_TEMP_PROJECT(null, userId, null, orgID, project.ID, project.Name, project.Desc, project.SamplingDesignType,
                                project.QAPPInd.ConvertOrDefault<Boolean?>(), project.QAPPAgency, "P", "");
                        }
                    }
                    //Response.Redirect("~/App_Pages/Secure/WQXImportProject.aspx?e=1");
                    actResult.ImportStatus = true;
                    actResult.ImportStatusMsg = "";
                    return actResult;

                }
                else
                {
                    // lblMsg.Text = "Unable to authenticate to EPA-WQX server.";
                    actResult.ImportStatus = false;
                    actResult.ImportStatusMsg = "Unable to authenticate to EPA-WQX server.";
                    return actResult;
                }
            }
            catch (Exception ex)
            {
                actResult.ImportStatus = false;
                return actResult;
            }

        }

        //TODO: duplicate code
        private CDXCredentials GetCDXSubmitCredentials2(string OrgID)
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
            catch (javax.xml.soap.SOAPException sExept)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", sExept.Message.Substring(0, 1999));   //logging an authentication failure
                return "";
            }
        }

        internal async System.Threading.Tasks.Task<ResultSetType> QueryHelperAsync(string NodeURL, string secToken, string dataFlow, string request, int? rowID, int? maxRows, List<ParameterType> pars)
        {
            try
            {
                NetworkNodePortType2Client.EndpointConfiguration endpoint = new
                     NetworkNodePortType2Client.EndpointConfiguration();
                NetworkNodePortType2Client nn = new
                    NetworkNodePortType2Client(endpoint, NodeURL);
                //NetworkNode2 nn = new NetworkNode2();
                //nn.Url = NodeURL;
                //nn.SoapVersion = SoapProtocolVersion.Soap12;

                Query q1 = new Query();
                q1.securityToken = secToken;
                q1.dataflow = dataFlow;
                q1.request = request;
                q1.rowId = (rowID ?? 0).ToString();
                q1.maxRows = (maxRows ?? -1).ToString();

                ParameterType[] ps = new ParameterType[pars.Count];
                int i = 0;
                System.Xml.XmlQualifiedName parType = new System.Xml.XmlQualifiedName("string", "http://www.w3.org/2001/XMLSchema");
                foreach (ParameterType par in pars)
                {
                    if (par.parameterEncoding == null) par.parameterEncoding = EncodingType.None;
                    ps[i] = par;
                    i++;
                }

                q1.parameters = ps;
                var result = await nn.QueryAsync(q1).ConfigureAwait(false);
                return result.QueryResponse1;
                //return nn.Query(q1);
            }
            catch (javax.xml.soap.SOAPException sExept)
            {
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", sExept.Message.SubStringPlus(0, 1999));   //logging an authentication failure

                //special handling of an unauthorized
                if (sExept.Message.SubStringPlus(0, 9) == "ORA-20997")
                {
                    ResultSetType rs = new ResultSetType();
                    rs.rowId = "-99";
                    return rs;
                }

                return null;
            }
        }

        public int InsertOrUpdateWQX_IMPORT_TEMP_PROJECT(global::System.Int32? tEMP_PROJECT_IDX, string uSER_ID, global::System.Int32? pROJECT_IDX, global::System.String oRG_ID,
                global::System.String pROJECT_ID, global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD,
                global::System.Boolean? qAPP_APPROVAL_IND, global::System.String qAPP_APPROVAL_AGENCY, string sTATUS_CD, string sTATUS_DESC)
        {
            Boolean insInd = false;
            try
            {
                TWqxImportTempProject a = new TWqxImportTempProject();

                if (tEMP_PROJECT_IDX != null)
                    a = (from c in _db.TWqxImportTempProject
                         where c.TempProjectIdx == tEMP_PROJECT_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (uSER_ID != null)
                {
                    a.UserId = uSER_ID;
                    if (uSER_ID.Length > 200) { sTATUS_CD = "F"; sTATUS_DESC += "User ID length exceeded. "; }
                }

                if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX;
                if (oRG_ID != null) a.OrgId = oRG_ID;

                if (pROJECT_ID != null)
                {
                    a.ProjectId = pROJECT_ID.SubStringPlus(0, 35).Trim();
                    if (pROJECT_ID.Length > 35) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID length exceeded. "; }

                    TWqxProject ptemp = GetWQX_PROJECT_ByIDString(pROJECT_ID, oRG_ID);
                    if (ptemp != null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID already exists. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_NAME))
                {
                    a.ProjectName = pROJECT_NAME.SubStringPlus(0, 120).Trim();
                    if (pROJECT_NAME.Length > 120) { sTATUS_CD = "F"; sTATUS_DESC += "Project Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_DESC))
                {
                    a.ProjectDesc = pROJECT_DESC.SubStringPlus(0, 1999);
                    if (pROJECT_DESC.Length > 1999) { sTATUS_CD = "F"; sTATUS_DESC += "Project Description length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(sAMP_DESIGN_TYPE_CD))
                {
                    a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD.Trim().SubStringPlus(0, 20);
                    if (sAMP_DESIGN_TYPE_CD.Length > 20) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Design Type Code length exceeded. "; }
                }

                if (qAPP_APPROVAL_IND != null)
                {
                    a.QappApprovalInd = qAPP_APPROVAL_IND;
                }

                if (!string.IsNullOrEmpty(qAPP_APPROVAL_AGENCY))
                {
                    a.QappApprovalAgency = qAPP_APPROVAL_AGENCY.SubStringPlus(0, 50);
                    if (qAPP_APPROVAL_AGENCY.Length > 50) { sTATUS_CD = "F"; sTATUS_DESC += "QAPP Approval Agency length exceeded. "; }
                }

                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                    _db.TWqxImportTempProject.Add(a);

                _db.SaveChanges();

                return a.TempProjectIdx;
            }
            catch (Exception ex)
            {
                sTATUS_CD = "F";
                sTATUS_DESC += "Unspecified error. ";
                return 0;
            }
        }
    }
}
