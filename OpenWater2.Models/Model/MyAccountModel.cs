using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class MyAccountModel
    {
        public MyAccountModel()
        {
            if (roles == null) roles = new List<string>();
            if (organizations == null) organizations = new List<string>();
        }
        public TOeUsers user { get; set; }
        public List<string> roles { get; set; }
        public List<string> organizations { get; set; }
    }
}
