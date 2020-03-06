using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssessUse
    {
        public TAttainsAssessUse()
        {
            TAttainsAssessUsePar = new HashSet<TAttainsAssessUsePar>();
        }

        public int AttainsAssessUseIdx { get; set; }
        public int AttainsAssessIdx { get; set; }
        public string UseName { get; set; }
        public string UseAttainmentCode { get; set; }
        public string ThreatenedInd { get; set; }
        public string TrendCode { get; set; }
        public string IrCatCode { get; set; }
        public string IrCatDesc { get; set; }
        public string AssessBasis { get; set; }
        public string AssessType { get; set; }
        public string AssessConfidence { get; set; }
        public DateTime? MonDateStart { get; set; }
        public DateTime? MonDateEnd { get; set; }
        public DateTime? AssessDate { get; set; }
        public string AssessorName { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsAssess AttainsAssessIdxNavigation { get; set; }
        public virtual ICollection<TAttainsAssessUsePar> TAttainsAssessUsePar { get; set; }
    }
}
