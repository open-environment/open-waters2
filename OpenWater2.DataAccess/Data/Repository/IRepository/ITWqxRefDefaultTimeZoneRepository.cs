using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefDefaultTimeZoneRepository : IRepository<TWqxRefDefaultTimeZone>
    {
        public TWqxRefDefaultTimeZone GetT_WQX_REF_DEFAULT_TIME_ZONE_ByName(string TimeZoneName);
        
    }
}
