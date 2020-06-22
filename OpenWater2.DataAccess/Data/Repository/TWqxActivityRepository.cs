using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxActivityRepository : Repository<TWqxActivity>, ITWqxActivityRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxActivityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTWqxActvityForDropDown()
        {
            throw new NotImplementedException();
        }

        public int GetT_WQX_RESULTCount(string OrgID)
        {
            try
            {
                return (from r in _db.TWqxResult
                        join a in _db.TWqxActivity on r.ActivityIdx equals a.ActivityIdx
                        where a.OrgId == OrgID
                        select r).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxActivity> GetWQX_ACTIVITY(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where (ActInd ? a.ActInd == true : true)
                        && a.OrgId == OrgID
                        && (WQXPending ? a.WqxSubmitStatus == "U" : true)
                        && (WQXPending ? a.WqxInd == true : true)
                        && (MonLocIDX == null ? true : a.MonlocIdx == MonLocIDX)
                        && (startDt == null ? true : a.ActStartDt >= startDt)
                        && (endDt == null ? true : a.ActStartDt <= endDt)
                        && (ActType == null ? true : a.ActType == ActType)
                        && (ProjectIDX == null ? true : a.ProjectIdx == ProjectIDX)
                        orderby a.ActEndDt descending
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetWQX_ACTIVITY_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TWqxActivity wqxActivity)
        {
            throw new NotImplementedException();
        }
    }
}
