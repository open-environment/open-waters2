using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefLab
    {
        public TWqxRefLab()
        {
            TWqxResult = new HashSet<TWqxResult>();
        }

        public int LabIdx { get; set; }
        public string OrgId { get; set; }
        public string LabName { get; set; }
        public string LabAccredInd { get; set; }
        public string LabAccredAuthority { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual ICollection<TWqxResult> TWqxResult { get; set; }
    }
}
