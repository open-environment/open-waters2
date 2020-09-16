using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefDefaultTimeZoneRepository : Repository<TWqxRefDefaultTimeZone>, ITWqxRefDefaultTimeZoneRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefDefaultTimeZoneRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TWqxRefDefaultTimeZone GetT_WQX_REF_DEFAULT_TIME_ZONE_ByName(string TimeZoneName)
        {
            try
            {
                return (from a in _db.TWqxRefDefaultTimeZone
                        where a.TimeZoneName == TimeZoneName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
