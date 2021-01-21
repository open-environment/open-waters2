using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxMonloc
    {
        public TWqxMonloc()
        {
            TAttainsAssessUnitsMloc = new HashSet<TAttainsAssessUnitsMloc>();
            TWqxActivity = new HashSet<TWqxActivity>();
            TWqxBioHabitatIndex = new HashSet<TWqxBioHabitatIndex>();
        }

        public int MonlocIdx { get; set; }
        public string OrgId { get; set; }
        public string MonlocId { get; set; }
        public string MonlocName { get; set; }
        public string MonlocType { get; set; }
        public string MonlocDesc { get; set; }
        public string HucEight { get; set; }
        public string HucTwelve { get; set; }
        public string TribalLandInd { get; set; }
        public string TribalLandName { get; set; }
        public string LatitudeMsr { get; set; }
        public string LongitudeMsr { get; set; }
        public int? SourceMapScale { get; set; }
        public string HorizAccuracy { get; set; }
        public string HorizAccuracyUnit { get; set; }
        public string HorizCollMethod { get; set; }
        public string HorizRefDatum { get; set; }
        public string VertMeasure { get; set; }
        public string VertMeasureUnit { get; set; }
        public string DrainageArea { get; set; }
        public string DrainageAreaUnit { get; set; }
        public string ContributingDrainageArea { get; set; }
        public string ContributingDrainageAreaUnit { get; set; }

        public string AquiferTypeName { get; set; }
        public string NationalAquiferCode { get; set; }
        public string LocalAquiferCode { get; set; }
        public string LocalAquiferCodeCtx { get; set; }
        public string LocalAquiferDesc { get; set; }
        public DateTime? ConstructionDate { get; set; }
        public string WellDepthMeasure { get; set; }
        public string WellDepthMeasureUnit { get; set; }

        public string VertCollMethod { get; set; }
        public string VertRefDatum { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string CountyCode { get; set; }
        public string WellType { get; set; }
        public string AquiferName { get; set; }
        public string FormationType { get; set; }
        public string WellholeDepthMsr { get; set; }
        public string WellholeDepthMsrUnit { get; set; }
        public bool? WqxInd { get; set; }
        public string WqxSubmitStatus { get; set; }
        public DateTime? WqxUpdateDt { get; set; }
        public string ImportMonlocId { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
        public virtual ICollection<TAttainsAssessUnitsMloc> TAttainsAssessUnitsMloc { get; set; }
        public virtual ICollection<TWqxActivity> TWqxActivity { get; set; }
        public virtual ICollection<TWqxBioHabitatIndex> TWqxBioHabitatIndex { get; set; }
    }
}
