﻿using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxOrganizationRepository : IRepository<TWqxOrganization>
    {
        IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown();
        void Update(TWqxOrganization wqxOrganization);
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd);
        public List<VWqxAllOrgs> GetV_WQX_ALL_ORGS();
        public List<TWqxOrganization> GetWQX_ORGANIZATION();
        public Task<TWqxOrganization> GetWQX_ORGANIZATION_ByIDAsync(string OrgID);
        public TWqxOrganization GetWQX_ORGANIZATION_ByID(string OrgID);
        public TEpaOrgs GetT_EPA_ORGS_ByOrgID(string OrgID);
        public Task<int> InsertOrUpdateT_WQX_ORGANIZATIONAsync(string oRG_ID, string oRG_NAME);
        public Task<int> InsertOrUpdateT_WQX_ORGANIZATIONAsync(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS,
            string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID,
            string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null,
            string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null);
        public int ApproveRejectT_WQX_USER_ORGS(string oRG_ID, Int32 uSER_IDX, string ApproveRejectCode);
        public int DeleteT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX);
        public List<TWqxRefData> GetT_WQX_REF_DATA(string tABLE, Boolean ActInd, Boolean UsedInd);
        public List<UserOrgDisplay> GetT_OE_USERSInOrganization(string OrgID);
        public List<TOeUsers> GetT_OE_USERSNotInOrganization(string OrgID);
        public Task<ConnectTestResult> ConnectTestAsync(string orgID, string typ);
        public List<TWqxImportTranslate> GetWQX_IMPORT_TRANSLATE_byOrg(string OrgID);
        public bool CanUserEditOrg(int UserIDX, string OrgID);
        public List<string> GetWQX_ORGANIZATION_PendingDataToSubmit();
        public Task<List<string>> GetWQX_ORGANIZATION_PendingDataToSubmit2Async();
        public Task<List<string>> GetWQX_ORGANIZATION_PendingDataToSubmitStatusAsync();

    }
}
