using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TAttainsReportLog
    {
        public int AttainsLogIdx { get; set; }
        public int AttainsReportIdx { get; set; }
        public DateTime SubmitDt { get; set; }
        public string SubmitFile { get; set; }
        public byte[] ResponseFile { get; set; }
        public string ResponseTxt { get; set; }
        public string CdxSubmitTransid { get; set; }
        public string CdxSubmitStatus { get; set; }
        public string OrgId { get; set; }

        public virtual TAttainsReport AttainsReportIdxNavigation { get; set; }
    }
}
