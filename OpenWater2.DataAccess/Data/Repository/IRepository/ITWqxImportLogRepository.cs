using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportLogRepository : IRepository<TWqxImportLog>
    {
        public int InsertUpdateWQX_IMPORT_LOG(int? importId, string orgId, string typeCd, string fileName, int fileSize, string importStatus, string importProgress,
            string importProgressMessage, byte[] importFile, string userId);
        public int GetWQX_IMPORT_LOG_ProcessingCount();
        public TWqxImportLog GetWQX_IMPORT_LOG_NewActivity();
    }
}
