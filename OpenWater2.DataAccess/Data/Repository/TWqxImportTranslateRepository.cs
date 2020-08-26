using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public class TWqxImportTranslateRepository : Repository<TWqxImportTranslate>, ITWqxImportTranslateRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportTranslateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public List<string> GetWQX_IMPORT_TRANSLATE_byColName(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTranslate
                        where a.OrgId == OrgID
                        select a.ColName).Distinct().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetWQX_IMPORT_TRANSLATE_byColNameAndValue(string OrgID, string ColName, string Value)
        {
            try
            {
                var xxx = (from a in _db.TWqxImportTranslate
                           where a.OrgId == OrgID
                           && a.ColName == ColName
                           && a.DataFrom == Value
                           select a).FirstOrDefault();

                return xxx != null ? xxx.DataTo : Value;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Update(TWqxImportTranslate wqxImportTranslate)
        {
            throw new NotImplementedException();
        }
    }
}
