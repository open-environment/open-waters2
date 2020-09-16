using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    class TWqxPendingRecordsRepository : Repository<VWqxPendingRecords>, ITWqxPendingRecordsRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxPendingRecordsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public List<VWqxPendingRecords> GetV_WQX_PENDING_RECORDS(string orgId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                return (from a in _db.VWqxPendingRecords
                        where (orgId != null ? a.OrgId == orgId : true)
                        && (startDate != null ? a.UpdateDt >= startDate : true)
                        && (endDate != null ? a.UpdateDt <= endDate : true)
                        orderby a.TableCd, a.UpdateDt
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
