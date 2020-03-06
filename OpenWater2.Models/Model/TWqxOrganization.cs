using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxOrganization
    {
        public TWqxOrganization()
        {
            TAttainsReport = new HashSet<TAttainsReport>();
            TWqxActivity = new HashSet<TWqxActivity>();
            TWqxBioHabitatIndex = new HashSet<TWqxBioHabitatIndex>();
            TWqxImportLog = new HashSet<TWqxImportLog>();
            TWqxImportTemplate = new HashSet<TWqxImportTemplate>();
            TWqxImportTranslate = new HashSet<TWqxImportTranslate>();
            TWqxMonloc = new HashSet<TWqxMonloc>();
            TWqxOrgAddress = new HashSet<TWqxOrgAddress>();
            TWqxProject = new HashSet<TWqxProject>();
            TWqxRefCharOrg = new HashSet<TWqxRefCharOrg>();
            TWqxRefTaxaOrg = new HashSet<TWqxRefTaxaOrg>();
            TWqxUserOrgs = new HashSet<TWqxUserOrgs>();
        }

        public string OrgId { get; set; }
        public string OrgFormalName { get; set; }
        public string OrgDesc { get; set; }
        public string TribalCode { get; set; }
        public string Electronicaddress { get; set; }
        public string Electronicaddresstype { get; set; }
        public string TelephoneNum { get; set; }
        public string TelephoneNumType { get; set; }
        public string TelephoneExt { get; set; }
        public string CdxSubmitterId { get; set; }
        public string CdxSubmitterPwdHash { get; set; }
        public string CdxSubmitterPwdSalt { get; set; }
        public bool? CdxSubmitInd { get; set; }
        public string DefaultTimezone { get; set; }
        public string MailingAddress { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingAddCity { get; set; }
        public string MailingAddState { get; set; }
        public string MailingAddZip { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public DateTime? UpdateDt { get; set; }
        public string UpdateUserid { get; set; }

        public virtual ICollection<TAttainsReport> TAttainsReport { get; set; }
        public virtual ICollection<TWqxActivity> TWqxActivity { get; set; }
        public virtual ICollection<TWqxBioHabitatIndex> TWqxBioHabitatIndex { get; set; }
        public virtual ICollection<TWqxImportLog> TWqxImportLog { get; set; }
        public virtual ICollection<TWqxImportTemplate> TWqxImportTemplate { get; set; }
        public virtual ICollection<TWqxImportTranslate> TWqxImportTranslate { get; set; }
        public virtual ICollection<TWqxMonloc> TWqxMonloc { get; set; }
        public virtual ICollection<TWqxOrgAddress> TWqxOrgAddress { get; set; }
        public virtual ICollection<TWqxProject> TWqxProject { get; set; }
        public virtual ICollection<TWqxRefCharOrg> TWqxRefCharOrg { get; set; }
        public virtual ICollection<TWqxRefTaxaOrg> TWqxRefTaxaOrg { get; set; }
        public virtual ICollection<TWqxUserOrgs> TWqxUserOrgs { get; set; }
    }
}
