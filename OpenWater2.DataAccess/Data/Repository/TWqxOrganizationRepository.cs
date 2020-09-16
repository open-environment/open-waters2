using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using net.epacdxnode.test;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxOrganizationRepository : Repository<TWqxOrganization>, ITWqxOrganizationRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        private readonly ITOeAppSettingsRepository _appSettingsRepo;
        private readonly ITOeSysLogRepository _sysLogRepo;
        public TWqxOrganizationRepository(ApplicationDbContext db,
            ILoggerFactory logFactory,
            ITOeAppSettingsRepository appSettingsRepo,
            ITOeSysLogRepository sysLogRepo) : base(db)
        {
            _db = db;
            _logger = logFactory.CreateLogger<TWqxOrganizationRepository>();
            _appSettingsRepo = appSettingsRepo;
            _sysLogRepo = sysLogRepo;
        }

        public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        {
            return _db.TWqxOrganization.Select(i => new SelectListItem()
            {
                 Text = i.OrgFormalName,
                 Value = i.OrgId
            });
        }
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd)
        {
            try
            {
                return (from a in _db.TWqxUserOrgs
                        join b in _db.TWqxOrganization on a.OrgId equals b.OrgId
                        where a.UserIdx == UserIDX
                        && (excludePendingInd == true ? a.RoleCd != "P" : true)
                        select b).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<VWqxAllOrgs> GetV_WQX_ALL_ORGS()
        {
            try
            {
                return (from a in _db.VWqxAllOrgs
                        orderby a.OrgFormalName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Update(TWqxOrganization wqxOrganization)
        {
            TWqxOrganization objFromDb = _db.TWqxOrganization.Where(i => i.OrgId == wqxOrganization.OrgId).FirstOrDefault();
            objFromDb.OrgFormalName = wqxOrganization.OrgFormalName;
            //TODO: implement rest of the properties
            _db.SaveChanges();
        }

        public TWqxOrganization GetWQX_ORGANIZATION_ByID(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxOrganization
                        where a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEpaOrgs GetT_EPA_ORGS_ByOrgID(string OrgID)
        {
            try
            {
                return (from a in _db.TEpaOrgs
                        where a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME)
        {
            return InsertOrUpdateT_WQX_ORGANIZATION(oRG_ID, oRG_NAME, "", "", "", "", "", "", "", "", "", null, "");
        }
        public int InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS, string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID, string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null, string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null)
        {
            Boolean insInd = false;
            try
            {
                TWqxOrganization a = new TWqxOrganization();

                if (oRG_ID != null)
                    a = (from c in _db.TWqxOrganization
                         where c.OrgId == oRG_ID
                         select c).FirstOrDefault();

                if (a == null) //insert case
                {
                    a = new TWqxOrganization();
                    insInd = true;
                    a.OrgId = oRG_ID;
                }

                if (oRG_NAME != null) a.OrgFormalName = oRG_NAME;
                if (oRG_DESC != null) a.OrgDesc = oRG_DESC;
                if (tRIBAL_CODE != null) a.TribalCode = tRIBAL_CODE;
                if (eLECTRONIC_ADDRESS != null) a.Electronicaddress = eLECTRONIC_ADDRESS;
                if (eLECTRONICADDRESSTYPE != null) a.Electronicaddresstype = eLECTRONICADDRESSTYPE;
                if (tELEPHONE_NUM != null) a.TelephoneNum = tELEPHONE_NUM;
                if (tELEPHONE_NUM_TYPE != null) a.TelephoneNumType = tELEPHONE_NUM_TYPE;
                if (TELEPHONE_EXT != null) a.TelephoneExt = TELEPHONE_EXT;
                if (dEFAULT_TIMEZONE != null) a.DefaultTimezone = dEFAULT_TIMEZONE;
                if (cDX_SUBMITTER_ID != null) a.CdxSubmitterId = cDX_SUBMITTER_ID;
                if (cDX_SUBMIT_IND != null) a.CdxSubmitInd = cDX_SUBMIT_IND;
                if (cDX_SUBMITTER_PWD != null && cDX_SUBMITTER_PWD != "--------")
                {
                    //encrypt CDX submitter password for increased security
                    string encryptOauth = new SimpleAES().Encrypt(cDX_SUBMITTER_PWD);
                    encryptOauth = System.Web.HttpUtility.UrlEncode(encryptOauth);
                    a.CdxSubmitterPwdHash = encryptOauth;
                }
                if (dEFAULT_TIMEZONE != null) a.DefaultTimezone = dEFAULT_TIMEZONE;
                if (mAIL_ADDRESS != null) a.MailingAddress = mAIL_ADDRESS;
                if (mAIL_ADD_CITY != null) a.MailingAddCity = mAIL_ADD_CITY;
                if (mAIL_ADD_STATE != null) a.MailingAddState = mAIL_ADD_STATE;
                if (mAIL_ADD_ZIP != null) a.MailingAddZip = mAIL_ADD_ZIP;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxOrganization.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return 1;
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    // Get entry

                    DbEntityEntry entry = item.Entry;
                    string entityTypeName = entry.Entity.GetType().Name;

                    // Display or log error messages

                    foreach (DbValidationError subItem in item.ValidationErrors)
                    {
                        string message = string.Format("Error '{0}' occurred in {1} at {2}",
                                 subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
                        Console.WriteLine(message);
                    }
                }
                return 0;
            }
            catch (Exception ex2)
            {
                _logger.LogInformation("Exception in InsertOrUpdateT_WQX_ORGANIZATION..");
                _logger.LogInformation(ex2.StackTrace);
                _logger.LogInformation("====================");
                _logger.LogInformation(ex2.InnerException.Message);
                string msg = ex2.InnerException.StackTrace;
                return 0;
            }
        }

        public int ApproveRejectT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX, string ApproveRejectCode)
        {
            try
            {
                if (ApproveRejectCode == "R")
                {
                    DeleteT_WQX_USER_ORGS(oRG_ID, uSER_IDX);
                    return -1;
                }
                else
                {
                    TWqxUserOrgs a = (from c in _db.TWqxUserOrgs
                                         where c.UserIdx == uSER_IDX
                                         && c.OrgId == oRG_ID
                                         select c).FirstOrDefault();

                    if (a == null)
                        return 0;

                    a.RoleCd = ApproveRejectCode;
                    _db.SaveChanges();

                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX)
        {
            try
            {
                TWqxUserOrgs r = new TWqxUserOrgs();
                r = (from c in _db.TWqxUserOrgs where c.UserIdx == uSER_IDX && c.OrgId == oRG_ID select c).FirstOrDefault();
                _db.TWqxUserOrgs.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<TWqxRefData> GetT_WQX_REF_DATA(string tABLE, bool ActInd, bool UsedInd)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        where (ActInd ? a.ActInd == true : true)
                        && (UsedInd ? a.UsedInd == true : true)
                        && a.Table == tABLE
                        orderby a.Value
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<UserOrgDisplay> GetT_OE_USERSInOrganization(string OrgID)
        {
            try
            {
                return (from u in _db.TOeUsers
                        join uo in _db.TWqxUserOrgs on u.UserIdx equals uo.UserIdx
                        where uo.OrgId == OrgID
                        //orderby u.USER_ID
                        select new UserOrgDisplay
                        {
                            USER_IDX = u.UserIdx,
                            USER_ID = u.UserId,
                            USER_NAME = u.Fname + " " + u.Lname,
                            ORG_ID = uo.OrgId,
                            ROLE_CD = uo.RoleCd
                        }).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TOeUsers> GetT_OE_USERSNotInOrganization(string OrgID)
        {
            try
            {
                //first get all users 
                var allUsers = (from itemA in _db.TOeUsers select itemA);

                //next get all users in role
                var UsersInRole = (from itemA in _db.TOeUsers
                                   join itemB in _db.TWqxUserOrgs on itemA.UserIdx equals itemB.UserIdx
                                   where itemB.OrgId == OrgID
                                   select itemA);

                //then get exclusions
                var usersNotInRole = allUsers.Except(UsersInRole);

                return usersNotInRole.OrderBy(a => a.UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async System.Threading.Tasks.Task<ConnectTestResult> ConnectTestAsync(string orgID, string typ)
        {
            ConnectTestResult connectTestResult = new ConnectTestResult();
            connectTestResult.typ = typ;
            try
            {
                //AUTHENTICATION TEST*********************************************
                CDXCredentials cred = GetCDXSubmitCredentials2(orgID);
                string token = await AuthHelperAsync(cred.userID, cred.credential, "Password", "default", cred.NodeURL).ConfigureAwait(false);
                if (token.Length > 0)
                {
                    //spnAuth.Attributes["class"] = "signup_header_check";
                    //lblAuthResult.Text = "Authentication passed.";
                    //lblCDXSubmitInd.CssClass = "fldPass";
                    //lblCDXSubmitInd.Text = "This Organization is able to submit to EPA.";
                    connectTestResult.lblAuthResult = "Authentication passed.";
                    connectTestResult.lblCDXSubmitInd = "This Organization is able to submit to EPA.";

                    //SUBMIT TEST*********************************************
                    List<net.epacdxnode.test.ParameterType> pars = new List<net.epacdxnode.test.ParameterType>();

                    net.epacdxnode.test.ParameterType p = new net.epacdxnode.test.ParameterType();
                    p.parameterName = "organizationIdentifier";
                    p.Value = orgID;
                    pars.Add(p);

                    net.epacdxnode.test.ParameterType p2 = new net.epacdxnode.test.ParameterType();
                    p2.parameterName = "monitoringLocationIdentifier";
                    p2.Value = "";
                    pars.Add(p2);

                    //OpenEnvironment.net.epacdxnode.test.ResultSetType rs = 
                    //WQXSubmit.QueryHelper(cred.NodeURL, token, "WQX", "WQX.GetMonitoringLocationByParameters_v2.1", null, null, pars);

                    var result = await QueryHelperAsync(cred.NodeURL, token, "WQX",
                        "WQX.GetMonitoringLocationByParameters_v2.1",
                        null, null, pars).ConfigureAwait(false);
                    
                    //if (rs.rowId == "-99")
                    if (result.rowId == "-99")
                    {
                        //THE NAAS ACCOUNT DOES NOT HAVE RIGHTS TO SUBMIT FOR THIS ORGANIZATION*********************************************
                        //spnSubmit.Attributes["class"] = "signup_header_cross";
                        if(typ == "LOCAL")
                        {
                            connectTestResult.lblSubmitResult = "The NAAS account you supplied is not authorized to submit for this organization. Please contact the STORET Helpdesk to request access.";
                        } else
                        {
                            connectTestResult.lblSubmitResult = "Open Waters is not authorized to submit for your organization. Please contact the STORET Helpdesk to request access.";
                        }
                        //if (typ == "LOCAL")
                        //    lblSubmitResult.Text = "The NAAS account you supplied is not authorized to submit for this organization. Please contact the STORET Helpdesk to request access.";
                        //else
                        //    lblSubmitResult.Text = "Open Waters is not authorized to submit for your organization. Please contact the STORET Helpdesk to request access.";

                        //lblCDXSubmitInd.CssClass = "fldErr";
                        //lblCDXSubmitInd.Text = "This Organization is unable to submit to EPA. Please correct this below.";
                        //db_WQX.InsertOrUpdateT_WQX_ORGANIZATION(Session["OrgID"].ToString(), null, null, null, null, null, null, null, null, null, null, false, null, User.Identity.Name);
                    }
                    else
                    {
                        //spnSubmit.Attributes["class"] = "signup_header_check";
                        //lblSubmitResult.Text = "Submit test passed.";
                        //lblCDXSubmitInd.CssClass = "fldPass";
                        //lblCDXSubmitInd.Text = "This Organization is able to submit to EPA.";
                        connectTestResult.lblSubmitResult = "Submit test passed.";
                        connectTestResult.lblCDXSubmitInd = "This Organization is able to submit to EPA.";
                        //BOTH AUTHENTICATION AND SUBMIT PASSES - UPDATE ORG SUBMIT IND*********************************************
                        //db_WQX.InsertOrUpdateT_WQX_ORGANIZATION(Session["OrgID"].ToString(), null, null, null, null, null, null, null, null, null, null, true, null, User.Identity.Name);
                    }
                }
                else  //failed authentication
                {
                    //spnAuth.Attributes["class"] = "signup_header_cross";
                    //lblAuthResult.Text = "Unable to authenticate to EPA-CDX. Please double-check your username and password.";

                    //spnSubmit.Attributes["class"] = "signup_header_crossbw";
                    //lblSubmitResult.Text = "Cannot test until authentication is resolved.";
                    //lblCDXSubmitInd.CssClass = "fldErr";
                    //lblCDXSubmitInd.Text = "This Organization is unable to submit to EPA. Please correct this below.";
                    connectTestResult.lblAuthResult = "Unable to authenticate to EPA-CDX. Please double-check your username and password.";
                    connectTestResult.lblSubmitResult = "Cannot test until authentication is resolved.";
                    connectTestResult.lblCDXSubmitInd = "This Organization is unable to submit to EPA. Please correct this below.";

                    //db_WQX.InsertOrUpdateT_WQX_ORGANIZATION(Session["OrgID"].ToString(), null, null, null, null, null, null, null, null, null, null, false, null, User.Identity.Name);
                }

                //pnlCDXResults.Visible = true;
            }
            catch (Exception ex)
            {
                connectTestResult.msg = ex.Message;
            }
            return connectTestResult;
        }

        public List<TWqxImportTranslate> GetWQX_IMPORT_TRANSLATE_byOrg(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTranslate
                        where a.OrgId == OrgID
                        orderby a.ColName, a.DataFrom
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CanUserEditOrg(int UserIDX, string OrgID)
        {
            try
            {
                var xxx = (from a in _db.TWqxUserOrgs
                           where a.UserIdx == UserIDX
                           && a.OrgId == OrgID
                           && (a.RoleCd == "A" || a.RoleCd == "U")
                           select a).Count();

                return xxx > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<TWqxOrganization> GetWQX_ORGANIZATION()
        {
            try
            {
                return (from a in _db.TWqxOrganization
                        orderby a.OrgFormalName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetWQX_ORGANIZATION_PendingDataToSubmit()
        {
            try
            {
                var x = (from m in _db.TWqxMonloc
                         join o in _db.TWqxOrganization on m.OrgId equals o.OrgId
                         where o.CdxSubmitInd == true
                         && m.WqxSubmitStatus == "U"
                         && m.WqxInd == true
                         select m.OrgId).Union
                         (from a in _db.TWqxActivity
                          join o in _db.TWqxOrganization on a.OrgId equals o.OrgId
                          where o.CdxSubmitInd == true
                          && a.WqxSubmitStatus == "U"
                          && a.WqxInd == true
                          select a.OrgId).Union
                          (from p in _db.TWqxProject
                           join o in _db.TWqxOrganization on p.OrgId equals o.OrgId
                           where o.CdxSubmitInd == true
                           && p.WqxSubmitStatus == "U"
                           && p.WqxInd == true
                           select p.OrgId);

                return x.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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

                TWqxOrganization org = GetWQX_ORGANIZATION_ByID(OrgID);
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
    }
}
