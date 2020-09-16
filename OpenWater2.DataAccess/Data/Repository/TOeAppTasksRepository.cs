using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TOeAppTasksRepository : Repository<TOeAppTasks>, IOeAppTasksRepository
    {
        private readonly ApplicationDbContext _db;
        public TOeAppTasksRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TOeAppTasks GetT_OE_APP_TASKS_ByName(string taskName)
        {
            try
            {
                return (from a in _db.TOeAppTasks
                        where a.TaskName == taskName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TOeAppTasks oeAppTasks)
        {
            try
            {
                if(oeAppTasks != null)
                {
                    _db.TOeAppTasks.Update(oeAppTasks);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateT_OE_APP_TASKS(string taskName, string taskStatus, int? taskFreqMs, string modifyUserId)
        {
            try
            {
                TOeAppTasks t = new TOeAppTasks();
                t = (from c in _db.TOeAppTasks
                     where c.TaskName == taskName
                     select c).First();

                if (taskStatus != null) t.TaskStatus = taskStatus;
                if (taskFreqMs != null) t.TaskFreqMs = (int)taskFreqMs;
                if (modifyUserId != null) t.ModifyUserid = modifyUserId;
                t.ModifyDt = System.DateTime.Now;
                _db.SaveChanges();

                return t.TaskIdx;
            }
            catch
            {
                return 0;
            }
        }
    }
}
