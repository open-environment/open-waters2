using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System.Xml.Linq;

namespace Open_Water2.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class TWQXRefDataController : Controller
    {
        IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TWQXRefDataController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
        [HttpGet("api/refdata/getTWqxRefDefaultTimeZone")]
        public IActionResult GetT_WQX_REF_DEFAULT_TIME_ZONE()
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_DEFAULT_TIME_ZONE();
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefCharacteristic")]
        public IActionResult GetT_WQX_REF_CHARACTERISTIC([FromQuery] Boolean ActInd, Boolean onlyUsedInd)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHARACTERISTIC(ActInd, onlyUsedInd);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefData")]
        public IActionResult GetT_WQX_REF_DATA([FromQuery] string table, Boolean actInd, Boolean usedInd)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_DATA(table, actInd, usedInd);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefAnalMethod")]
        public IActionResult GetT_WQX_REF_ANAL_METHOD([FromQuery] Boolean actInd)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_ANAL_METHOD(actInd);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefTaxaOrg")]
        public IActionResult GetT_WQX_REF_TAXA_ORG([FromQuery] string orgName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_TAXA_ORG(orgName);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefCharOrgByName")]
        public IActionResult GetT_WQX_REF_CHAR_ORGByName([FromQuery] string orgName, string charName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHAR_ORGByName(orgName, charName);
            return Ok(result);
        }
        [HttpDelete("api/refdata/deleteWqxRefCharOrg")]
        public IActionResult DeleteT_WQX_REF_CHAR_ORG([FromQuery] string orgName, string charName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.DeleteT_WQX_REF_CHAR_ORG(orgName, charName);
            return Ok(result);
        }
        [HttpPost("api/refdata/insertOrUpdateTWqxRefTaxaOrg")]
        public IActionResult InsertOrUpdateT_WQX_REF_TAXA_ORG([FromQuery] string bioSubjectTaxanomy, string orgName, string createUserId)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_TAXA_ORG(bioSubjectTaxanomy, orgName, createUserId);
            return Ok(result);
        }
        [HttpDelete("api/refdata/deleteTWqxRefTaxaOrg")]
        public IActionResult DeleteT_WQX_REF_TAXA_ORG([FromQuery] string orgName, string charName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.DeleteT_WQX_REF_TAXA_ORG(orgName, charName);
            return Ok(result);
        }
        [HttpDelete("api/refdata/deleteTWqxImportTranslate")]
        public IActionResult DeleteT_WQX_IMPORT_TRANSLATE([FromQuery] int TranslateID)
        {
            var result = _unitOfWork.tWqxRefDataRepository.DeleteT_WQX_IMPORT_TRANSLATE(TranslateID);
            return Ok(result);
        }
        [HttpPost("api/refdata/insertOrUpdateWqxImportTranslate")]
        public IActionResult InsertOrUpdateWQX_IMPORT_TRANSLATE([FromQuery] int? translateIdx, string orgId, string colName, string dataFrom, string dataTo, string createUser = "system")
        {
            if (translateIdx == 0) translateIdx = null;
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateWQX_IMPORT_TRANSLATE(translateIdx, orgId, colName, dataFrom, dataTo, createUser);
            return Ok(result);
        }
        [HttpGet("api/refdata/getAllColumnBasic")]
        public IActionResult GetAllColumnBasic([FromQuery] string importType)
        {
            var filePath = String.Format(@"{0}\xml\ImportColumnsConfig.xml", _webHostEnvironment.WebRootPath);
            var xml = XDocument.Load(filePath);
            var result = (from c in xml.Root.Descendants("Field")
                    .Where(i => i.Attribute("Level").Value == importType)
                    select c.Attribute("FieldName").Value
                    ).ToList();
            return Ok(result);
        }
        [HttpPost("api/refdata/InsertOrUpdateTWqxRefCharOrg")]
        public IActionResult InsertOrUpdateT_WQX_REF_CHAR_ORG(string charName, string orgName, string createUserId, string defaultDetectLimit, string defaultUnit, int? defaultAnalMethodIdx, string defaultSampFraction, string defaultResultStatus, string defaultResultTypeValue, string defaultLowerQuantLimit, string defaultUpperQuantLimit)
        {
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_REF_CHAR_ORG(charName, orgName, createUserId, defaultDetectLimit, defaultUnit, defaultAnalMethodIdx, defaultSampFraction, defaultResultStatus, defaultResultTypeValue, defaultLowerQuantLimit, defaultUpperQuantLimit);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefCharOrg")]
        public IActionResult GetT_WQX_REF_CHAR_ORG([FromQuery] string orgName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHAR_ORG(orgName);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefCounty")]
        public IActionResult GetT_WQX_REF_COUNTY([FromQuery] string stateCode)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_COUNTY(stateCode);
            return Ok(result);
        }
        [HttpGet("api/refdata/getTWqxRefDataCount")]
        public IActionResult GetT_WQX_REF_DATA_Count()
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_DATA_Count();
            return Ok(result);
        }

        [HttpGet("api/refdata/GetTWqxRefCharOrgCount")]
        public IActionResult GetT_WQX_REF_CHAR_ORG_Count(string orgName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHAR_ORG_Count(orgName);
            return Ok(result);
        }
        [HttpGet("api/refdata/GetTWqxRefSampColMethodByContext")]
        public IActionResult GetT_WQX_REF_SAMP_COL_METHOD_ByContext(string Context)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_SAMP_COL_METHOD_ByContext(Context);
            return Ok(result);
        }

        [HttpGet("api/refdata/getTWqxRefCharacteristicByOrg")]
        public IActionResult GetT_WQX_REF_CHARACTERISTIC_ByOrg([FromQuery] string OrgID, Boolean RBPInd)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHARACTERISTIC_ByOrg(OrgID, RBPInd);
            return Ok(result);
        }
        [HttpPost("api/refdata/insertOrUpdateTWqxResult")]
        public IActionResult InsertOrUpdateT_WQX_RESULT([FromQuery] global::System.Int32? rESULT_IDX, global::System.Int32 aCTIVITY_IDX, global::System.String rESULT_DETECT_CONDITION,
            global::System.String cHAR_NAME, global::System.String rESULT_SAMP_FRACTION, global::System.String rESULT_MSR, global::System.String rESULT_MSR_UNIT,
            global::System.String rESULT_STATUS, global::System.String rESULT_VALUE_TYPE, global::System.String rESULT_COMMENT,
            global::System.String bIO_INTENT_NAME, global::System.String bIO_INDIVIDUAL_ID, global::System.String bIO_TAXONOMY, global::System.String bIO_SAMPLE_TISSUE_ANATOMY,
            global::System.Int32? aNALYTIC_METHOD_IDX, int? lAB_IDX, DateTime? lAB_ANALYSIS_START_DT, global::System.String dETECTION_LIMIT, global::System.String pQL,
            global::System.String lOWER_QUANT_LIMIT, global::System.String uPPER_QUANT_LIMIT, int? lAB_SAMP_PREP_IDX, DateTime? lAB_SAMP_PREP_START_DT, string dILUTION_FACTOR,
            string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT,
            String cREATE_USER = "system")
        {
            if (lAB_IDX == 0) lAB_IDX = null;
            if (aNALYTIC_METHOD_IDX == 0) aNALYTIC_METHOD_IDX = null;
            var result = _unitOfWork.tWqxRefDataRepository.InsertOrUpdateT_WQX_RESULT(rESULT_IDX, aCTIVITY_IDX, rESULT_DETECT_CONDITION,
            cHAR_NAME, rESULT_SAMP_FRACTION, rESULT_MSR, rESULT_MSR_UNIT,
            rESULT_STATUS, rESULT_VALUE_TYPE, rESULT_COMMENT,
            bIO_INTENT_NAME, bIO_INDIVIDUAL_ID, bIO_TAXONOMY, bIO_SAMPLE_TISSUE_ANATOMY,
            aNALYTIC_METHOD_IDX, lAB_IDX, lAB_ANALYSIS_START_DT, dETECTION_LIMIT, pQL,
            lOWER_QUANT_LIMIT, uPPER_QUANT_LIMIT, lAB_SAMP_PREP_IDX, lAB_SAMP_PREP_START_DT, dILUTION_FACTOR,
            fREQ_CLASS_CODE, fREQ_CLASS_UNIT, cREATE_USER);
            return Ok(result);
        }
        [HttpGet("api/refdata/getTWqxRefTaxaByOrg")]
        public IActionResult GetT_WQX_REF_TAXA_ByOrg([FromQuery] string OrgID)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_TAXA_ByOrg(OrgID);
            return Ok(result);
        }
        [HttpGet("api/refdata/getTWqxRefCharLimitsByNameUnit")]
        public IActionResult GetT_WQX_REF_CHAR_LIMITS_ByNameUnit([FromQuery] string CharName, string UnitName)
        {
            var result = _unitOfWork.tWqxRefDataRepository.GetT_WQX_REF_CHAR_LIMITS_ByNameUnit(CharName, UnitName);
            return Ok(result);
        }
        [HttpDelete("api/refdata/deleteTWqxResult")]
        public IActionResult DeleteT_WQX_RESULT([FromQuery] int ResultIdx)
        {
            var result = _unitOfWork.tWqxRefDataRepository.DeleteT_WQX_RESULT(ResultIdx);
            return Ok(result);
        }
    }
}