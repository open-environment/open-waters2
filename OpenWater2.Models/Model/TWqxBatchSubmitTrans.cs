using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenWater2.Models.Model
{
    public partial class TWqxBatchSubmitTrans
    {
        public int Bstid { get; set; }
        public int? Bsmid { get; set; }
        public string TableCd { get; set; }
        public int? TableIdx { get; set; }
        public string TableId { get; set; }
        public string CdxSubmitStatus { get; set; }
        public string IsInBatchProcess { get; set; }

        public virtual TWqxBatchSubmit Bsm { get; set; }
    }
}
