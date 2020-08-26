using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Entities
{
    public class ImportProcessModel
    {
        public bool wqxImport { get; set; }
        public string wqxSubmitStatus { get; set; }
        public string selectedTempMonlocIds { get; set; }
        public int userIdx { get; set; }
        public string activityReplceType { get; set; }
    }
}
