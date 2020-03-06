using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxProject
    {
        public TWqxProject()
        {
            TWqxActivity = new HashSet<TWqxActivity>();
        }

        public int ProjectIdx { get; set; }
        public string OrgId { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }
        public string SampDesignTypeCd { get; set; }
        public bool? QappApprovalInd { get; set; }
        public string QappApprovalAgency { get; set; }
        public bool? WqxInd { get; set; }
        public string WqxSubmitStatus { get; set; }
        public DateTime? WqxUpdateDt { get; set; }
        public bool? ActInd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
        public virtual ICollection<TWqxActivity> TWqxActivity { get; set; }
    }
}
