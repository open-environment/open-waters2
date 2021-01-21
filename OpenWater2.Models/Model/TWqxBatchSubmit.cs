using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenWater2.Models.Model
{
    public partial class TWqxBatchSubmit
    {
        public TWqxBatchSubmit()
        {
            TWqxBatchSubmitTrans = new HashSet<TWqxBatchSubmitTrans>();
        }

        public int Bsmid { get; set; }
        public string CdxSubmitTransid { get; set; }
        public string CdxSubmitStatus { get; set; }
        public string SubmitType { get; set; }
        public string OrgId { get; set; }
        public string IsBatchInProcess { get; set; }
        public int? SubmitAttempt { get; set; }
        public int? StatusAttempt { get; set; }
        public DateTime? SubmitDate { get; set; }

        public virtual ICollection<TWqxBatchSubmitTrans> TWqxBatchSubmitTrans { get; set; }
    }
}
