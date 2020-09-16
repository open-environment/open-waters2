using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxPendingRecordsRepository : IRepository<VWqxPendingRecords>
    {
        public List<VWqxPendingRecords> GetV_WQX_PENDING_RECORDS(string orgId, DateTime? startDate, DateTime? endDate);
    }
}
