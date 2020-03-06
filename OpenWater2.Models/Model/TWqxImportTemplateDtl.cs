using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TWqxImportTemplateDtl
    {
        public int TemplateDtlId { get; set; }
        public int TemplateId { get; set; }
        public int ColNum { get; set; }
        public string FieldMap { get; set; }
        public string CharName { get; set; }
        public string CharDefaultUnit { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CreateUserid { get; set; }
        public string CharDefaultSampFraction { get; set; }

        public virtual TWqxImportTemplate Template { get; set; }
    }
}
