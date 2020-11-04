using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class GetChartDataModel
    {
        public string orgId { get; set; }
        public string  chartType { get; set; }
        public string charName { get; set; }
        public string charName2 { get; set; }
        public string begDt { get; set; }
        public string endDt { get; set; }
        public List<string> monLoc { get; set; }
        public string decimals { get; set; }
        public string wqxInd { get; set; }
        
    }
}
