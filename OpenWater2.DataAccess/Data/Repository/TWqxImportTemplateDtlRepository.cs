using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTemplateDtlRepository : Repository<TWqxImportTemplateDtl>, ITWqxImportTemplateDtlRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportTemplateDtlRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public TWqxImportTemplateDtl GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(int TemplateID, string FieldMap)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == FieldMap
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == "CHAR"
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TWqxImportTemplateDtl wqxImportTemplateDtl)
        {
            throw new NotImplementedException();
        }
    }
}
