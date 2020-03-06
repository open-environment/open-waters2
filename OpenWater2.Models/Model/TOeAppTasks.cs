using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeAppTasks
    {
        public int TaskIdx { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public string TaskStatus { get; set; }
        public int TaskFreqMs { get; set; }
        public string ModifyUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
    }
}
