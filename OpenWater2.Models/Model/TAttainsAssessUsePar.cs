using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssessUsePar
    {
        public int AttainsAssessUseParIdx { get; set; }
        public int AttainsAssessUseIdx { get; set; }
        public string ParamName { get; set; }
        public string ParamAttainmentCode { get; set; }
        public string TrendCode { get; set; }
        public string ParamComment { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsAssessUse AttainsAssessUseIdxNavigation { get; set; }
    }
}
