using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public int InsertOrUpdateWQX_ACTIVITY(int? aCTIVITY_IDX, string oRG_ID, int? pROJECT_IDX, int? mONLOC_IDX, string aCTIVITY_ID, string aCT_TYPE, string aCT_MEDIA, string aCT_SUBMEDIA, DateTime? aCT_START_DT, DateTime? aCT_END_DT, string aCT_TIME_ZONE, string rELATIVE_DEPTH_NAME, string aCT_DEPTHHEIGHT_MSR, string aCT_DEPTHHEIGHT_MSR_UNIT, string tOP_DEPTHHEIGHT_MSR, string tOP_DEPTHHEIGHT_MSR_UNIT, string bOT_DEPTHHEIGHT_MSR, string bOT_DEPTHHEIGHT_MSR_UNIT, string dEPTH_REF_POINT, string aCT_COMMENT, string bIO_ASSEMBLAGE_SAMPLED, string bIO_DURATION_MSR, string bIO_DURATION_MSR_UNIT, string bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, string bIO_REACH_LEN_MSR, string bIO_REACH_LEN_MSR_UNIT, string bIO_REACH_WID_MSR, string bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT, string bIO_NET_TYPE, string bIO_NET_AREA_MSR, string bIO_NET_AREA_MSR_UNIT, string bIO_NET_MESHSIZE_MSR, string bIO_MESHSIZE_MSR_UNIT, string bIO_BOAT_SPEED_MSR, string bIO_BOAT_SPEED_MSR_UNIT, string bIO_CURR_SPEED_MSR, string bIO_CURR_SPEED_MSR_UNIT, string bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, string sAMP_COLL_EQUIP, string sAMP_COLL_EQUIP_COMMENT, int? sAMP_PREP_IDX, string sAMP_PREP_CONT_TYPE, string sAMP_PREP_CONT_COLOR, string sAMP_PREP_CHEM_PRESERV, string sAMP_PREP_THERM_PRESERV, string sAMP_PREP_STORAGE_DESC, string wQX_SUBMIT_STATUS, bool? aCT_IND, bool? wQX_IND, string cREATE_USER = "system", string eNTRY_TYPE = "C")
        {
            Boolean insInd = false;
            try
            {
                TWqxActivity a = new TWqxActivity();

                if (aCTIVITY_IDX != null)
                    a = (from c in _db.TWqxActivity
                         where c.ActivityIdx == aCTIVITY_IDX
                         select c).FirstOrDefault();
                if (aCTIVITY_IDX == null) //insert case
                {
                    a = new TWqxActivity();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;
                if (pROJECT_IDX != null) a.ProjectIdx = (int)pROJECT_IDX;
                if (aCTIVITY_ID != null) a.ActivityId = aCTIVITY_ID;
                if (aCT_TYPE != null) a.ActType = aCT_TYPE;
                if (aCT_MEDIA != null) a.ActMedia = aCT_MEDIA;
                if (aCT_SUBMEDIA != null) a.ActSubmedia = aCT_SUBMEDIA;
                if (aCT_START_DT != null) a.ActStartDt = (DateTime)aCT_START_DT;
                if (aCT_END_DT != null) a.ActEndDt = (DateTime)aCT_END_DT;
                if (aCT_TIME_ZONE != null) a.ActTimeZone = aCT_TIME_ZONE;
                //put in Timezone if missing
                if (a.ActTimeZone == null)
                    a.ActTimeZone = OpewnWater2.DataAccess.Utils.GetWQXTimeZoneByDate(a.ActStartDt, oRG_ID);

                if (rELATIVE_DEPTH_NAME != null) a.RelativeDepthName = rELATIVE_DEPTH_NAME;
                if (aCT_DEPTHHEIGHT_MSR != null) a.ActDepthheightMsr = aCT_DEPTHHEIGHT_MSR;
                if (aCT_DEPTHHEIGHT_MSR_UNIT != null) a.ActDepthheightMsrUnit = aCT_DEPTHHEIGHT_MSR_UNIT;
                if (tOP_DEPTHHEIGHT_MSR != null) a.TopDepthheightMsr = tOP_DEPTHHEIGHT_MSR;
                if (tOP_DEPTHHEIGHT_MSR_UNIT != null) a.TopDepthheightMsrUnit = tOP_DEPTHHEIGHT_MSR_UNIT;
                if (bOT_DEPTHHEIGHT_MSR != null) a.BotDepthheightMsr = bOT_DEPTHHEIGHT_MSR;
                if (bOT_DEPTHHEIGHT_MSR_UNIT != null) a.BotDepthheightMsrUnit = bOT_DEPTHHEIGHT_MSR_UNIT;
                if (dEPTH_REF_POINT != null) a.DepthRefPoint = dEPTH_REF_POINT;
                if (aCT_COMMENT != null) a.ActComment = aCT_COMMENT;
                if (bIO_ASSEMBLAGE_SAMPLED != null) a.BioAssemblageSampled = bIO_ASSEMBLAGE_SAMPLED;
                if (bIO_DURATION_MSR != null) a.BioDurationMsr = bIO_DURATION_MSR;
                if (bIO_DURATION_MSR_UNIT != null) a.BioDurationMsrUnit = bIO_DURATION_MSR_UNIT;
                if (bIO_SAMP_COMPONENT != null) a.BioSampComponent = bIO_SAMP_COMPONENT;
                if (bIO_SAMP_COMPONENT_SEQ != null) a.BioSampComponentSeq = bIO_SAMP_COMPONENT_SEQ;
                if (bIO_REACH_LEN_MSR != null) a.BioReachLenMsr = bIO_REACH_LEN_MSR;
                if (bIO_REACH_LEN_MSR_UNIT != null) a.BioReachLenMsrUnit = bIO_REACH_LEN_MSR_UNIT;
                if (bIO_REACH_WID_MSR != null) a.BioReachWidMsr = bIO_REACH_WID_MSR;
                if (bIO_REACH_WID_MSR_UNIT != null) a.BioReachWidMsrUnit = bIO_REACH_WID_MSR_UNIT;
                if (bIO_PASS_COUNT != null) a.BioPassCount = bIO_PASS_COUNT;
                if (bIO_NET_TYPE != null) a.BioNetType = bIO_NET_TYPE;
                if (bIO_NET_AREA_MSR != null) a.BioNetAreaMsr = bIO_NET_AREA_MSR;
                if (bIO_NET_AREA_MSR_UNIT != null) a.BioNetAreaMsrUnit = bIO_NET_AREA_MSR_UNIT;
                if (bIO_NET_MESHSIZE_MSR != null) a.BioNetMeshsizeMsr = bIO_NET_MESHSIZE_MSR;
                if (bIO_MESHSIZE_MSR_UNIT != null) a.BioMeshsizeMsrUnit = bIO_MESHSIZE_MSR_UNIT;
                if (bIO_BOAT_SPEED_MSR != null) a.BioBoatSpeedMsr = bIO_BOAT_SPEED_MSR;
                if (bIO_BOAT_SPEED_MSR_UNIT != null) a.BioBoatSpeedMsrUnit = bIO_BOAT_SPEED_MSR_UNIT;
                if (bIO_CURR_SPEED_MSR != null) a.BioCurrSpeedMsr = bIO_CURR_SPEED_MSR;
                if (bIO_CURR_SPEED_MSR_UNIT != null) a.BioCurrSpeedMsrUnit = bIO_CURR_SPEED_MSR_UNIT;
                if (bIO_TOXICITY_TEST_TYPE != null) a.BioToxicityTestType = bIO_TOXICITY_TEST_TYPE;
                if (sAMP_COLL_METHOD_IDX != null) a.SampCollMethodIdx = sAMP_COLL_METHOD_IDX;
                if (sAMP_COLL_EQUIP != null) a.SampCollEquip = sAMP_COLL_EQUIP;
                if (sAMP_COLL_EQUIP_COMMENT != null) a.SampCollEquipComment = sAMP_COLL_EQUIP_COMMENT;
                if (sAMP_PREP_IDX != null) a.SampPrepIdx = sAMP_PREP_IDX;
                if (sAMP_PREP_CONT_TYPE != null) a.SampPrepContType = sAMP_PREP_CONT_TYPE;
                if (sAMP_PREP_CONT_COLOR != null) a.SampPrepContColor = sAMP_PREP_CONT_COLOR;
                if (sAMP_PREP_CHEM_PRESERV != null) a.SampPrepChemPreserv = sAMP_PREP_CHEM_PRESERV;
                if (sAMP_PREP_THERM_PRESERV != null) a.SampPrepThermPreserv = sAMP_PREP_THERM_PRESERV;
                if (sAMP_PREP_STORAGE_DESC != null) a.SampPrepStorageDesc = sAMP_PREP_STORAGE_DESC;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;
                if (eNTRY_TYPE != null) a.EntryType = eNTRY_TYPE;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxActivity.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return a.ActivityIdx;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in the state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }

                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<TWqxRefData> GetT_WQX_REF_DATA_ActivityTypeUsed(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        join b in _db.TWqxActivity on a.Value equals b.ActType
                        where a.Table == "ActivityType"
                        && b.OrgId == OrgID
                        orderby a.Text
                        select a).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxActivity GetWQX_ACTIVITY_ByID(int ActivityIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.ActivityIdx == ActivityIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
