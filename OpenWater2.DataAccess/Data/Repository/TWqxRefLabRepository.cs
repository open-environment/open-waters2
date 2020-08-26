using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefLabRepository : Repository<TWqxRefLab>, ITWqxRefLabRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefLabRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TWqxRefLab GetT_WQX_REF_LAB_ByIDandContext(string Name, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxRefLab
                        where a.OrgId == OrgID
                        && a.LabName == Name
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TWqxRefLab wqxRefLab)
        {
            throw new NotImplementedException();
        }
    }
}
