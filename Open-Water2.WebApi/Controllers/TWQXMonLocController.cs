using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class TWQXMonLocController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXMonLocController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("api/monloc/getUserOrgsByUserIDXOrgID")]
        public IActionResult GetWQX_USER_ORGS_ByUserIDX_OrgID([FromQuery]int UserIDX, string OrgID)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetWQX_USER_ORGS_ByUserIDX_OrgID(UserIDX, OrgID);
            return Ok(result);
        }
        [HttpGet("api/monloc/getWQXMonlocMyOrgCount")]
        public IActionResult GetWQX_MONLOC_MyOrgCount([FromQuery] int UserIDX)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetWQX_MONLOC_MyOrgCount(UserIDX);
            return Ok(result);
        }
        [HttpDelete("api/monloc/deleteWQXMonLoc")]
        public IActionResult DeleteT_WQX_MONLOC([FromQuery]int monLocIDX, int userIdx)
        {
            var result = _unitOfWork.tWqxMonLocRepository.DeleteT_WQX_MONLOC(monLocIDX, userIdx);
            return Ok(result);
        }
        [HttpGet("api/monloc/getWQXMonLoc")]
        public async Task<IActionResult> GetWQX_MONLOC([FromQuery]bool ActInd, string OrgID, bool? WQXPending)
        {
            var result = await _unitOfWork.tWqxMonLocRepository.GetWQX_MONLOC(ActInd, OrgID, WQXPending);
            return Ok(result);
        }
        [HttpGet("api/monloc/GetTWQXMonLocPendingInd")]
        public IActionResult GetT_WQX_MONLOC_PendingInd([FromQuery]string OrgID)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetT_WQX_MONLOC_PendingInd(OrgID);
            return Ok(result);
        }
        [HttpGet("api/monloc/GetWQXMonLocByID")]
        public IActionResult GetWQX_MONLOC_ByID([FromQuery]int MonLocIDX)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetWQX_MONLOC_ByID(MonLocIDX);
            return Ok(result);
        }
        [HttpPost("api/monloc/InsertOrUpdateWQXMonLoc")]
        public IActionResult InsertOrUpdateWQX_MONLOC([FromQuery]global::System.Int32? mONLOC_IDX, global::System.String oRG_ID, global::System.String mONLOC_ID, global::System.String mONLOC_NAME,
            global::System.String mONLOC_TYPE, global::System.String mONLOC_DESC, global::System.String hUC_EIGHT, global::System.String HUC_TWELVE, global::System.String tRIBAL_LAND_IND,
            global::System.String tRIBAL_LAND_NAME, global::System.String lATITUDE_MSR, global::System.String lONGITUDE_MSR, global::System.Int32? sOURCE_MAP_SCALE,
            global::System.String hORIZ_ACCURACY, global::System.String hORIZ_ACCURACY_UNIT, global::System.String hORIZ_COLL_METHOD, global::System.String hORIZ_REF_DATUM,
            global::System.String vERT_MEASURE, global::System.String vERT_MEASURE_UNIT, global::System.String vERT_COLL_METHOD, global::System.String vERT_REF_DATUM,
            global::System.String cOUNTRY_CODE, global::System.String sTATE_CODE, global::System.String cOUNTY_CODE, global::System.String wELL_TYPE, global::System.String aQUIFER_NAME,
            global::System.String fORMATION_TYPE, global::System.String wELLHOLE_DEPTH_MSR, global::System.String wELLHOLE_DEPTH_MSR_UNIT, global::System.String wQX_SUBMIT_STATUS,
            DateTime? wQXUpdateDate, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            var result = _unitOfWork.tWqxMonLocRepository.InsertOrUpdateWQX_MONLOC(mONLOC_IDX, oRG_ID, mONLOC_ID, mONLOC_NAME,
             mONLOC_TYPE, mONLOC_DESC, hUC_EIGHT, HUC_TWELVE, tRIBAL_LAND_IND,
             tRIBAL_LAND_NAME, lATITUDE_MSR, lONGITUDE_MSR, sOURCE_MAP_SCALE,
             hORIZ_ACCURACY, hORIZ_ACCURACY_UNIT, hORIZ_COLL_METHOD, hORIZ_REF_DATUM,
             vERT_MEASURE, vERT_MEASURE_UNIT, vERT_COLL_METHOD, vERT_REF_DATUM,
             cOUNTRY_CODE, sTATE_CODE, cOUNTY_CODE, wELL_TYPE, aQUIFER_NAME,
             fORMATION_TYPE, wELLHOLE_DEPTH_MSR, wELLHOLE_DEPTH_MSR_UNIT, wQX_SUBMIT_STATUS,
             wQXUpdateDate, aCT_IND, wQX_IND, cREATE_USER);
            return Ok(result);
        }

        [HttpGet("api/monloc/getWqxMonlocByOrgId")]
        public IActionResult GetWQX_MONLOC_ByOrgID([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetWQX_MONLOC_ByOrgID(OrgID);
            return Ok(result);
        }

        [HttpDelete("api/monloc/deleteTWqxImportTempMonloc")]
        public IActionResult DeleteTWqxImportTempMonloc([FromQuery] int userIdx)
        {
            var result = _unitOfWork.tWqxImportTempMonlocRepository.DeleteTWqxImportTempMonloc(userIdx);
            return Ok(result);
        }
        [HttpGet("api/monloc/wqxImportMonLoc")]
        public async Task<IActionResult> WQXImportMonLocAsync([FromQuery] string orgId, int userIdx)
        {
            var result = await _unitOfWork.tWqxMonLocRepository.WQXImportMonLocAsync(orgId, userIdx);
            return Ok(result);
        }
        [HttpGet("api/monloc/getSitesAsync")]
        public async Task<IActionResult> GetSitesAsync([FromQuery] bool ActInd, string OrgID, bool? WQXPending)
        {
            var result = await _unitOfWork.tWqxMonLocRepository.GetSitesAsync(ActInd, OrgID, WQXPending);
            return Ok(result);
        }
        [HttpPost("api/monloc/getChartData")]
        public IActionResult GetChartData([FromBody] GetChartDataModel getChartDataModel)
        {
            var result = _unitOfWork.tWqxMonLocRepository.GetChartData(
                getChartDataModel.orgId,
                getChartDataModel.chartType,
                System.Web.HttpUtility.UrlDecode(getChartDataModel.charName),
                System.Web.HttpUtility.UrlDecode(getChartDataModel.charName2),
                getChartDataModel.begDt,
                getChartDataModel.endDt,
                string.Join(",",getChartDataModel.monLoc),
                getChartDataModel.decimals,
                getChartDataModel.wqxInd);
            return Ok(result);
        }
    }
}