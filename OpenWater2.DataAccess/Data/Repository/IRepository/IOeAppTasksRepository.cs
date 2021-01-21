using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface IOeAppTasksRepository : IRepository<TOeAppTasks>
    {
        public Task<int> UpdateT_OE_APP_TASKSAsync(string taskName, string taskStatus, int? taskFreqMs, string modifyUserId);
        public Task<TOeAppTasks> GetT_OE_APP_TASKS_ByNameAsync(string taskName);
        public void Update(TOeAppTasks oeAppTasks);
    }
}
