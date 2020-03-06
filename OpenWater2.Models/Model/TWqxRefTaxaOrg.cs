using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefTaxaOrg
    {
        public string BioSubjectTaxonomy { get; set; }
        public string OrgId { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }

        public virtual TWqxOrganization Org { get; set; }
    }
}
