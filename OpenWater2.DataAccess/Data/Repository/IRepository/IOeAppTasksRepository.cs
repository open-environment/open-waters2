using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface IOeAppTasksRepository : IRepository<TOeAppTasks>
    {
        public int UpdateT_OE_APP_TASKS(string taskName, string taskStatus, int? taskFreqMs, string modifyUserId);
        public TOeAppTasks GetT_OE_APP_TASKS_ByName(string taskName);
        public void Update(TOeAppTasks oeAppTasks);
    }
}
