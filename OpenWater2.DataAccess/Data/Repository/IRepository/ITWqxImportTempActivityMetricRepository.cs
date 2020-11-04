using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempActivityMetricRepository : IRepository<TWqxImportTempActivityMetricRepository>
    {
        public int DeleteT_WQX_IMPORT_TEMP_ACTIVITY_METRIC(string userId);
        public void WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref TWqxImportTempActivityMetric a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f);
        public int InsertWQX_IMPORT_TEMP_ACTIVITY_METRIC(string userId, string orgId, Dictionary<string, string> colVals, string configFilePath);
        public List<TWqxImportTempActivityMetric> GetWqxImportTempActivityMetric(int userIdx);
        public List<TWqxImportTempActivityMetric> GetWqxImportTempActivityMetric(string userId);

        void Update(TWqxImportTempActivityMetricRepository wqxImportTempActivityMetric);

    }
}
