using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeUserRoles
    {
        public int UserRoleIdx { get; set; }
        public int UserIdx { get; set; }
        public int RoleIdx { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }

        public virtual TOeRoles RoleIdxNavigation { get; set; }
        public virtual TOeUsers UserIdxNavigation { get; set; }
    }
}
