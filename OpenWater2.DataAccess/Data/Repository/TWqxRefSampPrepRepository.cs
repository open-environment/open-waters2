using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpenWater2.Models.Model;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefSampPrepRepository : Repository<TWqxRefSampPrep>, ITWqxRefSampPrepRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefSampPrepRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TWqxRefSampPrep GetT_WQX_REF_SAMP_PREP_ByIDandContext(string ID, string Context)
        {
            try
            {
                return (from a in _db.TWqxRefSampPrep
                        where a.SampPrepMethodId == ID
                        && a.SampPrepMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TWqxRefSampPrep wqxRefSampPrep)
        {
            throw new NotImplementedException();
        }
    }
}
