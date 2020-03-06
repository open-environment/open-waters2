using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsAssessUnitsMloc
    {
        public int AttainsAssessUnitIdx { get; set; }
        public int MonlocIdx { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
        public string ModifyUserid { get; set; }

        public virtual TAttainsAssessUnits AttainsAssessUnitIdxNavigation { get; set; }
        public virtual TWqxMonloc MonlocIdxNavigation { get; set; }
    }
}
