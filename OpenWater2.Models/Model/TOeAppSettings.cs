using System;
using System.Collections.Generic;

namespace OpenWater2.Models.Model
{
    public partial class TOeAppSettings
    {
        public int SettingIdx { get; set; }
        public string SettingName { get; set; }
        public string SettingDesc { get; set; }
        public string SettingValue { get; set; }
        public bool? EncryptInd { get; set; }
        public string SettingValueSalt { get; set; }
        public string ModifyUserid { get; set; }
        public DateTime? ModifyDt { get; set; }
    }
}
