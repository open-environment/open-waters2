using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTempActivityMetric
    {
        public int TempActivityMetricIdx { get; set; }
        public string UserId { get; set; }
        public string OrgId { get; set; }
        public int? ActivityIdx { get; set; }
        public string ActivityId { get; set; }
        public string MetricTypeId { get; set; }
        public string MetricTypeIdContext { get; set; }
        public string MetricTypeName { get; set; }
        public string MetricScale { get; set; }
        public string MetricFormulaDesc { get; set; }
        public string MetricValueMsr { get; set; }
        public string MetricValueMsrUnit { get; set; }
        public string MetricScore { get; set; }
        public string MetricComment { get; set; }
        public int? TempBioHabitatIndexIdx { get; set; }
        public string ImportStatusCd { get; set; }
        public string ImportStatusDesc { get; set; }
    }
}
