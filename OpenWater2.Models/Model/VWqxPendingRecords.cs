using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class VWqxPendingRecords
    {
        public int RecIdx { get; set; }
        public string TableCd { get; set; }
        public string RecId { get; set; }
        public string OrgId { get; set; }
        public string UpdateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
    }
}
