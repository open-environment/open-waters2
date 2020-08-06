using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class TWQXActivityController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXActivityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/activity/getAllActivities")]
        public IActionResult GetWQX_Activities([FromQuery]bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX)
        {
            if (MonLocIDX == 0) MonLocIDX = null;
            if (ProjectIDX == 0) ProjectIDX = null;
            var result = _unitOfWork.tWqxActivityRepository.GetWQX_ACTIVITY(ActInd, OrgID, MonLocIDX, startDt, endDt, ActType, WQXPending, ProjectIDX);
            return Ok(result);
        }
        [HttpGet("api/activity/getTWQXResulTCount")]
        public IActionResult GetT_WQX_RESULTCount([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxActivityRepository.GetT_WQX_RESULTCount(OrgID);
            return Ok(result);
        }
        [HttpGet("api/activity/getWQXActivityMyOrgCount")]
        public IActionResult GetWQX_ACTIVITY_MyOrgCount([FromQuery] int UserIDX)
        {
            var result = _unitOfWork.tWqxActivityRepository.GetWQX_ACTIVITY_MyOrgCount(UserIDX);
            return Ok(result);
        }

        [HttpGet("api/activity/getWqxActivityDisplay")]
        public IActionResult GetWQX_ACTIVITYDisplay([FromQuery] bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX, string WQXStatus)
        {
            if (MonLocIDX == 0) MonLocIDX = null;
            if (ProjectIDX == 0) ProjectIDX = null;
            if (WQXStatus == null) WQXStatus = "";
            
            var result = _unitOfWork.tWqxActivityRepository.GetWQX_ACTIVITYDisplay(ActInd, OrgID, MonLocIDX, startDt, endDt, ActType, WQXPending, ProjectIDX, WQXStatus);
            return Ok(result);
        }

        [HttpDelete("api/activity/deleteTWqxActivity")]
        public IActionResult DeleteT_WQX_ACTIVITY([FromQuery] int ActivityIDX, string UserID)
        {
            var result = _unitOfWork.tWqxActivityRepository.DeleteT_WQX_ACTIVITY(ActivityIDX, UserID);
            return Ok(result);
        }
        [HttpPost("api/activity/insertOrUpdateWqxActivity")]
        public IActionResult InsertOrUpdateWQX_ACTIVITY([FromQuery] global::System.Int32? aCTIVITY_IDX, global::System.String oRG_ID, global::System.Int32? pROJECT_IDX, global::System.Int32? mONLOC_IDX, global::System.String aCTIVITY_ID,
            global::System.String aCT_TYPE, global::System.String aCT_MEDIA, global::System.String aCT_SUBMEDIA, global::System.DateTime? aCT_START_DT, global::System.DateTime? aCT_END_DT,
            global::System.String aCT_TIME_ZONE, global::System.String rELATIVE_DEPTH_NAME, global::System.String aCT_DEPTHHEIGHT_MSR, global::System.String aCT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String tOP_DEPTHHEIGHT_MSR, global::System.String tOP_DEPTHHEIGHT_MSR_UNIT, global::System.String bOT_DEPTHHEIGHT_MSR, global::System.String bOT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String dEPTH_REF_POINT, global::System.String aCT_COMMENT, global::System.String bIO_ASSEMBLAGE_SAMPLED, global::System.String bIO_DURATION_MSR,
            global::System.String bIO_DURATION_MSR_UNIT, global::System.String bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, global::System.String bIO_REACH_LEN_MSR,
            global::System.String bIO_REACH_LEN_MSR_UNIT, global::System.String bIO_REACH_WID_MSR, global::System.String bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT,
            global::System.String bIO_NET_TYPE, global::System.String bIO_NET_AREA_MSR, global::System.String bIO_NET_AREA_MSR_UNIT, global::System.String bIO_NET_MESHSIZE_MSR,
            global::System.String bIO_MESHSIZE_MSR_UNIT, global::System.String bIO_BOAT_SPEED_MSR, global::System.String bIO_BOAT_SPEED_MSR_UNIT, global::System.String bIO_CURR_SPEED_MSR,
            global::System.String bIO_CURR_SPEED_MSR_UNIT, global::System.String bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_EQUIP, global::System.String sAMP_COLL_EQUIP_COMMENT,
            int? sAMP_PREP_IDX, global::System.String sAMP_PREP_CONT_TYPE, global::System.String sAMP_PREP_CONT_COLOR, global::System.String sAMP_PREP_CHEM_PRESERV, global::System.String sAMP_PREP_THERM_PRESERV,
            global::System.String sAMP_PREP_STORAGE_DESC, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system", string eNTRY_TYPE = "C")
        {
            if (aCTIVITY_IDX == null || aCTIVITY_IDX <= 0) aCTIVITY_IDX = null;
            if (bIO_PASS_COUNT == 0) bIO_PASS_COUNT = null;
            var result = _unitOfWork.tWqxActivityRepository.InsertOrUpdateWQX_ACTIVITY(aCTIVITY_IDX,  oRG_ID, pROJECT_IDX, mONLOC_IDX,  aCTIVITY_ID,
            aCT_TYPE,  aCT_MEDIA,  aCT_SUBMEDIA, aCT_START_DT, aCT_END_DT,
            aCT_TIME_ZONE,  rELATIVE_DEPTH_NAME,  aCT_DEPTHHEIGHT_MSR,  aCT_DEPTHHEIGHT_MSR_UNIT,
            tOP_DEPTHHEIGHT_MSR,  tOP_DEPTHHEIGHT_MSR_UNIT,  bOT_DEPTHHEIGHT_MSR,  bOT_DEPTHHEIGHT_MSR_UNIT,
            dEPTH_REF_POINT,  aCT_COMMENT,  bIO_ASSEMBLAGE_SAMPLED,  bIO_DURATION_MSR,
             bIO_DURATION_MSR_UNIT,  bIO_SAMP_COMPONENT, bIO_SAMP_COMPONENT_SEQ,  bIO_REACH_LEN_MSR,
             bIO_REACH_LEN_MSR_UNIT,  bIO_REACH_WID_MSR,  bIO_REACH_WID_MSR_UNIT, bIO_PASS_COUNT,
             bIO_NET_TYPE,  bIO_NET_AREA_MSR,  bIO_NET_AREA_MSR_UNIT,  bIO_NET_MESHSIZE_MSR,
             bIO_MESHSIZE_MSR_UNIT,  bIO_BOAT_SPEED_MSR,  bIO_BOAT_SPEED_MSR_UNIT,  bIO_CURR_SPEED_MSR,
             bIO_CURR_SPEED_MSR_UNIT,  bIO_TOXICITY_TEST_TYPE, sAMP_COLL_METHOD_IDX,  sAMP_COLL_EQUIP,  sAMP_COLL_EQUIP_COMMENT,
             sAMP_PREP_IDX,  sAMP_PREP_CONT_TYPE,  sAMP_PREP_CONT_COLOR,  sAMP_PREP_CHEM_PRESERV,  sAMP_PREP_THERM_PRESERV,
             sAMP_PREP_STORAGE_DESC,  wQX_SUBMIT_STATUS, aCT_IND, wQX_IND, cREATE_USER, eNTRY_TYPE);
            return Ok(result);
        }

        [HttpGet("api/activity/getTWqxRefDataActivityTypeUsed")]
        public IActionResult GetT_WQX_REF_DATA_ActivityTypeUsed([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxActivityRepository.GetT_WQX_REF_DATA_ActivityTypeUsed(OrgID);
            return Ok(result);
        }

        [HttpGet("api/activity/getWqxActivityById")]
        public IActionResult GetWQX_ACTIVITY_ByID([FromQuery] int ActivityIDX)
        {
            var result = _unitOfWork.tWqxActivityRepository.GetWQX_ACTIVITY_ByID(ActivityIDX);
            return Ok(result);
        }

        [HttpGet("api/activity/getTWqxResult")]
        public IActionResult GetT_WQX_RESULT([FromQuery] int ActivityIDX)
        {
            var result = _unitOfWork.tWqxActivityRepository.GetT_WQX_RESULT(ActivityIDX);
            return Ok(result);
        }
        [HttpPut("api/activity/updateWqxActivityWqxStatus")]
        public IActionResult UpdateWQX_ACTIVITY_WQXStatus([FromQuery] global::System.Int32? aCTIVITY_IDX, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            var result = _unitOfWork.tWqxActivityRepository.UpdateWQX_ACTIVITY_WQXStatus(aCTIVITY_IDX,wQX_SUBMIT_STATUS,aCT_IND,wQX_IND,cREATE_USER);
            return Ok(result);
        }
    }
}