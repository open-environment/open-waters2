using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class ImportSampleResultDisplay
    {
        public int TempSampleIdx { get; set; }
        public string OrgId { get; set; }
        public string ProjectId { get; set; }
        public string MonlocId { get; set; }
        public string ActivityId { get; set; }
        public string ActType { get; set; }
        public string ActMedia { get; set; }
        public string ActSubmedia { get; set; }
        public DateTime? ActStartDt { get; set; }
        public DateTime? ActEndDt { get; set; }
        public string ActTimeZone { get; set; }
        public string RelativeDepthName { get; set; }
        public string ActDepthheightMsr { get; set; }
        public string ActDepthheightMsrUnit { get; set; }
        public string TopDepthheightMsr { get; set; }
        public string TopDepthheightMsrUnit { get; set; }
        public string BotDepthheightMsr { get; set; }
        public string BotDepthheightMsrUnit { get; set; }
        public string DepthRefPoint { get; set; }
        public string ActComment { get; set; }
        public string BioAssemblageSampled { get; set; }
        public string BioDurationMsr { get; set; }
        public string BioDurationMsrUnit { get; set; }
        public string BioSampComponent { get; set; }
        public int? BioSampComponentSeq { get; set; }
        public string SampCollMethodId { get; set; }
        public string SampCollMethodCtx { get; set; }
        public string SampCollEquip { get; set; }
        public string SampCollEquipComment { get; set; }
        public string SampPrepId { get; set; }
        public string SampPrepCtx { get; set; }

        public int? TempResultIdx { get; set; }
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
        public string ResultComment { get; set; }
        public string RES_DEPTH_HEIGHT_MSG { get; set; }
        public string RES_DEPTH_HEIGHT_MSR_UNIT { get; set; }

        public string BioIntentName { get; set; }
        public string BioIndividualId { get; set; }
        public string BioSubjectTaxonomy { get; set; }
        public string BioUnidentifiedSpeciesId { get; set; }
        public string BioSampleTissueAnatomy { get; set; }
        public string GrpSummCountWeightMsr { get; set; }
        public string GrpSummCountWeightMsrUnit { get; set; }
        public string FreqClassCode { get; set; }
        public string FreqClassUnit { get; set; }
        public string AnalyticMethodId { get; set; }
        public string AnalyticMethodCtx { get; set; }
        public string LabName { get; set; }
        public DateTime? LabAnalysisStartDt { get; set; }
        public DateTime? LabAnalysisEndDt { get; set; }
        public string ResultLabCommentCode { get; set; }
        public string MethodDetectionLevel { get; set; }
        public string LabReportingLevel { get; set; }
        public string Pql { get; set; }
        public string LowerQuantLimit { get; set; }
        public string UpperQuantLimit { get; set; }
        public string DetectionLimitUnit { get; set; }
        public DateTime? LabSampPrepStartDt { get; set; }
        public string DilutionFactor { get; set; }
        public string ImportStatusCd { get; set; }
        public string ImportStatusDesc { get; set; }
    }
}
