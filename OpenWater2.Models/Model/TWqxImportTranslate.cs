using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTranslate
    {
        public int TranslateIdx { get; set; }
        public string OrgId { get; set; }
        public string ColName { get; set; }
        public string DataFrom { get; set; }
        public string DataTo { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
    }
}
