using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxActivityRepository : IRepository<TWqxActivity>
    {
        IEnumerable<SelectListItem> GetTWqxActvityForDropDown();
        void Update(TWqxActivity wqxActivity);
        public List<TWqxActivity> GetWQX_ACTIVITY(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX);
        public int GetT_WQX_RESULTCount(string OrgID);
        public int GetWQX_ACTIVITY_MyOrgCount(int UserID);
        public List<ActivityListDisplay> GetWQX_ACTIVITYDisplay(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX, string WQXStatus);
        public int DeleteT_WQX_ACTIVITY(int ActivityIDX, int userIdx);
        public int DeleteT_WQX_ACTIVITY(int ActivityIDX, string UserID);
        public int InsertOrUpdateWQX_ACTIVITY(global::System.Int32? aCTIVITY_IDX, global::System.String oRG_ID, global::System.Int32? pROJECT_IDX, global::System.Int32? mONLOC_IDX, global::System.String aCTIVITY_ID,
            global::System.String aCT_TYPE, global::System.String aCT_MEDIA, global::System.String aCT_SUBMEDIA, global::System.DateTime? aCT_START_DT, global::System.DateTime? aCT_END_DT,
            global::System.String aCT_TIME_ZONE, global::System.String rELATIVE_DEPTH_NAME, global::System.String aCT_DEPTHHEIGHT_MSR, global::System.String aCT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String tOP_DEPTHHEIGHT_MSR, global::System.String tOP_DEPTHHEIGHT_MSR_UNIT, global::System.String bOT_DEPTHHEIGHT_MSR, global::System.String bOT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String dEPTH_REF_POINT, global::System.String aCT_COMMENT, global::System.String bIO_ASSEMBLAGE_SAMPLED, global::System.String bIO_DURATION_MSR,
            global::System.String bIO_DURATION_MSR_UNIT, global::System.String bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, global::System.String bIO_REACH_LEN_MSR,
            global::System.String bIO_REACH_LEN_MSR_UNIT, global::System.String bIO_REACH_WID_MSR, global::System.String bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT,
            global::System.String bIO_NET_TYPE, global::System.String bIO_NET_AREA_MSR, global::System.String bIO_NET_AREA_MSR_UNIT, global::System.String bIO_NET_MESHSIZE_MSR,
            global::System.String bIO_MESHSIZE_MSR_UNIT, global::System.String bIO_BOAT_SPEED_MSR, global::System.String bIO_BOAT_SPEED_MSR_UNIT, global::System.String bIO_CURR_SPEED_MSR,
            global::System.String bIO_CURR_SPEED_MSR_UNIT, global::System.String bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_EQUIP, global::System.String sAMP_COLL_EQUIP_COMMENT,
            int? sAMP_PREP_IDX, global::System.String sAMP_PREP_CONT_TYPE, global::System.String sAMP_PREP_CONT_COLOR, global::System.String sAMP_PREP_CHEM_PRESERV, global::System.String sAMP_PREP_THERM_PRESERV,
            global::System.String sAMP_PREP_STORAGE_DESC, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND,
            string activityIDUserSupplied, string sampCompName, string activityLocDescText,
            string measureValue, string gearProcUnitSelected, string habitatSelMethod, string methodName,
            string thermalPreservativeUsedName, string hydrologicCondition, string sampContLabNametring, string hydrologicEvent,
            string horizCollMethod, string horizCoRefSysDatumName, string latitudeMsr, string longitudeMsr,
            String cREATE_USER = "system", string eNTRY_TYPE = "C");
        public List<TWqxRefData> GetT_WQX_REF_DATA_ActivityTypeUsed(string OrgID);
        public TWqxActivity GetWQX_ACTIVITY_ByID(int ActivityIDX);
        public List<TWqxResult> GetT_WQX_RESULT(int ActivityIDX);
        public TWqxActivity GetWQX_ACTIVITY_ByUnique(string OrgID, string ActivityID);
        public int UpdateWQX_ACTIVITY_WQXStatus(global::System.Int32? aCTIVITY_IDX, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system");
        public List<VWqxActivityLatest> GetVWqxActivityLatest(string orgId);
        public VWqxActivityLatest GetVWqxActivityLatestByMonlocId(int monlocId);
        List<CharDisplay> GetTWqxResultSampledCharacteristics(string orgId);
    }
}
