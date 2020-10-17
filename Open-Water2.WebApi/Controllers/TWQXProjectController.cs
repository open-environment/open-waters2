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
    public class TWQXProjectController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXProjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/project/getAllProjects")]
        public IActionResult GetWQX_Projects()
        {
            var result = _unitOfWork.tWqxProjectRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("api/project/getUserOrgsByUserIDXOrgID")]
        public IActionResult GetWQX_USER_ORGS_ByUserIDX_OrgID([FromQuery]int UserIDX, string OrgID)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetWQX_USER_ORGS_ByUserIDX_OrgID(UserIDX, OrgID);
            return Ok(result);
        }

        [HttpDelete("api/project/deleteTWQXProject")]
        public IActionResult DeleteT_WQX_MONLOC([FromQuery]int ProjectIDX, string UserID)
        {
            var result = _unitOfWork.tWqxProjectRepository.DeleteT_WQX_PROJECT(ProjectIDX, UserID);
            return Ok(result);
        }

        [HttpGet("api/project/getWQXProjectByID")]
        public IActionResult GetWQX_PROJECT_ByID([FromQuery]int ProjectIDX)
        {
            var result = _unitOfWork.tWqxProjectRepository.GetWQX_PROJECT_ByID(ProjectIDX);
            return Ok(result);
        }
        
        [HttpGet("api/project/getWQXProjectMyOrgCount")]
        public IActionResult GetWQXProjectMyOrgCount([FromQuery] int UserIDX)
        {
            var result = _unitOfWork.tWqxProjectRepository.GetWQX_PROJECT_MyOrgCount(UserIDX);
            return Ok(result);
        }
        [HttpPost("api/project/InsertOrUpdateWQXProject")]
        public IActionResult InsertOrUpdateWQX_MONLOC([FromQuery]global::System.Int32? pROJECT_IDX, global::System.String oRG_ID, global::System.String pROJECT_ID,
            global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD, global::System.Boolean? qAPP_APPROVAL_IND,
            global::System.String qAPP_APPROVAL_AGENCY, global::System.String wQX_SUBMIT_STATUS, DateTime? wQX_SUBMIT_DT, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            if (pROJECT_IDX <= 0) pROJECT_IDX = null;
            var result = _unitOfWork.tWqxProjectRepository.InsertOrUpdateWQX_PROJECT(pROJECT_IDX, oRG_ID, pROJECT_ID,
            pROJECT_NAME, pROJECT_DESC, sAMP_DESIGN_TYPE_CD, qAPP_APPROVAL_IND,
            qAPP_APPROVAL_AGENCY, wQX_SUBMIT_STATUS, wQX_SUBMIT_DT, aCT_IND, wQX_IND, cREATE_USER);
            return Ok(result);
        }

        [HttpGet("api/project/getWqxProject")]
        public IActionResult GetWQX_PROJECT([FromQuery] bool ActInd, string OrgID, bool? WQXPending)
        {
            var result = _unitOfWork.tWqxProjectRepository.GetWQX_PROJECT(ActInd, OrgID, WQXPending);
            return Ok(result);
        }

        [HttpDelete("api/project/deleteTWqxImportTempProject")]
        public IActionResult DeleteTWqxImportTempProject([FromQuery] int userIdx)
        {
            var result = _unitOfWork.tWqxImportTempProjectRepository.DeleteTWqxImportTempProject(userIdx);
            return Ok(result);
        }

        [HttpGet("api/project/wqxImportProject")]
        public async Task<IActionResult> WQXImportProjectAsync([FromQuery] string orgId, int userIdx)
        {
            var result = await _unitOfWork.tWqxProjectRepository.WQXImportProjectAsync(orgId, userIdx);
            return Ok(result);
        }
    }
}