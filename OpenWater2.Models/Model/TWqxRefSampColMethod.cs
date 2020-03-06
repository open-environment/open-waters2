using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefSampColMethod
    {
        public int SampCollMethodIdx { get; set; }
        public string SampCollMethodId { get; set; }
        public string SampCollMethodCtx { get; set; }
        public string SampCollMethodName { get; set; }
        public string SampCollMethodDesc { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
