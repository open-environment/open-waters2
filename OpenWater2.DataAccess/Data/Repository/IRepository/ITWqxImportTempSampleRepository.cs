using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempSampleRepository : IRepository<TWqxImportTempSample>
    {
        public int CancelProcessImportTempSample(int userIdx);
        public int DeleteTWqxImportTempSample(int userIdx);
        public int DeleteTWqxImportTempSample(string userId);
        public void WQX_IMPORT_TEMP_SAMPLE_GenVal(ref TWqxImportTempSample a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f);
        public int InsertUpdateWQX_IMPORT_TEMP_SAMPLE_New(string userId, string orgId, int? projectIdx, string projectId, Dictionary<string, string> colVals, string configFilePath);
        public void Update(TWqxImportTempSample wqxImportTempSample);
        public int SP_ImportActivityFromTemp(int userIdx, string WQXInd, string activityReplacedInd);
        public int SP_ImportActivityFromTemp(string userID, string WQXInd, string activityReplacedInd);

        public List<ImportSampleResultDisplay> GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(int UserIdx);
        public List<ImportSampleResultDisplay> GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(string UserID);
        public int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE_Status(int tEMP_SAMPLE_IDX, string sTATUS_CD, string sTATUS_DESC);
        public int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE(global::System.Int32? tEMP_SAMPLE_IDX, string uSER_ID, global::System.String oRG_ID, global::System.Int32? pROJECT_IDX,
            string pROJECT_ID, global::System.Int32? mONLOC_IDX, string mONLOC_ID, global::System.Int32? aCTIVITY_IDX, global::System.String aCTIVITY_ID,
            global::System.String aCT_TYPE, global::System.String aCT_MEDIA, global::System.String aCT_SUBMEDIA, global::System.DateTime? aCT_START_DT, global::System.DateTime? aCT_END_DT,
            global::System.String aCT_TIME_ZONE, global::System.String rELATIVE_DEPTH_NAME, global::System.String aCT_DEPTHHEIGHT_MSR, global::System.String aCT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String tOP_DEPTHHEIGHT_MSR, global::System.String tOP_DEPTHHEIGHT_MSR_UNIT, global::System.String bOT_DEPTHHEIGHT_MSR, global::System.String bOT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String dEPTH_REF_POINT, global::System.String aCT_COMMENT, global::System.String bIO_ASSEMBLAGE_SAMPLED, global::System.String bIO_DURATION_MSR,
            global::System.String bIO_DURATION_MSR_UNIT, global::System.String bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, global::System.String bIO_REACH_LEN_MSR,
            global::System.String bIO_REACH_LEN_MSR_UNIT, global::System.String bIO_REACH_WID_MSR, global::System.String bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT,
            global::System.String bIO_NET_TYPE, global::System.String bIO_NET_AREA_MSR, global::System.String bIO_NET_AREA_MSR_UNIT, global::System.String bIO_NET_MESHSIZE_MSR,
            global::System.String bIO_MESHSIZE_MSR_UNIT, global::System.String bIO_BOAT_SPEED_MSR, global::System.String bIO_BOAT_SPEED_MSR_UNIT, global::System.String bIO_CURR_SPEED_MSR,
            global::System.String bIO_CURR_SPEED_MSR_UNIT, global::System.String bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            global::System.String sAMP_COLL_METHOD_CTX, global::System.String sAMP_COLL_METHOD_NAME, global::System.String sAMP_COLL_EQUIP, global::System.String sAMP_COLL_EQUIP_COMMENT,
            int? sAMP_PREP_IDX, global::System.String sAMP_PREP_ID, global::System.String sAMP_PREP_CTX, global::System.String sAMP_PREP_NAME,
            global::System.String sAMP_PREP_CONT_TYPE, global::System.String sAMP_PREP_CONT_COLOR, global::System.String sAMP_PREP_CHEM_PRESERV,
            global::System.String sAMP_PREP_THERM_PRESERV, global::System.String sAMP_PREP_STORAGE_DESC, string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, Boolean autoImportRefDataInd);
        public Task<bool> ImportActivityAsync(string OrgID, int? ImportID, string UserID);
    }
}
