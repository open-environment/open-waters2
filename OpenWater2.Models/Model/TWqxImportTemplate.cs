using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTemplate
    {
        public TWqxImportTemplate()
        {
            TWqxImportTemplateDtl = new HashSet<TWqxImportTemplateDtl>();
        }

        public int TemplateId { get; set; }
        public string OrgId { get; set; }
        public string TypeCd { get; set; }
        public string TemplateName { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
        public virtual ICollection<TWqxImportTemplateDtl> TWqxImportTemplateDtl { get; set; }
    }
}
