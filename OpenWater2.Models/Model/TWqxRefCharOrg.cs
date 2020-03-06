using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxRefCharOrg
    {
        public string CharName { get; set; }
        public string OrgId { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? CreateDt { get; set; }
        public string DefaultDetectLimit { get; set; }
        public string DefaultUnit { get; set; }
        public int? DefaultAnalMethodIdx { get; set; }
        public string DefaultSampFraction { get; set; }
        public string DefaultResultStatus { get; set; }
        public string DefaultResultValueType { get; set; }
        public string DefaultLowerQuantLimit { get; set; }
        public string DefaultUpperQuantLimit { get; set; }

        public virtual TWqxRefCharacteristic CharNameNavigation { get; set; }
        public virtual TWqxRefAnalMethod DefaultAnalMethodIdxNavigation { get; set; }
        public virtual TWqxOrganization Org { get; set; }
    }
}
