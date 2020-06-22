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
    public class TWQXRefDataController : Controller
    {
        IUnitOfWork _unitOfWork;
        public TWQXRefDataController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/refdata/GetAllTWQXRefData")]
        public IActionResult GetAllT_WQX_REF_DATA() {
            var result = _unitOfWork.tWqxRefDataRepository.GetAllT_WQX_REF_DATA();
            return Ok(result);
        }

        [HttpGet("api/refdata/GetAllTWQXRefCharacteristic")]
        public IActionResult GetAllT_WQX_REF_CHARACTERISTIC()
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetAllT_WQX_REF_CHARACTERISTIC();
            return Ok(result);
        }

        [HttpPost("api/refdata/InsertOrUpdateTWQXRefAnalMethod")]
        public IActionResult InsertOrUpdateT_WQX_REF_ANAL_METHOD([FromQuery]global::System.Int32? aNALYTIC_METHOD_IDX, global::System.String aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX,
            string aNALYTIC_METHOD_NAME, string aNALYTIC_METHOD_DESC, bool aCT_IND)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_ANAL_METHOD(aNALYTIC_METHOD_IDX, aNALYTIC_METHOD_ID, aNALYTIC_METHOD_CTX,
            aNALYTIC_METHOD_NAME, aNALYTIC_METHOD_DESC, aCT_IND);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWQXRefAnalMethodByIDandContext")]
        public IActionResult GetT_WQX_REF_ANAL_METHODByIDandContext([FromQuery]string ID, string Context)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_ANAL_METHODByIDandContext(ID, Context);
            return Ok(result);
        }
        [HttpPost("api/refdata/InsertOrUpdateTWQXRefSampColMethod")]
        public IActionResult InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD([FromQuery]global::System.Int32? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(sAMP_COLL_METHOD_IDX, sAMP_COLL_METHOD_ID,
            sAMP_COLL_METHOD_CTX, sAMP_COLL_METHOD_NAME, sAMP_COLL_METHOD_DESC, aCT_IND);
            return Ok(result);
        }
        [HttpPost("api/refdata/InsertOrUpdateTWQXRefSampPrep")]
        public IActionResult InsertOrUpdateT_WQX_REF_SAMP_PREP([FromQuery]global::System.Int32? sAMP_PREP_IDX, global::System.String sAMP_PREP_METHOD_ID,
            string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_SAMP_PREP(sAMP_PREP_IDX, sAMP_PREP_METHOD_ID,
            sAMP_PREP_METHOD_CTX, sAMP_PREP_METHOD_NAME, sAMP_PREP_METHOD_DESC, aCT_IND);
            return Ok(result);
        }
        [HttpPost("api/refdata/InsertOrUpdateTWQXRefLab")]
        public IActionResult InsertOrUpdateT_WQX_REF_LAB([FromQuery]global::System.Int32? lAB_IDX, global::System.String lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_SAMP_PREP(lAB_IDX, lAB_NAME, lAB_ACCRED_IND, lAB_ACCRED_AUTHORITY, oRG_ID, aCT_IND);
            return Ok(result);
        }
        [HttpPut("api/refdata/updateTWQXRefDataByIdx")]
        public IActionResult UpdateT_WQX_REF_DATAByIDX([FromQuery]global::System.Int32 IDX, global::System.String Value, global::System.String Text, Boolean ActInd)
        {
            var result = _unitOfWork.tWqxRefDataRepository.UpdateT_WQX_REF_DATAByIDX(IDX, Value, Text, ActInd);
            return Ok(result);
        }
        [HttpPost("api/refdata/InsertOrUpdateTWQXRefCharacteristic")]
        public IActionResult InsertOrUpdateT_WQX_REF_CHARACTERISTIC([FromQuery]global::System.String cHAR_NAME, global::System.Decimal? dETECT_LIMIT, global::System.String dEFAULT_UNIT, global::System.Boolean? uSED_IND,
            global::System.Boolean aCT_IND, global::System.String sAMP_FRAC_REQ, global::System.String pICK_LIST)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_CHARACTERISTIC(cHAR_NAME, dETECT_LIMIT, dEFAULT_UNIT, uSED_IND,
            aCT_IND, sAMP_FRAC_REQ, pICK_LIST);
            return Ok(result);
        }
    }
}