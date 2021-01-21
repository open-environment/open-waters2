using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxActivity
    {
        public TWqxActivity()
        {
            TWqxActivityMetric = new HashSet<TWqxActivityMetric>();
            TWqxResult = new HashSet<TWqxResult>();
        }

        public int ActivityIdx { get; set; }
        public string OrgId { get; set; }
        public int ProjectIdx { get; set; }
        public int? MonlocIdx { get; set; }
        public string ActivityId { get; set; }
        public string ActType { get; set; }
        public string ActMedia { get; set; }
        public string ActSubmedia { get; set; }
        public DateTime ActStartDt { get; set; }
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
        public string BioReachLenMsr { get; set; }
        public string BioReachLenMsrUnit { get; set; }
        public string BioReachWidMsr { get; set; }
        public string BioReachWidMsrUnit { get; set; }
        public int? BioPassCount { get; set; }
        public string BioNetType { get; set; }
        public string BioNetAreaMsr { get; set; }
        public string BioNetAreaMsrUnit { get; set; }
        public string BioNetMeshsizeMsr { get; set; }
        public string BioMeshsizeMsrUnit { get; set; }
        public string BioBoatSpeedMsr { get; set; }
        public string BioBoatSpeedMsrUnit { get; set; }
        public string BioCurrSpeedMsr { get; set; }
        public string BioCurrSpeedMsrUnit { get; set; }
        public string BioToxicityTestType { get; set; }
        public int? SampCollMethodIdx { get; set; }
        public string SampCollEquip { get; set; }
        public string SampCollEquipComment { get; set; }
        public int? SampPrepIdx { get; set; }
        public string SampPrepContType { get; set; }
        public string SampPrepContColor { get; set; }
        public string SampPrepChemPreserv { get; set; }
        public string SampPrepThermPreserv { get; set; }
        public string SampPrepStorageDesc { get; set; }
        public bool? WqxInd { get; set; }
        public string WqxSubmitStatus { get; set; }
        public DateTime? WqxUpdateDt { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }
        public int? TempSampleIdx { get; set; }
        public string EntryType { get; set; }

        public string ActivityIdentifierUserSupplied { get; set; }
        public string SamplingComponentName { get; set; }
        public string ActivityLocationDescriptionText { get; set; }
        public string MeasureValue { get; set; }
        public string GearProcedureUnitCode { get; set; }
        public string HabitatSelectionMethod { get; set; }
        public string MethodName { get; set; }
        public string ThermalPreservativeUsedName { get; set; }
        public string HydrologicCondition { get; set; }
        public string SampleContainerLabelName { get; set; }
        public string HydrologicEvent { get; set; }
        public string HorizCollMethod { get; set; }
        public string HorizCoRefSysDatumName { get; set; }
        public string LatitudeMsr { get; set; }
        public string LongitudeMsr { get; set; }

        public virtual TWqxMonloc MonlocIdxNavigation { get; set; }
        public virtual TWqxOrganization Org { get; set; }
        public virtual TWqxProject ProjectIdxNavigation { get; set; }
        public virtual ICollection<TWqxActivityMetric> TWqxActivityMetric { get; set; }
        public virtual ICollection<TWqxResult> TWqxResult { get; set; }
    }
}
