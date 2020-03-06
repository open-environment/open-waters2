using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssess
    {
        public TAttainsAssess()
        {
            TAttainsAssessCause = new HashSet<TAttainsAssessCause>();
            TAttainsAssessUse = new HashSet<TAttainsAssessUse>();
        }

        public int AttainsAssessIdx { get; set; }
        public string ReportingCycle { get; set; }
        public string ReportStatus { get; set; }
        public int AttainsAssessUnitIdx { get; set; }
        public string AgencyCode { get; set; }
        public string CycleLastAssessed { get; set; }
        public string CycleLastMonitored { get; set; }
        public string TrophicStatusCode { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsAssessUnits AttainsAssessUnitIdxNavigation { get; set; }
        public virtual ICollection<TAttainsAssessCause> TAttainsAssessCause { get; set; }
        public virtual ICollection<TAttainsAssessUse> TAttainsAssessUse { get; set; }
    }
}
