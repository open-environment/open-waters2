using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTempProject
    {
        public int TempProjectIdx { get; set; }
        public string UserId { get; set; }
        public int? ProjectIdx { get; set; }
        public string OrgId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string SampDesignTypeCd { get; set; }
        public bool? QappApprovalInd { get; set; }
        public string QappApprovalAgency { get; set; }
        public string ImportStatusCd { get; set; }
        public string ImportStatusDesc { get; set; }
    }
}
