using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsRefWaterType
    {
        public TAttainsRefWaterType()
        {
            TAttainsAssessUnits = new HashSet<TAttainsAssessUnits>();
        }

        public string WaterTypeCode { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }

        public virtual ICollection<TAttainsAssessUnits> TAttainsAssessUnits { get; set; }
    }
}
