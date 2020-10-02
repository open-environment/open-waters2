using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Entities
{
    public class OrgUserClientShortDisplayType
    {
        public string CLIENT_ID { get; set; }
        public int? ORG_USER_CLIENT_IDX { get; set; }
        public int? ORG_USER_IDX { get; set; }
        public bool? ADMIN_IND { get; set; }
        public string STATUS_IND { get; set; }
        public string ORG_CLIENT_ALIAS { get; set; }
    }
}
