using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTemplateRepository : IRepository<TWqxImportTemplate>
    {
        public List<TWqxImportTemplate> GetWQX_IMPORT_TEMPLATE(string OrgID);
        public int DeleteT_WQX_IMPORT_TEMPLATE(int TemplateID);
        public int InsertOrUpdateWQX_IMPORT_TEMPLATE(int? templateId,
                                        string orgId,
                                        string typeCd,
                                        string templateName,
                                        string createUser = "system");
        void Update(TWqxImportTemplate wqxImportTemplate);
    }
}
