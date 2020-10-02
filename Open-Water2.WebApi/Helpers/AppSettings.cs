using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string SvcPortalJWTLoginEndPoint { get; set; }
        public string SvcPortalGetNewUserData { get; set; }
        public string Authority { get; set; }
        public string Audience { get; set; }
    }
}
