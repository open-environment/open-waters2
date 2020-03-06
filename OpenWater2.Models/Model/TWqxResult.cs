using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxResult
    {
        public int ResultIdx { get; set; }
        public int ActivityIdx { get; set; }
        public string DataLoggerLine { get; set; }
        public string ResultDetectCondition { get; set; }
        public string CharName { get; set; }
        public string MethodSpeciationName { get; set; }
        public string ResultSampFraction { get; set; }
        public string ResultMsr { get; set; }
        public string ResultMsrUnit { get; set; }
        public string ResultMsrQual { get; set; }
        public string ResultStatus { get; set; }
        public string StatisticBaseCode { get; set; }
        public string ResultValueType { get; set; }
        public string WeightBasis { get; set; }
        public string TimeBasis { get; set; }
        public string TempBasis { get; set; }
        public string ParticlesizeBasis { get; set; }
        public string PrecisionValue { get; set; }
        public string BiasValue { get; set; }
        public string ConfidenceIntervalValue { get; set; }
        public string UpperConfidenceLimit { get; set; }
        public string LowerConfidenceLimit { get; set; }
        public string ResultComment { get; set; }
        public string DepthHeightMsr { get; set; }
        public string DepthHeightMsrUnit { get; set; }
        public string Depthaltituderefpoint { get; set; }
        public string ResultSampPoint { get; set; }
        public string BioIntentName { get; set; }
        public string BioIndividualId { get; set; }
        public string BioSubjectTaxonomy { get; set; }
        public string BioUnidentifiedSpeciesId { get; set; }
        public string BioSampleTissueAnatomy { get; set; }
        public string GrpSummCountWeightMsr { get; set; }
        public string GrpSummCountWeightMsrUnit { get; set; }
        public string TaxDtlCellForm { get; set; }
        public string TaxDtlCellShape { get; set; }
        public string TaxDtlHabit { get; set; }
        public string TaxDtlVoltinism { get; set; }
        public string TaxDtlPollTolerance { get; set; }
        public string TaxDtlPollToleranceScale { get; set; }
        public string TaxDtlTrophicLevel { get; set; }
        public string TaxDtlFuncFeedingGroup1 { get; set; }
        public string TaxDtlFuncFeedingGroup2 { get; set; }
        public string TaxDtlFuncFeedingGroup3 { get; set; }
        public string FreqClassCode { get; set; }
        public string FreqClassUnit { get; set; }
        public string FreqClassUpper { get; set; }
        public string FreqClassLower { get; set; }
        public int? AnalyticMethodIdx { get; set; }
        public int? LabIdx { get; set; }
        public DateTime? LabAnalysisStartDt { get; set; }
        public DateTime? LabAnalysisEndDt { get; set; }
        public string LabAnalysisTimezone { get; set; }
        public string ResultLabCommentCode { get; set; }
        public string DetectionLimitType { get; set; }
        public string DetectionLimit { get; set; }
        public string LabTaxonAccredInd { get; set; }
        public string LabTaxonAccredAuthority { get; set; }
        public string LabReportingLevel { get; set; }
        public string Pql { get; set; }
        public string LowerQuantLimit { get; set; }
        public string UpperQuantLimit { get; set; }
        public string DetectionLimitUnit { get; set; }
        public int? LabSampPrepIdx { get; set; }
        public DateTime? LabSampPrepStartDt { get; set; }
        public DateTime? LabSampPrepEndDt { get; set; }
        public string DilutionFactor { get; set; }

        public virtual TWqxActivity ActivityIdxNavigation { get; set; }
        public virtual TWqxRefAnalMethod AnalyticMethodIdxNavigation { get; set; }
        public virtual TWqxRefLab LabIdxNavigation { get; set; }
    }
}
