using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempMonlocRepository : IRepository<TWqxImportTempMonloc>
    {
        
        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(int UserIdx);
        public List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(string UserID);
        public int DeleteTWqxImportTempMonloc(int userIdx);
        public int DeleteTWqxImportTempMonloc(string userId);
        public int InsertOrUpdateWQX_IMPORT_TEMP_MONLOC(int? tEMP_MONLOC_IDX, string uSER_ID, int? mONLOC_IDX, string oRG_ID, string mONLOC_ID,
            string mONLOC_NAME, string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND, string tRIBAL_LAND_NAME, string lATITUDE_MSR,
            string lONGITUDE_MSR, int? sOURCE_MAP_SCALE, string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM, string vERT_MEASURE,
            string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM, string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE,
            string aQUIFER_NAME, string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string sTATUS_CD, string sTATUS_DESC);
        public int InsertWQX_IMPORT_TEMP_MONLOC_New(string userID, string oRG_ID, Dictionary<string, string> colVals, string configFilePath);
        public void WQX_IMPORT_TEMP_MONLOC_GenVal(ref TWqxImportTempMonloc a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f);
        public TWqxImportTempMonloc GetWQX_IMPORT_TEMP_MONLOC_ByID(int TempMonLocID);
        public int ProcessImportTempMonloc(Boolean wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx);
        public int CancelProcessImportTempMonloc(Boolean wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx);
        void Update(TWqxImportTempMonloc wqxImportTempMonloc);
    }
}
