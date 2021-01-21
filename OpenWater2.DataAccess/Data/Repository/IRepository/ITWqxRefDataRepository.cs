using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefDataRepository : IRepository<TWqxRefData>
    {
        public int InsertOrUpdateT_WQX_REF_ANAL_METHOD(int? analyticMethodIdx, string analyticMethodId, string analyticMethodCtx,
            string analyticMethodName, string analyticMethodDesc, bool actInd);

        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(global::System.Int32? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND);

        public int InsertOrUpdateT_WQX_REF_SAMP_PREP(global::System.Int32? sAMP_PREP_IDX, global::System.String sAMP_PREP_METHOD_ID,
            string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND);
        public int InsertOrUpdateT_WQX_REF_LAB(global::System.Int32? lAB_IDX, global::System.String lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND);

        public int UpdateT_WQX_REF_DATAByIDX(global::System.Int32 IDX, global::System.String vALUE, global::System.String tEXT, Boolean ActInd);
        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(global::System.String cHAR_NAME, global::System.Decimal? dETECT_LIMIT, global::System.String dEFAULT_UNIT, global::System.Boolean? uSED_IND,
            global::System.Boolean aCT_IND, global::System.String sAMP_FRAC_REQ, global::System.String pICK_LIST);
        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(string cHAR_NAME, decimal? dETECT_LIMIT, string dEFAULT_UNIT, bool? uSED_IND,
            bool aCT_IND, string sAMP_FRAC_REQ, string pICK_LIST, string mETH_SPEC_REQ);
        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDandContext(string ID, string Context);
        public List<TWqxRefAnalMethod> GetT_WQX_REF_ANAL_METHODByValue(string value);
        public List<TWqxRefData> GetAllT_WQX_REF_DATA();
        public List<TWqxRefCharacteristic> GetAllT_WQX_REF_CHARACTERISTIC();
        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTICByCharName(string charName);
        public List<TWqxRefAnalMethod> GetAllT_WQX_REF_ANAL_METHOD();
        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREP();
        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREPByContext(string Context);
        public List<TWqxRefDefaultTimeZone> GetT_WQX_REF_DEFAULT_TIME_ZONE();
        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC(Boolean ActInd, Boolean onlyUsedInd);
        public List<TWqxRefData> GetT_WQX_REF_DATA(string tABLE, Boolean ActInd, Boolean UsedInd);

        public List<AnalMethodDisplay> GetT_WQX_REF_ANAL_METHOD(Boolean ActInd);
        public List<TWqxRefCharOrg> GetT_WQX_REF_CHAR_ORG(string orgName);
        public List<TWqxRefTaxaOrg> GetT_WQX_REF_TAXA_ORG(string orgName);
        public TWqxRefCharOrg GetT_WQX_REF_CHAR_ORGByName(string orgName, string charName);
        public int InsertOrUpdateT_WQX_REF_CHAR_ORG(global::System.String cHAR_NAME, global::System.String oRG_NAME, global::System.String cREATE_USER_ID,
            string dEFAULT_DETECT_LIMIT, string dEFAULT_UNIT, int? dEFAULT_ANAL_METHOD_IDX, string dEFAULT_SAMP_FRACTION, string dEFAULT_RESULT_STATUS,
            string dEFAULT_RESULT_VALUE_TYPE, string dEFAULT_LOWER_QUANT_LIMIT, string dEFAULT_UPPER_QUANT_LIMIT);
        public int DeleteT_WQX_REF_CHAR_ORG(string orgName, string charName);
        public int InsertOrUpdateT_WQX_REF_TAXA_ORG(string bioSubjectTaxanomy, string orgName, string createUserId);
        public int DeleteT_WQX_REF_TAXA_ORG(string orgName, string charName);
        public int DeleteT_WQX_IMPORT_TRANSLATE(int TranslateID);

        public int InsertOrUpdateWQX_IMPORT_TRANSLATE(int? tRANSLATE_IDX, string oRG_ID, string cOL_NAME, string dATA_FROM, string dATA_TO, string cREATE_USER = "system");
        public List<TWqxRefCounty> GetT_WQX_REF_COUNTY(string StateCode);
        public List<TWqxRefCounty> GetAllT_WQX_REF_COUNTY();
        public int GetT_WQX_REF_DATA_Count();
        public int GetT_WQX_REF_CHAR_ORG_Count(string orgName);
        public List<TWqxRefSampColMethod> GetT_WQX_REF_SAMP_COL_METHOD_ByContext(string Context);
        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC_ByOrg(string OrgID, Boolean RBPInd);
        public int InsertOrUpdateT_WQX_RESULT(global::System.Int32? rESULT_IDX, global::System.Int32 aCTIVITY_IDX, global::System.String rESULT_DETECT_CONDITION,
            global::System.String cHAR_NAME, global::System.String rESULT_SAMP_FRACTION, global::System.String rESULT_MSR, global::System.String rESULT_MSR_UNIT,
            global::System.String rESULT_STATUS, global::System.String rESULT_VALUE_TYPE, global::System.String rESULT_COMMENT,
            global::System.String bIO_INTENT_NAME, global::System.String bIO_INDIVIDUAL_ID, global::System.String bIO_TAXONOMY, global::System.String bIO_SAMPLE_TISSUE_ANATOMY,
            global::System.Int32? aNALYTIC_METHOD_IDX, int? lAB_IDX, DateTime? lAB_ANALYSIS_START_DT, global::System.String dETECTION_LIMIT, global::System.String pQL,
            global::System.String lOWER_QUANT_LIMIT, global::System.String uPPER_QUANT_LIMIT, int? lAB_SAMP_PREP_IDX, DateTime? lAB_SAMP_PREP_START_DT, string dILUTION_FACTOR,
            string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT,
            string targetCount, decimal? proportionSampProcNumeric, string resultSampPointType, string resultSampPointPlaceInSeries,
            string resultSampPointCommentText, string recordIdentifierUserSupplied, string subjectTaxonomicNameUserSupplied,
            string subjectTaxonomicNameUserSuppliedRefText, string groupSummaryCount, string functionalFeedingGroupName,
            string comparableAnalMethodIdentifier, string comparableAnalMethodIdentifierCtx, string comparableAnalMethodModificationText,
            string labCommentText, string detectionQuantLimitCommentText, string labSampSplitRatio,
            String cREATE_USER = "system");
        public List<TWqxRefData> GetT_WQX_REF_TAXA_ByOrg(string OrgID);
        public TWqxRefCharLimits GetT_WQX_REF_CHAR_LIMITS_ByNameUnit(string CharName, string UnitName);
        public bool GetT_WQX_REF_DATA_ByKey(string table, string value);
        public List<TWqxRefData> GetT_WQX_REF_DATA_ByValueOrText(string table, string value);
        public TWqxRefCounty GetT_WQX_REF_COUNTY_ByCountyNameAndState(string stateName, string countyName);
        public int DeleteT_WQX_RESULT(int ResultIDX);
        public string GetT_WQX_REF_DATA_LastUpdate();
        public int WQXImport_Org();
        public System.Threading.Tasks.Task<int> WQXImport_RefDataAsync(string tableName);
        public int InsertOrUpdateT_WQX_REF_DATA(string table, string value, string text, Boolean? UsedInd, bool? ActInd);
        public int InsertOrUpdateT_WQX_REF_DATA(TWqxRefData refData);
        public int InsertOrUpdateT_WQX_REF_COUNTY(string stateCode, string countyCode, string countyName, Boolean? UsedInd);
        public List<TWqxRefLab> GetT_WQX_REF_LAB_ByOrgId(string OrgId);
        public TWqxRefData GetT_WQX_REF_DATA_ByTextGetRow(string table, string text);
    }
    
}
