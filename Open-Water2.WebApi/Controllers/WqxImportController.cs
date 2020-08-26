using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Open_Water2.WebApi.Entities;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace Open_Water2.WebApi.Controllers
{
    [ApiController]
    public class WqxImportController : ControllerBase
    {
        IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        public WqxImportController(IUnitOfWork unitOfWork,
            IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }
        // POST api/import/ProcessWqxImportData
        [Route("api/import/processWqxImportData")]
        [HttpPost]
        public string ProcessWqxImportData([FromBody] ImportModel model)
        {
            string configFilePath = _env.WebRootPath + @"\xml\ImportColumnsConfig.xml";
            byte[] data = Convert.FromBase64String(model.importData);
            string importData = Encoding.UTF8.GetString(data);
            string actResult = _unitOfWork.wqxImportRepository.ProcessImport(
                model.userIdx, 
                model.orgId, 
                model.importType,
                importData, 
                model.templateInd, 
                model.projectId, 
                model.projectName, 
                model.templateId, 
                model.template, configFilePath);
            return actResult;
        }

        // GET api/import/getWqxImportTempMonlocByUserIdx
        [Route("api/import/getWqxImportTempMonlocByUserIdx")]
        [HttpGet]
        public IActionResult getWqxImportTempMonlocByUserIdx([FromQuery] int userIdx)
        {
           var result = _unitOfWork.tWqxImportTempMonlocRepository.GetWQX_IMPORT_TEMP_MONLOC(userIdx);
            return Ok(result);
        }

        // GET api/import/getWqxImportTempSampleByUserIdx
        [Route("api/import/getWqxImportTempSampleByUserIdx")]
        [HttpGet]
        public IActionResult getWqxImportTempSampleByUserIdx([FromQuery] int userIdx)
        {
            var result = _unitOfWork.tWqxImportTempSampleRepository.GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(userIdx);
            return Ok(result);
        }

        // POST api/import/processImportTempMonloc
        [Route("api/import/processImportTempMonloc")]
        [HttpPost]
        public IActionResult processImportTempMonloc([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempMonlocRepository.ProcessImportTempMonloc(model.wqxImport,
                                                                        model.wqxSubmitStatus,
                                                                        model.selectedTempMonlocIds,
                                                                        model.userIdx);
            return Ok(result);
        }

        // POST api/import/processImportTempSample
        [Route("api/import/processImportTempSample")]
        [HttpPost]
        public IActionResult processImportTempSample([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempSampleRepository.SP_ImportActivityFromTemp(model.userIdx,model.wqxSubmitStatus,
                                                                        model.activityReplceType);
            return Ok(result);
        }

        // POST api/import/cancelProcessImportTempMonloc
        [Route("api/import/cancelProcessImportTempMonloc")]
        [HttpPost]
        public IActionResult cancelProcessImportTempMonloc([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempMonlocRepository.CancelProcessImportTempMonloc(model.wqxImport,
                                                                        model.wqxSubmitStatus,
                                                                        model.selectedTempMonlocIds,
                                                                        model.userIdx);
            return Ok(result);
        }

        // POST api/import/cancelProcessImportTempSample
        [Route("api/import/cancelProcessImportTempSample")]
        [HttpPost]
        public IActionResult cancelProcessImportTempSample([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempSampleRepository.CancelProcessImportTempSample(model.userIdx);
            return Ok(result);
        }
    }
}
