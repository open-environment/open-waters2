using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefCounty
    {
        public string StateCode { get; set; }
        public string CountyCode { get; set; }
        public string CountyName { get; set; }
        public bool? ActInd { get; set; }
        public bool? UsedInd { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
