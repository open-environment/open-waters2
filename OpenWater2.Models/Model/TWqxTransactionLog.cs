using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxTransactionLog
    {
        public int LogId { get; set; }
        public string TableCd { get; set; }
        public int TableIdx { get; set; }
        public DateTime SubmitDt { get; set; }
        public string SubmitType { get; set; }
        public byte[] ResponseFile { get; set; }
        public string ResponseTxt { get; set; }
        public string CdxSubmitTransid { get; set; }
        public string CdxSubmitStatus { get; set; }
        public string OrgId { get; set; }
    }
}
