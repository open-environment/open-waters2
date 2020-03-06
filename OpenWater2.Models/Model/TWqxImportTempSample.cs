using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTempSample
    {
        public TWqxImportTempSample()
        {
            TWqxImportTempResult = new HashSet<TWqxImportTempResult>();
        }

        public int TempSampleIdx { get; set; }
        public string UserId { get; set; }
        public string OrgId { get; set; }
        public int? ProjectIdx { get; set; }
        public string ProjectId { get; set; }
        public int? MonlocIdx { get; set; }
        public string MonlocId { get; set; }
        public int? ActivityIdx { get; set; }
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
        public string SampCollMethodId { get; set; }
        public string SampCollMethodCtx { get; set; }
        public string SampCollMethodName { get; set; }
        public string SampCollEquip { get; set; }
        public string SampCollEquipComment { get; set; }
        public int? SampPrepIdx { get; set; }
        public string SampPrepId { get; set; }
        public string SampPrepCtx { get; set; }
        public string SampPrepName { get; set; }
        public string SampPrepContType { get; set; }
        public string SampPrepContColor { get; set; }
        public string SampPrepChemPreserv { get; set; }
        public string SampPrepThermPreserv { get; set; }
        public string SampPrepStorageDesc { get; set; }
        public string ImportStatusCd { get; set; }
        public string ImportStatusDesc { get; set; }

        public virtual ICollection<TWqxImportTempResult> TWqxImportTempResult { get; set; }
    }
}
