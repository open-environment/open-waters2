using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxProjectRepository : IRepository<TWqxProject>
    {
        IEnumerable<SelectListItem> GetTWqxProjectsForDropDown();
        void Update(TWqxProject wqxProject);
        public int DeleteT_WQX_PROJECT(int ProjectIDX, string UserID);
        public TWqxProject GetWQX_PROJECT_ByID(int ProjectIDX);
        public int GetWQX_PROJECT_MyOrgCount(int UserIDX);
        public TWqxProject GetWQX_PROJECT_ByIDString(string ProjectID, string OrgID);
        public int InsertOrUpdateWQX_PROJECT(global::System.Int32? pROJECT_IDX, global::System.String oRG_ID, global::System.String pROJECT_ID,
            global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD, global::System.Boolean? qAPP_APPROVAL_IND,
            global::System.String qAPP_APPROVAL_AGENCY, global::System.String wQX_SUBMIT_STATUS, DateTime? wQX_SUBMIT_DT, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system");
        public List<TWqxProject> GetWQX_PROJECT(bool ActInd, string OrgID, bool? WQXPending);
        public Task<ImportStatusModel> WQXImportProjectAsync(string orgID, int userIdx);
        public Task<ImportStatusModel> WQXImportProjectAsync(string orgID, string userId);
    }
}
