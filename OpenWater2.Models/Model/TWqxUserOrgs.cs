using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxUserOrgs
    {
        public int UserIdx { get; set; }
        public string OrgId { get; set; }
        public string RoleCd { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }

        public virtual TWqxOrganization Org { get; set; }
        public virtual TOeUsers UserIdxNavigation { get; set; }
    }
}
