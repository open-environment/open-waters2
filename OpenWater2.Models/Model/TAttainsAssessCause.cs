using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssessCause
    {
        public int AttainsAssessCauseIdx { get; set; }
        public int AttainsAssessIdx { get; set; }
        public string CauseName { get; set; }
        public string PollutantInd { get; set; }
        public string AgencyCode { get; set; }
        public string CycleFirstListed { get; set; }
        public string CycleSchedTmdl { get; set; }
        public string TmdlPriorityName { get; set; }
        public string ConsentDecreeCycle { get; set; }
        public string TmdlCauseReportId { get; set; }
        public string CycleExpectedAttain { get; set; }
        public string CauseComment { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsAssess AttainsAssessIdxNavigation { get; set; }
    }
}
