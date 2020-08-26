using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open_Water2.WebApi.Entities
{
    public class ImportModel
    {
        public int userIdx { get; set; }
        public string orgId { get; set; }
        public string importType { get; set; }
        public string importData { get; set; }
        public string templateInd { get; set; }
        public int projectId { get; set; }
        public string projectName { get; set; }
        public int templateId { get; set; }
        public string template { get; set; }
    }
}
