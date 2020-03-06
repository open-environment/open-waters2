using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxBioHabitatIndex
    {
        public TWqxBioHabitatIndex()
        {
            TWqxActivityMetric = new HashSet<TWqxActivityMetric>();
        }

        public int BioHabitatIndexIdx { get; set; }
        public string OrgId { get; set; }
        public int? MonlocIdx { get; set; }
        public string IndexId { get; set; }
        public string IndexTypeId { get; set; }
        public string IndexTypeIdContext { get; set; }
        public string IndexTypeName { get; set; }
        public string ResourceTitle { get; set; }
        public string ResourceCreator { get; set; }
        public string ResourceSubject { get; set; }
        public string ResourcePublisher { get; set; }
        public DateTime? ResourceDate { get; set; }
        public string ResourceId { get; set; }
        public string IndexTypeScale { get; set; }
        public string IndexScore { get; set; }
        public string IndexQualCd { get; set; }
        public string IndexComment { get; set; }
        public DateTime? IndexCalcDate { get; set; }
        public bool? WqxInd { get; set; }
        public string WqxSubmitStatus { get; set; }
        public DateTime? WqxUpdateDt { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual TWqxMonloc MonlocIdxNavigation { get; set; }
        public virtual TWqxOrganization Org { get; set; }
        public virtual ICollection<TWqxActivityMetric> TWqxActivityMetric { get; set; }
    }
}
