using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTranslateRepository : IRepository<TWqxImportTranslate>
    {
        public string GetWQX_IMPORT_TRANSLATE_byColNameAndValue(string OrgID, string ColName, string Value);
        public List<string> GetWQX_IMPORT_TRANSLATE_byColName(string OrgID);
        void Update(TWqxImportTranslate wqxImportTranslate);
    }
}
