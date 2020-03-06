using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class VWqxActivityLatest
    {
        public int? ActivityIdx { get; set; }
        public string OrgId { get; set; }
        public int? ProjectIdx { get; set; }
        public int? MonlocIdx { get; set; }
        public string MonlocName { get; set; }
        public string ActivityId { get; set; }
        public string ActType { get; set; }
        public DateTime? ActStartDt { get; set; }
        public bool? WqxInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public string ActComment { get; set; }
        public string AlkalinityTotal { get; set; }
        public string Ammonia { get; set; }
        public string DissolvedOxygenDo { get; set; }
        public string EscherichiaColi { get; set; }
        public string Nitrate { get; set; }
        public string Nitrite { get; set; }
        public string PH { get; set; }
        public string Phosphorus { get; set; }
        public string Salinity { get; set; }
        public string SpecificConductance { get; set; }
        public string TemperatureAir { get; set; }
        public string TemperatureWater { get; set; }
        public string TotalDissolvedSolids { get; set; }
        public string Turbidity { get; set; }
    }
}
