using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeSysLogRepository : IRepository<TOeSysLog>
    {
        public Task<int> InsertT_OE_SYS_LOGAsync(string logType, string logMsg);
        public int InsertT_OE_SYS_LOG(string logType, string logMsg);
        public void Update(TOeSysLog oeSysLog);
    }
}
