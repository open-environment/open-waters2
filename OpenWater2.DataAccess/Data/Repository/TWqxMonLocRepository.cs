using Microsoft.AspNetCore.Mvc.Rendering;
using net.epacdxnode.test;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxMonLocRepository : Repository<TWqxMonloc>, ITWqxMonLocRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITOeAppSettingsRepository _appSettingsRepo;
        private readonly ITWqxOrganizationRepository _orgRepo;
        private readonly ITOeSysLogRepository _sysLogRepo;
        private readonly ITWqxRefDataRepository _refDataRepo;
        //private readonly ITWqxImportTempMonlocRepository _impTempMonlocRepo;
        public TWqxMonLocRepository(ApplicationDbContext db,
            ITOeAppSettingsRepository appSettingsRepo,
            ITWqxOrganizationRepository orgRepo,
            ITOeSysLogRepository sysLogRepo,
            ITWqxRefDataRepository refDataRepo
            /*ITWqxImportTempMonlocRepository impTempMonlocRepo*/) : base(db)
        {
            _db = db;
            _appSettingsRepo = appSettingsRepo;
            _orgRepo = orgRepo;
            _sysLogRepo = sysLogRepo;
            _refDataRepo = refDataRepo;
            //_impTempMonlocRepo = impTempMonlocRepo;
        }

        public int DeleteT_WQX_MONLOC(int monLocIDX, string UserID)
        {
            try
            {
                TWqxMonloc m = GetWQX_MONLOC_ByID(monLocIDX);
                if (m != null)
                {
                    if (m.WqxSubmitStatus == "Y" && m.ActInd == false)
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is passed ("Y")
                        //string sql = "DELETE FROM T_WQX_MONLOC WHERE MONLOC_IDX = " + monLocIDX;
                        //_db.ExecuteStoreCommand(sql);
                        TWqxMonloc entityToRemove = _db.TWqxMonloc.Where(i => i.MonlocIdx == monLocIDX).FirstOrDefault();
                        if(entityToRemove != null)
                        {
                            _db.TWqxMonloc.Remove(entityToRemove);
                            _db.SaveChanges();
                        }
                        return 1;
                    }

                    //if there are any activities for this monitoring location, don't delete becuase this would cause WQX to delete all activities for this mon loc.
                    int iActCount = GetWQX_ACTIVITYByMonLocID(monLocIDX);
                    if (iActCount > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        InsertOrUpdateWQX_MONLOC(monLocIDX, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "U", null, false, null, UserID);
                        return 1;
                    }

                }
                else
                    return 0;

            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<SelectListItem> GetTWqxMonLocForDropDown()
        {
            return _db.TWqxMonloc.Select(i => new SelectListItem()
            {
                Text = i.MonlocName,
                Value = i.MonlocId
            });
        }

        public bool GetT_WQX_MONLOC_PendingInd(string OrgID)
        {
            try
            {
                if (_db.TWqxMonloc.Any(u => u.OrgId == OrgID && u.WqxSubmitStatus == "U" && u.WqxInd == true))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetWQX_ACTIVITYByMonLocID(int monLocIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.MonlocIdx == monLocIDX
                        && a.ActInd == true
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TWqxMonloc>> GetWQX_MONLOC(bool ActInd, string OrgID, bool? WQXPending)
        {
            if (WQXPending == false) WQXPending = null;
            try
            {
                return (from a in _db.TWqxMonloc
                        where (ActInd ? a.ActInd == true : true)
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        && (OrgID == null ? true : a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxMonloc GetWQX_MONLOC_ByID(int monLocIDX)
        {
            return _db.TWqxMonloc.Where(i => i.MonlocIdx == monLocIDX).FirstOrDefault();
        }

        public int InsertOrUpdateWQX_MONLOC(int? mONLOC_IDX, string oRG_ID, string mONLOC_ID, string mONLOC_NAME, string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND, string tRIBAL_LAND_NAME, string lATITUDE_MSR, string lONGITUDE_MSR, int? sOURCE_MAP_SCALE, string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM, string vERT_MEASURE, string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM, string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE, string aQUIFER_NAME, string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string wQX_SUBMIT_STATUS, DateTime? wQXUpdateDate, bool? aCT_IND, bool? wQX_IND, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxMonloc a = new TWqxMonloc();

                if (mONLOC_IDX != null)
                    a = (from c in _db.TWqxMonloc
                         where c.MonlocIdx == mONLOC_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (a == null) //insert case
                {
                    a = new TWqxMonloc();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_ID != null) a.MonlocId = mONLOC_ID;
                if (mONLOC_NAME != null) a.MonlocName = mONLOC_NAME;
                if (mONLOC_TYPE != null) a.MonlocType = mONLOC_TYPE;

                if (mONLOC_DESC != null) a.MonlocDesc = mONLOC_DESC;
                if (hUC_EIGHT != null) a.HucEight = hUC_EIGHT;
                if (HUC_TWELVE != null) a.HucTwelve = HUC_TWELVE;
                if (tRIBAL_LAND_IND != null) a.TribalLandInd = tRIBAL_LAND_IND;
                if (tRIBAL_LAND_NAME != null) a.TribalLandName = tRIBAL_LAND_NAME;

                if (lATITUDE_MSR != null) a.LatitudeMsr = lATITUDE_MSR;
                if (lONGITUDE_MSR != null) a.LongitudeMsr = lONGITUDE_MSR;
                if (sOURCE_MAP_SCALE != null) a.SourceMapScale = sOURCE_MAP_SCALE;
                if (hORIZ_ACCURACY != null) a.HorizAccuracy = hORIZ_ACCURACY;
                if (hORIZ_ACCURACY_UNIT != null) a.HorizAccuracyUnit = hORIZ_ACCURACY_UNIT;
                if (hORIZ_COLL_METHOD != null) a.HorizCollMethod = hORIZ_COLL_METHOD;
                if (hORIZ_REF_DATUM != null) a.HorizRefDatum = hORIZ_REF_DATUM;
                if (vERT_MEASURE != null) a.VertMeasure = vERT_MEASURE;
                if (vERT_MEASURE_UNIT != null) a.VertMeasureUnit = vERT_MEASURE_UNIT;
                if (vERT_COLL_METHOD != null) a.VertCollMethod = vERT_COLL_METHOD;
                if (vERT_REF_DATUM != null) a.VertRefDatum = vERT_REF_DATUM;
                if (cOUNTRY_CODE != null) a.CountryCode = cOUNTRY_CODE;
                if (sTATE_CODE != null) a.StateCode = sTATE_CODE;
                if (cOUNTY_CODE != null) a.CountyCode = cOUNTY_CODE;

                if (wELL_TYPE != null) a.WellType = wELL_TYPE;
                if (aQUIFER_NAME != null) a.AquiferName = aQUIFER_NAME;
                if (fORMATION_TYPE != null) a.FormationType = fORMATION_TYPE;
                if (wELLHOLE_DEPTH_MSR != null) a.WellholeDepthMsr = wELLHOLE_DEPTH_MSR;
                if (wELLHOLE_DEPTH_MSR_UNIT != null) a.WellholeDepthMsrUnit = wELLHOLE_DEPTH_MSR_UNIT;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxMonloc.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return a.MonlocIdx;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in the state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxMonloc wqxMonloc)
        {
            _db.TWqxMonloc.Update(wqxMonloc);
            _db.SaveChanges();
        }

        public TWqxUserOrgs GetWQX_USER_ORGS_ByUserIDX_OrgID(int UserIDX, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxUserOrgs
                        where a.UserIdx == UserIDX
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetWQX_MONLOC_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxMonloc> GetWQX_MONLOC_ByOrgID(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where (a.ActInd == true)
                        && (a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TWqxMonloc GetWQX_MONLOC_ByIDString(string orgID, string MonLocID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where a.MonlocId == MonLocID
                        && a.OrgId == orgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int DeleteT_WQX_MONLOC(int monLocIDX, int userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if(user == null)
                {
                    return actResult;
                }
                return DeleteT_WQX_MONLOC(monLocIDX, user.UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        public async Task<ImportStatusModel> WQXImportMonLocAsync(string orgID, int userIdx)
        {
            ImportStatusModel actResult = new ImportStatusModel();
            TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
            if(user != null)
            {
                actResult = await WQXImportMonLocAsync(orgID, user.UserId).ConfigureAwait(false);
            }
            return actResult;
        }

        public async Task<ImportStatusModel> WQXImportMonLocAsync(string orgID, string userId)
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

                    net.epacdxnode.test.ParameterType p = new net.epacdxnode.test.ParameterType
                    {
                        parameterName = "organizationIdentifier",
                        Value = orgID
                    };
                    pars.Add(p);

                    net.epacdxnode.test.ParameterType p2 = new net.epacdxnode.test.ParameterType
                    {
                        parameterName = "monitoringLocationIdentifier",
                        Value = ""
                    };
                    pars.Add(p2);

                    net.epacdxnode.test.ResultSetType queryResp = await QueryHelperAsync(cred.NodeURL, token, "WQX", "WQX.GetMonitoringLocationByParameters_v2.2", null, null, pars).ConfigureAwait(false);

                    //handle no response
                    if (queryResp == null || queryResp.results == null)
                    {
                        // lblMsg.Text = "No monitoring locations found at EPA for this organization.";
                        actResult.ImportStatus = false;
                        actResult.ImportStatusMsg = "No monitoring locations found at EPA for this organization.";
                        return actResult;
                    }

                    XDocument xdoc = XDocument.Parse(queryResp.results.Any[0].InnerXml);
                    var mlocs = (from mloc
                                in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocation")
                                 select new
                                 {
                                     ID = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentifier") ?? String.Empty,
                                     Name = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationName") ?? String.Empty,
                                     MonLocType = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationTypeName") ?? String.Empty,
                                     Desc = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationDescriptionText") ?? String.Empty,
                                     HUC8 = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}HUCEightDigitCode") ?? String.Empty,
                                     HUC12 = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}HUCTwelveDigitCode") ?? String.Empty,
                                     TribeLandInd = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}TribalLandIndicator") ?? String.Empty,
                                     TribeLandName = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationIdentity").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}TribalLandName") ?? String.Empty,
                                     Lat = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}LatitudeMeasure") ?? String.Empty,
                                     Long = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}LongitudeMeasure") ?? String.Empty,
                                     SourceMapScale = (int?)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}SourceMapScaleNumeric").ConvertOrDefault<int?>(),
                                     HorizontalAccuracyMeasure = mloc.Element("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalAccuracyMeasure") != null ? (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalAccuracyMeasure").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MeasureValue") ?? String.Empty : "",
                                     HorizontalAccuracyMeasureUnit = mloc.Element("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalAccuracyMeasure") != null ? (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalAccuracyMeasure").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MeasureUnitCode") ?? String.Empty : "",
                                     HorizontalCollectionMethodName = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalCollectionMethodName") ?? String.Empty,
                                     HorizontalCoordinateReferenceSystemDatumName = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}HorizontalCoordinateReferenceSystemDatumName") ?? String.Empty,
                                     VerticalMeasure = mloc.Element("{http://www.exchangenetwork.net/schema/wqx/2}VerticalMeasure") != null ? (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}VerticalMeasure").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MeasureValue") ?? String.Empty : "",
                                     VerticalMeasureUnit = mloc.Element("{http://www.exchangenetwork.net/schema/wqx/2}VerticalMeasure") != null ? (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}VerticalMeasure").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}MeasureUnitCode") ?? String.Empty : "",
                                     VerticalCollectionMethodName = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}VerticalCollectionMethodName") ?? String.Empty,
                                     VerticalCoordinateReferenceSystemDatumName = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}VerticalCoordinateReferenceSystemDatumName") ?? String.Empty,
                                     CountryCode = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}CountryCode") ?? String.Empty,
                                     StateCode = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}StateCode") ?? String.Empty,
                                     CountyCode = (string)mloc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}MonitoringLocationGeospatial").FirstOrDefault().Element("{http://www.exchangenetwork.net/schema/wqx/2}CountyCode") ?? String.Empty
                                 });

                    //loop through retrieved data and insert into temp table
                    if (mlocs != null)
                    {
                        foreach (var mloc in mlocs)
                        {
                            int Succ = InsertOrUpdateWQX_IMPORT_TEMP_MONLOC(null, userId, null, orgID, mloc.ID, mloc.Name, mloc.MonLocType, mloc.Desc, mloc.HUC8, mloc.HUC12, mloc.TribeLandInd,
                                mloc.TribeLandName, mloc.Lat, mloc.Long, mloc.SourceMapScale, mloc.HorizontalAccuracyMeasure, mloc.HorizontalAccuracyMeasureUnit, mloc.HorizontalCollectionMethodName,
                                mloc.HorizontalCoordinateReferenceSystemDatumName, mloc.VerticalMeasure, mloc.VerticalMeasureUnit, mloc.VerticalCollectionMethodName, mloc.VerticalCoordinateReferenceSystemDatumName,
                                mloc.CountryCode, mloc.StateCode, mloc.CountyCode, null, null, null, null, null, "P", "");
                        }
                    }
                    // Response.Redirect("~/App_Pages/Secure/WQXImportMonLoc.aspx?e=1");
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
                Exception realerror = ex;
                while (realerror.InnerException != null)
                    realerror = realerror.InnerException;
                _sysLogRepo.InsertT_OE_SYS_LOG("ERROR", realerror.Message ?? "");
                actResult.ImportStatus = false;
                actResult.ImportStatusMsg = "Something went wrong!";
                return actResult;
            }
        }

        // ***************************************************************
        // This is duplicate method from TWqxImportTempMonlocRepository.cs
        // This is to avoid circular reference between current class and 
        // TWqxImportTempMonlocRepository.cs class dependency
        // TODO: Need to be fixed
        // ***************************************************************
        public int InsertOrUpdateWQX_IMPORT_TEMP_MONLOC(int? tEMP_MONLOC_IDX, string uSER_ID, int? mONLOC_IDX, string oRG_ID, string mONLOC_ID, string mONLOC_NAME, string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND, string tRIBAL_LAND_NAME, string lATITUDE_MSR, string lONGITUDE_MSR, int? sOURCE_MAP_SCALE, string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM, string vERT_MEASURE, string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM, string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE, string aQUIFER_NAME, string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string sTATUS_CD, string sTATUS_DESC)
        {
            Boolean insInd = false;
            try
            {
                TWqxImportTempMonloc a = new TWqxImportTempMonloc();

                if (tEMP_MONLOC_IDX != null)
                    a = (from c in _db.TWqxImportTempMonloc
                         where c.TempMonlocIdx == tEMP_MONLOC_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (uSER_ID != null)
                {
                    a.UserId = uSER_ID;
                    if (uSER_ID.Length > 200) { sTATUS_CD = "F"; sTATUS_DESC += "User ID length exceeded. "; }
                }

                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;
                if (oRG_ID != null) a.OrgId = oRG_ID;

                if (mONLOC_ID != null)
                {
                    a.MonlocId = mONLOC_ID.SubStringPlus(0, 35).Trim();
                    if (mONLOC_ID.Length > 35) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID length exceeded. "; }

                    TWqxMonloc mtemp = GetWQX_MONLOC_ByIDString(oRG_ID, mONLOC_ID);
                    if (mtemp != null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID already exists. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_NAME))
                {
                    a.MonlocName = mONLOC_NAME.SubStringPlus(0, 255).Trim();
                    if (mONLOC_NAME.Length > 255) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_TYPE))
                {
                    a.MonlocType = mONLOC_TYPE.SubStringPlus(0, 45);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MonitoringLocationType", mONLOC_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Type not valid. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_DESC))
                {
                    a.MonlocDesc = mONLOC_DESC.SubStringPlus(0, 1999);
                    if (mONLOC_DESC.Length > 1999) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Description length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(hUC_EIGHT))
                {
                    a.HucEight = hUC_EIGHT.Trim().SubStringPlus(0, 8);
                    if (hUC_EIGHT.Length > 8) { sTATUS_CD = "F"; sTATUS_DESC += "HUC8 length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(HUC_TWELVE))
                {
                    a.HucTwelve = HUC_TWELVE.Trim().SubStringPlus(0, 12);
                    if (HUC_TWELVE.Length > 12) { sTATUS_CD = "F"; sTATUS_DESC += "HUC12 length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(tRIBAL_LAND_IND))
                {
                    if (tRIBAL_LAND_IND.ToUpper() == "TRUE") tRIBAL_LAND_IND = "Y";
                    if (tRIBAL_LAND_IND.ToUpper() == "FALSE") tRIBAL_LAND_IND = "N";

                    a.TribalLandInd = tRIBAL_LAND_IND.SubStringPlus(0, 1);
                    if (tRIBAL_LAND_IND.Length > 1) { sTATUS_CD = "F"; sTATUS_DESC += "Tribal Land Indicator length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(tRIBAL_LAND_NAME))
                {
                    a.TribalLandName = tRIBAL_LAND_NAME.SubStringPlus(0, 200);
                    if (tRIBAL_LAND_NAME.Length > 200) { sTATUS_CD = "F"; sTATUS_DESC += "Tribal Land Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(lATITUDE_MSR))
                {
                    a.LatitudeMsr = lATITUDE_MSR.SubStringPlus(0, 30);
                    decimal iii = 0;
                    if (Decimal.TryParse(lATITUDE_MSR, out iii) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Latitude is not decimal format. "; }
                }

                if (!string.IsNullOrEmpty(lONGITUDE_MSR))
                {
                    a.LongitudeMsr = lONGITUDE_MSR.SubStringPlus(0, 30);
                    decimal iii = 0;
                    if (Decimal.TryParse(lONGITUDE_MSR, out iii) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Longitude is not decimal format. "; }
                }

                if (sOURCE_MAP_SCALE != null)
                {
                    a.SourceMapScale = sOURCE_MAP_SCALE;
                }

                if (!string.IsNullOrEmpty(hORIZ_COLL_METHOD))
                {
                    a.HorizCollMethod = hORIZ_COLL_METHOD.SubStringPlus(0, 150).Trim();
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("HorizontalCollectionMethod", hORIZ_COLL_METHOD.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Horizontal Collection Method not valid. "; }
                }

                if (!string.IsNullOrEmpty(hORIZ_REF_DATUM))
                {
                    a.HorizRefDatum = hORIZ_REF_DATUM.Trim().SubStringPlus(0, 6);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("HorizontalCoordinateReferenceSystemDatum", hORIZ_REF_DATUM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Horizontal Collection Datum not valid. "; }
                }

                if (!string.IsNullOrEmpty(vERT_MEASURE))
                {
                    a.VertMeasure = vERT_MEASURE.Trim().SubStringPlus(0, 12);
                    if (vERT_MEASURE.Length > 12) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Measure length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(vERT_MEASURE_UNIT))
                {
                    a.VertMeasureUnit = vERT_MEASURE_UNIT.Trim().SubStringPlus(0, 12);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("MeasureUnit", vERT_MEASURE_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Measure Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(vERT_COLL_METHOD))
                {
                    a.VertCollMethod = vERT_COLL_METHOD.Trim().SubStringPlus(0, 50);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("VerticalCollectionMethod", vERT_COLL_METHOD.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Collection Method not acceptable. "; }
                }

                if (!string.IsNullOrEmpty(vERT_REF_DATUM))
                {
                    a.VertRefDatum = vERT_REF_DATUM.Trim().SubStringPlus(0, 6);
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey("VerticalCoordinateReferenceSystemDatum", vERT_REF_DATUM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Collection Datum not acceptable. "; }
                }

                if (!string.IsNullOrEmpty(cOUNTRY_CODE))
                {
                    //if there is a match of country NAME value to reference data text (in case user is importing country name instead of code)
                    TWqxRefData rd = _refDataRepo.GetT_WQX_REF_DATA_ByTextGetRow("Country", cOUNTRY_CODE);
                    if (rd != null)
                        a.CountryCode = rd.Value.SubStringPlus(0, 2);
                    else
                    {
                        a.CountryCode = cOUNTRY_CODE.SubStringPlus(0, 2);
                        if (cOUNTRY_CODE.Length > 2) { sTATUS_CD = "F"; sTATUS_DESC += "Country Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(sTATE_CODE))
                {
                    //if there is a match of state value to reference data text (in case user is importing state name instead of code)
                    TWqxRefData rd = _refDataRepo.GetT_WQX_REF_DATA_ByTextGetRow("State", sTATE_CODE);
                    if (rd != null)
                        a.StateCode = rd.Value;
                    else
                    {
                        a.StateCode = sTATE_CODE.SubStringPlus(0, 2);
                        if (sTATE_CODE.Length > 2) { sTATUS_CD = "F"; sTATUS_DESC += "State Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(cOUNTY_CODE))
                {
                    //if there is a match of county value to reference data text (in case user is importing county text instead of code)
                    TWqxRefCounty c = _refDataRepo.GetT_WQX_REF_COUNTY_ByCountyNameAndState(sTATE_CODE, cOUNTY_CODE);
                    if (c != null)
                        a.CountyCode = c.CountyCode;
                    else
                    {
                        a.CountyCode = cOUNTY_CODE.SubStringPlus(0, 3);
                        if (cOUNTY_CODE.Length > 3) { sTATUS_CD = "F"; sTATUS_DESC += "County Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(wELL_TYPE))
                {
                    a.WellType = wELL_TYPE.Trim().SubStringPlus(0, 255);
                }

                if (!string.IsNullOrEmpty(aQUIFER_NAME))
                {
                    a.AquiferName = aQUIFER_NAME.Trim().SubStringPlus(0, 120);
                }

                if (!string.IsNullOrEmpty(fORMATION_TYPE))
                {
                    a.FormationType = fORMATION_TYPE.Trim().SubStringPlus(0, 50);
                }

                if (!string.IsNullOrEmpty(wELLHOLE_DEPTH_MSR))
                {
                    a.WellholeDepthMsr = wELLHOLE_DEPTH_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(wELLHOLE_DEPTH_MSR_UNIT))
                {
                    a.WellholeDepthMsrUnit = wELLHOLE_DEPTH_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                    _db.TWqxImportTempMonloc.Add(a);


                _db.SaveChanges();

                return a.TempMonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
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
    }
}
