using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempBioIndexRepository : IRepository<TWqxImportTempBioIndex>
    {
        public int DeleteT_WQX_IMPORT_TEMP_BIO_INDEX(string userId);
        public void Update(TWqxImportTempBioIndex wqxImportTempBioIndex);
    }
}
