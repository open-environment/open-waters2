using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxImportTempResultRepository : IRepository<TWqxImportTempResult>
    {
        public void WQX_IMPORT_TEMP_RESULT_GenVal(ref TWqxImportTempResult a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f);
        public int InsertWQX_IMPORT_TEMP_RESULT_New(int tEMP_SAMPLE_IDX, Dictionary<string, string> colVals, string orgID, string configFilePath);
        public int InsertOrUpdateWQX_IMPORT_TEMP_RESULT(global::System.Int32? tEMP_RESULT_IDX, int tEMP_SAMPLE_IDX, global::System.Int32? rESULT_IDX, string dATA_LOGGER_LINE,
            string rESULT_DETECT_CONDITION, global::System.String cHAR_NAME, string mETHOD_SPECIATION_NAME, string rESULT_SAMP_FRACTION, global::System.String rESULT_MSR, global::System.String rESULT_MSR_UNIT,
            string rESULT_MSR_QUAL, string rESULT_STATUS, string sTATISTIC_BASE_CODE, string rESULT_VALUE_TYPE, string wEIGHT_BASIS, string tIME_BASIS, string tEMP_BASIS, string pARTICAL_BASIS,
            string pRECISION_VALUE, string bIAS_VALUE, string cONFIDENCE_INTERVAL_VALUE, string uP_CONFIDENCE_LIMIT, string lOW_CONFIDENCE_LIMIT, string rESULT_COMMENT, string dEPTH_HEIGHT_MSR,
            string dEPTH_HEIGHT_MSR_UNIT, string dEPTHALTITUDEREFPOINT, string bIO_INTENT_NAME, string bIO_INDIVIDUAL_ID, string bIO_SUBJECT_TAXONOMY, string bIO_UNIDENTIFIED_SPECIES_ID,
            string bIO_SAMPLE_TISSUE_ANATOMY, string gRP_SUMM_COUNT_WEIGHT_MSR, string gRP_SUMM_COUNT_WEIGHT_MSR_UNIT, string tAX_DTL_CELL_FORM, string tAX_DTL_CELL_SHAPE, string tAX_DTL_HABIT,
            string tAX_DTL_VOLTINISM, string tAX_DTL_POLL_TOLERANCE, string tAX_DTL_POLL_TOLERANCE_SCALE, string tAX_DTL_TROPHIC_LEVEL, string tAX_DTL_FUNC_FEEDING_GROUP1,
            string tAX_DTL_FUNC_FEEDING_GROUP2, string tAX_DTL_FUNC_FEEDING_GROUP3, string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT, string fREQ_CLASS_UPPER, string fREQ_CLASS_LOWER,
            int? aNALYTIC_METHOD_IDX, string aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX, string aNALYTIC_METHOD_NAME,
            int? lAB_IDX, string lAB_NAME, DateTime? lAB_ANALYSIS_START_DT, DateTime? lAB_ANALYSIS_END_DT, string lAB_ANALYSIS_TIMEZONE, string rESULT_LAB_COMMENT_CODE,
            string mETHOD_DETECTION_LEVEL, string lAB_REPORTING_LEVEL, string pQL, string lOWER_QUANT_LIMIT, string uPPER_QUANT_LIMIT, string dETECTION_LIMIT_UNIT, int? lAB_SAMP_PREP_IDX,
            string lAB_SAMP_PREP_ID, string lAB_SAMP_PREP_CTX, DateTime? lAB_SAMP_PREP_START_DT, DateTime? lAB_SAMP_PREP_END_DT, string dILUTION_FACTOR, string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, string orgID, Boolean autoImportRefDataInd);
        public void Update(TWqxImportTempResult wqxImportTempResult);
    }
}
