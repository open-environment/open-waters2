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
                DeleteT_WQX_IMPORT_TEMP_MONLOC(user.UserId);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }

        

        public int DeleteT_WQX_IMPORT_TEMP_MONLOC(string userId)
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
                            m.WellholeDepthMsrUnit, wqxSubmitStatus, null, true, wqxImport, userName);

                    }
                }

                DeleteT_WQX_IMPORT_TEMP_MONLOC(userName);

                _importLogRepo.InsertUpdateWQX_IMPORT_LOG(null, OrgID, "MonitoringLocations", "MonitoringLocations", 0, "Success", "100", "", null, userName);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw ex;
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
