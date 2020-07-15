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
            var result = _unitOfWork.tWqxActivityRepository.GetWQX_ACTIVITYDisplay(ActInd, OrgID, MonLocIDX, startDt, endDt, ActType, WQXPending, ProjectIDX, WQXStatus);
            return Ok(result);
        }

        [HttpDelete("api/activity/deleteTWqxActivity")]
        public IActionResult DeleteT_WQX_ACTIVITY([FromQuery] int ActivityIDX, string UserID)
        {
            var result = _unitOfWork.tWqxActivityRepository.DeleteT_WQX_ACTIVITY(ActivityIDX, UserID);
            return Ok(result);
        }
    }
}