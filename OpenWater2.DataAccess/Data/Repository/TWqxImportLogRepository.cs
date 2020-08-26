﻿using OpenWater2.DataAccess.Data.Repository.IRepository;
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
