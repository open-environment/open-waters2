using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTemplateDtlRepository : IRepository<TWqxImportTemplateDtl>
    {
        public TWqxImportTemplateDtl GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(int TemplateID, string FieldMap);
        List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(int TemplateID);
        public void Update(TWqxImportTemplateDtl wqxImportTemplateDtl);
    }
}
