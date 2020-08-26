using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data
{
    public class WqxImportModel
    {
        public TWqxImportTempMonloc wqxImportTempMonloc { get; set; }
        public TWqxImportTempActivityMetric wqxImportTempActivityMetric { get; set; }
        public TWqxImportTempSample  wqxImportTempSample { get; set; }

    }
}
