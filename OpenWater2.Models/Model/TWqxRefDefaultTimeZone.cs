using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefDefaultTimeZone
    {
        public string TimeZoneName { get; set; }
        public string OfficialTimeZoneName { get; set; }
        public string WqxCodeStandard { get; set; }
        public string WqxCodeDaylight { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }
    }
}
