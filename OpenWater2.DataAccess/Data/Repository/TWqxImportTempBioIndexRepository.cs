using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace OpenWater2.DataAccess.Data.Repository
{
    class TWqxImportTempBioIndexRepository : Repository<TWqxImportTempBioIndex>, ITWqxImportTempBioIndexRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportTempBioIndexRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public int DeleteT_WQX_IMPORT_TEMP_BIO_INDEX(string userId)
        {
            try
            {
                _db.TWqxImportTempBioIndex.RemoveRange(
                    _db.TWqxImportTempBioIndex.Where(b => b.UserId == userId));
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public void Update(TWqxImportTempBioIndex wqxImportTempBioIndex)
        {
            throw new NotImplementedException();
        }
    }
}
