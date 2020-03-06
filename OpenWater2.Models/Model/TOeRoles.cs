using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeRoles
    {
        public TOeRoles()
        {
            TOeUserRoles = new HashSet<TOeUserRoles>();
        }

        public int RoleIdx { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }
        public string ModifyUserid { get; set; }
        public DateTime? ModifyDt { get; set; }

        public virtual ICollection<TOeUserRoles> TOeUserRoles { get; set; }
    }
}
