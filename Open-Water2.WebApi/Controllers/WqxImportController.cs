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
using OpenWater2.Models.Model;

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

        // GET api/import/getWqxImportTempProjectByUserIdx
        [Route("api/import/getWqxImportTempProjectByUserIdx")]
        [HttpGet]
        public IActionResult getWqxImportTempProjectByUserIdx([FromQuery] int userIdx)
        {
            var result = _unitOfWork.tWqxImportTempProjectRepository.GetWqxImportTempProject(userIdx);
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

        // POST api/import/processImportTempProject
        [Route("api/import/processImportTempProject")]
        [HttpPost]
        public IActionResult processImportTempProject([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempProjectRepository.ProcessImportTempProject(model.wqxImport,
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

        // POST api/import/cancelProcessImportTempProject
        [Route("api/import/cancelProcessImportTempProject")]
        [HttpPost]
        public IActionResult cancelProcessImportTempProject([FromBody] ImportProcessModel model)
        {
            int result = _unitOfWork.tWqxImportTempProjectRepository.CancelProcessImportTempProject(model.wqxImport,
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

        // GET api/import/getWqxImportTemplate
        [Route("api/import/getWqxImportTemplate")]
        [HttpGet]
        public IActionResult getWqxImportTemplate([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxImportTemplateRepository.GetWQX_IMPORT_TEMPLATE(OrgID);
            return Ok(result);
        }

        // GET api/import/getWqxImportTemplateDtlDynamicByTemplateId
        [Route("api/import/getWqxImportTemplateDtlDynamicByTemplateId")]
        [HttpGet]
        public IActionResult getWqxImportTemplateDtlDynamicByTemplateId([FromQuery] int TemplateID)
        {
            var result = _unitOfWork.tWqxImportTemplateDtlRepository.GetWQX_IMPORT_TEMPLATE_DTL_DynamicByTemplateID(TemplateID);
            return Ok(result);
        }

        // DELETE api/import/deleteTWqxImportTemplate
        [Route("api/import/deleteTWqxImportTemplate")]
        [HttpDelete]
        public IActionResult deleteTWqxImportTemplate([FromQuery] int TemplateID)
        {
            var result = _unitOfWork.tWqxImportTemplateRepository.DeleteT_WQX_IMPORT_TEMPLATE(TemplateID);
            return Ok(result);
        }

        // GET api/import/getWqxImportTemplateDtlHarCodeByTemplateId
        [Route("api/import/getWqxImportTemplateDtlHarCodeByTemplateId")]
        [HttpGet]
        public IActionResult getWqxImportTemplateDtlHarCodeByTemplateId([FromQuery] int TemplateID)
        {
            var result = _unitOfWork.tWqxImportTemplateDtlRepository.GetWQX_IMPORT_TEMPLATE_DTL_HardCodeByTemplateID(TemplateID);
            return Ok(result);
        }

        // POST api/import/insertOrUpdateWqxImportTemplate
        [Route("api/import/insertOrUpdateWqxImportTemplate")]
        [HttpPost]
        public IActionResult insertOrUpdateWqxImportTemplate([FromBody] TWqxImportTemplate wqxImportTemplate)
        {
            var result = _unitOfWork.tWqxImportTemplateRepository.
                            InsertOrUpdateWQX_IMPORT_TEMPLATE(wqxImportTemplate.TemplateId,
                                                                wqxImportTemplate.OrgId,
                                                                wqxImportTemplate.TypeCd,
                                                                wqxImportTemplate.TemplateName,
                                                                wqxImportTemplate.CreateUserid);
            return Ok(result);
        }

        // POST api/import/insertOrUpdateWqxImportTemplateDtl
        [Route("api/import/insertOrUpdateWqxImportTemplateDtl")]
        [HttpPost]
        public IActionResult insertOrUpdateWqxImportTemplateDtl([FromBody] TWqxImportTemplateDtl wqxImportTemplateDtl)
        {
            var result = _unitOfWork.tWqxImportTemplateDtlRepository.
                            InsertOrUpdateWQX_IMPORT_TEMPLATE_DTL(wqxImportTemplateDtl.TemplateDtlId,
                                                                    wqxImportTemplateDtl.TemplateId,
                                                                    wqxImportTemplateDtl.ColNum,
                                                                    wqxImportTemplateDtl.FieldMap,
                                                                    wqxImportTemplateDtl.CharName,
                                                                    wqxImportTemplateDtl.CharDefaultUnit,
                                                                    wqxImportTemplateDtl.CreateUserid,
                                                                    wqxImportTemplateDtl.CharDefaultSampFraction);
            return Ok(result);
        }

        // DELETE api/import/deleteTWqxImportTemplateDtl
        [Route("api/import/deleteTWqxImportTemplateDtl")]
        [HttpDelete]
        public IActionResult deleteTWqxImportTemplateDtl([FromQuery] int TemplateDtlID)
        {
            var result = _unitOfWork.tWqxImportTemplateDtlRepository.DeleteT_WQX_IMPORT_TEMPLATE_DTL(TemplateDtlID);
            return Ok(result);
        }

        // GET api/import/getWqxImportLog
        [Route("api/import/getWqxImportLog")]
        [HttpGet]
        public IActionResult GetWQX_IMPORT_LOG([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxImportLogRepository.GetWQX_IMPORT_LOG(OrgID);
            return Ok(result);
        }

        // DELETE api/import/deleteTWqxImportLog
        [Route("api/import/deleteTWqxImportLog")]
        [HttpDelete]
        public IActionResult DeleteTWqxImportLog([FromQuery] int importId)
        {
            var result = _unitOfWork.tWqxImportLogRepository.DeleteTWqxImportLog(importId);
            return Ok(result);
        }

        // DELETE api/import/insertOrUpdateTwqxImportLog
        [Route("api/import/insertOrUpdateTwqxImportLog")]
        [HttpPost]
        public IActionResult InsertOrUpdateTwqxImportLog([FromBody] TWqxImportLog importLog)
        {
            var result = _unitOfWork.tWqxImportLogRepository.InsertUpdateWQX_IMPORT_LOG(
                importLog.ImportId,
                importLog.OrgId,
                importLog.TypeCd,
                importLog.FileName,
                importLog.FileSize,
                importLog.ImportStatus,
                importLog.ImportProgress,
                importLog.ImportProgressMsg,
                importLog.ImportFile,
                importLog.CreateUserid);
            return Ok(result);
        }

        // GET api/import/importActivity
        [Route("api/import/importActivity")]
        [HttpGet]
        public async Task<IActionResult> ImportActivityAsync([FromQuery] string orgId, int? importId, string userId)
        {
            var result = await _unitOfWork.tWqxImportTempSampleRepository.ImportActivityAsync(orgId, importId, userId);
            return Ok(result);
        }
        // GET api/import/getWqxImportTempActivityMetric
        [Route("api/import/getWqxImportTempActivityMetric")]
        [HttpGet]
        public IActionResult GetWqxImportTempActivityMetric([FromQuery] int userIdx)
        {
            var result = _unitOfWork.tWqxImportTempActivityMetricRepository.GetWqxImportTempActivityMetric(userIdx);
            return Ok(result);
        }
    }

}
