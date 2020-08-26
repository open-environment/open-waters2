using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefAnalMethodRepository : Repository<TWqxRefAnalMethod>, ITWqxRefAnalMethodRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefAnalMethodRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDX(int IDX)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where a.AnalyticMethodIdx == IDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TWqxRefAnalMethod wqxRefAnalMethod)
        {
            throw new NotImplementedException();
        }
    }
}
