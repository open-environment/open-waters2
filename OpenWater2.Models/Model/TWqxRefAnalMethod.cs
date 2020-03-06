using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefAnalMethod
    {
        public TWqxRefAnalMethod()
        {
            TWqxRefCharOrg = new HashSet<TWqxRefCharOrg>();
            TWqxResult = new HashSet<TWqxResult>();
        }

        public int AnalyticMethodIdx { get; set; }
        public string AnalyticMethodId { get; set; }
        public string AnalyticMethodCtx { get; set; }
        public string AnalyticMethodName { get; set; }
        public string AnalyticMethodDesc { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? UpdateDt { get; set; }

        public virtual ICollection<TWqxRefCharOrg> TWqxRefCharOrg { get; set; }
        public virtual ICollection<TWqxResult> TWqxResult { get; set; }
    }
}
