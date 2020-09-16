using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTemplateDtlRepository : IRepository<TWqxImportTemplateDtl>
    {
        public TWqxImportTemplateDtl GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(int TemplateID, string FieldMap);
        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(int TemplateID);
        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_DynamicByTemplateID(int TemplateID);
        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_HardCodeByTemplateID(int TemplateID);
        public int InsertOrUpdateWQX_IMPORT_TEMPLATE_DTL(int? templateDtlId,
                                            int? templateId,
                                            int? colNum,
                                            string fieldMap,
                                            string charName,
                                            string charDefaultUnit,
                                            string createUser = "system",
                                            string charDefaultSampFraction = null);
        public int DeleteT_WQX_IMPORT_TEMPLATE_DTL(int TemplateDtlID);
        public void Update(TWqxImportTemplateDtl wqxImportTemplateDtl);
    }
}
