using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Open_Water2.WebApi.Controllers
{
    
    [ApiController]
    public class TWQXMgmtController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public TWQXMgmtController(IUnitOfWork unitOfWork,
            IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // GET api/mgmt/getVWqxTransactionLog
        [Route("api/mgmt/getVWqxTransactionLog")]
        [HttpGet]
        public IActionResult getVWqxTransactionLog(string TableCD, DateTime? startDt, DateTime? endDt, string OrgID)
        {
            var result = _unitOfWork.tWqxTransactionLogRepository.GetV_WQX_TRANSACTION_LOG(TableCD, startDt, endDt, OrgID);
            return Ok(result);
        }

        // GET api/mgmt/getWqxTransactionLog
        [Route("api/mgmt/getWqxTransactionLog")]
        [HttpGet]
        public IActionResult getWqxTransactionLog(string TableCD, int TableIdx)
        {
            var result = _unitOfWork.tWqxTransactionLogRepository.GetWQX_TRANSACTION_LOG(TableCD, TableIdx);
            return Ok(result);
        }

        // GET api/mgmt/getVWqxPendingRecords
        [Route("api/mgmt/getVWqxPendingRecords")]
        [HttpGet]
        public IActionResult getVWqxPendingRecords(string OrgID, DateTime? startDate, DateTime? endDate)
        {
            var result = _unitOfWork.tWqxPendingRecordsRepository.GetV_WQX_PENDING_RECORDS(OrgID, startDate, endDate);
            return Ok(result);
        }

        // GET api/mgmt/getTOeAppTasksByName
        [Route("api/mgmt/getTOeAppTasksByName")]
        [HttpGet]
        public IActionResult getTOeAppTasksByName(string taskName)
        {
            var result = _unitOfWork.oeAppTasksRepository.GetT_OE_APP_TASKS_ByName(taskName);
            return Ok(result);
        }

        // PUT api/mgmt/updateTOeAppTasks
        [Route("api/mgmt/updateTOeAppTasks")]
        [HttpPut]
        public IActionResult updateTOeAppTasks([FromBody]TOeAppTasks oeAppTasks)
        {
            var result = _unitOfWork.oeAppTasksRepository.UpdateT_OE_APP_TASKS(oeAppTasks.TaskName, oeAppTasks.TaskStatus, oeAppTasks.TaskFreqMs, oeAppTasks.ModifyUserid);
            return Ok(result);
        }

        // GET api/mgmt/getWqxTransactionLogByLogId
        [Route("api/mgmt/getWqxTransactionLogByLogId")]
        [HttpGet]
        public IActionResult getWqxTransactionLogByLogId(int LogID)
        {
            TWqxTransactionLogModel actResult = new TWqxTransactionLogModel();
            var result = _unitOfWork.tWqxTransactionLogRepository.GetWQX_TRANSACTION_LOG_ByLogID(LogID);
            actResult.wqxTransactionLog = result;
            if(result.ResponseFile != null)
            {
               actResult.ResponseFileXML = Encoding.UTF8.GetString(result.ResponseFile, 0, result.ResponseFile.Length);
            }
            return Ok(actResult);
        }

        // GET api/mgmt/wqxMaster
        [Route("api/mgmt/wqxMaster")]
        [HttpGet]
        public async Task<IActionResult> WQX_MasterAsync([FromQuery]string orgId)
        {
            await _unitOfWork.tWqxSubmitRepository.WQX_MasterAsync(orgId);
            return Ok(1);
        }

        // GET api/mgmt/getCdxSubmitCredentials2
        [Route("api/mgmt/getCdxSubmitCredentials2")]
        [HttpGet]
        public IActionResult getCdxSubmitCredentials2([FromQuery] string orgId)
        {
            _unitOfWork.tWqxSubmitRepository.GetCDXSubmitCredentials2(orgId);
            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        // TODO: THIS IS FOR TEST ONLY, REMOVE DURING REFACTRING
        // *****************************************************
        [Route("api/mgmt/test")]
        [HttpGet]
        public IActionResult test([FromQuery] string TypeText, int recordIDX)
        {
            _unitOfWork.tWqxSubmitRepository.SP_GenWQXXML_Single_Delete(TypeText, recordIDX);
            return new StatusCodeResult(StatusCodes.Status200OK);
        }

        // GET api/mgmt/wqxSubmitOneByOne
        [Route("api/mgmt/wqxSubmitOneByOne")]
        [HttpGet]
        public IActionResult wqxSubmitOneByOne([FromQuery] string typeText, int RecordIDX, string userID, string credential, string NodeURL, string orgID, bool? InsUpdIndicator)
        {
            _unitOfWork.tWqxSubmitRepository.WQX_Submit_OneByOneAsync(typeText, RecordIDX, userID, credential, NodeURL, orgID, InsUpdIndicator);
            return Ok(1);
        }
    }
}
