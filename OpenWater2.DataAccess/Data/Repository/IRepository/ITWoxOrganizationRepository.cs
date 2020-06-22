using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxOrganizationRepository : IRepository<TWqxOrganization>
    {
        IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown();
        void Update(TWqxOrganization wqxOrganization);
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd);
        public List<VWqxAllOrgs> GetV_WQX_ALL_ORGS();
        public TWqxOrganization GetWQX_ORGANIZATION_ByID(string OrgID);
        public TEpaOrgs GetT_EPA_ORGS_ByOrgID(string OrgID);
        public int InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS,
            string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID,
            string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null,
            string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null);
        public int ApproveRejectT_WQX_USER_ORGS(string oRG_ID, Int32 uSER_IDX, string ApproveRejectCode);
        public int DeleteT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX);
    }
}
