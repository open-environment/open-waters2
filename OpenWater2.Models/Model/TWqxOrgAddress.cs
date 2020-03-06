using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxOrgAddress
    {
        public string OrgId { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string SuppAddress { get; set; }
        public string Locality { get; set; }
        public string StateCd { get; set; }
        public string PostalCd { get; set; }
        public string CountryCd { get; set; }
        public string CountyCd { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual TWqxOrganization Org { get; set; }
    }
}
