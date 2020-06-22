using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data
{
    public class SessionVars
    {
        public string UserIDX { get; set; }
        public string OrgID { get; set; }
        public bool MLOC_HUC_EIGHT { get; set; }
        public bool MLOC_HUC_TWELVE { get; set; }
        public bool MLOC_TRIBAL_LAND { get; set; }
        public bool MLOC_SOURCE_MAP_SCALE { get; set; }
        public bool MLOC_HORIZ_COLL_METHOD { get; set; }
        public bool MLOC_HORIZ_REF_DATUM { get; set; }
        public bool MLOC_VERT_MEASURE { get; set; }
        public bool MLOC_COUNTRY_CODE { get; set; }
        public bool MLOC_STATE_CODE { get; set; }
        public bool MLOC_COUNTY_CODE { get; set; }
        public bool MLOC_WELL_DATA { get; set; }
        public bool MLOC_WELL_TYPE { get; set; }
        public bool MLOC_AQUIFER_NAME { get; set; }
        public bool MLOC_FORMATION_TYPE { get; set; }
        public bool MLOC_WELLHOLE_DEPTH { get; set; }
        public bool PROJ_SAMP_DESIGN_TYPE_CD { get; set; }
        public bool PROJ_QAPP_APPROVAL { get; set; }
        public bool SAMP_ACT_END_DT { get; set; }
        public bool SAMP_COLL_METHOD { get; set; }
        public bool SAMP_COLL_EQUIP { get; set; }
        public bool SAMP_PREP { get; set; }
        public bool SAMP_DEPTH { get; set; }
    }
}
