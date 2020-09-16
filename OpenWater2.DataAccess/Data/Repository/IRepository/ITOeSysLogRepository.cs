using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeSysLogRepository : IRepository<TOeSysLog>
    {
        public int InsertT_OE_SYS_LOG(string logType, string logMsg);
        public void Update(TOeSysLog oeSysLog);
    }
}
