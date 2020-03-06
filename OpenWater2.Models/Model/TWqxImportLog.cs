using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportLog
    {
        public int ImportId { get; set; }
        public string OrgId { get; set; }
        public string TypeCd { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string ImportStatus { get; set; }
        public string ImportProgress { get; set; }
        public string ImportProgressMsg { get; set; }
        public byte[] ImportFile { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
    }
}
