using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeUsers
    {
        public TOeUsers()
        {
            TOeUserRoles = new HashSet<TOeUserRoles>();
            TWqxUserOrgs = new HashSet<TWqxUserOrgs>();
        }

        public int UserIdx { get; set; }
        public string UserId { get; set; }
        public string PwdHash { get; set; }
        public string PwdSalt { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public bool InitalPwdFlag { get; set; }
        public DateTime EffectiveDt { get; set; }
        public DateTime? LastloginDt { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public string DefaultOrgId { get; set; }
        public bool ActInd { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }
        public string ModifyUserid { get; set; }
        public DateTime? ModifyDt { get; set; }

        public virtual ICollection<TOeUserRoles> TOeUserRoles { get; set; }
        public virtual ICollection<TWqxUserOrgs> TWqxUserOrgs { get; set; }
    }
}
