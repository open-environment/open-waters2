using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository
{
    class TOeSysLogRepository : Repository<TOeSysLog>, ITOeSysLogRepository
    {
        private readonly ApplicationDbContext _db;
        public TOeSysLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public int InsertT_OE_SYS_LOG(string logType, string logMsg)
        {
            try
            {
                TOeSysLog e = new TOeSysLog();
                e.LogType = logType;
                if (logMsg != null)
                    e.LogMsg = logMsg.SubStringPlus(0, 1999);
                e.LogDt = System.DateTime.Now;

                _db.TOeSysLog.Add(e);
                _db.SaveChanges();
                return e.SysLogId;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> InsertT_OE_SYS_LOGAsync(string logType, string logMsg)
        {
            try
            {
                TOeSysLog e = new TOeSysLog();
                e.LogType = logType;
                if (logMsg != null)
                    e.LogMsg = logMsg.SubStringPlus(0, 1999);
                e.LogDt = System.DateTime.Now;

                _db.TOeSysLog.Add(e);
                await _db.SaveChangesAsync().ConfigureAwait(false);
                return e.SysLogId;
            }
            catch(Exception e)
            {
                return 0;
            }
        }

        public void Update(TOeSysLog oeSysLog)
        {
            try
            {
                _db.TOeSysLog.Update(oeSysLog);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
