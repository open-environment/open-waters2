using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxActivityMetric
    {
        public int ActivityMetricIdx { get; set; }
        public int ActivityIdx { get; set; }
        public string MetricTypeId { get; set; }
        public string MetricTypeIdContext { get; set; }
        public string MetricTypeName { get; set; }
        public string CitationTitle { get; set; }
        public string CitationCreator { get; set; }
        public string CitationSubject { get; set; }
        public string CitationPublisher { get; set; }
        public DateTime? CitationDate { get; set; }
        public string CitationId { get; set; }
        public string MetricScale { get; set; }
        public string MetricFormulaDesc { get; set; }
        public string MetricValueMsr { get; set; }
        public string MetricValueMsrUnit { get; set; }
        public string MetricScore { get; set; }
        public string MetricComment { get; set; }
        public int? BioHabitatIndexIdx { get; set; }
        public bool? WqxInd { get; set; }
        public string WqxSubmitStatus { get; set; }
        public DateTime? WqxUpdateDt { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual TWqxActivity ActivityIdxNavigation { get; set; }
        public virtual TWqxBioHabitatIndex BioHabitatIndexIdxNavigation { get; set; }
    }
}
