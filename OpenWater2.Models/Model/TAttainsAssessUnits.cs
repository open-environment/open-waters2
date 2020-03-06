using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssessUnits
    {
        public TAttainsAssessUnits()
        {
            TAttainsAssess = new HashSet<TAttainsAssess>();
            TAttainsAssessUnitsMloc = new HashSet<TAttainsAssessUnitsMloc>();
        }

        public int AttainsAssessUnitIdx { get; set; }
        public int AttainsReportIdx { get; set; }
        public string AssessUnitId { get; set; }
        public string AssessUnitName { get; set; }
        public string LocationDesc { get; set; }
        public string AgencyCode { get; set; }
        public string StateCode { get; set; }
        public string ActInd { get; set; }
        public string WaterTypeCode { get; set; }
        public decimal? WaterSize { get; set; }
        public string WaterUnitCode { get; set; }
        public string UseClassCode { get; set; }
        public string UseClassName { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsReport AttainsReportIdxNavigation { get; set; }
        public virtual TAttainsRefWaterType WaterTypeCodeNavigation { get; set; }
        public virtual ICollection<TAttainsAssess> TAttainsAssess { get; set; }
        public virtual ICollection<TAttainsAssessUnitsMloc> TAttainsAssessUnitsMloc { get; set; }
    }
}
