using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempProjectRepository : IRepository<TWqxImportTempProject>
    {
        public List<TWqxImportTempProject> GetWqxImportTempProject(int UserIdx);
        public List<TWqxImportTempProject> GetWqxImportTempProject(string UserID);
        public int CancelProcessImportTempProject(bool wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx);
        public int DeleteTWqxImportTempProject(int userIdx);
        public int DeleteTWqxImportTempProject(string userId);
        public int InsertOrUpdateWQX_IMPORT_TEMP_PROJECT(global::System.Int32? tEMP_PROJECT_IDX, string uSER_ID, global::System.Int32? pROJECT_IDX, global::System.String oRG_ID,
            global::System.String pROJECT_ID, global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD,
            global::System.Boolean? qAPP_APPROVAL_IND, global::System.String qAPP_APPROVAL_AGENCY, string sTATUS_CD, string sTATUS_DESC);
        public int ProcessImportTempProject(bool wqxImport, string wqxSubmitStatus, string selectedProjectIds, int userIdx);
    }
}
