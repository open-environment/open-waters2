using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Entities
{
    public class UserOrgDisplayType
    {
        public int? ORG_USER_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string USER_ID { get; set; }
        public string ACCESS_LEVEL { get; set; }
        public string STATUS_IND { get; set; }
        public string ORG_NAME { get; set; }
        public string USER_NAME { get; set; }
    }
}
