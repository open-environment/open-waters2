using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsReport
    {
        public TAttainsReport()
        {
            TAttainsAssessUnits = new HashSet<TAttainsAssessUnits>();
            TAttainsReportLog = new HashSet<TAttainsReportLog>();
        }

        public int AttainsReportIdx { get; set; }
        public string OrgId { get; set; }
        public string ReportName { get; set; }
        public DateTime? DataFrom { get; set; }
        public DateTime? DataTo { get; set; }
        public bool? AttainsInd { get; set; }
        public string AttainsSubmitStatus { get; set; }
        public DateTime? AttainsUpdateDt { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
        public virtual ICollection<TAttainsAssessUnits> TAttainsAssessUnits { get; set; }
        public virtual ICollection<TAttainsReportLog> TAttainsReportLog { get; set; }
    }
}
