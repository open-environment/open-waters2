using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefDataRepository : Repository<TWqxRefData>, ITWqxRefDataRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefDataRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<TWqxRefAnalMethod> GetAllT_WQX_REF_ANAL_METHOD()
        {
            return _db.TWqxRefAnalMethod.ToList();
        }

        public List<TWqxRefCharacteristic> GetAllT_WQX_REF_CHARACTERISTIC()
        {
            return _db.TWqxRefCharacteristic.ToList();
        }

        public List<TWqxRefData> GetAllT_WQX_REF_DATA()
        {
            return _db.TWqxRefData.ToList();
        }

        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREP()
        {
            return _db.TWqxRefSampPrep.ToList();
        }

        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDandContext(string ID, string Context)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where a.AnalyticMethodId == ID
                        && a.AnalyticMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateT_WQX_REF_ANAL_METHOD(int? aNALYTIC_METHOD_IDX, string aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX, string aNALYTIC_METHOD_NAME, string aNALYTIC_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefAnalMethod a = new TWqxRefAnalMethod();

                if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodIdx == aNALYTIC_METHOD_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefAnalMethod
                         where c.AnalyticMethodIdx == aNALYTIC_METHOD_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == aNALYTIC_METHOD_ID && o.AnalyticMethodCtx == aNALYTIC_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefAnalMethod
                             where c.AnalyticMethodId == aNALYTIC_METHOD_ID
                             && c.AnalyticMethodCtx == aNALYTIC_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (aNALYTIC_METHOD_ID != null) a.AnalyticMethodId = aNALYTIC_METHOD_ID;
                if (aNALYTIC_METHOD_CTX != null) a.AnalyticMethodCtx = aNALYTIC_METHOD_CTX;
                if (aNALYTIC_METHOD_NAME != null) a.AnalyticMethodName = aNALYTIC_METHOD_NAME;
                if (aNALYTIC_METHOD_DESC != null) a.AnalyticMethodDesc = aNALYTIC_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                    _db.TWqxRefAnalMethod.Add(a);

                _db.SaveChanges();
                return a.AnalyticMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(string cHAR_NAME, decimal? dETECT_LIMIT, string dEFAULT_UNIT, bool? uSED_IND, bool aCT_IND, string sAMP_FRAC_REQ, string pICK_LIST)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCharacteristic a = new TWqxRefCharacteristic();

                if (_db.TWqxRefCharacteristic.Any(o => o.CharName == cHAR_NAME))
                {
                    //update case
                    a = (from c in _db.TWqxRefCharacteristic
                         where c.CharName == cHAR_NAME
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.CharName = cHAR_NAME;
                if (dETECT_LIMIT != null) a.DefaultDetectLimit = dETECT_LIMIT;
                if (dEFAULT_UNIT != null) a.DefaultUnit = dEFAULT_UNIT;
                if (uSED_IND != null) a.UsedInd = uSED_IND;
                if (sAMP_FRAC_REQ != null) a.SampFracReq = sAMP_FRAC_REQ;
                if (pICK_LIST != null) a.PickList = pICK_LIST;

                a.UpdateDt = System.DateTime.Now;
                a.ActInd = true;

                if (insInd) //insert case
                {
                    a.UsedInd = false;
                    _db.TWqxRefCharacteristic.Add(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_LAB(int? lAB_IDX, string lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefLab a = new TWqxRefLab();

                if (_db.TWqxRefLab.Any(o => o.LabIdx == lAB_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefLab
                         where c.LabIdx == lAB_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefLab.Any(o => o.LabName == lAB_NAME && o.OrgId == oRG_ID))
                    {
                        //update case
                        a = (from c in _db.TWqxRefLab
                             where c.LabName == lAB_NAME
                             && c.OrgId == oRG_ID
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (lAB_NAME != null) a.LabName = lAB_NAME;
                if (lAB_ACCRED_IND != null) a.LabAccredInd = lAB_ACCRED_IND;
                if (lAB_ACCRED_AUTHORITY != null) a.LabAccredAuthority = lAB_ACCRED_AUTHORITY;
                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxRefLab.Add(a);
                }

                _db.SaveChanges();
                return a.LabIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(int? sAMP_COLL_METHOD_IDX, string sAMP_COLL_METHOD_ID, string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampColMethod a = new TWqxRefSampColMethod();

                if (_db.TWqxRefSampColMethod.Any(o => o.SampCollMethodIdx == sAMP_COLL_METHOD_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampColMethod
                         where c.SampCollMethodIdx == sAMP_COLL_METHOD_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == sAMP_COLL_METHOD_ID && o.AnalyticMethodCtx == sAMP_COLL_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampColMethod
                             where c.SampCollMethodId == sAMP_COLL_METHOD_ID
                             && c.SampCollMethodCtx == sAMP_COLL_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sAMP_COLL_METHOD_ID != null) a.SampCollMethodId = sAMP_COLL_METHOD_ID;
                if (sAMP_COLL_METHOD_CTX != null) a.SampCollMethodCtx = sAMP_COLL_METHOD_CTX;
                if (sAMP_COLL_METHOD_NAME != null) a.SampCollMethodName = sAMP_COLL_METHOD_NAME;
                if (sAMP_COLL_METHOD_DESC != null) a.SampCollMethodDesc = sAMP_COLL_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                    _db.TWqxRefSampColMethod.Add(a);

                _db.SaveChanges();
                return a.SampCollMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_SAMP_PREP(int? sAMP_PREP_IDX, string sAMP_PREP_METHOD_ID, string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampPrep a = new TWqxRefSampPrep();

                if (_db.TWqxRefSampPrep.Any(o => o.SampPrepIdx == sAMP_PREP_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampPrep
                         where c.SampPrepIdx == sAMP_PREP_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == sAMP_PREP_METHOD_ID && o.AnalyticMethodCtx == sAMP_PREP_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampPrep
                             where c.SampPrepMethodId == sAMP_PREP_METHOD_ID
                             && c.SampPrepMethodCtx == sAMP_PREP_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sAMP_PREP_METHOD_ID != null) a.SampPrepMethodId = sAMP_PREP_METHOD_ID;
                if (sAMP_PREP_METHOD_CTX != null) a.SampPrepMethodCtx = sAMP_PREP_METHOD_CTX;
                if (sAMP_PREP_METHOD_NAME != null) a.SampPrepMethodName = sAMP_PREP_METHOD_NAME;
                if (sAMP_PREP_METHOD_DESC != null) a.SampPrepMethodDesc = sAMP_PREP_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                    _db.TWqxRefSampPrep.Add(a);

                _db.SaveChanges();
                return a.SampPrepIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateT_WQX_REF_DATAByIDX(int IDX, string vALUE, string tEXT, bool ActInd)
        {
            try
            {
                TWqxRefData a = new TWqxRefData();
                a = (from c in _db.TWqxRefData
                     where c.RefDataIdx == IDX
                     select c).FirstOrDefault();

                if (vALUE != null) a.Value = vALUE;
                if (tEXT != null) a.Text = Utils.SubStringPlus(tEXT, 0, 200);
                a.UpdateDt = System.DateTime.Now;
                a.ActInd = ActInd;
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        //{
        //    return _db.TWqxOrganization.Select(i => new SelectListItem()
        //    {
        //         Text = i.OrgFormalName,
        //         Value = i.OrgId
        //    });
        //}
        //public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd)
        //{
        //    try
        //    {
        //        return (from a in _db.TWqxUserOrgs
        //                join b in _db.TWqxOrganization on a.OrgId equals b.OrgId
        //                where a.UserIdx == UserIDX
        //                && (excludePendingInd == true ? a.RoleCd != "P" : true)
        //                select b).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public List<VWqxAllOrgs> GetV_WQX_ALL_ORGS()
        //{
        //    try
        //    {
        //        return (from a in _db.VWqxAllOrgs
        //                orderby a.OrgFormalName
        //                select a).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public void Update(TWqxOrganization wqxOrganization)
        //{
        //    TWqxOrganization objFromDb = _db.TWqxOrganization.Where(i => i.OrgId == wqxOrganization.OrgId).FirstOrDefault();
        //    objFromDb.OrgFormalName = wqxOrganization.OrgFormalName;
        //    //TODO: implement rest of the properties
        //    _db.SaveChanges();
        //}
    }
}
