using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTempMonlocRepository : Repository<TWqxImportTempMonloc>, ITWqxImportTempMonlocRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxRefDataRepository _refDataRepo;
        private readonly ITWqxMonLocRepository _monlocRepo;
        private readonly ITWqxImportLogRepository _importLogRepo;
        public TWqxImportTempMonlocRepository(ApplicationDbContext db,
            ITWqxRefDataRepository refDataRepo,
            ITWqxMonLocRepository monlocRepo,
            ITWqxImportLogRepository importLogRepo) : base(db)
        {
            _db = db;
            _refDataRepo = refDataRepo;
            _monlocRepo = monlocRepo;
            _importLogRepo = importLogRepo;
        }

        public int CancelProcessImportTempMonloc(bool wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if (user == null)
                {
                    return actResult;
                }
                DeleteTWqxImportTempMonloc(user.UserId);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        

        public int DeleteTWqxImportTempMonloc(string userId)
        {
            try
            {
                _db.TWqxImportTempMonloc.RemoveRange(
                    _db.TWqxImportTempMonloc.Where(m => m.UserId == userId));
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteTWqxImportTempMonloc(int userIdx)
        {
            TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
            if(user != null)
            {
                return DeleteTWqxImportTempMonloc(user.UserId);
            }
            return 0;
        }

        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempMonloc
                        where a.UserId == UserID
                        orderby a.TempMonlocIdx
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(int UserIdx)
        {
            List<TWqxImportTempMonloc> actResult = null;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == UserIdx).FirstOrDefault();
                if(user != null)
                {
                    return GetWQX_IMPORT_TEMP_MONLOC(user.UserId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        public TWqxImportTempMonloc GetWQX_IMPORT_TEMP_MONLOC_ByID(int TempMonLocID)
        {
            try
            {
                return (from a in _db.TWqxImportTempMonloc
                        where a.TempMonlocIdx == TempMonLocID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

                    TWqxMonloc mtemp = _monlocRepo.GetWQX_MONLOC_ByIDString(oRG_ID, mONLOC_ID);
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

        public int InsertWQX_IMPORT_TEMP_MONLOC_New(string userID, string orgId, Dictionary<string, string> colVals, string configFilePath)
        {
            try
            {
                //get import config rules
                List<ConfigInfoType> _allRules = UtilityHelper.GetAllColumnInfo("M", configFilePath);

                TWqxImportTempMonloc a = new TWqxImportTempMonloc();

                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(userID)) a.UserId = userID;
                if (!string.IsNullOrEmpty(orgId)) a.OrgId = orgId;

                //*************** PRE CUSTOM VALIDATION **********************************************
                string _t = null;

                _t = UtilityHelper.GetValueOrDefault(colVals, "TRIBAL_LAND_IND");
                if (!string.IsNullOrEmpty(_t))
                {
                    if (_t.ToUpper() == "TRUE") colVals["TRIBAL_LAND_IND"] = "Y";
                    if (_t.ToUpper() == "FALSE") colVals["TRIBAL_LAND_IND "] = "N";
                }

                //if there is a match of county value to reference data text (in case user is importing county text instead of code)
                _t = UtilityHelper.GetValueOrDefault(colVals, "COUNTY_CODE");
                if (!string.IsNullOrEmpty(_t))
                {
                    TWqxRefCounty c =  _refDataRepo.GetT_WQX_REF_COUNTY_ByCountyNameAndState(UtilityHelper.GetValueOrDefault(colVals, "STATE_CODE"), _t);
                    if (c != null)
                        a.CountryCode = c.CountyCode;
                    else
                        WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "COUNTY_CODE");
                }
                //********************** end custom validation ********************************************

                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MonlocId");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MonlocName");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MonlocType");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MonlocDesc");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HucEight");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HucTwelve");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "TribalLandInd");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "TribalLandName");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "LatitudeMsr");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "LongitudeMsr");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "SourceMapScale");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HorizCollMethod");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HorizRefDatum");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VertMeasure");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VertMeasureUnit");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VertCollMethod");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VertRefDatum");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "CountryCode");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "StateCode");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WellType");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "AquiferName");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "FormationType");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WellholeDepthMsr");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WellholeDepthMsrUnit");

                //*************** POST CUSTOM VALIDATION **********************************************
                if (!string.IsNullOrEmpty(a.MonlocId))
                    if (_monlocRepo.GetWQX_MONLOC_ByIDString(orgId, a.MonlocId) != null) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Monitoring Location ID already exists. "; }

                decimal ii;
                if (!string.IsNullOrEmpty(a.LatitudeMsr))
                    if (Decimal.TryParse(a.LatitudeMsr, out ii) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Latitude is not decimal format. "; }

                if (!string.IsNullOrEmpty(a.LongitudeMsr))
                    if (Decimal.TryParse(a.LongitudeMsr, out ii) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Longitude is not decimal format. "; }
                //*************** END CUSTOM VALIDATION **********************************************


                _db.TWqxImportTempMonloc.Add(a);
                _db.SaveChanges();

                return a.TempMonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //TODO: need to handle tempmonloc for V3.0
        public int ProcessImportTempMonloc(bool wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int  userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if (user == null)
                {
                    return actResult;
                }
                string userName = user.UserId;
                string OrgID = "";
                foreach (string tempId in selectedMonlocIds.Split(","))
                {

                    TWqxImportTempMonloc m = GetWQX_IMPORT_TEMP_MONLOC_ByID(Convert.ToInt32(tempId));
                    if (m != null)
                    {
                        OrgID = m.OrgId;

                        int SuccID = _monlocRepo.InsertOrUpdateWQX_MONLOC(m.MonlocIdx, m.OrgId, m.MonlocId, m.MonlocName, m.MonlocType, m.MonlocDesc, m.HucEight, m.HucTwelve, m.TribalLandInd,
                            m.TribalLandName, m.LatitudeMsr, m.LongitudeMsr, m.SourceMapScale, m.HorizAccuracy, m.HorizAccuracyUnit, m.HorizCollMethod, m.HorizRefDatum, m.VertMeasure,
                            m.VertMeasureUnit, m.VertCollMethod, m.VertRefDatum, m.CountryCode, m.StateCode, m.CountyCode, m.WellType, m.AquiferName, m.FormationType, m.WellholeDepthMsr,
                            m.WellholeDepthMsrUnit, wqxSubmitStatus, null, null, null, null, null, null, null, null, null, null, null, null, null, true, wqxImport, userName);

                    }
                }

                DeleteTWqxImportTempMonloc(userName);

                _importLogRepo.InsertUpdateWQX_IMPORT_LOG(null, OrgID, "MonitoringLocations", "MonitoringLocations", 0, "Success", "100", "", null, userName);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw;
            }
            return actResult;
        }

        public void Update(TWqxImportTempMonloc wqxImportTempMonloc)
        {
            throw new NotImplementedException();
        }

        public void WQX_IMPORT_TEMP_MONLOC_GenVal(ref TWqxImportTempMonloc a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            string _value = UtilityHelper.GetValueOrDefault(colVals, f); //supplied value for this field
            var _rules = t.Find(item => item._name == f);   //import rules for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ").SubStringPlus(0, 100);

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ").SubStringPlus(0, 100);
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ").SubStringPlus(0, 100);
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    _value = "-";
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ").SubStringPlus(0, 100);
                }
            }

            //finally set the value before returning
            if (_rules._datatype == "")
                typeof(TWqxImportTempMonloc).GetProperty(f).SetValue(a, _value);
            else if (_rules._datatype == "int")
                typeof(TWqxImportTempMonloc).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
        }
    }
}
