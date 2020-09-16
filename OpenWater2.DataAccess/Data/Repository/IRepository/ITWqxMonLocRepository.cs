using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxMonLocRepository : IRepository<TWqxMonloc>
    {
        IEnumerable<SelectListItem> GetTWqxMonLocForDropDown();
        void Update(TWqxMonloc wqxMonloc);
        public bool GetT_WQX_MONLOC_PendingInd(string OrgID);
        public Task<List<TWqxMonloc>> GetWQX_MONLOC(bool ActInd, string OrgID, bool? WQXPending);
        public int DeleteT_WQX_MONLOC(int monLocIDX, int userIdx);
        public int DeleteT_WQX_MONLOC(int monLocIDX, string UserID);
        public TWqxMonloc GetWQX_MONLOC_ByID(int monLocIDX);
        public int GetWQX_ACTIVITYByMonLocID(int monLocIDX);
        public TWqxUserOrgs GetWQX_USER_ORGS_ByUserIDX_OrgID(int UserIDX, string OrgID);
        public int GetWQX_MONLOC_MyOrgCount(int UserIDX);
        public TWqxMonloc GetWQX_MONLOC_ByIDString(string orgID, string MonLocID);
        public int InsertOrUpdateWQX_MONLOC(int? mONLOC_IDX, string oRG_ID, string mONLOC_ID, string mONLOC_NAME,
            string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND,
            string tRIBAL_LAND_NAME, string lATITUDE_MSR, string lONGITUDE_MSR, Int32? sOURCE_MAP_SCALE,
            string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM,
            string vERT_MEASURE, string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM,
            string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE, string aQUIFER_NAME,
            string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string wQX_SUBMIT_STATUS,
            DateTime? wQXUpdateDate, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system");

        public List<TWqxMonloc> GetWQX_MONLOC_ByOrgID(string OrgID);
    }
}
