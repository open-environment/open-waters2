using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.Models.Model
{
    public class ActivityListDisplay
    {
        public int ACTIVITY_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string MONLOC_ID { get; set; }
        public string ACTIVITY_ID { get; set; }
        public string ACT_TYPE { get; set; }
        public string ACT_MEDIA { get; set; }
        public string ACT_SUBMEDIA { get; set; }
        public DateTime? ACT_START_DT { get; set; }
        public DateTime? ACT_END_DT { get; set; }
        public string ACT_DEPTHHEIGHT_MSR { get; set; }
        public string ACT_DEPTHHEIGHT_MSR_UNIT { get; set; }
        public string TOP_DEPTHHEIGHT_MSR { get; set; }
        public string BOT_DEPTHHEIGHT_MSR { get; set; }
        public string DEPTH_REF_POINT { get; set; }
        public string ACT_COMMENT { get; set; }
        public string SAMP_COLL_METHOD { get; set; }
        public string SAMP_COLL_EQUIP { get; set; }
        public string SAMP_COLL_EQUIP_COMMENT { get; set; }
        public string SAMP_PREP_METHOD { get; set; }
        public Boolean? WQX_IND { get; set; }
        public string WQX_SUBMIT_STATUS { get; set; }
        public Boolean? ACT_IND { get; set; }
    }
}
