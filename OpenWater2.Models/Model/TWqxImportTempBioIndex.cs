using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTempBioIndex
    {
        public int TempBioHabitatIndexIdx { get; set; }
        public string UserId { get; set; }
        public string OrgId { get; set; }
        public int? MonlocIdx { get; set; }
        public string IndexId { get; set; }
        public string IndexTypeId { get; set; }
        public string IndexTypeIdContext { get; set; }
        public string IndexTypeName { get; set; }
        public string IndexTypeScale { get; set; }
        public string IndexScore { get; set; }
        public string IndexQualCd { get; set; }
        public string IndexComment { get; set; }
        public DateTime? IndexCalcDate { get; set; }
        public string ImportStatusCd { get; set; }
        public string ImportStatusDesc { get; set; }
    }
}
