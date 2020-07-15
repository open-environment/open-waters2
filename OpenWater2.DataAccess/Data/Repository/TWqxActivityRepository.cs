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

        public int DeleteT_WQX_ACTIVITY(int ActivityIDX, string UserID)
        {
            try
            {
                TWqxActivity a = _db.TWqxActivity.Where(x => x.ActivityIdx == ActivityIDX).FirstOrDefault();
                if (a != null)
                {
                    if (a.ActInd == false && (a.WqxInd == false || a.WqxSubmitStatus != "U"))
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is not pending ("U")
                        _db.TWqxActivity.Remove(a);
                        _db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        UpdateWQX_ACTIVITY_WQXStatus(ActivityIDX, "U", false, null, UserID);
                        return 1;
                    }

                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
        public int UpdateWQX_ACTIVITY_WQXStatus(global::System.Int32? aCTIVITY_IDX, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            try
            {
                TWqxActivity a = (from c in _db.TWqxActivity
                                    where c.ActivityIdx == aCTIVITY_IDX
                                    select c).FirstOrDefault();

                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;
                a.UpdateUserid = cREATE_USER.ToUpper();
                a.UpdateDt = System.DateTime.Now;

                _db.SaveChanges();

                return a.ActivityIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
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

        public List<ActivityListDisplay> GetWQX_ACTIVITYDisplay(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX, string WQXStatus)
        {
            try
            {
                var query = (from a in _db.TWqxActivity
                             join p in _db.TWqxProject on a.ProjectIdx equals p.ProjectIdx
                             join m in _db.TWqxMonloc on a.MonlocIdx equals m.MonlocIdx
                             where (ActInd ? a.ActInd == true : true)
                             && a.OrgId == OrgID
                             && (WQXPending ? a.WqxSubmitStatus == "U" : true)
                             && (WQXPending ? a.WqxInd == true : true)
                             && (MonLocIDX == null ? true : a.MonlocIdx == MonLocIDX)
                             && (startDt == null ? true : a.ActStartDt >= startDt)
                             && (endDt == null ? true : a.ActStartDt <= endDt)
                             && (ActType == null ? true : a.ActType == ActType)
                             && (ProjectIDX == null ? true : a.ProjectIdx == ProjectIDX)
                             && (WQXStatus == "" ? true : (a.WqxInd == true && a.WqxSubmitStatus == WQXStatus))
                             orderby a.ActStartDt descending, a.ActivityIdx descending
                             select new ActivityListDisplay
                             {
                                 ACTIVITY_IDX = a.ActivityIdx,
                                 ORG_ID = a.OrgId,
                                 PROJECT_ID = p.ProjectId,
                                 MONLOC_ID = m.MonlocId,
                                 ACTIVITY_ID = a.ActivityId,
                                 ACT_TYPE = a.ActType,
                                 ACT_MEDIA = a.ActMedia,
                                 ACT_SUBMEDIA = a.ActSubmedia,
                                 ACT_START_DT = a.ActStartDt,
                                 ACT_END_DT = a.ActEndDt,
                                 ACT_DEPTHHEIGHT_MSR = a.ActDepthheightMsr,
                                 ACT_DEPTHHEIGHT_MSR_UNIT = a.ActDepthheightMsrUnit,
                                 TOP_DEPTHHEIGHT_MSR = a.TopDepthheightMsr,
                                 BOT_DEPTHHEIGHT_MSR = a.BotDepthheightMsr,
                                 DEPTH_REF_POINT = a.DepthRefPoint,
                                 ACT_COMMENT = a.ActComment,
                                 SAMP_COLL_METHOD = null,
                                 SAMP_COLL_EQUIP = a.SampCollEquip,
                                 SAMP_COLL_EQUIP_COMMENT = a.SampCollEquipComment,
                                 SAMP_PREP_METHOD = null,
                                 WQX_IND = a.WqxInd,
                                 WQX_SUBMIT_STATUS = a.WqxSubmitStatus,
                                 ACT_IND = a.ActInd
                             }).ToList();
                return query;
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
