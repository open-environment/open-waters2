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
        public int InsertOrUpdateT_WQX_REF_ANAL_METHOD(global::System.Int32? aNALYTIC_METHOD_IDX, global::System.String aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX,
            string aNALYTIC_METHOD_NAME, string aNALYTIC_METHOD_DESC, bool aCT_IND);

        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(global::System.Int32? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND);

        public int InsertOrUpdateT_WQX_REF_SAMP_PREP(global::System.Int32? sAMP_PREP_IDX, global::System.String sAMP_PREP_METHOD_ID,
            string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND);
        public int InsertOrUpdateT_WQX_REF_LAB(global::System.Int32? lAB_IDX, global::System.String lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND);

        public int UpdateT_WQX_REF_DATAByIDX(global::System.Int32 IDX, global::System.String vALUE, global::System.String tEXT, Boolean ActInd);
        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(global::System.String cHAR_NAME, global::System.Decimal? dETECT_LIMIT, global::System.String dEFAULT_UNIT, global::System.Boolean? uSED_IND,
            global::System.Boolean aCT_IND, global::System.String sAMP_FRAC_REQ, global::System.String pICK_LIST);
        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDandContext(string ID, string Context);
        public List<TWqxRefData> GetAllT_WQX_REF_DATA();
        public List<TWqxRefCharacteristic> GetAllT_WQX_REF_CHARACTERISTIC();
        public List<TWqxRefAnalMethod> GetAllT_WQX_REF_ANAL_METHOD();
        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREP();
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
        public int GetT_WQX_REF_DATA_Count();
        public int GetT_WQX_REF_CHAR_ORG_Count(string orgName);
        public List<TWqxRefSampColMethod> GetT_WQX_REF_SAMP_COL_METHOD_ByContext(string Context);

    }
    
}
