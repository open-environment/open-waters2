using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
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
    }
    
}
