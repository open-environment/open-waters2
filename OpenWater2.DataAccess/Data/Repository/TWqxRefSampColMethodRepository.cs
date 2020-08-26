using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefSampColMethodRepository : Repository<TWqxRefSampColMethod>, ITWqxRefSampColMethodRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefSampColMethodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(string ID, string Context)
        {
            try
            {
                return (from a in _db.TWqxRefSampColMethod
                        where a.SampCollMethodId == ID
                        && a.SampCollMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(int? IDX)
        {
            try
            {
                return (from a in _db.TWqxRefSampColMethod
                        where a.SampCollMethodIdx == IDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(int? sampCollMehtodIdx, string sampCollMethodId, 
            string sampCollMethodCtx, string sampCollMethodName, 
            string sampCollMethodDesc, bool actInd)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampColMethod a = new TWqxRefSampColMethod();

                if (_db.TWqxRefSampColMethod.Any(o => o.SampCollMethodIdx == sampCollMehtodIdx))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampColMethod
                         where c.SampCollMethodIdx == sampCollMehtodIdx
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(
                        o => o.AnalyticMethodId == sampCollMethodId 
                        && o.AnalyticMethodCtx == sampCollMethodCtx))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampColMethod
                             where c.SampCollMethodId == sampCollMethodId
                             && c.SampCollMethodCtx == sampCollMethodCtx
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sampCollMethodId != null) a.SampCollMethodId = sampCollMethodId;
                if (sampCollMethodCtx != null) a.SampCollMethodCtx = sampCollMethodCtx;
                if (sampCollMethodName != null) a.SampCollMethodName = sampCollMethodName;
                if (sampCollMethodDesc != null) a.SampCollMethodDesc = sampCollMethodDesc;
                if (actInd != null) a.ActInd = actInd;

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

        public void Update(TWqxRefSampColMethod wqxRefSampColMethod)
        {
            throw new NotImplementedException();
        }
    }
}
