using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTempProjectRepository : Repository<TWqxImportTempProject>, ITWqxImportTempProjectRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ITWqxProjectRepository _projRepo;
        private readonly ITWqxImportLogRepository _importLogRepo;
        public TWqxImportTempProjectRepository(ApplicationDbContext db,
            ITWqxProjectRepository projRepo,
            ITWqxImportLogRepository importLogRepo) : base(db)
        {
            _db = db;
            _projRepo = projRepo;
            _importLogRepo = importLogRepo;
        }

        public int CancelProcessImportTempProject(bool wqxImport, string wqxSubmitStatus, string selectedMonlocIds, int userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if (user == null)
                {
                    return actResult;
                }
                DeleteTWqxImportTempProject(user.UserId);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }
        public List<TWqxImportTempProject> GetWqxImportTempProject(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempProject
                        where a.UserId == UserID
                        orderby a.TempProjectIdx
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTempProject> GetWqxImportTempProject(int UserIdx)
        {
            List<TWqxImportTempProject> actResult = null;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == UserIdx).FirstOrDefault();
                if (user != null)
                {
                    return GetWqxImportTempProject(user.UserId);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return actResult;
        }
        public int DeleteTWqxImportTempProject(int userIdx)
        {
            int actResult = 0;
            TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
            if(user != null)
            {
                return DeleteTWqxImportTempProject(user.UserId);
            }
            return actResult;
        }

        public int DeleteTWqxImportTempProject(string userId)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_PROJECT WHERE USER_ID = '" + userId + "'";
                _db.Database.ExecuteSqlCommand(sql);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        TWqxImportTempProject GetWqxImportTempProjectById(int tempProjectId)
        {
            try
            {
                return (from a in _db.TWqxImportTempProject
                        where a.TempProjectIdx == tempProjectId
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public int InsertOrUpdateWQX_IMPORT_TEMP_PROJECT(global::System.Int32? tEMP_PROJECT_IDX, string uSER_ID, global::System.Int32? pROJECT_IDX, global::System.String oRG_ID,
            global::System.String pROJECT_ID, global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD,
            global::System.Boolean? qAPP_APPROVAL_IND, global::System.String qAPP_APPROVAL_AGENCY, string sTATUS_CD, string sTATUS_DESC)
        {
            Boolean insInd = false;
            try
            {
                TWqxImportTempProject a = new TWqxImportTempProject();

                if (tEMP_PROJECT_IDX != null)
                    a = (from c in _db.TWqxImportTempProject
                         where c.TempProjectIdx == tEMP_PROJECT_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (uSER_ID != null)
                {
                    a.UserId = uSER_ID;
                    if (uSER_ID.Length > 200) { sTATUS_CD = "F"; sTATUS_DESC += "User ID length exceeded. "; }
                }

                if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX;
                if (oRG_ID != null) a.OrgId = oRG_ID;

                if (pROJECT_ID != null)
                {
                    a.ProjectId = pROJECT_ID.SubStringPlus(0, 35).Trim();
                    if (pROJECT_ID.Length > 35) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID length exceeded. "; }

                    TWqxProject ptemp = _projRepo.GetWQX_PROJECT_ByIDString(pROJECT_ID, oRG_ID);
                    if (ptemp != null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID already exists. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_NAME))
                {
                    a.ProjectName = pROJECT_NAME.SubStringPlus(0, 120).Trim();
                    if (pROJECT_NAME.Length > 120) { sTATUS_CD = "F"; sTATUS_DESC += "Project Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_DESC))
                {
                    a.ProjectDesc = pROJECT_DESC.SubStringPlus(0, 1999);
                    if (pROJECT_DESC.Length > 1999) { sTATUS_CD = "F"; sTATUS_DESC += "Project Description length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(sAMP_DESIGN_TYPE_CD))
                {
                    a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD.Trim().SubStringPlus(0, 20);
                    if (sAMP_DESIGN_TYPE_CD.Length > 20) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Design Type Code length exceeded. "; }
                }

                if (qAPP_APPROVAL_IND != null)
                {
                    a.QappApprovalInd = qAPP_APPROVAL_IND;
                }

                if (!string.IsNullOrEmpty(qAPP_APPROVAL_AGENCY))
                {
                    a.QappApprovalAgency = qAPP_APPROVAL_AGENCY.SubStringPlus(0, 50);
                    if (qAPP_APPROVAL_AGENCY.Length > 50) { sTATUS_CD = "F"; sTATUS_DESC += "QAPP Approval Agency length exceeded. "; }
                }

                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                    _db.TWqxImportTempProject.Add(a);

                _db.SaveChanges();

                return a.TempProjectIdx;
            }
            catch (Exception ex)
            {
                sTATUS_CD = "F";
                sTATUS_DESC += "Unspecified error. ";
                return 0;
            }
        }

        public int ProcessImportTempProject(bool wqxImport, string wqxSubmitStatus, string selectedProjectIds, int userIdx)
        {
            int actResult = 0;
            try
            {
                TOeUsers user = _db.TOeUsers.Where(u => u.UserIdx == userIdx).FirstOrDefault();
                if (user == null)
                {
                    return actResult;
                }
                string userName = user.UserId;
                string OrgID = "";
                foreach (string tempId in selectedProjectIds.Split(","))
                {

                    TWqxImportTempProject m = GetWqxImportTempProjectById(Convert.ToInt32(tempId));
                    if (m != null)
                    {
                        OrgID = m.OrgId;

                        int SuccID = _projRepo.InsertOrUpdateWQX_PROJECT(m.ProjectIdx, m.OrgId, m.ProjectId, m.ProjectName,
                            m.ProjectDesc,m.SampDesignTypeCd,m.QappApprovalInd,m.QappApprovalAgency,
                            wqxSubmitStatus,null,true,wqxImport,userName);

                    }
                }

                DeleteTWqxImportTempProject(userName);

                _importLogRepo.InsertUpdateWQX_IMPORT_LOG(null, OrgID, "MonitoringLocations", "MonitoringLocations", 0, "Success", "100", "", null, userName);
                actResult = 1;
            }
            catch (Exception ex)
            {
                throw;
            }
            return actResult;
        }
    }
}
