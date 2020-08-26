using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxMonLocRepository : Repository<TWqxMonloc>, ITWqxMonLocRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxMonLocRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_WQX_MONLOC(int monLocIDX, string UserID)
        {
            try
            {
                TWqxMonloc m = GetWQX_MONLOC_ByID(monLocIDX);
                if (m != null)
                {
                    if (m.WqxSubmitStatus == "Y" && m.ActInd == false)
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is passed ("Y")
                        //string sql = "DELETE FROM T_WQX_MONLOC WHERE MONLOC_IDX = " + monLocIDX;
                        //_db.ExecuteStoreCommand(sql);
                        TWqxMonloc entityToRemove = _db.TWqxMonloc.Where(i => i.MonlocIdx == monLocIDX).FirstOrDefault();
                        if(entityToRemove != null)
                        {
                            _db.TWqxMonloc.Remove(entityToRemove);
                            _db.SaveChanges();
                        }
                        return 1;
                    }

                    //if there are any activities for this monitoring location, don't delete becuase this would cause WQX to delete all activities for this mon loc.
                    int iActCount = GetWQX_ACTIVITYByMonLocID(monLocIDX);
                    if (iActCount > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        InsertOrUpdateWQX_MONLOC(monLocIDX, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "U", null, false, null, UserID);
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

        public IEnumerable<SelectListItem> GetTWqxMonLocForDropDown()
        {
            return _db.TWqxMonloc.Select(i => new SelectListItem()
            {
                Text = i.MonlocName,
                Value = i.MonlocId
            });
        }

        public bool GetT_WQX_MONLOC_PendingInd(string OrgID)
        {
            try
            {
                if (_db.TWqxMonloc.Any(u => u.OrgId == OrgID && u.WqxSubmitStatus == "U" && u.WqxInd == true))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetWQX_ACTIVITYByMonLocID(int monLocIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.MonlocIdx == monLocIDX
                        && a.ActInd == true
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxMonloc> GetWQX_MONLOC(bool ActInd, string OrgID, bool? WQXPending)
        {
            if (WQXPending == false) WQXPending = null;
            try
            {
                return (from a in _db.TWqxMonloc
                        where (ActInd ? a.ActInd == true : true)
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        && (OrgID == null ? true : a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxMonloc GetWQX_MONLOC_ByID(int monLocIDX)
        {
            return _db.TWqxMonloc.Where(i => i.MonlocIdx == monLocIDX).FirstOrDefault();
        }

        public int InsertOrUpdateWQX_MONLOC(int? mONLOC_IDX, string oRG_ID, string mONLOC_ID, string mONLOC_NAME, string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND, string tRIBAL_LAND_NAME, string lATITUDE_MSR, string lONGITUDE_MSR, int? sOURCE_MAP_SCALE, string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM, string vERT_MEASURE, string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM, string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE, string aQUIFER_NAME, string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string wQX_SUBMIT_STATUS, DateTime? wQXUpdateDate, bool? aCT_IND, bool? wQX_IND, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxMonloc a = new TWqxMonloc();

                if (mONLOC_IDX != null)
                    a = (from c in _db.TWqxMonloc
                         where c.MonlocIdx == mONLOC_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (a == null) //insert case
                {
                    a = new TWqxMonloc();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_ID != null) a.MonlocId = mONLOC_ID;
                if (mONLOC_NAME != null) a.MonlocName = mONLOC_NAME;
                if (mONLOC_TYPE != null) a.MonlocType = mONLOC_TYPE;
                if (mONLOC_DESC != null) a.MonlocDesc = mONLOC_DESC;
                if (hUC_EIGHT != null) a.HucEight = hUC_EIGHT;
                if (HUC_TWELVE != null) a.HucTwelve = HUC_TWELVE;
                if (tRIBAL_LAND_IND != null) a.TribalLandInd = tRIBAL_LAND_IND;
                if (tRIBAL_LAND_NAME != null) a.TribalLandName = tRIBAL_LAND_NAME;
                if (lATITUDE_MSR != null) a.LatitudeMsr = lATITUDE_MSR;
                if (lONGITUDE_MSR != null) a.LongitudeMsr = lONGITUDE_MSR;
                if (sOURCE_MAP_SCALE != null) a.SourceMapScale = sOURCE_MAP_SCALE;
                if (hORIZ_ACCURACY != null) a.HorizAccuracy = hORIZ_ACCURACY;
                if (hORIZ_ACCURACY_UNIT != null) a.HorizAccuracyUnit = hORIZ_ACCURACY_UNIT;
                if (hORIZ_COLL_METHOD != null) a.HorizCollMethod = hORIZ_COLL_METHOD;
                if (hORIZ_REF_DATUM != null) a.HorizRefDatum = hORIZ_REF_DATUM;
                if (vERT_MEASURE != null) a.VertMeasure = vERT_MEASURE;
                if (vERT_MEASURE_UNIT != null) a.VertMeasureUnit = vERT_MEASURE_UNIT;
                if (vERT_COLL_METHOD != null) a.VertCollMethod = vERT_COLL_METHOD;
                if (vERT_REF_DATUM != null) a.VertRefDatum = vERT_REF_DATUM;
                if (cOUNTRY_CODE != null) a.CountryCode = cOUNTRY_CODE;
                if (sTATE_CODE != null) a.StateCode = sTATE_CODE;
                if (cOUNTY_CODE != null) a.CountyCode = cOUNTY_CODE;

                if (wELL_TYPE != null) a.WellType = wELL_TYPE;
                if (aQUIFER_NAME != null) a.AquiferName = aQUIFER_NAME;
                if (fORMATION_TYPE != null) a.FormationType = fORMATION_TYPE;
                if (wELLHOLE_DEPTH_MSR != null) a.WellholeDepthMsr = wELLHOLE_DEPTH_MSR;
                if (wELLHOLE_DEPTH_MSR_UNIT != null) a.WellholeDepthMsrUnit = wELLHOLE_DEPTH_MSR_UNIT;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxMonloc.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                }

                _db.SaveChanges();

                return a.MonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxMonloc wqxMonloc)
        {
            _db.TWqxMonloc.Update(wqxMonloc);
            _db.SaveChanges();
        }

        public TWqxUserOrgs GetWQX_USER_ORGS_ByUserIDX_OrgID(int UserIDX, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxUserOrgs
                        where a.UserIdx == UserIDX
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetWQX_MONLOC_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxMonloc> GetWQX_MONLOC_ByOrgID(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where (a.ActInd == true)
                        && (a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public TWqxMonloc GetWQX_MONLOC_ByIDString(string orgID, string MonLocID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where a.MonlocId == MonLocID
                        && a.OrgId == orgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
