using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTempActivityMetricRepository : Repository<TWqxImportTempActivityMetricRepository>, ITWqxImportTempActivityMetricRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxRefDataRepository _refDataRepo;
        private readonly ITWqxActivityRepository _activityRepo;
        public TWqxImportTempActivityMetricRepository(ApplicationDbContext db,
            ITWqxRefDataRepository refDataRepo,
            ITWqxActivityRepository activityRepo) : base(db)
        {
            _db = db;
            _refDataRepo = refDataRepo;
            _activityRepo = activityRepo;
        }

        public int DeleteT_WQX_IMPORT_TEMP_ACTIVITY_METRIC(string userId)
        {
            try
            {
                _db.TWqxImportTempActivityMetric.RemoveRange(
                    _db.TWqxImportTempActivityMetric.Where(a => a.UserId == userId));
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int InsertWQX_IMPORT_TEMP_ACTIVITY_METRIC(string userId, string orgId, Dictionary<string, string> colVals, string configFilePath)
        {
            try
            {
                //get import config ruless
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("I", configFilePath);

                TWqxImportTempActivityMetric a = new TWqxImportTempActivityMetric();
                
                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(userId)) a.UserId = userId;
                if (!string.IsNullOrEmpty(orgId)) a.OrgId = orgId;

                //*************** PRE CUSTOM VALIDATION **********************************************
                string _t = null;

                //fail if no matching activity id found
                _t = Utils.GetValueOrDefault(colVals, "ACTIVITY_ID");
                if (!string.IsNullOrEmpty(_t))
                {
                    TWqxActivity act = _activityRepo.GetWQX_ACTIVITY_ByUnique(orgId, _t);
                    if (act == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching activity ID found. Please import activity prior to importing activity metric. "; }
                    else
                        a.ActivityIdx = act.ActivityIdx;
                }

                //********************** end custom validation ********************************************

                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "ActivityId");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricTypeId");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricTypeIdContext");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricValueMsr");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricValueMsrUnit");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricScore");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "MetricComment");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "TempBioHabitatIndexIdx");

                //*************** POST CUSTOM VALIDATION **********************************************

                //*************** END CUSTOM VALIDATION **********************************************


                _db.TWqxImportTempActivityMetric.Add(a);
                _db.SaveChanges();

                return a.TempActivityMetricIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxImportTempActivityMetricRepository wqxImportTempActivityMetric)
        {
            throw new NotImplementedException();
        }

        public void WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref TWqxImportTempActivityMetric a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field
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
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ").SubStringPlus(0, 200);

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
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ").SubStringPlus(0, 200);
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (_refDataRepo.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ").SubStringPlus(0, 200);
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
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ").SubStringPlus(0, 200);
                }
            }

            //finally set the value before returning
            if (_rules._datatype == "")
                typeof(TWqxImportTempActivityMetric).GetProperty(f).SetValue(a, _value);
            else if (_rules._datatype == "int")
                typeof(TWqxImportTempActivityMetric).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
        }
    }
}
