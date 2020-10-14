using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportLogRepository : Repository<TWqxImportLog>, ITWqxImportLogRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_WQX_IMPORT_LOG(int importId)
        {
            try
            {
                TWqxImportLog wqxImportLog = _db.TWqxImportLog.Where(i => i.ImportId == importId).FirstOrDefault();
                if(wqxImportLog != null)
                {
                    _db.TWqxImportLog.Remove(wqxImportLog);
                    _db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public List<TWqxImportLog> GetWQX_IMPORT_LOG(string OrgID)
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.OrgId == OrgID
                        select i).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxImportLog GetWQX_IMPORT_LOG_NewActivity()
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.ImportStatus == "New"
                        && i.TypeCd == "Sample"
                        select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetWQX_IMPORT_LOG_ProcessingCount()
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.ImportStatus == "Processing"
                        && i.TypeCd == "Sample"
                        select i).Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertUpdateWQX_IMPORT_LOG(int? importId, string orgId, string typeCd, string fileName, int fileSize, string importStatus, string importProgress, string importProgressMessage, byte[] importFile, string userId)
        {
            try
            {
                TWqxImportLog t = new TWqxImportLog();
                if (importId != null)
                    t = (from c in _db.TWqxImportLog
                         where c.ImportId == importId
                         select c).First();

                if (importId == null)
                    t = new TWqxImportLog();

                if (orgId != null) t.OrgId = orgId;
                if (typeCd != null) t.TypeCd = typeCd.Substring(0, 5);
                if (fileName != null) t.FileName = fileName;
                t.FileSize = fileSize;
                if (importStatus != null) t.ImportStatus = importStatus;
                if (importProgress != null) t.ImportProgress = importProgress;
                if (importProgressMessage != null) t.ImportProgressMsg = importProgressMessage;
                if (importFile != null) t.ImportFile = importFile;
                if (userId != null) t.CreateUserid = userId;

                if (importId == null) //insert case
                {
                    t.CreateDt = DateTime.Now;
                    _db.TWqxImportLog.Add(t);
                }
                else
                {
                }

                _db.SaveChanges();

                return t.ImportId;
            }
            catch
            {
                return 0;
            }
        }
    }
}
