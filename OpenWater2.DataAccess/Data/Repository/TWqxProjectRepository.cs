using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxProjectRepository : Repository<TWqxProject>, ITWqxProjectRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_WQX_PROJECT(int ProjectIDX, string UserID)
        {
            TWqxProject entityToDelete = _db.TWqxProject.Where(p => p.ProjectIdx == ProjectIDX).FirstOrDefault();
            if(entityToDelete == null)
            {
                _db.TWqxProject.Remove(entityToDelete);
                _db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<SelectListItem> GetTWqxProjectsForDropDown()
        {
            return _db.TWqxProject.Select(i => new SelectListItem()
            {
                Text = i.ProjectName,
                Value = i.ProjectId
            });
        }

        public List<TWqxProject> GetWQX_PROJECT(bool ActInd, string OrgID, bool? WQXPending)
        {
            try
            {
                return (from a in _db.TWqxProject
                        where (ActInd ? a.ActInd == true : true)
                        && a.OrgId == OrgID
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        orderby a.ProjectId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxProject GetWQX_PROJECT_ByID(int ProjectIDX)
        {
            return _db.TWqxProject.Where(p => p.ProjectIdx == ProjectIDX).FirstOrDefault();
        }

        public int GetWQX_PROJECT_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxProject
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateWQX_PROJECT(int? pROJECT_IDX, string oRG_ID, string pROJECT_ID, string pROJECT_NAME, string pROJECT_DESC, string sAMP_DESIGN_TYPE_CD, bool? qAPP_APPROVAL_IND, string qAPP_APPROVAL_AGENCY, string wQX_SUBMIT_STATUS, DateTime? wQX_SUBMIT_DT, bool? aCT_IND, bool? wQX_IND, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxProject a = new TWqxProject();

                if (pROJECT_IDX != null)
                    a = (from c in _db.TWqxProject
                         where c.ProjectIdx == pROJECT_IDX
                         select c).FirstOrDefault();

                if (pROJECT_IDX == null) //insert case
                {
                    a = new TWqxProject();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (pROJECT_ID != null) a.ProjectId = pROJECT_ID;
                if (pROJECT_NAME != null) a.ProjectName = pROJECT_NAME;
                if (pROJECT_DESC != null) a.ProjectDesc = pROJECT_DESC;
                if (sAMP_DESIGN_TYPE_CD != null) a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD;
                if (qAPP_APPROVAL_IND != null) a.QappApprovalInd = qAPP_APPROVAL_IND;
                if (qAPP_APPROVAL_AGENCY != null) a.QappApprovalAgency = qAPP_APPROVAL_AGENCY;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (wQX_SUBMIT_DT != null) a.UpdateDt = wQX_SUBMIT_DT;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxProject.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return a.ProjectIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxProject wqxProject)
        {
            _db.TWqxProject.Update(wqxProject);
            _db.SaveChanges();
        }

    }
}
