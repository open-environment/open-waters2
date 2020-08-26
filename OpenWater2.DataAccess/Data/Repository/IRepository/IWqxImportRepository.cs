using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface IWqxImportRepository : IRepository<WqxImportModel>
    {
        public string ProcessImport(int useridx, string orgId,
            string importType, string importData, string templatInd,
            int projectId, string projectName,
            int templateId, string template, string configFilePath);
    }
    
}
