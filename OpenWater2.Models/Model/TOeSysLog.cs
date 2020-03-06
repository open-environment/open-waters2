using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeSysLog
    {
        public int SysLogId { get; set; }
        public DateTime LogDt { get; set; }
        public int? LogUseridx { get; set; }
        public string LogType { get; set; }
        public string LogMsg { get; set; }
    }
}
