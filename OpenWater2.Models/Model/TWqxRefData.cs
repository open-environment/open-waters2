using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefData
    {
        public int RefDataIdx { get; set; }
        public string Table { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public bool? ActInd { get; set; }
        public bool? UsedInd { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
