using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefCharacteristic
    {
        public TWqxRefCharacteristic()
        {
            TWqxRefCharLimits = new HashSet<TWqxRefCharLimits>();
            TWqxRefCharOrg = new HashSet<TWqxRefCharOrg>();
        }

        public string CharName { get; set; }
        public decimal? DefaultDetectLimit { get; set; }
        public string DefaultUnit { get; set; }
        public bool? UsedInd { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string SampFracReq { get; set; }
        public string PickList { get; set; }
        // public string MethSpecReq { get; set; }
        public virtual ICollection<TWqxRefCharLimits> TWqxRefCharLimits { get; set; }
        public virtual ICollection<TWqxRefCharOrg> TWqxRefCharOrg { get; set; }
    }
}
