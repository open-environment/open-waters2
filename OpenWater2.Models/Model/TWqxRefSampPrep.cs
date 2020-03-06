using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefSampPrep
    {
        public int SampPrepIdx { get; set; }
        public string SampPrepMethodId { get; set; }
        public string SampPrepMethodCtx { get; set; }
        public string SampPrepMethodName { get; set; }
        public string SampPrepMethodDesc { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
