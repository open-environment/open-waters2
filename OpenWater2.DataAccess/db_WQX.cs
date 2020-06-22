using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;



namespace OpwnWater2.DataAccess
{
    public class ImportSampleResultDisplay
    {
        public int TEMP_SAMPLE_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string MONLOC_ID { get; set; }
        public string ACTIVITY_ID { get; set; }
        public string ACT_TYPE { get; set; }
        public string ACT_MEDIA { get; set; }
        public string ACT_SUBMEDIA { get; set; }
        public DateTime? ACT_START_DT { get; set; }
        public DateTime? ACT_END_DT { get; set; }
        public string ACT_TIME_ZONE { get; set; }
        public string RELATIVE_DEPTH_NAME { get; set; }
        public string ACT_DEPTHHEIGHT_MSR { get; set; }
        public string ACT_DEPTHHEIGHT_MSR_UNIT { get; set; }
        public string TOP_DEPTHHEIGHT_MSR { get; set; }
        public string TOP_DEPTHHEIGHT_MSR_UNIT { get; set; }
        public string BOT_DEPTHHEIGHT_MSR { get; set; }
        public string BOT_DEPTHHEIGHT_MSR_UNIT { get; set; }
        public string DEPTH_REF_POINT { get; set; }
        public string ACT_COMMENT { get; set; }
        public string BIO_ASSEMBLAGE_SAMPLED { get; set; }
        public string BIO_DURATION_MSR { get; set; }
        public string BIO_DURATION_MSR_UNIT { get; set; }
        public string BIO_SAMP_COMPONENT { get; set; }
        public int? BIO_SAMP_COMPONENT_SEQ { get; set; }
        public string SAMP_COLL_METHOD_ID { get; set; }
        public string SAMP_COLL_METHOD_CTX { get; set; }
        public string SAMP_COLL_EQUIP { get; set; }
        public string SAMP_COLL_EQUIP_COMMENT { get; set; }
        public string SAMP_PREP_ID { get; set; }
        public string SAMP_PREP_CTX { get; set; }

        public int? TEMP_RESULT_IDX { get; set; }
        public string DATA_LOGGER_LINE { get; set; }
        public string RESULT_DETECT_CONDITION { get; set; }
        public string CHAR_NAME { get; set; }
        public string METHOD_SPECIATION_NAME { get; set; }
        public string RESULT_SAMP_FRACTION { get; set; }
        public string RESULT_MSR { get; set; }
        public string RESULT_MSR_UNIT { get; set; }
        public string RESULT_MSR_QUAL { get; set; }
        public string RESULT_STATUS { get; set; }
        public string STATISTIC_BASE_CODE { get; set; }
        public string RESULT_VALUE_TYPE { get; set; }
        public string WEIGHT_BASIS { get; set; }
        public string TIME_BASIS { get; set; }
        public string TEMP_BASIS { get; set; }
        public string PARTICLESIZE_BASIS { get; set; }
        public string PRECISION_VALUE { get; set; }
        public string BIAS_VALUE { get; set; }
        public string RESULT_COMMENT { get; set; }
        public string RES_DEPTH_HEIGHT_MSG { get; set; }
        public string RES_DEPTH_HEIGHT_MSR_UNIT { get; set; }

        public string BIO_INTENT_NAME { get; set; }
        public string BIO_INDIVIDUAL_ID { get; set; }
        public string BIO_SUBJECT_TAXONOMY { get; set; }
        public string BIO_UNIDENTIFIED_SPECIES_ID { get; set; }
        public string BIO_SAMPLE_TISSUE_ANATOMY { get; set; }
        public string GRP_SUMM_COUNT_WEIGHT_MSR { get; set; }
        public string GRP_SUMM_COUNT_WEIGHT_MSR_UNIT { get; set; }
        public string FREQ_CLASS_CODE { get; set; }
        public string FREQ_CLASS_UNIT { get; set; }
        public string ANAL_METHOD_ID { get; set; }
        public string ANAL_METHOD_CTX { get; set; }
        public string LAB_NAME { get; set; }
        public DateTime? ANAL_START_DT { get; set; }
        public DateTime? ANAL_END_DT { get; set; }
        public string LAB_COMMENT_CODE { get; set; }
        public string DETECTION_LIMIT { get; set; }
        public string LAB_REPORTING_LEVEL { get; set; }
        public string PQL { get; set; }
        public string LOWER_QUANT_LIMIT { get; set; }
        public string UPPER_QUANT_LIMIT { get; set; }
        public string DETECTION_LIMIT_UNIT { get; set; }
        public DateTime? LAB_SAMP_PREP_START_DT { get; set; }
        public string DILUTION_FACTOR { get; set; }
        public string IMPORT_STATUS_CD { get; set; }
        public string IMPORT_STATUS_DESC { get; set; }
    }

    public class CharDisplay
    {
        public string CHAR_NAME { get; set; }
    }

    public class ActivityListDisplay
    {
        public int ACTIVITY_IDX { get; set; }
        public string ORG_ID { get; set; }
        public string PROJECT_ID { get; set; }
        public string MONLOC_ID { get; set; }
        public string ACTIVITY_ID { get; set; }
        public string ACT_TYPE { get; set; }
        public string ACT_MEDIA { get; set; }
        public string ACT_SUBMEDIA { get; set; }
        public DateTime? ACT_START_DT { get; set; }
        public DateTime? ACT_END_DT { get; set; }
        public string ACT_DEPTHHEIGHT_MSR { get; set; }
        public string ACT_DEPTHHEIGHT_MSR_UNIT { get; set; }
        public string TOP_DEPTHHEIGHT_MSR { get; set; }
        public string BOT_DEPTHHEIGHT_MSR { get; set; }
        public string DEPTH_REF_POINT { get; set; }
        public string ACT_COMMENT { get; set; }
        public string SAMP_COLL_METHOD { get; set; }
        public string SAMP_COLL_EQUIP { get; set; }
        public string SAMP_COLL_EQUIP_COMMENT { get; set; }
        public string SAMP_PREP_METHOD { get; set; }
        public Boolean? WQX_IND { get; set; }
        public string WQX_SUBMIT_STATUS { get; set; }
        public Boolean? ACT_IND { get; set; }
    }

    public class ResultGridDisplay
    {
        public int RESULT_IDX { get; set; }
        public int ACTIVITY_IDX { get; set; }
        public string DATA_LOGGER_LINE { get; set; }
        public string RESULT_DETECT_CONDITION { get; set; }
        public string CHAR_NAME { get; set; }
        public string METHOD_SPECIATION_NAME { get; set; }
        public string RESULT_SAMP_FRACTION { get; set; }
        public string RESULT_MSR { get; set; }
        public string RESULT_MSR_UNIT { get; set; }
        public string RESULT_MSR_QUAL { get; set; }
        public string RESULT_STATUS { get; set; }
        public string STATISTIC_BASE_CODE { get; set; }
        public string RESULT_VALUE_TYPE { get; set; }
        public string WEIGHT_BASIS { get; set; }
        public string TIME_BASIS { get; set; }
        public string TEMP_BASIS { get; set; }
        public string PARTICLESIZE_BASIS { get; set; }
        public string PRECISION_VALUE { get; set; }
        public string BIAS_VALUE { get; set; }
        public string RESULT_COMMENT { get; set; }
        public string RES_DEPTH_HEIGHT_MSG { get; set; }
        public string RES_DEPTH_HEIGHT_MSR_UNIT { get; set; }

        public string BIO_INTENT_NAME { get; set; }
        public string BIO_INDIVIDUAL_ID { get; set; }
        public string BIO_SUBJECT_TAXONOMY { get; set; }
        public string BIO_UNIDENTIFIED_SPECIES_ID { get; set; }
        public string BIO_SAMPLE_TISSUE_ANATOMY { get; set; }
        public string GRP_SUMM_COUNT_WEIGHT_MSR { get; set; }
        public string GRP_SUMM_COUNT_WEIGHT_MSR_UNIT { get; set; }

        public int? ANAL_METHOD_IDX { get; set; }
        public string ANAL_METHOD_ID { get; set; }
        public string ANAL_METHOD_CTX { get; set; }
        public int? LAB_IDX { get; set; }
        public string LAB_NAME { get; set; }
        public DateTime? ANAL_START_DT { get; set; }
        public DateTime? ANAL_END_DT { get; set; }
        public string LAB_COMMENT_CODE { get; set; }

        public string DETECTION_LIMIT_TYPE { get; set; }
        public string DETECTION_LIMIT { get; set; }
        public string LAB_REPORTING_LEVEL { get; set; }
        public string PQL { get; set; }
        public string LOWER_QUANT_LIMIT { get; set; }
        public string UPPER_QUANT_LIMIT { get; set; }
        public string DETECTION_LIMIT_UNIT { get; set; }
        public int? LAB_SAMP_PREP_IDX { get; set; }
        public string LAB_SAMP_PREP_ID { get; set; }

    }

    public class UserOrgDisplay
    {
        public int USER_IDX { get; set; }
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string ORG_ID { get; set; }
        public string ROLE_CD { get; set; }
    }

    public class db_WQX
    {
        private static ApplicationDbContext _db;
        public db_WQX(ApplicationDbContext db)
        {
            _db = db;
        }
        // *************************** MONLOC **********************************
        // *********************************************************************
        public static int InsertOrUpdateWQX_MONLOC(global::System.Int32? mONLOC_IDX, global::System.String oRG_ID, global::System.String mONLOC_ID, global::System.String mONLOC_NAME,
            global::System.String mONLOC_TYPE, global::System.String mONLOC_DESC, global::System.String hUC_EIGHT, global::System.String HUC_TWELVE, global::System.String tRIBAL_LAND_IND,
            global::System.String tRIBAL_LAND_NAME, global::System.String lATITUDE_MSR, global::System.String lONGITUDE_MSR, global::System.Int32? sOURCE_MAP_SCALE,
            global::System.String hORIZ_ACCURACY, global::System.String hORIZ_ACCURACY_UNIT, global::System.String hORIZ_COLL_METHOD, global::System.String hORIZ_REF_DATUM,
            global::System.String vERT_MEASURE, global::System.String vERT_MEASURE_UNIT, global::System.String vERT_COLL_METHOD, global::System.String vERT_REF_DATUM,
            global::System.String cOUNTRY_CODE, global::System.String sTATE_CODE, global::System.String cOUNTY_CODE, global::System.String wELL_TYPE, global::System.String aQUIFER_NAME,
            global::System.String fORMATION_TYPE, global::System.String wELLHOLE_DEPTH_MSR, global::System.String wELLHOLE_DEPTH_MSR_UNIT, global::System.String wQX_SUBMIT_STATUS,
            DateTime? wQXUpdateDate, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxMonloc a = new TWqxMonloc();

                if (mONLOC_IDX != null)
                    a = (from c in _db.TWqxMonloc
                         where c.MonlocIdx == mONLOC_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (a == null) //insert case
                {
                    a = new TWqxMonloc();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_ID != null) a.MonlocId = mONLOC_ID;
                if (mONLOC_NAME != null) a.MonlocName = mONLOC_NAME;
                if (mONLOC_TYPE != null) a.MonlocType = mONLOC_TYPE;
                if (mONLOC_DESC != null) a.MonlocDesc = mONLOC_DESC;
                if (hUC_EIGHT != null) a.HucEight = hUC_EIGHT;
                if (HUC_TWELVE != null) a.HucTwelve = HUC_TWELVE;
                if (tRIBAL_LAND_IND != null) a.TribalLandInd = tRIBAL_LAND_IND;
                if (tRIBAL_LAND_NAME != null) a.TribalLandName = tRIBAL_LAND_NAME;
                if (lATITUDE_MSR != null) a.LatitudeMsr = lATITUDE_MSR;
                if (lONGITUDE_MSR != null) a.LongitudeMsr = lONGITUDE_MSR;
                if (sOURCE_MAP_SCALE != null) a.SourceMapScale = sOURCE_MAP_SCALE;
                if (hORIZ_ACCURACY != null) a.HorizAccuracy = hORIZ_ACCURACY;
                if (hORIZ_ACCURACY_UNIT != null) a.HorizAccuracyUnit = hORIZ_ACCURACY_UNIT;
                if (hORIZ_COLL_METHOD != null) a.HorizCollMethod = hORIZ_COLL_METHOD;
                if (hORIZ_REF_DATUM != null) a.HorizRefDatum = hORIZ_REF_DATUM;
                if (vERT_MEASURE != null) a.VertMeasure = vERT_MEASURE;
                if (vERT_MEASURE_UNIT != null) a.VertMeasureUnit = vERT_MEASURE_UNIT;
                if (vERT_COLL_METHOD != null) a.VertCollMethod = vERT_COLL_METHOD;
                if (vERT_REF_DATUM != null) a.VertRefDatum = vERT_REF_DATUM;
                if (cOUNTRY_CODE != null) a.CountryCode = cOUNTRY_CODE;
                if (sTATE_CODE != null) a.StateCode = sTATE_CODE;
                if (cOUNTY_CODE != null) a.CountyCode = cOUNTY_CODE;

                if (wELL_TYPE != null) a.WellType = wELL_TYPE;
                if (aQUIFER_NAME != null) a.AquiferName = aQUIFER_NAME;
                if (fORMATION_TYPE != null) a.FormationType = fORMATION_TYPE;
                if (wELLHOLE_DEPTH_MSR != null) a.WellholeDepthMsr = wELLHOLE_DEPTH_MSR;
                if (wELLHOLE_DEPTH_MSR_UNIT != null) a.WellholeDepthMsrUnit = wELLHOLE_DEPTH_MSR_UNIT;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxMonloc.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                    _db.TWqxMonloc.Update(a);
                }

                _db.SaveChanges();

                return a.MonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        /// <summary>
        /// Returns listing of Monitoring Locations, filtered by Organization ID
        /// </summary>
        public static List<TWqxMonloc> GetWQX_MONLOC(bool ActInd, string OrgID, bool? WQXPending)
        {
            if (WQXPending == false) WQXPending = null;
            try
            {
                return (from a in _db.TWqxMonloc
                        where (ActInd ? a.ActInd == true : true)
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        && (OrgID == null ? true : a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns listing of Monitoring Locations, filtered by Organization ID
        /// </summary>
        public static List<TWqxMonloc> GetWQX_MONLOC_ByOrgID(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where (a.ActInd == true)
                        && (a.OrgId == OrgID)
                        orderby a.MonlocId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns Monitoring Location record by ID
        /// </summary>
        public static TWqxMonloc GetWQX_MONLOC_ByID(int MonLocIDX)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where a.MonlocIdx == MonLocIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxMonloc GetWQX_MONLOC_ByIDString(string orgID, string MonLocID)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        where a.MonlocId == MonLocID
                        && a.OrgId == orgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool GetT_WQX_MONLOC_PendingInd(string OrgID)
        {
            try
            {
                if (_db.TWqxMonloc.Any(u => u.OrgId == OrgID && u.WqxSubmitStatus == "U" && u.WqxInd == true))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static int DeleteT_WQX_MONLOC(int monLocIDX, string UserID)
        {
            try
            {
                TWqxMonloc m = db_WQX.GetWQX_MONLOC_ByID(monLocIDX);
                if (m != null)
                {
                    if (m.WqxSubmitStatus == "Y" && m.ActInd == false)
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is passed ("Y")
                        string sql = "DELETE FROM T_WQX_MONLOC WHERE MONLOC_IDX = " + monLocIDX;
                        int result = _db.Database.ExecuteSqlCommand(sql, null);
                        return 1;
                    }

                    //if there are any activities for this monitoring location, don't delete becuase this would cause WQX to delete all activities for this mon loc.
                    int iActCount = db_WQX.GetWQX_ACTIVITYByMonLocID(monLocIDX);
                    if (iActCount > 0)
                    {
                        return -1;
                    }
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        db_WQX.InsertOrUpdateWQX_MONLOC(monLocIDX, null, null, null, null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "U", null, false, null, UserID);
                        return 1;
                    }

                }
                else
                    return 0;

            }
            catch
            {
                return 0;
            }

        }

        public static int GetWQX_MONLOC_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxMonloc
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // *************************** PROJECT *********************************
        // *********************************************************************
        public static List<TWqxProject> GetWQX_PROJECT(bool ActInd, string OrgID, bool? WQXPending)
        {
            if (WQXPending == false) WQXPending = null;

            try
            {
                return (from a in _db.TWqxProject
                        where (ActInd ? a.ActInd == true : true)
                        && a.OrgId == OrgID
                        && (!WQXPending.HasValue ? true : a.WqxSubmitStatus == "U")
                        && (!WQXPending.HasValue ? true : a.WqxInd == true)
                        orderby a.ProjectId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxProject GetWQX_PROJECT_ByID(int ProjectIDX)
        {
            try
            {
                return (from a in _db.TWqxProject
                        where a.ProjectIdx == ProjectIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxProject GetWQX_PROJECT_ByIDString(string ProjectID, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxProject
                        where a.ProjectId == ProjectID
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int InsertOrUpdateWQX_PROJECT(global::System.Int32? pROJECT_IDX, global::System.String oRG_ID, global::System.String pROJECT_ID,
            global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD, global::System.Boolean? qAPP_APPROVAL_IND,
            global::System.String qAPP_APPROVAL_AGENCY, global::System.String wQX_SUBMIT_STATUS, DateTime? wQX_SUBMIT_DT, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxProject a = new TWqxProject();

                if (pROJECT_IDX != null)
                    a = (from c in _db.TWqxProject
                         where c.ProjectIdx == pROJECT_IDX
                         select c).FirstOrDefault();

                if (pROJECT_IDX == null) //insert case
                {
                    a = new TWqxProject();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (pROJECT_ID != null) a.ProjectId = pROJECT_ID;
                if (pROJECT_NAME != null) a.ProjectName = pROJECT_NAME;
                if (pROJECT_DESC != null) a.ProjectDesc = pROJECT_DESC;
                if (sAMP_DESIGN_TYPE_CD != null) a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD;
                if (qAPP_APPROVAL_IND != null) a.QappApprovalInd = qAPP_APPROVAL_IND;
                if (qAPP_APPROVAL_AGENCY != null) a.QappApprovalAgency = qAPP_APPROVAL_AGENCY;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (wQX_SUBMIT_DT != null) a.WqxUpdateDt = wQX_SUBMIT_DT;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxProject.Add(a);
                    //ctx.AddToT_WQX_PROJECT(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.WqxUpdateDt = System.DateTime.Now;
                    _db.TWqxProject.Update(a);
                }

                _db.SaveChanges();
                //ctx.SaveChanges();

                return a.ProjectIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_WQX_PROJECT(int ProjectIDX, string UserID)
        {
            try
            {
                TWqxProject p = db_WQX.GetWQX_PROJECT_ByID(ProjectIDX);
                if (p != null)
                {
                    if (p.WqxSubmitStatus == "Y" && p.ActInd == false)
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is passed ("Y")
                        string sql = "DELETE FROM T_WQX_PROJECT WHERE PROJECT_IDX = " + ProjectIDX;
                        int result = _db.Database.ExecuteSqlCommand(sql, null);
                        return 1;
                    }

                    //if there are any active activities for this project, don't delete becuase this would cause WQX to delete all activities for this project.
                    int iActCount = db_WQX.GetWQX_ACTIVITYByProjectID(ProjectIDX);
                    if (iActCount > 0)
                        return -1;
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        InsertOrUpdateWQX_PROJECT(ProjectIDX, null, null, null, null, null, null, null, "U", null, false, null, UserID);
                        return 1;
                    }

                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }

        }

        public static int GetWQX_PROJECT_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxProject
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // *************************** ACTIVITY **********************************
        // *********************************************************************
        public static int InsertOrUpdateWQX_ACTIVITY(IHttpContextAccessor ihttpContextAccessor, global::System.Int32? aCTIVITY_IDX, global::System.String oRG_ID, global::System.Int32? pROJECT_IDX, global::System.Int32? mONLOC_IDX, global::System.String aCTIVITY_ID,
            global::System.String aCT_TYPE, global::System.String aCT_MEDIA, global::System.String aCT_SUBMEDIA, global::System.DateTime? aCT_START_DT, global::System.DateTime? aCT_END_DT,
            global::System.String aCT_TIME_ZONE, global::System.String rELATIVE_DEPTH_NAME, global::System.String aCT_DEPTHHEIGHT_MSR, global::System.String aCT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String tOP_DEPTHHEIGHT_MSR, global::System.String tOP_DEPTHHEIGHT_MSR_UNIT, global::System.String bOT_DEPTHHEIGHT_MSR, global::System.String bOT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String dEPTH_REF_POINT, global::System.String aCT_COMMENT, global::System.String bIO_ASSEMBLAGE_SAMPLED, global::System.String bIO_DURATION_MSR,
            global::System.String bIO_DURATION_MSR_UNIT, global::System.String bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, global::System.String bIO_REACH_LEN_MSR,
            global::System.String bIO_REACH_LEN_MSR_UNIT, global::System.String bIO_REACH_WID_MSR, global::System.String bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT,
            global::System.String bIO_NET_TYPE, global::System.String bIO_NET_AREA_MSR, global::System.String bIO_NET_AREA_MSR_UNIT, global::System.String bIO_NET_MESHSIZE_MSR,
            global::System.String bIO_MESHSIZE_MSR_UNIT, global::System.String bIO_BOAT_SPEED_MSR, global::System.String bIO_BOAT_SPEED_MSR_UNIT, global::System.String bIO_CURR_SPEED_MSR,
            global::System.String bIO_CURR_SPEED_MSR_UNIT, global::System.String bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_EQUIP, global::System.String sAMP_COLL_EQUIP_COMMENT,
            int? sAMP_PREP_IDX, global::System.String sAMP_PREP_CONT_TYPE, global::System.String sAMP_PREP_CONT_COLOR, global::System.String sAMP_PREP_CHEM_PRESERV, global::System.String sAMP_PREP_THERM_PRESERV,
            global::System.String sAMP_PREP_STORAGE_DESC, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system", string eNTRY_TYPE = "C")
        {
            Boolean insInd = false;
            try
            {
                TWqxActivity a = new TWqxActivity();

                if (aCTIVITY_IDX != null)
                    a = (from c in _db.TWqxActivity
                         where c.ActivityIdx == aCTIVITY_IDX
                         select c).FirstOrDefault();
                if (aCTIVITY_IDX == null) //insert case
                {
                    a = new TWqxActivity();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;
                if (pROJECT_IDX != null) a.ProjectIdx = (int)pROJECT_IDX;
                if (aCTIVITY_ID != null) a.ActivityId = aCTIVITY_ID;
                if (aCT_TYPE != null) a.ActType = aCT_TYPE;
                if (aCT_MEDIA != null) a.ActMedia = aCT_MEDIA;
                if (aCT_SUBMEDIA != null) a.ActSubmedia = aCT_SUBMEDIA;
                if (aCT_START_DT != null) a.ActStartDt = (DateTime)aCT_START_DT;
                if (aCT_END_DT != null) a.ActEndDt = (DateTime)aCT_END_DT;
                if (aCT_TIME_ZONE != null) a.ActTimeZone = aCT_TIME_ZONE;
                //put in Timezone if missing
                if (a.ActTimeZone == null)
                    a.ActTimeZone = Utils.GetWQXTimeZoneByDate(a.ActStartDt, ihttpContextAccessor);

                if (rELATIVE_DEPTH_NAME != null) a.RelativeDepthName = rELATIVE_DEPTH_NAME;
                if (aCT_DEPTHHEIGHT_MSR != null) a.ActDepthheightMsr = aCT_DEPTHHEIGHT_MSR;
                if (aCT_DEPTHHEIGHT_MSR_UNIT != null) a.ActDepthheightMsrUnit = aCT_DEPTHHEIGHT_MSR_UNIT;
                if (tOP_DEPTHHEIGHT_MSR != null) a.TopDepthheightMsr = tOP_DEPTHHEIGHT_MSR;
                if (tOP_DEPTHHEIGHT_MSR_UNIT != null) a.TopDepthheightMsrUnit = tOP_DEPTHHEIGHT_MSR_UNIT;
                if (bOT_DEPTHHEIGHT_MSR != null) a.BotDepthheightMsr = bOT_DEPTHHEIGHT_MSR;
                if (bOT_DEPTHHEIGHT_MSR_UNIT != null) a.BotDepthheightMsrUnit = bOT_DEPTHHEIGHT_MSR_UNIT;
                if (dEPTH_REF_POINT != null) a.DepthRefPoint = dEPTH_REF_POINT;
                if (aCT_COMMENT != null) a.ActComment = aCT_COMMENT;
                if (bIO_ASSEMBLAGE_SAMPLED != null) a.BioAssemblageSampled = bIO_ASSEMBLAGE_SAMPLED;
                if (bIO_DURATION_MSR != null) a.BioDurationMsr = bIO_DURATION_MSR;
                if (bIO_DURATION_MSR_UNIT != null) a.BioDurationMsrUnit = bIO_DURATION_MSR_UNIT;
                if (bIO_SAMP_COMPONENT != null) a.BioSampComponent = bIO_SAMP_COMPONENT;
                if (bIO_SAMP_COMPONENT_SEQ != null) a.BioSampComponentSeq = bIO_SAMP_COMPONENT_SEQ;
                if (bIO_REACH_LEN_MSR != null) a.BioReachLenMsr = bIO_REACH_LEN_MSR;
                if (bIO_REACH_LEN_MSR_UNIT != null) a.BioReachLenMsrUnit = bIO_REACH_LEN_MSR_UNIT;
                if (bIO_REACH_WID_MSR != null) a.BioReachWidMsr = bIO_REACH_WID_MSR;
                if (bIO_REACH_WID_MSR_UNIT != null) a.BioReachWidMsrUnit = bIO_REACH_WID_MSR_UNIT;
                if (bIO_PASS_COUNT != null) a.BioPassCount = bIO_PASS_COUNT;
                if (bIO_NET_TYPE != null) a.BioNetType = bIO_NET_TYPE;
                if (bIO_NET_AREA_MSR != null) a.BioNetAreaMsr = bIO_NET_AREA_MSR;
                if (bIO_NET_AREA_MSR_UNIT != null) a.BioNetAreaMsrUnit = bIO_NET_AREA_MSR_UNIT;
                if (bIO_NET_MESHSIZE_MSR != null) a.BioNetMeshsizeMsr = bIO_NET_MESHSIZE_MSR;
                if (bIO_MESHSIZE_MSR_UNIT != null) a.BioMeshsizeMsrUnit = bIO_MESHSIZE_MSR_UNIT;
                if (bIO_BOAT_SPEED_MSR != null) a.BioBoatSpeedMsr = bIO_BOAT_SPEED_MSR;
                if (bIO_BOAT_SPEED_MSR_UNIT != null) a.BioBoatSpeedMsrUnit = bIO_BOAT_SPEED_MSR_UNIT;
                if (bIO_CURR_SPEED_MSR != null) a.BioCurrSpeedMsr = bIO_CURR_SPEED_MSR;
                if (bIO_CURR_SPEED_MSR_UNIT != null) a.BioCurrSpeedMsrUnit = bIO_CURR_SPEED_MSR_UNIT;
                if (bIO_TOXICITY_TEST_TYPE != null) a.BioToxicityTestType = bIO_TOXICITY_TEST_TYPE;
                if (sAMP_COLL_METHOD_IDX != null) a.SampCollMethodIdx = sAMP_COLL_METHOD_IDX;
                if (sAMP_COLL_EQUIP != null) a.SampCollEquip = sAMP_COLL_EQUIP;
                if (sAMP_COLL_EQUIP_COMMENT != null) a.SampCollEquipComment = sAMP_COLL_EQUIP_COMMENT;
                if (sAMP_PREP_IDX != null) a.SampPrepIdx = sAMP_PREP_IDX;
                if (sAMP_PREP_CONT_TYPE != null) a.SampPrepContType = sAMP_PREP_CONT_TYPE;
                if (sAMP_PREP_CONT_COLOR != null) a.SampPrepContColor = sAMP_PREP_CONT_COLOR;
                if (sAMP_PREP_CHEM_PRESERV != null) a.SampPrepChemPreserv = sAMP_PREP_CHEM_PRESERV;
                if (sAMP_PREP_THERM_PRESERV != null) a.SampPrepThermPreserv = sAMP_PREP_THERM_PRESERV;
                if (sAMP_PREP_STORAGE_DESC != null) a.SampPrepStorageDesc = sAMP_PREP_STORAGE_DESC;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;
                if (eNTRY_TYPE != null) a.EntryType = eNTRY_TYPE;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxActivity.Add(a);
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                    _db.TWqxActivity.Update(a);
                }

                _db.SaveChanges();

                return a.ActivityIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int UpdateWQX_ACTIVITY_WQXStatus(global::System.Int32? aCTIVITY_IDX, global::System.String wQX_SUBMIT_STATUS, Boolean? aCT_IND, Boolean? wQX_IND, String cREATE_USER = "system")
        {
            try
            {
                TWqxActivity a = (from c in _db.TWqxActivity
                                    where c.ActivityIdx == aCTIVITY_IDX
                                    select c).FirstOrDefault();

                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;
                a.UpdateUserid = cREATE_USER.ToUpper();
                a.UpdateDt = System.DateTime.Now;
                _db.TWqxActivity.Update(a);
                _db.SaveChanges();

                return a.ActivityIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int UpdateWQX_ACTIVITY_EntryType(global::System.Int32? aCTIVITY_IDX, string eNTRY_TYPE)
        {
            try
            {
                TWqxActivity a = (from c in _db.TWqxActivity
                                    where c.ActivityIdx == aCTIVITY_IDX
                                    select c).FirstOrDefault();

                if (a != null)
                    if (eNTRY_TYPE != null) a.EntryType = eNTRY_TYPE;
                _db.TWqxActivity.Update(a);
                _db.SaveChanges();

                return a.ActivityIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxActivity> GetWQX_ACTIVITY(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where (ActInd ? a.ActInd == true : true)
                        && a.OrgId == OrgID
                        && (WQXPending ? a.WqxSubmitStatus == "U" : true)
                        && (WQXPending ? a.WqxInd == true : true)
                        && (MonLocIDX == null ? true : a.MonlocIdx == MonLocIDX)
                        && (startDt == null ? true : a.ActStartDt >= startDt)
                        && (endDt == null ? true : a.ActStartDt <= endDt)
                        && (ActType == null ? true : a.ActType == ActType)
                        && (ProjectIDX == null ? true : a.ProjectIdx == ProjectIDX)
                        orderby a.ActEndDt descending
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ActivityListDisplay> GetWQX_ACTIVITYDisplay(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX, string WQXStatus)
        {
            try
            {
                var query = (from a in _db.TWqxActivity
                             join p in _db.TWqxProject on a.ProjectIdx equals p.ProjectIdx
                             join m in _db.TWqxMonloc on a.MonlocIdx equals m.MonlocIdx
                             where (ActInd ? a.ActInd == true : true)
                             && a.OrgId == OrgID
                             && (WQXPending ? a.WqxSubmitStatus == "U" : true)
                             && (WQXPending ? a.WqxInd == true : true)
                             && (MonLocIDX == null ? true : a.MonlocIdx == MonLocIDX)
                             && (startDt == null ? true : a.ActStartDt >= startDt)
                             && (endDt == null ? true : a.ActStartDt <= endDt)
                             && (ActType == null ? true : a.ActType == ActType)
                             && (ProjectIDX == null ? true : a.ProjectIdx == ProjectIDX)
                             && (WQXStatus == "" ? true : (a.WqxInd == true && a.WqxSubmitStatus == WQXStatus))
                             orderby a.ActStartDt descending, a.ActivityIdx descending
                             select new ActivityListDisplay
                             {
                                 ACTIVITY_IDX = a.ActivityIdx,
                                 ORG_ID = a.OrgId,
                                 PROJECT_ID = p.ProjectId,
                                 MONLOC_ID = m.MonlocId,
                                 ACTIVITY_ID = a.ActivityId,
                                 ACT_TYPE = a.ActType,
                                 ACT_MEDIA = a.ActMedia,
                                 ACT_SUBMEDIA = a.ActSubmedia,
                                 ACT_START_DT = a.ActStartDt,
                                 ACT_END_DT = a.ActEndDt,
                                 ACT_DEPTHHEIGHT_MSR = a.ActDepthheightMsr,
                                 ACT_DEPTHHEIGHT_MSR_UNIT = a.ActDepthheightMsrUnit,
                                 TOP_DEPTHHEIGHT_MSR = a.TopDepthheightMsr,
                                 BOT_DEPTHHEIGHT_MSR = a.BotDepthheightMsr,
                                 DEPTH_REF_POINT = a.DepthRefPoint,
                                 ACT_COMMENT = a.ActComment,
                                 SAMP_COLL_METHOD = null,
                                 SAMP_COLL_EQUIP = a.SampCollEquip,
                                 SAMP_COLL_EQUIP_COMMENT = a.SampCollEquipComment,
                                 SAMP_PREP_METHOD = null,
                                 WQX_IND = a.WqxInd,
                                 WQX_SUBMIT_STATUS = a.WqxSubmitStatus,
                                 ACT_IND = a.ActInd
                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxActivity GetWQX_ACTIVITY_ByID(int ActivityIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.ActivityIdx == ActivityIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxActivity GetWQX_ACTIVITY_ByUnique(string OrgID, string ActivityID)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.ActivityId == ActivityID
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_ACTIVITYByMonLocID(int MonLocIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.MonlocIdx == MonLocIDX
                        && a.ActInd == true
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_ACTIVITYByProjectID(int ProjectIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        where a.ProjectIdx == ProjectIDX
                        && a.ActInd == true
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_ACTIVITY(int ActivityIDX, string UserID)
        {
            try
            {
                TWqxActivity a = db_WQX.GetWQX_ACTIVITY_ByID(ActivityIDX);
                if (a != null)
                {
                    if (a.ActInd == false && (a.WqxInd == false || a.WqxSubmitStatus != "U"))
                    {
                        //only actually delete record from database if it has already been set to inactive and WQX status is not pending ("U")
                        string sql = "DELETE FROM T_WQX_ACTIVITY WHERE ACTIVITY_IDX = " + ActivityIDX;
                        int result = _db.Database.ExecuteSqlCommand(sql, null);
                        return 1;
                    }
                    else
                    {
                        //mark as inactive (deleted), which will send the delete request to EPA-WQX
                        UpdateWQX_ACTIVITY_WQXStatus(ActivityIDX, "U", false, null, UserID);
                        return 1;
                    }

                }
                else
                    return 0;
            }
            catch
            {
                return 0;
            }

        }

        public static int GetWQX_ACTIVITY_MyOrgCount(int UserIDX)
        {
            try
            {
                return (from a in _db.TWqxActivity
                        join b in _db.TWqxUserOrgs on a.OrgId equals b.OrgId
                        where b.UserIdx == UserIDX
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // *************************** ACTIVITY METRICS*************************
        // *********************************************************************
        public static int InsertOrUpdateWQX_ACTIVITY_METRIC(global::System.Int32? aCTIVITY_METRIC_IDX, global::System.Int32 aCTIVITY_IDX, global::System.String mETRIC_TYPE_ID,
            global::System.String mETRIC_TYPE_ID_CONTEXT, global::System.String mETRIC_TYPE_NAME, global::System.String cITATION_TITLE, global::System.String cITATION_CREATOR,
            global::System.String cITATION_SUBJECT, global::System.String cITATION_PUBLISHER, global::System.DateTime? cITATION_DATE, global::System.String cITATION_ID,
            global::System.String mETRIC_SCALE, global::System.String mETRIC_FORMULA_DESC, global::System.String mETRIC_VALUE_MSR, global::System.String mETRIC_VALUE_MSR_UNIT,
            global::System.String mETRIC_SCORE, global::System.String mETRIC_COMMENT, Boolean? wQX_IND, global::System.String wQX_SUBMIT_STATUS, DateTime? WQX_UPDATE_DT, Boolean? aCT_IND, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TWqxActivityMetric a = new TWqxActivityMetric();

                if (aCTIVITY_METRIC_IDX != null)
                    a = (from c in _db.TWqxActivityMetric
                         where c.ActivityMetricIdx == aCTIVITY_METRIC_IDX
                         select c).FirstOrDefault();
                if (aCTIVITY_METRIC_IDX == null) //insert case
                {
                    a = new TWqxActivityMetric();
                    insInd = true;
                }

                a.ActivityIdx = aCTIVITY_IDX;
                if (mETRIC_TYPE_ID != null) a.MetricTypeId = mETRIC_TYPE_ID;
                if (mETRIC_TYPE_ID_CONTEXT != null) a.MetricTypeIdContext = mETRIC_TYPE_ID_CONTEXT;
                if (mETRIC_TYPE_NAME != null) a.MetricTypeName = mETRIC_TYPE_NAME;
                if (cITATION_TITLE != null) a.CitationTitle = cITATION_TITLE;
                if (cITATION_CREATOR != null) a.CitationCreator = cITATION_CREATOR;
                if (cITATION_SUBJECT != null) a.CitationSubject = cITATION_SUBJECT;
                if (cITATION_PUBLISHER != null) a.CitationPublisher = cITATION_PUBLISHER;
                if (cITATION_DATE != null) a.CitationDate = (DateTime)cITATION_DATE;
                if (cITATION_ID != null) a.CitationId = cITATION_ID;
                if (mETRIC_SCALE != null) a.MetricScale = mETRIC_SCALE;
                if (mETRIC_FORMULA_DESC != null) a.MetricFormulaDesc = mETRIC_FORMULA_DESC;
                if (mETRIC_VALUE_MSR != null) a.MetricValueMsr = mETRIC_VALUE_MSR;
                if (mETRIC_VALUE_MSR_UNIT != null) a.MetricValueMsrUnit = mETRIC_VALUE_MSR_UNIT;
                if (mETRIC_SCORE != null) a.MetricScore = mETRIC_SCORE;
                if (mETRIC_COMMENT != null) a.MetricComment = mETRIC_COMMENT;
                if (wQX_IND != null) a.WqxInd = wQX_IND;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (WQX_UPDATE_DT != null) a.WqxUpdateDt = WQX_UPDATE_DT;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxActivityMetric.Add(a);
                    
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                    _db.TWqxActivityMetric.Update(a);
                }

                _db.SaveChanges();

                return a.ActivityMetricIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        // *************************** BIO INDICES******************************
        // *********************************************************************
        public static int InsertOrUpdateWQX_BIO_HABITAT_INDEX(global::System.Int32? bIO_HABITAT_INDEX_IDX, global::System.String oRG_ID, global::System.Int32? mONLOC_IDX,
            global::System.String iNDEX_ID, global::System.String iNDEX_TYPE_ID, global::System.String iNDEX_TYPE_ID_CONTEXT, global::System.String INDEX_TYPE_NAME,
            global::System.String rESOURCE_TITLE, global::System.String rESOURCE_CREATOR, global::System.String rESOURCE_SUBJECT, global::System.String rESOURCE_PUBLISHER,
            global::System.DateTime? rESOURCE_DATE, global::System.String rESOURCE_ID, global::System.String iNDEX_TYPE_SCALE, global::System.String iNDEX_SCORE, global::System.String iNDEX_QUAL_CD,
            global::System.String iNDEX_COMMENT, global::System.DateTime? iNDEX_CALC_DATE, Boolean? wQX_IND, global::System.String wQX_SUBMIT_STATUS, DateTime? WQX_UPDATE_DT, Boolean? aCT_IND, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TWqxBioHabitatIndex a = new TWqxBioHabitatIndex();

                if (bIO_HABITAT_INDEX_IDX != null)
                    a = (from c in _db.TWqxBioHabitatIndex
                         where c.BioHabitatIndexIdx == bIO_HABITAT_INDEX_IDX
                         select c).FirstOrDefault();
                if (bIO_HABITAT_INDEX_IDX == null) //insert case
                {
                    a = new TWqxBioHabitatIndex();
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;
                if (iNDEX_ID != null) a.IndexId = iNDEX_ID;
                if (iNDEX_TYPE_ID != null) a.IndexTypeId = iNDEX_TYPE_ID;
                if (iNDEX_TYPE_ID_CONTEXT != null) a.IndexTypeIdContext = iNDEX_TYPE_ID_CONTEXT;
                if (INDEX_TYPE_NAME != null) a.IndexTypeName = INDEX_TYPE_NAME;
                if (rESOURCE_TITLE != null) a.ResourceTitle = rESOURCE_TITLE;
                if (rESOURCE_CREATOR != null) a.ResourceCreator = rESOURCE_CREATOR;
                if (rESOURCE_SUBJECT != null) a.ResourceSubject = rESOURCE_SUBJECT;
                if (rESOURCE_PUBLISHER != null) a.ResourcePublisher = rESOURCE_PUBLISHER;
                if (rESOURCE_DATE != null) a.ResourceDate = (DateTime)rESOURCE_DATE;
                if (rESOURCE_ID != null) a.ResourceId = rESOURCE_ID;
                if (iNDEX_TYPE_SCALE != null) a.IndexTypeScale = iNDEX_TYPE_SCALE;
                if (iNDEX_SCORE != null) a.IndexScore = iNDEX_SCORE;
                if (iNDEX_QUAL_CD != null) a.IndexQualCd = iNDEX_QUAL_CD;
                if (iNDEX_COMMENT != null) a.IndexComment = iNDEX_COMMENT;
                if (iNDEX_CALC_DATE != null) a.IndexCalcDate = iNDEX_CALC_DATE;
                if (wQX_SUBMIT_STATUS != null) a.WqxSubmitStatus = wQX_SUBMIT_STATUS;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wQX_IND != null) a.WqxInd = wQX_IND;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxBioHabitatIndex.Add(a);
                    
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                    _db.TWqxBioHabitatIndex.Update(a);
                }
                
                _db.SaveChanges();

                return a.BioHabitatIndexIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        // *************************** RESULTS    ******************************
        // *********************************************************************
        public static List<TWqxResult> GetT_WQX_RESULT(int ActivityIDX)
        {
            try
            {
                return (from a in _db.TWqxResult
                        .Include("T_WQX_REF_ANAL_METHOD")
                        where a.ActivityIdx == ActivityIDX
                        orderby a.CharName ascending
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxResult GetT_WQX_RESULT_ByIDX(int ResultIDX)
        {
            try
            {
                return (from a in _db.TWqxResult
                        where a.ResultIdx == ResultIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetT_WQX_RESULTCount(string OrgID)
        {
            try
            {
                return (from r in _db.TWqxResult
                        join a in _db.TWqxActivity on r.ActivityIdx equals a.ActivityIdx
                        where a.OrgId == OrgID
                        select r).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_RESULT(int ResultIDX)
        {
            try
            {
                TWqxResult r = new TWqxResult();
                r = (from c in _db.TWqxResult where c.ResultIdx == ResultIDX select c).FirstOrDefault();
                _db.TWqxResult.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int InsertOrUpdateT_WQX_RESULT(global::System.Int32? rESULT_IDX, global::System.Int32 aCTIVITY_IDX, global::System.String rESULT_DETECT_CONDITION,
            global::System.String cHAR_NAME, global::System.String rESULT_SAMP_FRACTION, global::System.String rESULT_MSR, global::System.String rESULT_MSR_UNIT,
            global::System.String rESULT_STATUS, global::System.String rESULT_VALUE_TYPE, global::System.String rESULT_COMMENT,
            global::System.String bIO_INTENT_NAME, global::System.String bIO_INDIVIDUAL_ID, global::System.String bIO_TAXONOMY, global::System.String bIO_SAMPLE_TISSUE_ANATOMY,
            global::System.Int32? aNALYTIC_METHOD_IDX, int? lAB_IDX, DateTime? lAB_ANALYSIS_START_DT, global::System.String dETECTION_LIMIT, global::System.String pQL,
            global::System.String lOWER_QUANT_LIMIT, global::System.String uPPER_QUANT_LIMIT, int? lAB_SAMP_PREP_IDX, DateTime? lAB_SAMP_PREP_START_DT, string dILUTION_FACTOR,
            string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT,
            String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TWqxResult a = new TWqxResult();

                if (rESULT_IDX != null)
                    a = (from c in _db.TWqxResult
                         where c.ResultIdx == rESULT_IDX
                         select c).FirstOrDefault();

                if (a == null)
                    a = new TWqxResult();

                if (a.ResultIdx == 0) //insert case
                    insInd = true;

                a.ActivityIdx = aCTIVITY_IDX;

                if (rESULT_DETECT_CONDITION != null) a.ResultDetectCondition = rESULT_DETECT_CONDITION;
                if (cHAR_NAME != null) a.CharName = cHAR_NAME;

                if (rESULT_SAMP_FRACTION != null) a.ResultSampFraction = rESULT_SAMP_FRACTION;
                if (rESULT_MSR != null) a.ResultMsr = rESULT_MSR;
                if (rESULT_MSR_UNIT != null) a.ResultMsrUnit = rESULT_MSR_UNIT;
                if (rESULT_STATUS != null) a.ResultStatus = rESULT_STATUS;
                if (rESULT_VALUE_TYPE != null) a.ResultValueType = rESULT_VALUE_TYPE;
                if (rESULT_COMMENT != null) a.ResultComment = rESULT_COMMENT;
                if (bIO_INTENT_NAME != null) a.BioIntentName = bIO_INTENT_NAME;
                if (bIO_INDIVIDUAL_ID != null) a.BioIndividualId = bIO_INDIVIDUAL_ID;
                if (bIO_TAXONOMY != null) a.BioSubjectTaxonomy = bIO_TAXONOMY;
                if (bIO_SAMPLE_TISSUE_ANATOMY != null) a.BioSampleTissueAnatomy = bIO_SAMPLE_TISSUE_ANATOMY;
                if (aNALYTIC_METHOD_IDX != null) a.AnalyticMethodIdx = aNALYTIC_METHOD_IDX;
                if (lAB_IDX != null) a.LabIdx = lAB_IDX;
                if (lAB_ANALYSIS_START_DT != null) a.LabAnalysisStartDt = lAB_ANALYSIS_START_DT;
                if (dETECTION_LIMIT != null) a.DetectionLimit = dETECTION_LIMIT;
                if (pQL != null) a.Pql = pQL;
                if (lOWER_QUANT_LIMIT != null) a.LowerQuantLimit = lOWER_QUANT_LIMIT;
                if (uPPER_QUANT_LIMIT != null) a.UpperQuantLimit = uPPER_QUANT_LIMIT;
                if (lAB_SAMP_PREP_IDX != null) a.LabSampPrepIdx = lAB_SAMP_PREP_IDX;
                if (lAB_SAMP_PREP_START_DT != null) a.LabSampPrepStartDt = lAB_SAMP_PREP_START_DT;
                if (dILUTION_FACTOR != null) a.DilutionFactor = dILUTION_FACTOR;
                if (fREQ_CLASS_CODE != null) a.FreqClassCode = fREQ_CLASS_CODE;
                if (fREQ_CLASS_UNIT != null) a.FreqClassUnit = fREQ_CLASS_UNIT;
                //set freq class unit to count if not provided
                if (fREQ_CLASS_UNIT == null && fREQ_CLASS_CODE != null) fREQ_CLASS_UNIT = "count";

                if (insInd) //insert case
                {
                    _db.TWqxResult.Add(a);
                }
                else
                {
                    _db.TWqxResult.Update(a);
                }

                _db.SaveChanges();

                return a.ResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<CharDisplay> GetT_WQX_RESULT_SampledCharacteristics(string OrgID)
        {
            try
            {
                var xxx = (from r in _db.TWqxResult
                           join a in _db.TWqxActivity on r.ActivityIdx equals a.ActivityIdx
                           where a.OrgId == OrgID
                           //&&  System.Data.Objects.SqlClient.SqlFunctions.IsNumeric(r.ResultMsr) == 1
                           && r.ResultMsr == "1"
                           select new CharDisplay
                           {
                               CHAR_NAME = r.CharName
                           }).Distinct().OrderBy(x => x.CHAR_NAME).ToList();


                return xxx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // *************************** ORGANIZATION*****************************
        // *********************************************************************
        public static List<TWqxOrganization> GetWQX_ORGANIZATION()
        {
            try
            {
                return (from a in _db.TWqxOrganization
                        orderby a.OrgFormalName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<string> GetWQX_ORGANIZATION_PendingDataToSubmit()
        {
            try
            {
                var x = (from m in _db.TWqxMonloc
                         join o in _db.TWqxOrganization on m.OrgId equals o.OrgId
                         where o.CdxSubmitInd == true
                         && m.WqxSubmitStatus == "U"
                         && m.WqxInd == true
                         select m.OrgId).Union
                         (from a in _db.TWqxActivity
                          join o in _db.TWqxOrganization on a.OrgId equals o.OrgId
                          where o.CdxSubmitInd == true
                          && a.WqxSubmitStatus == "U"
                          && a.WqxInd == true
                          select a.OrgId).Union
                          (from p in _db.TWqxProject
                           join o in _db.TWqxOrganization on p.OrgId equals o.OrgId
                           where o.CdxSubmitInd == true
                           && p.WqxSubmitStatus == "U"
                           && p.WqxInd == true
                           select p.OrgId);

                return x.Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxOrganization GetWQX_ORGANIZATION_ByID(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxOrganization
                        where a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS,
            string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID,
            string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null,
            string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null)
        {
            Boolean insInd = false;
            try
            {
                TWqxOrganization a = new TWqxOrganization();

                if (oRG_ID != null)
                    a = (from c in _db.TWqxOrganization
                         where c.OrgId == oRG_ID
                         select c).FirstOrDefault();

                if (a == null) //insert case
                {
                    a = new TWqxOrganization();
                    insInd = true;
                    a.OrgId = oRG_ID;
                }

                if (oRG_NAME != null) a.OrgFormalName = oRG_NAME;
                if (oRG_DESC != null) a.OrgDesc = oRG_DESC;
                if (tRIBAL_CODE != null) a.TribalCode = tRIBAL_CODE;
                if (eLECTRONIC_ADDRESS != null) a.Electronicaddress = eLECTRONIC_ADDRESS;
                if (eLECTRONICADDRESSTYPE != null) a.Electronicaddresstype = eLECTRONICADDRESSTYPE;
                if (tELEPHONE_NUM != null) a.TelephoneNum = tELEPHONE_NUM;
                if (tELEPHONE_NUM_TYPE != null) a.TelephoneNumType = tELEPHONE_NUM_TYPE;
                if (TELEPHONE_EXT != null) a.TelephoneExt = TELEPHONE_EXT;
                if (dEFAULT_TIMEZONE != null) a.DefaultTimezone = dEFAULT_TIMEZONE;
                if (cDX_SUBMITTER_ID != null) a.CdxSubmitterId = cDX_SUBMITTER_ID;
                if (cDX_SUBMIT_IND != null) a.CdxSubmitInd = cDX_SUBMIT_IND;
                if (cDX_SUBMITTER_PWD != null && cDX_SUBMITTER_PWD != "--------")
                {
                    //encrypt CDX submitter password for increased security
                    string encryptOauth = new SimpleAES().Encrypt(cDX_SUBMITTER_PWD);
                    encryptOauth = System.Web.HttpUtility.UrlEncode(encryptOauth);
                    a.CdxSubmitterPwdHash = encryptOauth;
                }
                if (dEFAULT_TIMEZONE != null) a.DefaultTimezone = dEFAULT_TIMEZONE;
                if (mAIL_ADDRESS != null) a.MailingAddress = mAIL_ADDRESS;
                if (mAIL_ADD_CITY != null) a.MailingAddCity = mAIL_ADD_CITY;
                if (mAIL_ADD_STATE != null) a.MailingAddState = mAIL_ADD_STATE;
                if (mAIL_ADD_ZIP != null) a.MailingAddZip = mAIL_ADD_ZIP;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxOrganization.Add(a);
                    
                }
                else
                {
                    a.UpdateUserid = cREATE_USER.ToUpper();
                    a.UpdateDt = System.DateTime.Now;
                    _db.TWqxOrganization.Update(a);
                }

                _db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        // ***************************** T_EPA_ORGS ******************************
        // *********************************************************************
        public static int DeleteT_EPA_ORGS()
        {
            try
            {
                string sql = "DELETE FROM T_EPA_ORGS";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static int InsertOrUpdateT_EPA_ORGS(global::System.String oRG_ID, global::System.String oRG_NAME)
        {
            try
            {

                TEpaOrgs a = new TEpaOrgs();
                a.OrgId = oRG_ID;
                if (oRG_NAME != null) a.OrgFormalName = oRG_NAME;
                a.UpdateDt = System.DateTime.Now;
                _db.TEpaOrgs.Add(a);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static TEpaOrgs GetT_EPA_ORGS_ByOrgID(string OrgID)
        {
            try
            {
                return (from a in _db.TEpaOrgs
                        where a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DateTime? GetT_EPA_ORGS_LastUpdateDate()
        {
            try
            {
                return (from a in _db.TEpaOrgs
                        select a.UpdateDt).Max();
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        // *************************** V_WQX_ALL_ORGS   ************************
        // *********************************************************************
        public static List<VWqxAllOrgs> GetV_WQX_ALL_ORGS()
        {
            try
            {
                
                return (from a in _db.VWqxAllOrgs
                        orderby a.OrgFormalName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // *************************** V_WQX_PENDING_RECORDS   ************************
        // *********************************************************************
        public static List<VWqxPendingRecords> GetV_WQX_PENDING_RECORDS(string OrgID, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                
                return (from a in _db.VWqxPendingRecords
                        where (OrgID != null ? a.OrgId == OrgID : true)
                        && (startDate != null ? a.UpdateDt >= startDate : true)
                        && (endDate != null ? a.UpdateDt <= endDate : true)
                        orderby a.TableCd, a.UpdateDt
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // *************************** USER ORGANIZATION************************
        // *********************************************************************
        public static List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd)
        {
            try
            {

                return (from a in _db.TWqxUserOrgs
                        join b in _db.TWqxOrganization on a.OrgId equals b.OrgId
                        where a.UserIdx == UserIDX
                        && (excludePendingInd == true ? a.RoleCd != "P" : true)
                        select b).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertT_WQX_USER_ORGS(global::System.String oRG_ID, global::System.Int32 uSER_IDX, string rOLE_CD, String cREATE_USER = "system")
        {
            try
            {

                TWqxUserOrgs a = new TWqxUserOrgs();

                a.OrgId = oRG_ID;
                a.UserIdx = uSER_IDX;
                if (rOLE_CD != null) a.RoleCd = rOLE_CD;
                a.CreateUserid = cREATE_USER.ToUpper();
                a.CreateDt = System.DateTime.Now;
                _db.TWqxUserOrgs.Add(a);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_WQX_USER_ORGS(global::System.String oRG_ID, global::System.Int32 uSER_IDX)
        {
            try
            {

                TWqxUserOrgs r = new TWqxUserOrgs();
                r = (from c in _db.TWqxUserOrgs where c.UserIdx == uSER_IDX && c.OrgId == oRG_ID select c).FirstOrDefault();
                _db.TWqxUserOrgs.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int ApproveRejectT_WQX_USER_ORGS(global::System.String oRG_ID, global::System.Int32 uSER_IDX, string ApproveRejectCode)
        {
            //ApproveRejectCode = U (for user approve) A (for Admin approve) or R (for reject)
            try
            {
                if (ApproveRejectCode == "R")
                {
                    DeleteT_WQX_USER_ORGS(oRG_ID, uSER_IDX);
                    return -1;
                }
                else
                {

                    TWqxUserOrgs a = (from c in _db.TWqxUserOrgs
                                      where c.UserIdx == uSER_IDX
                                         && c.OrgId == oRG_ID
                                         select c).FirstOrDefault();

                    if (a == null)
                        return 0;

                    a.RoleCd = ApproveRejectCode;
                    _db.TWqxUserOrgs.Update(a);
                    _db.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public static List<UserOrgDisplay> GetT_OE_USERSInOrganization(string OrgID)
        {
            try
            {
                return (from u in _db.TOeUsers
                        join uo in _db.TWqxUserOrgs on u.UserIdx equals uo.UserIdx
                        where uo.OrgId == OrgID
                        //orderby u.USER_ID
                        select new UserOrgDisplay
                        {
                            USER_IDX = u.UserIdx,
                            USER_ID = u.UserId,
                            USER_NAME = u.Fname + " " + u.Lname,
                            ORG_ID = uo.OrgId,
                            ROLE_CD = uo.RoleCd
                        }).ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TOeUsers> GetT_OE_USERSNotInOrganization(string OrgID)
        {
            try
            {
                //first get all users 
                var allUsers = (from itemA in _db.TOeUsers select itemA);

                //next get all users in role
                var UsersInRole = (from itemA in _db.TOeUsers
                                   join itemB in _db.TWqxUserOrgs on itemA.UserIdx equals itemB.UserIdx
                                   where itemB.OrgId == OrgID
                                   select itemA);

                //then get exclusions
                var usersNotInRole = allUsers.Except(UsersInRole);

                return usersNotInRole.OrderBy(a => a.UserId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<UserOrgDisplay> GetT_OE_USERSPending(string OrgID)
        {
            try
            {
                return (from u in _db.TOeUsers
                        join uo in _db.TWqxUserOrgs on u.UserIdx equals uo.UserIdx
                        where uo.RoleCd == "P"
                        && (OrgID == null ? true : uo.OrgId == OrgID)
                        select new UserOrgDisplay
                        {
                            USER_IDX = u.UserIdx,
                            USER_ID = u.UserId,
                            USER_NAME = u.Fname + " " + u.Lname,
                            ORG_ID = uo.OrgId
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TOeUsers> GetWQX_USER_ORGS_AdminsByOrg(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxUserOrgs
                        join b in _db.TOeUsers on a.UserIdx equals b.UserIdx
                        where a.OrgId == OrgID
                        && a.RoleCd != "P"
                        select b).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxUserOrgs GetWQX_USER_ORGS_ByUserIDX_OrgID(int UserIDX, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxUserOrgs
                        where a.UserIdx == UserIDX
                        && a.OrgId == OrgID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CanUserEditOrg(int UserIDX, string OrgID)
        {
            try
            {
                var xxx = (from a in _db.TWqxUserOrgs
                           where a.UserIdx == UserIDX
                           && a.OrgId == OrgID
                           && (a.RoleCd == "A" || a.RoleCd == "U")
                           select a).Count();

                return xxx > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool CanUserAdminOrgs(int UserIDX)
        {
            try
            {
                var xxx = (from a in _db.TWqxUserOrgs
                           where a.UserIdx == UserIDX
                           && (a.RoleCd == "A")
                           select a).Count();

                return xxx > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Sets access to all organizations to inactive for a given user 
        /// </summary>
        /// <param name="uSER_IDX"></param>
        public static void DeleteT_WQX_USER_ORGS_AllByUserIDX(int uSER_IDX)
        {
            try
            {
                //first get all users 
                var xxx = (from itemA in _db.TWqxUserOrgs
                           where itemA.UserIdx == uSER_IDX
                           select itemA);

                // now use First or a loop if you expect multiple
                //TODO: fix every call to delete also called SaveChanges
                foreach (var user_org in xxx)
                {
                    DeleteT_WQX_USER_ORGS(user_org.OrgId, user_org.UserIdx);
                }

                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                return;
            }
            return;
        }


        // *************************** IMPORT_TEMPLATE    ******************************
        // *****************************************************************************
        public static int InsertOrUpdateWQX_IMPORT_TEMPLATE(global::System.Int32? tEMPLATE_ID, global::System.String oRG_ID, string tYPE_CD, string tEMPLATE_NAME, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTemplate a = new TWqxImportTemplate();

                if (tEMPLATE_ID != null)
                    a = (from c in _db.TWqxImportTemplate
                         where c.TemplateId == tEMPLATE_ID
                         select c).FirstOrDefault();

                if (tEMPLATE_ID == null) //insert case
                    insInd = true;

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (tYPE_CD != null) a.TypeCd = tYPE_CD;
                if (tEMPLATE_NAME != null) a.TemplateName = tEMPLATE_NAME;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = cREATE_USER;
                    _db.TWqxImportTemplate.Add(a);
                }
                else
                {
                    _db.TWqxImportTemplate.Update(a);
                }

                _db.SaveChanges();

                return a.TemplateId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxImportTemplate> GetWQX_IMPORT_TEMPLATE(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplate
                        where a.OrgId == OrgID
                        orderby a.TemplateId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_IMPORT_TEMPLATE(int TemplateID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMPLATE WHERE TEMPLATE_ID = " + TemplateID;
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }

        }



        // *************************** IMPORT_TEMPLATE_DTL    ******************************
        // *****************************************************************************
        public static TWqxImportTemplateDtl GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(int TemplateID, string FieldMap)
        {
            try
            {

                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == FieldMap
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == "CHAR"
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_DynamicByTemplateID(int TemplateID)
        {
            try
            {
                
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.ColNum > 0
                        orderby a.ColNum
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_HardCodeByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.ColNum == 0
                        orderby a.TemplateDtlId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_IMPORT_TEMPLATE_DTL(int TemplateDtlID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMPLATE_DTL WHERE TEMPLATE_DTL_ID = " + TemplateDtlID;
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int InsertOrUpdateWQX_IMPORT_TEMPLATE_DTL(global::System.Int32? tEMPLATE_DTL_ID, global::System.Int32? tEMPLATE_ID, global::System.Int32? cOL_NUM, global::System.String fIELD_MAP,
            string cHAR_NAME, string cHAR_DEFAULT_UNIT, String cREATE_USER = "system", string cHAR_DEFAULT_SAMP_FRACTION = null)
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTemplateDtl a = new TWqxImportTemplateDtl();

                if (tEMPLATE_ID != null)
                    a = (from c in _db.TWqxImportTemplateDtl
                         where c.TemplateDtlId == tEMPLATE_DTL_ID
                         select c).FirstOrDefault();

                if (a == null) //insert case
                {
                    insInd = true;
                    a = new TWqxImportTemplateDtl();
                }

                if (tEMPLATE_ID != null) a.TemplateId = tEMPLATE_ID.ConvertOrDefault<int>();
                if (cOL_NUM != null) a.ColNum = cOL_NUM.ConvertOrDefault<int>();
                if (fIELD_MAP != null) a.FieldMap = fIELD_MAP;
                if (cHAR_NAME != null) a.CharName = cHAR_NAME;
                if (cHAR_DEFAULT_UNIT != null) a.CharDefaultUnit = cHAR_DEFAULT_UNIT;
                if (cHAR_DEFAULT_SAMP_FRACTION != null) a.CharDefaultSampFraction = cHAR_DEFAULT_SAMP_FRACTION;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = cREATE_USER;
                    _db.TWqxImportTemplateDtl.Add(a);
                }
                else
                {
                    _db.TWqxImportTemplateDtl.Update(a);
                }

                _db.SaveChanges();

                return a.TemplateDtlId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        // *************************** IMPORT_TRANSLATE   ******************************
        // *****************************************************************************
        public static Dictionary<string, string> GetWQX_IMPORT_TRANSLATE_byColName(string OrgID, string ColName)
        {
            try
            {
                var translators = (from a in _db.TWqxImportTranslate
                                   where a.ColName == ColName
                                   && a.OrgId == OrgID
                                   select a).ToList();

                var xxx = translators.ToDictionary(DataFrom => DataFrom.DataFrom, DataTo => DataTo.DataTo);
                return xxx;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<string> GetWQX_IMPORT_TRANSLATE_byColName(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTranslate
                        where a.OrgId == OrgID
                        select a.ColName).Distinct().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetWQX_IMPORT_TRANSLATE_byColNameAndValue(string OrgID, string ColName, string Value)
        {
            try
            {
                var xxx = (from a in _db.TWqxImportTranslate
                           where a.OrgId == OrgID
                           && a.ColName == ColName
                           && a.DataFrom == Value
                           select a).FirstOrDefault();

                return xxx != null ? xxx.DataTo : Value;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<TWqxImportTranslate> GetWQX_IMPORT_TRANSLATE_byOrg(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTranslate
                        where a.OrgId == OrgID
                        orderby a.ColName, a.DataFrom
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int DeleteT_WQX_IMPORT_TRANSLATE(int TranslateID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TRANSLATE WHERE TRANSLATE_IDX = " + TranslateID;
                int result = _db.Database.ExecuteSqlCommand(sql);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int InsertOrUpdateWQX_IMPORT_TRANSLATE(int? tRANSLATE_IDX, string oRG_ID, string cOL_NAME, string dATA_FROM, string dATA_TO, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTranslate a = null;

                if (tRANSLATE_IDX != null)
                    a = (from c in _db.TWqxImportTranslate
                         where c.TranslateIdx == tRANSLATE_IDX
                         select c).FirstOrDefault();

                if (a == null) //insert case
                {
                    insInd = true;
                    a = new TWqxImportTranslate();
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (cOL_NAME != null) a.ColName = cOL_NAME;
                if (dATA_FROM != null) a.DataFrom = dATA_FROM;
                if (dATA_TO != null) a.DataTo = dATA_TO;

                if (insInd) //insert case
                {
                    a.CreateDt = DateTime.Now;
                    a.CreateUserid = cREATE_USER;
                    _db.TWqxImportTranslate.Add(a);
                }
                else
                {
                    _db.TWqxImportTranslate.Update(a);
                }

                _db.SaveChanges();

                return a.TranslateIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        // *************************** IMPORT: MONLOC    ******************************
        // *****************************************************************************

        public static int InsertOrUpdateWQX_IMPORT_TEMP_MONLOC(int? tEMP_MONLOC_IDX, string uSER_ID, int? mONLOC_IDX, string oRG_ID, string mONLOC_ID,
            string mONLOC_NAME, string mONLOC_TYPE, string mONLOC_DESC, string hUC_EIGHT, string HUC_TWELVE, string tRIBAL_LAND_IND, string tRIBAL_LAND_NAME, string lATITUDE_MSR,
            string lONGITUDE_MSR, int? sOURCE_MAP_SCALE, string hORIZ_ACCURACY, string hORIZ_ACCURACY_UNIT, string hORIZ_COLL_METHOD, string hORIZ_REF_DATUM, string vERT_MEASURE,
            string vERT_MEASURE_UNIT, string vERT_COLL_METHOD, string vERT_REF_DATUM, string cOUNTRY_CODE, string sTATE_CODE, string cOUNTY_CODE, string wELL_TYPE,
            string aQUIFER_NAME, string fORMATION_TYPE, string wELLHOLE_DEPTH_MSR, string wELLHOLE_DEPTH_MSR_UNIT, string sTATUS_CD, string sTATUS_DESC)
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTempMonloc a = new TWqxImportTempMonloc();

                if (tEMP_MONLOC_IDX != null)
                    a = (from c in _db.TWqxImportTempMonloc
                         where c.TempMonlocIdx == tEMP_MONLOC_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (uSER_ID != null)
                {
                    a.UserId = uSER_ID;
                    if (uSER_ID.Length > 25) { sTATUS_CD = "F"; sTATUS_DESC += "User ID length exceeded. "; }
                }

                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;
                if (oRG_ID != null) a.OrgId = oRG_ID;

                if (mONLOC_ID != null)
                {
                    a.MonlocId = mONLOC_ID.SubStringPlus(0, 35).Trim();
                    if (mONLOC_ID.Length > 35) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID length exceeded. "; }

                    TWqxMonloc mtemp = db_WQX.GetWQX_MONLOC_ByIDString(oRG_ID, mONLOC_ID);
                    if (mtemp != null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID already exists. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_NAME))
                {
                    a.MonlocName = mONLOC_NAME.SubStringPlus(0, 255).Trim();
                    if (mONLOC_NAME.Length > 255) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_TYPE))
                {
                    a.MonlocType = mONLOC_TYPE.SubStringPlus(0, 45);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MonitoringLocationType", mONLOC_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Type not valid. "; }
                }

                if (!string.IsNullOrEmpty(mONLOC_DESC))
                {
                    a.MonlocDesc = mONLOC_DESC.SubStringPlus(0, 1999);
                    if (mONLOC_DESC.Length > 1999) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location Description length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(hUC_EIGHT))
                {
                    a.HucEight = hUC_EIGHT.Trim().SubStringPlus(0, 8);
                    if (hUC_EIGHT.Length > 8) { sTATUS_CD = "F"; sTATUS_DESC += "HUC8 length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(HUC_TWELVE))
                {
                    a.HucTwelve = HUC_TWELVE.Trim().SubStringPlus(0, 12);
                    if (HUC_TWELVE.Length > 12) { sTATUS_CD = "F"; sTATUS_DESC += "HUC12 length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(tRIBAL_LAND_IND))
                {
                    if (tRIBAL_LAND_IND.ToUpper() == "TRUE") tRIBAL_LAND_IND = "Y";
                    if (tRIBAL_LAND_IND.ToUpper() == "FALSE") tRIBAL_LAND_IND = "N";

                    a.TribalLandInd = tRIBAL_LAND_IND.SubStringPlus(0, 1);
                    if (tRIBAL_LAND_IND.Length > 1) { sTATUS_CD = "F"; sTATUS_DESC += "Tribal Land Indicator length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(tRIBAL_LAND_NAME))
                {
                    a.TribalLandName = tRIBAL_LAND_NAME.SubStringPlus(0, 200);
                    if (tRIBAL_LAND_NAME.Length > 200) { sTATUS_CD = "F"; sTATUS_DESC += "Tribal Land Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(lATITUDE_MSR))
                {
                    a.LatitudeMsr = lATITUDE_MSR.SubStringPlus(0, 30);
                    decimal iii = 0;
                    if (Decimal.TryParse(lATITUDE_MSR, out iii) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Latitude is not decimal format. "; }
                }

                if (!string.IsNullOrEmpty(lONGITUDE_MSR))
                {
                    a.LongitudeMsr = lONGITUDE_MSR.SubStringPlus(0, 30);
                    decimal iii = 0;
                    if (Decimal.TryParse(lONGITUDE_MSR, out iii) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Longitude is not decimal format. "; }
                }

                if (sOURCE_MAP_SCALE != null)
                {
                    a.SourceMapScale = sOURCE_MAP_SCALE;
                }

                if (!string.IsNullOrEmpty(hORIZ_COLL_METHOD))
                {
                    a.HorizCollMethod = hORIZ_COLL_METHOD.SubStringPlus(0, 150).Trim();
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("HorizontalCollectionMethod", hORIZ_COLL_METHOD.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Horizontal Collection Method not valid. "; }
                }

                if (!string.IsNullOrEmpty(hORIZ_REF_DATUM))
                {
                    a.HorizRefDatum = hORIZ_REF_DATUM.Trim().SubStringPlus(0, 6);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("HorizontalCoordinateReferenceSystemDatum", hORIZ_REF_DATUM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Horizontal Collection Datum not valid. "; }
                }

                if (!string.IsNullOrEmpty(vERT_MEASURE))
                {
                    a.VertMeasure = vERT_MEASURE.Trim().SubStringPlus(0, 12);
                    if (vERT_MEASURE.Length > 12) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Measure length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(vERT_MEASURE_UNIT))
                {
                    a.VertMeasureUnit = vERT_MEASURE_UNIT.Trim().SubStringPlus(0, 12);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", vERT_MEASURE_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Measure Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(vERT_COLL_METHOD))
                {
                    a.VertCollMethod = vERT_COLL_METHOD.Trim().SubStringPlus(0, 50);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("VerticalCollectionMethod", vERT_COLL_METHOD.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Collection Method not acceptable. "; }
                }

                if (!string.IsNullOrEmpty(vERT_REF_DATUM))
                {
                    a.VertRefDatum = vERT_REF_DATUM.Trim().SubStringPlus(0, 6);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("VerticalCoordinateReferenceSystemDatum", vERT_REF_DATUM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Vertical Collection Datum not acceptable. "; }
                }

                if (!string.IsNullOrEmpty(cOUNTRY_CODE))
                {
                    //if there is a match of country NAME value to reference data text (in case user is importing country name instead of code)
                    TWqxRefData rd = db_Ref.GetT_WQX_REF_DATA_ByTextGetRow("Country", cOUNTRY_CODE);
                    if (rd != null)
                        a.CountryCode = rd.Value.SubStringPlus(0, 2);
                    else
                    {
                        a.CountryCode = cOUNTRY_CODE.SubStringPlus(0, 2);
                        if (cOUNTRY_CODE.Length > 2) { sTATUS_CD = "F"; sTATUS_DESC += "Country Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(sTATE_CODE))
                {
                    //if there is a match of state value to reference data text (in case user is importing state name instead of code)
                    TWqxRefData rd = db_Ref.GetT_WQX_REF_DATA_ByTextGetRow("State", sTATE_CODE);
                    if (rd != null)
                        a.StateCode = rd.Value;
                    else
                    {
                        a.StateCode = sTATE_CODE.SubStringPlus(0, 2);
                        if (sTATE_CODE.Length > 2) { sTATUS_CD = "F"; sTATUS_DESC += "State Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(cOUNTY_CODE))
                {
                    //if there is a match of county value to reference data text (in case user is importing county text instead of code)
                    TWqxRefCounty c = db_Ref.GetT_WQX_REF_COUNTY_ByCountyNameAndState(sTATE_CODE, cOUNTY_CODE);
                    if (c != null)
                        a.CountyCode = c.CountyCode;
                    else
                    {
                        a.CountyCode = cOUNTY_CODE.SubStringPlus(0, 3);
                        if (cOUNTY_CODE.Length > 3) { sTATUS_CD = "F"; sTATUS_DESC += "County Code length exceeded. "; }
                    }
                }

                if (!string.IsNullOrEmpty(wELL_TYPE))
                {
                    a.WellType = wELL_TYPE.Trim().SubStringPlus(0, 255);
                }

                if (!string.IsNullOrEmpty(aQUIFER_NAME))
                {
                    a.AquiferName = aQUIFER_NAME.Trim().SubStringPlus(0, 120);
                }

                if (!string.IsNullOrEmpty(fORMATION_TYPE))
                {
                    a.FormationType = fORMATION_TYPE.Trim().SubStringPlus(0, 50);
                }

                if (!string.IsNullOrEmpty(wELLHOLE_DEPTH_MSR))
                {
                    a.WellholeDepthMsr = wELLHOLE_DEPTH_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(wELLHOLE_DEPTH_MSR_UNIT))
                {
                    a.WellholeDepthMsrUnit = wELLHOLE_DEPTH_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                {
                    _db.TWqxImportTempMonloc.Add(a);
                }
                else
                {
                    _db.TWqxImportTempMonloc.Update(a);
                }

                _db.SaveChanges();

                return a.TempMonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //cofigFilePath = HttpContext.Current.Server.MapPath("~/App_Docs/ImportColumnsConfig.xml")
        public static int InsertWQX_IMPORT_TEMP_MONLOC_New(string uSER_ID, string oRG_ID, Dictionary<string, string> colVals,string configFilePath)
        {
            try
            {
                //get import config rules
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("M", configFilePath);

                TWqxImportTempMonloc a = new TWqxImportTempMonloc();

                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(uSER_ID)) a.UserId = uSER_ID;
                if (!string.IsNullOrEmpty(oRG_ID)) a.OrgId = oRG_ID;

                //*************** PRE CUSTOM VALIDATION **********************************************
                string _t = null;

                _t = Utils.GetValueOrDefault(colVals, "TRIBAL_LAND_IND");
                if (!string.IsNullOrEmpty(_t))
                {
                    if (_t.ToUpper() == "TRUE") colVals["TRIBAL_LAND_IND"] = "Y";
                    if (_t.ToUpper() == "FALSE") colVals["TRIBAL_LAND_IND "] = "N";
                }

                //if there is a match of county value to reference data text (in case user is importing county text instead of code)
                _t = Utils.GetValueOrDefault(colVals, "COUNTY_CODE");
                if (!string.IsNullOrEmpty(_t))
                {

                    TWqxRefCounty c = db_Ref.GetT_WQX_REF_COUNTY_ByCountyNameAndState(Utils.GetValueOrDefault(colVals, "STATE_CODE"), _t);
                    if (c != null)
                        a.CountyCode = c.CountyCode;
                    else
                        WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "COUNTY_CODE");
                }
                //********************** end custom validation ********************************************

                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MONLOC_ID");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MONLOC_NAME");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MONLOC_TYPE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "MONLOC_DESC");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HUC_EIGHT");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HUC_TWELVE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "TRIBAL_LAND_IND");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "TRIBAL_LAND_NAME");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "LATITUDE_MSR");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "LONGITUDE_MSR");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "SOURCE_MAP_SCALE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HORIZ_COLL_METHOD");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "HORIZ_REF_DATUM");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VERT_MEASURE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VERT_MEASURE_UNIT");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VERT_COLL_METHOD");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "VERT_REF_DATUM");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "COUNTRY_CODE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "STATE_CODE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WELL_TYPE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "AQUIFER_NAME");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "FORMATION_TYPE");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WELLHOLE_DEPTH_MSR");
                WQX_IMPORT_TEMP_MONLOC_GenVal(ref a, _allRules, colVals, "WELLHOLE_DEPTH_MSR_UNIT");

                //*************** POST CUSTOM VALIDATION **********************************************
                if (!string.IsNullOrEmpty(a.MonlocId))
                    if (db_WQX.GetWQX_MONLOC_ByIDString(oRG_ID, a.MonlocId) != null) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Monitoring Location ID already exists. "; }

                decimal ii;
                if (!string.IsNullOrEmpty(a.LatitudeMsr))
                    if (Decimal.TryParse(a.LatitudeMsr, out ii) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Latitude is not decimal format. "; }

                if (!string.IsNullOrEmpty(a.LongitudeMsr))
                    if (Decimal.TryParse(a.LongitudeMsr, out ii) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Longitude is not decimal format. "; }
                //*************** END CUSTOM VALIDATION **********************************************

                _db.TWqxImportTempMonloc.Add(a);
                _db.SaveChanges();

                return a.TempMonlocIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void WQX_IMPORT_TEMP_MONLOC_GenVal(ref TWqxImportTempMonloc a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field
            var _rules = t.Find(item => item._name == f);   //import rules for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ").SubStringPlus(0, 100);

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ").SubStringPlus(0, 100);
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ").SubStringPlus(0, 100);
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    _value = "-";
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ").SubStringPlus(0, 100);
                }
            }
            
            //finally set the value before returning
            if (_rules._datatype == "")
                typeof(TWqxImportTempMonloc).GetProperty(f).SetValue(a, _value);
            else if (_rules._datatype == "int")
                typeof(TWqxImportTempMonloc).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
        }

        public static List<TWqxImportTempMonloc> GetWQX_IMPORT_TEMP_MONLOC(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempMonloc
                        where a.UserId == UserID
                        orderby a.TempMonlocIdx
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_IMPORT_TEMP_MONLOC_CountByUserID(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempMonloc
                        where a.UserId == UserID
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxImportTempMonloc GetWQX_IMPORT_TEMP_MONLOC_ByID(int TempMonLocID)
        {

            try
            {
                return (from a in _db.TWqxImportTempMonloc
                        where a.TempMonlocIdx == TempMonLocID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_IMPORT_TEMP_MONLOC(string uSER_ID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_MONLOC WHERE USER_ID = '" + uSER_ID + "'";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }

        }



        // *************************** IMPORT: PROJECT    ******************************
        // *****************************************************************************
        public static int InsertOrUpdateWQX_IMPORT_TEMP_PROJECT(global::System.Int32? tEMP_PROJECT_IDX, string uSER_ID, global::System.Int32? pROJECT_IDX, global::System.String oRG_ID,
            global::System.String pROJECT_ID, global::System.String pROJECT_NAME, global::System.String pROJECT_DESC, global::System.String sAMP_DESIGN_TYPE_CD,
            global::System.Boolean? qAPP_APPROVAL_IND, global::System.String qAPP_APPROVAL_AGENCY, string sTATUS_CD, string sTATUS_DESC)
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTempProject a = new TWqxImportTempProject();

                if (tEMP_PROJECT_IDX != null)
                    a = (from c in _db.TWqxImportTempProject
                         where c.TempProjectIdx == tEMP_PROJECT_IDX
                         select c).FirstOrDefault();
                else
                    insInd = true;

                if (uSER_ID != null)
                {
                    a.UserId = uSER_ID;
                    if (uSER_ID.Length > 25) { sTATUS_CD = "F"; sTATUS_DESC += "User ID length exceeded. "; }
                }

                if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX;
                if (oRG_ID != null) a.OrgId = oRG_ID;

                if (pROJECT_ID != null)
                {
                    a.ProjectId = pROJECT_ID.SubStringPlus(0, 35).Trim();
                    if (pROJECT_ID.Length > 35) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID length exceeded. "; }

                    TWqxProject ptemp = db_WQX.GetWQX_PROJECT_ByIDString(pROJECT_ID, oRG_ID);
                    if (ptemp != null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID already exists. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_NAME))
                {
                    a.ProjectName = pROJECT_NAME.SubStringPlus(0, 120).Trim();
                    if (pROJECT_NAME.Length > 120) { sTATUS_CD = "F"; sTATUS_DESC += "Project Name length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(pROJECT_DESC))
                {
                    a.ProjectDesc = pROJECT_DESC.SubStringPlus(0, 1999);
                    if (pROJECT_DESC.Length > 1999) { sTATUS_CD = "F"; sTATUS_DESC += "Project Description length exceeded. "; }
                }

                if (!string.IsNullOrEmpty(sAMP_DESIGN_TYPE_CD))
                {
                    a.SampDesignTypeCd = sAMP_DESIGN_TYPE_CD.Trim().SubStringPlus(0, 20);
                    if (sAMP_DESIGN_TYPE_CD.Length > 20) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Design Type Code length exceeded. "; }
                }

                if (qAPP_APPROVAL_IND != null)
                {
                    a.QappApprovalInd = qAPP_APPROVAL_IND;
                }

                if (!string.IsNullOrEmpty(qAPP_APPROVAL_AGENCY))
                {
                    a.QappApprovalAgency = qAPP_APPROVAL_AGENCY.SubStringPlus(0, 50);
                    if (qAPP_APPROVAL_AGENCY.Length > 50) { sTATUS_CD = "F"; sTATUS_DESC += "QAPP Approval Agency length exceeded. "; }
                }

                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                {
                    _db.TWqxImportTempProject.Add(a);
                }
                else
                {
                    _db.TWqxImportTempProject.Update(a);
                }

                _db.SaveChanges();

                return a.TempProjectIdx;
            }
            catch (Exception ex)
            {
                sTATUS_CD = "F";
                sTATUS_DESC += "Unspecified error. ";
                return 0;
            }
        }

        public static List<TWqxImportTempProject> GetWQX_IMPORT_TEMP_PROJECT(string UserID)
        {
            try
            {
                
                return (from a in _db.TWqxImportTempProject
                        where a.UserId == UserID
                        orderby a.TempProjectIdx
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxImportTempProject GetWQX_IMPORT_TEMP_PROJECT_ByID(int TempProjectID)
        {
            try
            {
                
                return (from a in _db.TWqxImportTempProject
                        where a.TempProjectIdx == TempProjectID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_IMPORT_TEMP_PROJECT(string uSER_ID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_PROJECT WHERE USER_ID = '" + uSER_ID + "'";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        // *************************** IMPORT: BIO INDEX ******************************
        // *****************************************************************************
        public static int DeleteT_WQX_IMPORT_TEMP_BIO_INDEX(string uSER_ID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_BIO_INDEX WHERE USER_ID = '" + uSER_ID + "'";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }

        }


        // *************************** IMPORT: ACTIVITY METRIC ******************************
        // *****************************************************************************
        //cofigFilePath = HttpContext.Current.Server.MapPath("~/App_Docs/ImportColumnsConfig.xml")
        public static int InsertWQX_IMPORT_TEMP_ACTIVITY_METRIC(string uSER_ID, string oRG_ID, Dictionary<string, string> colVals,string configFilePath)
        {
            try
            {
                //get import config rules
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("I", configFilePath);

                TWqxImportTempActivityMetric a = new TWqxImportTempActivityMetric();

                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(uSER_ID)) a.UserId = uSER_ID;
                if (!string.IsNullOrEmpty(oRG_ID)) a.OrgId = oRG_ID;

                //*************** PRE CUSTOM VALIDATION **********************************************
                string _t = null;

                //fail if no matching activity id found
                _t = Utils.GetValueOrDefault(colVals, "ACTIVITY_ID");
                if (!string.IsNullOrEmpty(_t))
                {

                    TWqxActivity act = db_WQX.GetWQX_ACTIVITY_ByUnique(oRG_ID, _t);
                    if (act == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching activity ID found. Please import activity prior to importing activity metric. "; }
                    else
                        a.ActivityIdx = act.ActivityIdx;
                }

                //********************** end custom validation ********************************************

                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "ACTIVITY_ID");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_TYPE_ID");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_TYPE_ID_CONTEXT");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_VALUE_MSR");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_VALUE_MSR_UNIT");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_SCORE");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "METRIC_COMMENT");
                WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref a, _allRules, colVals, "TEMP_BIO_HABITAT_INDEX_IDX");

                //*************** POST CUSTOM VALIDATION **********************************************

                //*************** END CUSTOM VALIDATION **********************************************

                _db.TWqxImportTempActivityMetric.Add(a);
                _db.SaveChanges();


                return a.TempActivityMetricIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void WQX_IMPORT_TEMP_ACTIVITY_METRIC_GenVal(ref TWqxImportTempActivityMetric a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field
            var _rules = t.Find(item => item._name == f);   //import rules for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ").SubStringPlus(0, 200);

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ").SubStringPlus(0, 200);
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ").SubStringPlus(0, 200);
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    _value = "-";
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ").SubStringPlus(0, 200);
                }
            }

            //finally set the value before returning
            if (_rules._datatype == "")
                typeof(TWqxImportTempActivityMetric).GetProperty(f).SetValue(a, _value);
            else if (_rules._datatype == "int")
                typeof(TWqxImportTempActivityMetric).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
        }

        public static List<TWqxImportTempActivityMetric> GetWQX_IMPORT_TEMP_ACTIVITY_METRIC(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempActivityMetric
                        where a.UserId == UserID
                        orderby a.TempActivityMetricIdx
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxImportTempActivityMetric GetWQX_IMPORT_TEMP_ACTIVITY_METRIC_byID(int _ID)
        {
            try
            {
                return (from a in _db.TWqxImportTempActivityMetric
                        where a.TempActivityMetricIdx == _ID
                        orderby a.TempActivityMetricIdx
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int GetWQX_IMPORT_TEMP_ACTIVITY_METRIC_CountByUserID(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempActivityMetric
                        where a.UserId == UserID
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteT_WQX_IMPORT_TEMP_ACTIVITY_METRIC(string uSER_ID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_ACTIVITY_METRIC WHERE USER_ID = '" + uSER_ID + "'";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }
        }



        // *************************** IMPORT: SAMPLE    ******************************
        // *****************************************************************************
        public static int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE(IHttpContextAccessor httpContextAccessor, global::System.Int32? tEMP_SAMPLE_IDX, string uSER_ID, global::System.String oRG_ID, global::System.Int32? pROJECT_IDX,
            string pROJECT_ID, global::System.Int32? mONLOC_IDX, string mONLOC_ID, global::System.Int32? aCTIVITY_IDX, global::System.String aCTIVITY_ID,
            global::System.String aCT_TYPE, global::System.String aCT_MEDIA, global::System.String aCT_SUBMEDIA, global::System.DateTime? aCT_START_DT, global::System.DateTime? aCT_END_DT,
            global::System.String aCT_TIME_ZONE, global::System.String rELATIVE_DEPTH_NAME, global::System.String aCT_DEPTHHEIGHT_MSR, global::System.String aCT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String tOP_DEPTHHEIGHT_MSR, global::System.String tOP_DEPTHHEIGHT_MSR_UNIT, global::System.String bOT_DEPTHHEIGHT_MSR, global::System.String bOT_DEPTHHEIGHT_MSR_UNIT,
            global::System.String dEPTH_REF_POINT, global::System.String aCT_COMMENT, global::System.String bIO_ASSEMBLAGE_SAMPLED, global::System.String bIO_DURATION_MSR,
            global::System.String bIO_DURATION_MSR_UNIT, global::System.String bIO_SAMP_COMPONENT, int? bIO_SAMP_COMPONENT_SEQ, global::System.String bIO_REACH_LEN_MSR,
            global::System.String bIO_REACH_LEN_MSR_UNIT, global::System.String bIO_REACH_WID_MSR, global::System.String bIO_REACH_WID_MSR_UNIT, int? bIO_PASS_COUNT,
            global::System.String bIO_NET_TYPE, global::System.String bIO_NET_AREA_MSR, global::System.String bIO_NET_AREA_MSR_UNIT, global::System.String bIO_NET_MESHSIZE_MSR,
            global::System.String bIO_MESHSIZE_MSR_UNIT, global::System.String bIO_BOAT_SPEED_MSR, global::System.String bIO_BOAT_SPEED_MSR_UNIT, global::System.String bIO_CURR_SPEED_MSR,
            global::System.String bIO_CURR_SPEED_MSR_UNIT, global::System.String bIO_TOXICITY_TEST_TYPE, int? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            global::System.String sAMP_COLL_METHOD_CTX, global::System.String sAMP_COLL_METHOD_NAME, global::System.String sAMP_COLL_EQUIP, global::System.String sAMP_COLL_EQUIP_COMMENT,
            int? sAMP_PREP_IDX, global::System.String sAMP_PREP_ID, global::System.String sAMP_PREP_CTX, global::System.String sAMP_PREP_NAME,
            global::System.String sAMP_PREP_CONT_TYPE, global::System.String sAMP_PREP_CONT_COLOR, global::System.String sAMP_PREP_CHEM_PRESERV,
            global::System.String sAMP_PREP_THERM_PRESERV, global::System.String sAMP_PREP_STORAGE_DESC, string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, Boolean autoImportRefDataInd)
        {
            try
            {
                Boolean insInd = false;

                //******************* GET STARTING RECORD *************************************************

                TWqxImportTempSample a;
                if (tEMP_SAMPLE_IDX != null)  //grab from IDX if given
                    a = (from c in _db.TWqxImportTempSample
                         where c.TempSampleIdx == tEMP_SAMPLE_IDX
                         select c).FirstOrDefault();
                else  //check if existing activity ID exists in the import
                {
                    a = (from c in _db.TWqxImportTempSample
                         where c.ActivityId == aCTIVITY_ID
                         && c.OrgId == oRG_ID
                         select c).FirstOrDefault();
                }

                //if can't find a match based on supplied IDX or ID, then create a new record
                if (a == null)
                {
                    insInd = true;
                    a = new TWqxImportTempSample();
                }
                //********************** END GET STARTING RECORD ************************************************


                if (!string.IsNullOrEmpty(uSER_ID)) a.UserId = uSER_ID;
                if (!string.IsNullOrEmpty(oRG_ID)) a.OrgId = oRG_ID;

                //PROJECT HANDLING
                if (pROJECT_IDX == null && pROJECT_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID must be provided. "; }
                if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX;

                if (pROJECT_ID != null)
                {
                    a.ProjectId = pROJECT_ID.Trim().SubStringPlus(0, 35);

                    TWqxProject ptemp = db_WQX.GetWQX_PROJECT_ByIDString(pROJECT_ID, oRG_ID);
                    if (ptemp == null) { sTATUS_CD = "F"; sTATUS_DESC += "Project ID does not exist. Create project first."; }
                    else { a.ProjectIdx = ptemp.ProjectIdx; }
                }

                //MONITORING LOCATION HANDLING
                if (mONLOC_IDX == null && mONLOC_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID must be provided. "; }
                if (mONLOC_IDX != null) a.MonlocIdx = mONLOC_IDX;

                if (mONLOC_ID != null)
                {
                    a.MonlocId = mONLOC_ID.Trim().SubStringPlus(0, 35);

                    TWqxMonloc mm = db_WQX.GetWQX_MONLOC_ByIDString(oRG_ID, mONLOC_ID);
                    if (mm == null) { sTATUS_CD = "F"; sTATUS_DESC += "Monitoring Location ID does not exist. Import MonLocs first."; }
                    else { a.MonlocIdx = mm.MonlocIdx; }
                }


                //ACTIVITY ID HANDLING
                if (aCTIVITY_IDX == null && aCTIVITY_ID == null) { sTATUS_CD = "F"; sTATUS_DESC += "Activity ID must be provided. "; }
                if (aCTIVITY_IDX != null) a.ActivityIdx = aCTIVITY_IDX;
                if (!string.IsNullOrEmpty(aCTIVITY_ID)) a.ActivityId = aCTIVITY_ID.Trim().SubStringPlus(0, 35);


                //ACTIVITY TYPE HANDLING
                if (!string.IsNullOrEmpty(aCT_TYPE))
                {
                    a.ActType = aCT_TYPE.SubStringPlus(0, 70) ?? "";
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ActivityType", aCT_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Type not valid. "; }
                }
                else
                { a.ActType = ""; sTATUS_CD = "F"; sTATUS_DESC += "Activity Type is required."; }

                if (!string.IsNullOrEmpty(aCT_MEDIA))
                {
                    a.ActMedia = aCT_MEDIA.SubStringPlus(0, 20) ?? "";
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ActivityMedia", aCT_MEDIA.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Media not valid. "; }
                }
                else
                { a.ActMedia = ""; sTATUS_CD = "F"; sTATUS_DESC += "Activity Media is required."; }

                if (!string.IsNullOrEmpty(aCT_SUBMEDIA))
                {
                    a.ActSubmedia = aCT_SUBMEDIA.SubStringPlus(0, 45);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ActivityMediaSubdivision", aCT_SUBMEDIA.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Activity Media Subdivision not valid. "; }
                }


                if (aCT_START_DT == null)
                {
                    sTATUS_CD = "F"; sTATUS_DESC += "Activity Start Date must be provided. ";
                }
                else
                {
                    //fix improperly formatted datetime
                    if (aCT_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                    { sTATUS_CD = "F"; sTATUS_DESC += "Activity Start Date is formatted incorrectly. "; }
                    else
                        a.ActStartDt = aCT_START_DT;
                }

                if (aCT_END_DT != null)
                {
                    //fix improperly formatted datetime
                    if (aCT_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        aCT_END_DT = null;

                    a.ActEndDt = aCT_END_DT;
                }

                if (!string.IsNullOrEmpty(aCT_TIME_ZONE))
                {
                    a.ActTimeZone = aCT_TIME_ZONE.Trim().SubStringPlus(0, 4);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("TimeZone", aCT_TIME_ZONE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "TimeZone not valid. "; }
                }
                else
                {
                    //put in Timezone if missing
                    a.ActTimeZone = Utils.GetWQXTimeZoneByDate(a.ActStartDt.ConvertOrDefault<DateTime>(), httpContextAccessor);
                }


                if (!string.IsNullOrEmpty(rELATIVE_DEPTH_NAME))
                {
                    a.RelativeDepthName = rELATIVE_DEPTH_NAME.Trim().SubStringPlus(0, 15);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ActivityRelativeDepth", rELATIVE_DEPTH_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Relative Depth Name not valid. "; }
                }

                if (!string.IsNullOrEmpty(aCT_DEPTHHEIGHT_MSR))
                {
                    a.ActDepthheightMsr = aCT_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(aCT_DEPTHHEIGHT_MSR_UNIT))
                {
                    a.ActDepthheightMsrUnit = aCT_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", aCT_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Depth Measure Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(tOP_DEPTHHEIGHT_MSR))
                {
                    a.TopDepthheightMsr = tOP_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(tOP_DEPTHHEIGHT_MSR_UNIT))
                {
                    a.TopDepthheightMsrUnit = tOP_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", tOP_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Top Depth Measure Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(bOT_DEPTHHEIGHT_MSR))
                {
                    a.BotDepthheightMsr = bOT_DEPTHHEIGHT_MSR.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(bOT_DEPTHHEIGHT_MSR_UNIT))
                {
                    a.BotDepthheightMsrUnit = bOT_DEPTHHEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bOT_DEPTHHEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bottom Depth Measure Unit not valid. "; }
                }

                if (!string.IsNullOrEmpty(dEPTH_REF_POINT))
                {
                    a.DepthRefPoint = dEPTH_REF_POINT.Trim().SubStringPlus(0, 125);
                }

                if (!string.IsNullOrEmpty(aCT_COMMENT))
                {
                    a.ActComment = aCT_COMMENT.Trim().SubStringPlus(0, 4000);
                }

                //BIOLOGICAL MONITORING 
                if (BioIndicator == true)
                {
                    if (!string.IsNullOrEmpty(bIO_ASSEMBLAGE_SAMPLED))
                    {
                        a.BioAssemblageSampled = bIO_ASSEMBLAGE_SAMPLED.Trim().SubStringPlus(0, 50);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("Assemblage", bIO_ASSEMBLAGE_SAMPLED.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Assemblage not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_DURATION_MSR))
                    {
                        a.BioDurationMsr = bIO_DURATION_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_DURATION_MSR_UNIT))
                    {
                        a.BioDurationMsrUnit = bIO_DURATION_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_DURATION_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Collection Duration Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_SAMP_COMPONENT))
                    {
                        a.BioSampComponent = bIO_SAMP_COMPONENT.Trim().SubStringPlus(0, 15);
                    }

                    if (bIO_SAMP_COMPONENT_SEQ != null) a.BioSampComponentSeq = bIO_SAMP_COMPONENT_SEQ;

                    if (!string.IsNullOrEmpty(bIO_REACH_LEN_MSR))
                    {
                        a.BioReachLenMsr = bIO_REACH_LEN_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_REACH_LEN_MSR_UNIT))
                    {
                        a.BioReachLenMsrUnit = bIO_REACH_LEN_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_REACH_LEN_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Reach Length Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_REACH_WID_MSR))
                    {
                        a.BioReachWidMsr = bIO_REACH_WID_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_REACH_WID_MSR_UNIT))
                    {
                        a.BioReachWidMsrUnit = bIO_REACH_WID_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_REACH_WID_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Reach Width Unit not valid. "; }
                    }

                    if (bIO_PASS_COUNT != null) a.BioPassCount = bIO_PASS_COUNT;

                    if (!string.IsNullOrEmpty(bIO_NET_TYPE))
                    {
                        a.BioNetType = bIO_NET_TYPE.Trim().SubStringPlus(0, 30);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("NetType", bIO_NET_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Type not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_NET_AREA_MSR))
                    {
                        a.BioNetAreaMsr = bIO_NET_AREA_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_NET_AREA_MSR_UNIT))
                    {
                        a.BioNetAreaMsrUnit = bIO_NET_AREA_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_NET_AREA_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Area Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_NET_MESHSIZE_MSR))
                    {
                        a.BioNetMeshsizeMsr = bIO_NET_MESHSIZE_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_MESHSIZE_MSR_UNIT))
                    {
                        a.BioMeshsizeMsrUnit = bIO_MESHSIZE_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_MESHSIZE_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Bio Net Mesh Size Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_BOAT_SPEED_MSR))
                    {
                        a.BioBoatSpeedMsr = bIO_BOAT_SPEED_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_BOAT_SPEED_MSR_UNIT))
                    {
                        a.BioBoatSpeedMsrUnit = bIO_BOAT_SPEED_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_BOAT_SPEED_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Boat Speed Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_CURR_SPEED_MSR))
                    {
                        a.BioCurrSpeedMsr = bIO_CURR_SPEED_MSR.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(bIO_CURR_SPEED_MSR_UNIT))
                    {
                        a.BioCurrSpeedMsrUnit = bIO_CURR_SPEED_MSR_UNIT.Trim().SubStringPlus(0, 12);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", bIO_CURR_SPEED_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Current Speed Unit not valid. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_TOXICITY_TEST_TYPE))
                    {
                        a.BioToxicityTestType = bIO_TOXICITY_TEST_TYPE.Trim().SubStringPlus(0, 7);
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("ToxicityTestType", bIO_TOXICITY_TEST_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Toxicity Test Type not valid. "; }
                    }
                }

                if (sAMP_COLL_METHOD_IDX != null)
                {
                    a.SampCollMethodIdx = sAMP_COLL_METHOD_IDX;

                    //if IDX is populated but ID/Name/Ctx aren't then grab them

                    TWqxRefSampColMethod scm = db_Ref.GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(a.SampCollMethodIdx);
                    if (scm != null)
                    {
                        a.SampCollMethodId = scm.SampCollMethodId;
                        a.SampCollMethodName = scm.SampCollMethodName;
                        a.SampCollMethodCtx = scm.SampCollMethodCtx;
                    }
                }
                else
                {
                    //set context to org id if none is provided 
                    if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_ID) && string.IsNullOrEmpty(sAMP_COLL_METHOD_CTX))
                        sAMP_COLL_METHOD_CTX = oRG_ID;

                    if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_ID) && !string.IsNullOrEmpty(sAMP_COLL_METHOD_CTX))
                    {
                        //lookup matching collection method IDX

                        TWqxRefSampColMethod scm = db_Ref.GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(sAMP_COLL_METHOD_ID.Trim(), sAMP_COLL_METHOD_CTX.Trim());
                        if (scm != null)
                            a.SampCollMethodIdx = scm.SampCollMethodIdx;
                        else  //no matching sample collection method lookup found
                        {
                            if (autoImportRefDataInd == true)
                            {
                                db_Ref.InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(null, sAMP_COLL_METHOD_ID.Trim(), sAMP_COLL_METHOD_CTX.Trim(), sAMP_COLL_METHOD_NAME.Trim(), "", true);
                            }
                            else
                            {
                                sTATUS_CD = "F"; sTATUS_DESC += "No matching Sample Collection Method found - please add it at the Reference Data screen first. ";
                            }
                        }
                        //****************************************

                        a.SampCollMethodId = sAMP_COLL_METHOD_ID.Trim().SubStringPlus(0, 20);
                        a.SampCollMethodCtx = sAMP_COLL_METHOD_CTX.Trim().SubStringPlus(0, 120);

                        if (!string.IsNullOrEmpty(sAMP_COLL_METHOD_NAME))
                        {
                            a.SampCollMethodName = sAMP_COLL_METHOD_NAME.Trim().SubStringPlus(0, 120);
                        }
                    }
                }

                if (a.SampCollMethodIdx == null && a.ActType.ToUpper().Contains("SAMPLE"))
                { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Method is required when Activity Type contains the term -Sample-. "; }


                if (!string.IsNullOrEmpty(sAMP_COLL_EQUIP))
                {
                    a.SampCollEquip = sAMP_COLL_EQUIP.Trim().SubStringPlus(0, 40);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("SampleCollectionEquipment", sAMP_COLL_EQUIP.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Equipment not valid. "; }
                }
                else
                {
                    //special validation requiring sampling collection equipment if activity type contains "Sample"
                    if (a.ActType.ToUpper().Contains("SAMPLE"))
                    { sTATUS_CD = "F"; sTATUS_DESC += "Sample Collection Equipment is required when Activity Type contains the term -Sample-. "; }
                }


                if (!string.IsNullOrEmpty(sAMP_COLL_EQUIP_COMMENT))
                {
                    a.SampCollEquipComment = sAMP_COLL_EQUIP_COMMENT.Trim().SubStringPlus(0, 4000);
                }


                if (sAMP_PREP_IDX != null)
                    a.SampPrepIdx = sAMP_PREP_IDX;
                else
                {
                    //set context to org id if none is provided 
                    if (!string.IsNullOrEmpty(sAMP_PREP_ID) && string.IsNullOrEmpty(sAMP_PREP_CTX))
                        sAMP_PREP_CTX = oRG_ID;

                    if (!string.IsNullOrEmpty(sAMP_PREP_ID) && !string.IsNullOrEmpty(sAMP_PREP_CTX))
                    {
                        //see if matching prep method exists
                        TWqxRefSampPrep sp = db_Ref.GetT_WQX_REF_SAMP_PREP_ByIDandContext(sAMP_PREP_ID.Trim(), sAMP_PREP_CTX.Trim());
                        if (sp != null)
                            a.SampPrepIdx = sp.SampPrepIdx;
                        //****************************************

                        a.SampPrepId = sAMP_PREP_ID.Trim().SubStringPlus(0, 20);
                        a.SampPrepCtx = sAMP_PREP_CTX.Trim().SubStringPlus(0, 120);

                        if (!string.IsNullOrEmpty(sAMP_PREP_NAME))
                        {
                            a.SampPrepName = sAMP_PREP_NAME.Trim().SubStringPlus(0, 120);
                        }
                    }
                }


                if (!string.IsNullOrEmpty(sAMP_PREP_CONT_TYPE))
                {
                    a.SampPrepContType = sAMP_PREP_CONT_TYPE.Trim().SubStringPlus(0, 35);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("SampleContainerType", sAMP_PREP_CONT_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Container Type not valid. "; }
                }


                if (!string.IsNullOrEmpty(sAMP_PREP_CONT_COLOR))
                {
                    a.SampPrepContColor = sAMP_PREP_CONT_COLOR.Trim().SubStringPlus(0, 15);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("SampleContainerColor", sAMP_PREP_CONT_COLOR.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Container Color not valid. "; }
                }


                if (!string.IsNullOrEmpty(sAMP_PREP_CHEM_PRESERV))
                {
                    a.SampPrepChemPreserv = sAMP_PREP_CHEM_PRESERV.Trim().SubStringPlus(0, 250);
                }

                if (!string.IsNullOrEmpty(sAMP_PREP_THERM_PRESERV))
                {
                    a.SampPrepThermPreserv = sAMP_PREP_THERM_PRESERV.Trim().SubStringPlus(0, 25);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ThermalPreservativeUsed", sAMP_PREP_THERM_PRESERV.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Thermal Preservative Used not valid. "; }
                }

                if (!string.IsNullOrEmpty(sAMP_PREP_STORAGE_DESC))
                {
                    a.SampPrepStorageDesc = sAMP_PREP_STORAGE_DESC.Trim().SubStringPlus(0, 250);
                }


                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                {
                    _db.TWqxImportTempSample.Add(a);
                }
                else
                {
                    _db.TWqxImportTempSample.Update(a);
                }

                _db.SaveChanges();

                return a.TempSampleIdx;
            }
            catch (Exception ex)
            {
                sTATUS_CD = "F";
                sTATUS_DESC += "Unspecified error";
                return 0;
            }

        }

        //cofigFilePath = HttpContext.Current.Server.MapPath("~/App_Docs/ImportColumnsConfig.xml")
        public static int InsertUpdateWQX_IMPORT_TEMP_SAMPLE_New(string uSER_ID, string oRG_ID, int? pROJECT_IDX, string pROJECT_ID, Dictionary<string, string> colVals, string configFilePath, IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                bool insInd = false;

                //******************* GET STARTING RECORD *************************************************
                string _a = Utils.GetValueOrDefault(colVals, "ACTIVITY_ID");

                TWqxImportTempSample a = (from c in _db.TWqxImportTempSample
                                          where c.ActivityId == _a
                                              && c.OrgId == oRG_ID
                                              select c).FirstOrDefault();

                //if can't find a match based on supplied ID, then create a new record
                if (a == null)
                {
                    insInd = true;
                    a = new TWqxImportTempSample();
                }
                //********************** END GET STARTING RECORD ************************************************


                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                if (!string.IsNullOrEmpty(uSER_ID)) a.UserId = uSER_ID; else return 0;
                if (!string.IsNullOrEmpty(oRG_ID)) a.OrgId = oRG_ID; else return 0;
                if (pROJECT_IDX != null) a.ProjectIdx = pROJECT_IDX; else return 0;
                if (!string.IsNullOrEmpty(pROJECT_ID)) a.ProjectId = pROJECT_ID; else return 0;

                //get import config rules
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("S", configFilePath);


                //validate mandatory fields
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "MONLOC_ID");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ACTIVITY_ID");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ACT_TYPE");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ACT_MEDIA");
                WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, "ACT_START_DT");

                //loop through all optional fields
                List<string> rFields = new List<string>(new string[] { "ACT_SUBMEDIA","ACT_END_DT","ACT_TIME_ZONE","RELATIVE_DEPTH_NAME","ACT_DEPTHHEIGHT_MSR",
                        "ACT_DEPTHHEIGHT_MSR_UNIT","TOP_DEPTHHEIGHT_MSR","TOP_DEPTHHEIGHT_MSR_UNIT","BOT_DEPTHHEIGHT_MSR","BOT_DEPTHHEIGHT_MSR_UNIT","DEPTH_REF_POINT",
                        "ACT_COMMENT","BIO_ASSEMBLAGE_SAMPLED","BIO_DURATION_MSR","BIO_DURATION_MSR_UNIT","BIO_SAMP_COMPONENT", "BIO_SAMP_COMPONENT_SEQ","BIO_REACH_LEN_MSR",
                        "BIO_REACH_LEN_MSR_UNIT","BIO_REACH_WID_MSR","BIO_REACH_WID_MSR_UNIT","BIO_PASS_COUNT","BIO_NET_TYPE","BIO_NET_AREA_MSR","BIO_NET_AREA_MSR_UNIT",
                        "BIO_NET_MESHSIZE_MSR","BIO_MESHSIZE_MSR_UNIT","BIO_BOAT_SPEED_MSR","BIO_BOAT_SPEED_MSR_UNIT","BIO_CURR_SPEED_MSR","BIO_CURR_SPEED_MSR_UNIT",
                        "BIO_TOXICITY_TEST_TYPE","SAMP_COLL_METHOD_IDX","SAMP_COLL_METHOD_ID","SAMP_COLL_METHOD_CTX","SAMP_COLL_EQUIP","SAMP_COLL_EQUIP_COMMENT",
                        "SAMP_PREP_IDX","SAMP_PREP_ID","SAMP_PREP_CTX","SAMP_PREP_CONT_TYPE","SAMP_PREP_CONT_COLOR","SAMP_PREP_CHEM_PRESERV","SAMP_PREP_THERM_PRESERV","SAMP_PREP_STORAGE_DESC"
                    });

                foreach (KeyValuePair<string, string> entry in colVals)
                    if (rFields.Contains(entry.Key))
                        WQX_IMPORT_TEMP_SAMPLE_GenVal(ref a, _allRules, colVals, entry.Key);


                //********************** CUSTOM POST VALIDATION ********************************************
                //SET MONLOC_IDX based on supplied MONLOC_ID
                if (!string.IsNullOrEmpty(a.MonlocId))
                {
                    TWqxMonloc mm = db_WQX.GetWQX_MONLOC_ByIDString(oRG_ID, a.MonlocId);
                    if (mm == null) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Invalid Monitoring Location ID."; }
                    else { a.MonlocIdx = mm.MonlocIdx; }
                }

                //SET ACTIVITY TIMEZONE IF NOT SUPPLIED
                if (string.IsNullOrEmpty(a.ActTimeZone))
                    a.ActTimeZone = Utils.GetWQXTimeZoneByDate(a.ActStartDt.ConvertOrDefault<DateTime>(), httpContextAccessor);

                //special sampling collection method handling
                if (a.SampCollMethodIdx != null)
                {
                    //if IDX is populated, grab ID/Name/Ctx 

                    TWqxRefSampColMethod scm = db_Ref.GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(a.SampCollMethodIdx);
                    if (scm != null)
                    {
                        a.SampCollMethodId = scm.SampCollMethodId;
                        a.SampCollMethodName = scm.SampCollMethodName;
                        a.SampCollMethodCtx = scm.SampCollMethodCtx;
                    }
                }
                else
                {
                    //set context to org id if none is provided 
                    if (!string.IsNullOrEmpty(a.SampCollMethodId) && string.IsNullOrEmpty(a.SampCollMethodCtx))
                        a.SampCollMethodCtx = oRG_ID;

                    if (!string.IsNullOrEmpty(a.SampCollMethodId))
                    {
                        TWqxRefSampColMethod scm = db_Ref.GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(a.SampCollMethodId, a.SampCollMethodCtx);
                        if (scm != null)
                            a.SampCollMethodIdx = scm.SampCollMethodIdx;
                        else  //no matching sample collection method lookup found
                        { a.ImportStatusCd = "F"; a.ImportStatusCd += "No matching Sample Collection Method found - please add it at the Reference Data screen first. "; }
                    }
                }


                //special validation requiring sampling collection method if activity type contains "Sample"
                if (a.SampCollMethodIdx == null && a.ActType.ToUpper().Contains("SAMPLE"))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Collection Method is required when Activity Type contains the term -Sample-. "; }

                //special validation requiring sampling collection equipment if activity type contains "Sample"
                if (string.IsNullOrEmpty(a.SampCollEquip) && a.ActType.ToUpper().Contains("SAMPLE"))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Collection Equipment is required when Activity Type contains the term -Sample-. "; }


                //sampling prep method handling
                if (a.SampPrepIdx == null)
                {
                    if (string.IsNullOrEmpty(a.SampPrepCtx) && !string.IsNullOrEmpty(a.SampPrepId))
                        a.SampPrepCtx = oRG_ID;

                    if (!string.IsNullOrEmpty(a.SampPrepId) && !string.IsNullOrEmpty(a.SampPrepCtx))
                    {
                        //see if matching prep method exists

                        TWqxRefSampPrep sp = db_Ref.GetT_WQX_REF_SAMP_PREP_ByIDandContext(a.SampPrepId, a.SampPrepCtx);
                        if (sp != null)
                            a.SampPrepIdx = sp.SampPrepIdx;
                        else  //no matching sample prep method lookup found
                        { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Sample Prep Method found - please add it at the Reference Data screen first. "; }
                    }
                }
                //********************** CUSTOM POST VALIDATION ********************************************


                a.ImportStatusDesc = a.ImportStatusDesc.SubStringPlus(0, 200);

                if (insInd) //insert case
                {
                    _db.TWqxImportTempSample.Add(a);
                }
                else
                {
                    _db.TWqxImportTempSample.Update(a);
                }

                _db.SaveChanges();

                return a.TempSampleIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void WQX_IMPORT_TEMP_SAMPLE_GenVal(ref TWqxImportTempSample a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            
            var _rules = t.Find(item => item._name == f);   //import validation rules for this field
            if (_rules == null)
                return;

            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //if this field has another field which gets added to it (used for Date + Time fields)
                if (!string.IsNullOrEmpty(_rules._addfield))
                    _value = _value + " " + Utils.GetValueOrDefault(colVals, _rules._addfield);

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ");

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ");
                    }
                }

                //datetime: check type
                if (_rules._datatype == "datetime")
                {
                    if (_value.ConvertOrDefault<DateTime>().Year < 1900)
                    {
                        if (_rules._req == "Y")
                            _value = new DateTime(1900, 1, 1).ToString();

                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not properly formatted. ");
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ");
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    if (_rules._datatype == "")
                        _value = "-";
                    else if (_rules._datatype == "datetime")
                        _value = new DateTime(1900, 1, 1).ToString();
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ");
                }
            }

            //finally set the value before returning
            try
            {
                if (_rules._datatype == "")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value);
                else if (_rules._datatype == "int")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
                else if (_rules._datatype == "datetime" && _rules._req == "Y")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime>());
                else if (_rules._datatype == "datetime" && _rules._req == "N")
                    typeof(TWqxImportTempSample).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime?>());
            }
            catch { }
        }


        public static int InsertOrUpdateWQX_IMPORT_TEMP_SAMPLE_Status(int tEMP_SAMPLE_IDX, string sTATUS_CD, string sTATUS_DESC)
        {
            try
            {
                //TODO: Insert and update logice need to be fixed
                TWqxImportTempSample a =
                        (from c in _db.TWqxImportTempSample
                         where c.TempSampleIdx == tEMP_SAMPLE_IDX
                         select c).FirstOrDefault();

               
                a.ImportStatusCd = sTATUS_CD;
                a.ImportStatusDesc = (a.ImportStatusDesc + " " + sTATUS_DESC).SubStringPlus(0, 100);
                _db.TWqxImportTempSample.Update(a);
                _db.SaveChanges();

                return tEMP_SAMPLE_IDX;
            }
            catch (Exception ex)
            {
                sTATUS_CD = "F";
                sTATUS_DESC += "Unspecified error";
                return 0;
            }

        }

        public static int DeleteT_WQX_IMPORT_TEMP_SAMPLE(string uSER_ID)
        {
            try
            {
                string sql = "DELETE FROM T_WQX_IMPORT_TEMP_SAMPLE WHERE USER_ID = '" + uSER_ID + "'";
                int result = _db.Database.ExecuteSqlCommand(sql, null);
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static TWqxImportTempSample GetWQX_IMPORT_TEMP_SAMPLE_ByID(int TempSampleID)
        {
            try
            {
                
                return (from a in _db.TWqxImportTempSample
                        where a.TempSampleIdx == TempSampleID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_IMPORT_TEMP_SAMPLE_CountByUserID(string UserID)
        {
            try
            {
                
                return (from a in _db.TWqxImportTempSample
                        where a.UserId == UserID
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_IMPORT_TEMP_SAMPLE_DupActivityIDs(string UserID, string OrgID)
        {
            try
            {
                return (from t in _db.TWqxImportTempSample
                        join a in _db.TWqxActivity on t.ActivityId equals a.ActivityId
                        where t.UserId == UserID
                        && a.OrgId == OrgID
                        select a).Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int SP_ImportActivityFromTemp(string userID, string WQXInd, string activityReplacedInd)
        {
            try
            {
                //TODO: verify call to StoredProcedure is working
                //return ctx.ImportActivityFromTemp(userID, WQXInd, activityReplacedInd);
                return _db.Database.ExecuteSqlCommand("ImportActivityFromTemp @p0, @p1, @p2", parameters: new[] { userID, WQXInd, activityReplacedInd });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // *************************** IMPORT: RESULT ******************************
        // *****************************************************************************
        public static int InsertOrUpdateWQX_IMPORT_TEMP_RESULT(IHttpContextAccessor httpContextAccessor, global::System.Int32? tEMP_RESULT_IDX, int tEMP_SAMPLE_IDX, global::System.Int32? rESULT_IDX, string dATA_LOGGER_LINE,
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
            string lAB_SAMP_PREP_ID, string lAB_SAMP_PREP_CTX, DateTime? lAB_SAMP_PREP_START_DT, DateTime? lAB_SAMP_PREP_END_DT, string dILUTION_FACTOR, string sTATUS_CD, string sTATUS_DESC, bool BioIndicator, string orgID, Boolean autoImportRefDataInd)
        {
            Boolean insInd = false;
            try
            {

                TWqxImportTempResult a = new TWqxImportTempResult();

                if (tEMP_RESULT_IDX != null)
                    a = (from c in _db.TWqxImportTempResult
                         where c.TempResultIdx == tEMP_RESULT_IDX
                         select c).FirstOrDefault();

                if (tEMP_RESULT_IDX == null) //insert case
                    insInd = true;

                a.TempSampleIdx = tEMP_SAMPLE_IDX;
                if (rESULT_IDX != null) a.ResultIdx = rESULT_IDX;

                if (!string.IsNullOrEmpty(dATA_LOGGER_LINE))
                {
                    a.DataLoggerLine = dATA_LOGGER_LINE.Trim().SubStringPlus(0, 15);
                }

                if (rESULT_DETECT_CONDITION == "DNQ" || rESULT_MSR == "DNQ") { rESULT_DETECT_CONDITION = "Detected Not Quantified"; rESULT_MSR = "DNQ"; }
                if (rESULT_DETECT_CONDITION == "ND" || rESULT_MSR == "ND") { rESULT_DETECT_CONDITION = "Not Detected"; rESULT_MSR = "ND"; }
                if (rESULT_DETECT_CONDITION == "NR" || rESULT_MSR == "NR") { rESULT_DETECT_CONDITION = "Not Reported"; rESULT_MSR = "NR"; }
                if (rESULT_DETECT_CONDITION == "PAQL" || rESULT_MSR == "PAQL") { rESULT_DETECT_CONDITION = "Present Above Quantification Limit"; rESULT_MSR = "PAQL"; }
                if (rESULT_DETECT_CONDITION == "PBQL" || rESULT_MSR == "PBQL") { rESULT_DETECT_CONDITION = "Present Below Quantification Limit"; rESULT_MSR = "PBQL"; }

                if (!string.IsNullOrEmpty(rESULT_DETECT_CONDITION))
                {
                    a.ResultDetectCondition = rESULT_DETECT_CONDITION.Trim().SubStringPlus(0, 35);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultDetectionCondition", rESULT_DETECT_CONDITION.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Detection Condition not valid. "; }
                }

                if (!string.IsNullOrEmpty(cHAR_NAME))
                {
                    a.CharName = cHAR_NAME.Trim().SubStringPlus(0, 120);
                    if (db_Ref.GetT_WQX_REF_CHARACTERISTIC_ExistCheck(cHAR_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Characteristic Name not valid. "; }
                }

                if (!string.IsNullOrEmpty(mETHOD_SPECIATION_NAME))
                {
                    a.MethodSpeciationName = mETHOD_SPECIATION_NAME.Trim().SubStringPlus(0, 20);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MethodSpeciation", mETHOD_SPECIATION_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Method Speciation not valid. "; }
                }

                if (!string.IsNullOrEmpty(rESULT_SAMP_FRACTION))
                {
                    a.ResultSampFraction = rESULT_SAMP_FRACTION.Trim().SubStringPlus(0, 25);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultSampleFraction", rESULT_SAMP_FRACTION.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Sample Fraction not valid. "; }
                }
                else
                {
                    if (db_Ref.GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(cHAR_NAME.Trim()) == true) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Fraction must be reported."; }
                }

                if (!string.IsNullOrEmpty(rESULT_MSR))
                {
                    a.ResultMsr = rESULT_MSR.Trim().SubStringPlus(0, 60).Replace(",", "");
                }
                else
                {
                    if (string.IsNullOrEmpty(rESULT_DETECT_CONDITION)) { sTATUS_CD = "F"; sTATUS_DESC += "Either Result Measure or Result Detection Condition must be reported."; }
                }

                if (!string.IsNullOrEmpty(rESULT_MSR_UNIT))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", rESULT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Measurement Unit not valid. "; }
                    a.ResultMsrUnit = rESULT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(rESULT_MSR_QUAL))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultMeasureQualifier", rESULT_MSR_QUAL.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Measurement Qualifier not valid. "; }
                    a.ResultMsrQual = rESULT_MSR_QUAL.Trim().SubStringPlus(0, 5);
                }

                if (!string.IsNullOrEmpty(rESULT_STATUS))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultStatus", rESULT_STATUS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Status not valid. "; }
                    a.ResultStatus = rESULT_STATUS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(sTATISTIC_BASE_CODE))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("StatisticalBase", sTATISTIC_BASE_CODE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Statistic Base Code not valid. "; }
                    a.StatisticBaseCode  = sTATISTIC_BASE_CODE.Trim().SubStringPlus(0, 25);
                }

                if (!string.IsNullOrEmpty(rESULT_VALUE_TYPE))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultValueType", rESULT_VALUE_TYPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Value Type not valid. "; }
                    a.ResultValueType = rESULT_VALUE_TYPE.Trim().SubStringPlus(0, 20);
                }

                if (!string.IsNullOrEmpty(wEIGHT_BASIS))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultWeightBasis", wEIGHT_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Weight Basis not valid. "; }
                    a.WeightBasis = wEIGHT_BASIS.Trim().SubStringPlus(0, 15);
                }

                if (!string.IsNullOrEmpty(tIME_BASIS))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultTimeBasis", tIME_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Time Basis not valid. "; }
                    a.TimeBasis = tIME_BASIS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(tEMP_BASIS))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("ResultTemperatureBasis", tEMP_BASIS.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Temp Basis not valid. "; }
                    a.TempBasis = tEMP_BASIS.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(pARTICAL_BASIS))
                    a.ParticlesizeBasis = pARTICAL_BASIS.Trim().SubStringPlus(0, 40);

                if (!string.IsNullOrEmpty(pRECISION_VALUE))
                    a.PrecisionValue = pRECISION_VALUE.Trim().SubStringPlus(0, 60);

                if (!string.IsNullOrEmpty(bIAS_VALUE))
                    a.BiasValue = bIAS_VALUE.Trim().SubStringPlus(0, 60);

                if (!string.IsNullOrEmpty(cONFIDENCE_INTERVAL_VALUE))
                    a.ConfidenceIntervalValue = cONFIDENCE_INTERVAL_VALUE.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(uP_CONFIDENCE_LIMIT))
                    a.UpperConfidenceLimit = uP_CONFIDENCE_LIMIT.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(lOW_CONFIDENCE_LIMIT))
                    a.LowerConfidenceLimit = lOW_CONFIDENCE_LIMIT.Trim().SubStringPlus(0, 15);

                if (!string.IsNullOrEmpty(rESULT_COMMENT))
                    a.ResultComment = rESULT_COMMENT.Trim().SubStringPlus(0, 4000);

                if (!string.IsNullOrEmpty(dEPTH_HEIGHT_MSR))
                    a.DepthHeightMsr = dEPTH_HEIGHT_MSR.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(dEPTH_HEIGHT_MSR_UNIT))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", dEPTH_HEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Result Depth Unit not valid. "; }
                    a.DepthHeightMsrUnit = dEPTH_HEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                }

                if (!string.IsNullOrEmpty(dEPTHALTITUDEREFPOINT))
                    a.Depthaltituderefpoint = dEPTHALTITUDEREFPOINT.Trim().SubStringPlus(0, 125);


                if (BioIndicator == true)
                {

                    if (!string.IsNullOrEmpty(bIO_INTENT_NAME))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("BiologicalIntent", bIO_INTENT_NAME.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Biological Intent not valid. "; }
                        a.BioIntentName = bIO_INTENT_NAME.Trim().SubStringPlus(0, 35);

                        if (string.IsNullOrEmpty(bIO_SUBJECT_TAXONOMY)) { sTATUS_CD = "F"; sTATUS_DESC += "Taxonomy must be reported when intent is reported. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_INDIVIDUAL_ID))
                        a.BioIndividualId = bIO_INDIVIDUAL_ID.Trim().SubStringPlus(0, 4);

                    if (!string.IsNullOrEmpty(bIO_SUBJECT_TAXONOMY))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("Taxon", bIO_SUBJECT_TAXONOMY.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Subject Taxonomy not valid. "; }
                        a.BioSubjectTaxonomy = bIO_SUBJECT_TAXONOMY.Trim().SubStringPlus(0, 120);

                        if (string.IsNullOrEmpty(bIO_INTENT_NAME)) { sTATUS_CD = "F"; sTATUS_DESC += "Biological intent must be reported when taxonomy is reported. "; }
                    }

                    if (!string.IsNullOrEmpty(bIO_UNIDENTIFIED_SPECIES_ID))
                        a.BioUnidentifiedSpeciesId = bIO_UNIDENTIFIED_SPECIES_ID.Trim().SubStringPlus(0, 120);

                    if (!string.IsNullOrEmpty(bIO_SAMPLE_TISSUE_ANATOMY))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("SampleTissueAnatomy", bIO_SAMPLE_TISSUE_ANATOMY.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Sample Tissue Anatomy not valid. "; }
                        a.BioSampleTissueAnatomy = bIO_SAMPLE_TISSUE_ANATOMY.Trim().SubStringPlus(0, 30);
                    }

                    if (!string.IsNullOrEmpty(gRP_SUMM_COUNT_WEIGHT_MSR))
                        a.GrpSummCountWeightMsr = gRP_SUMM_COUNT_WEIGHT_MSR.Trim().SubStringPlus(0, 12);

                    if (!string.IsNullOrEmpty(gRP_SUMM_COUNT_WEIGHT_MSR_UNIT))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", gRP_SUMM_COUNT_WEIGHT_MSR_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Group Summary Unit not valid. "; }
                        a.GrpSummCountWeightMsrUnit = gRP_SUMM_COUNT_WEIGHT_MSR_UNIT.Trim().SubStringPlus(0, 12);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_CELL_FORM))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("CellForm", tAX_DTL_CELL_FORM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Cell Form not valid. "; }
                        a.TaxDtlCellForm = tAX_DTL_CELL_FORM.Trim().SubStringPlus(0, 11);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_CELL_SHAPE))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("CellShape", tAX_DTL_CELL_SHAPE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Cell Shape not valid. "; }
                        a.TaxDtlCellShape = tAX_DTL_CELL_SHAPE.Trim().SubStringPlus(0, 18);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_HABIT))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("Habit", tAX_DTL_HABIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Habit not valid. "; }
                        a.TaxDtlHabit = tAX_DTL_HABIT.Trim().SubStringPlus(0, 15);
                    }

                    if (!string.IsNullOrEmpty(tAX_DTL_VOLTINISM))
                    {
                        if (db_Ref.GetT_WQX_REF_DATA_ByKey("Voltinism", tAX_DTL_VOLTINISM.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Voltinism not valid. "; }
                        a.TaxDtlVoltinism = tAX_DTL_VOLTINISM.Trim().SubStringPlus(0, 25);
                    }


                    if (!string.IsNullOrEmpty(tAX_DTL_POLL_TOLERANCE))
                        a.TaxDtlPollTolerance = tAX_DTL_POLL_TOLERANCE.Trim().SubStringPlus(0, 4);


                    if (!string.IsNullOrEmpty(tAX_DTL_POLL_TOLERANCE_SCALE))
                        a.TaxDtlPollToleranceScale = tAX_DTL_POLL_TOLERANCE_SCALE.Trim().SubStringPlus(0, 50);

                    if (!string.IsNullOrEmpty(tAX_DTL_TROPHIC_LEVEL))
                        a.TaxDtlTrophicLevel = tAX_DTL_TROPHIC_LEVEL.Trim().SubStringPlus(0, 4);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP1))
                        a.TaxDtlFuncFeedingGroup1 = tAX_DTL_FUNC_FEEDING_GROUP1.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP2))
                        a.TaxDtlFuncFeedingGroup2 = tAX_DTL_FUNC_FEEDING_GROUP2.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(tAX_DTL_FUNC_FEEDING_GROUP3))
                        a.TaxDtlFuncFeedingGroup3 = tAX_DTL_FUNC_FEEDING_GROUP3.Trim().SubStringPlus(0, 6);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassCode = fREQ_CLASS_CODE.Trim().SubStringPlus(0, 50);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_UNIT))
                        a.FreqClassUnit = fREQ_CLASS_UNIT.Trim().SubStringPlus(0, 12);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassUpper = fREQ_CLASS_UPPER.Trim().SubStringPlus(0, 8);

                    if (!string.IsNullOrEmpty(fREQ_CLASS_CODE))
                        a.FreqClassLower = fREQ_CLASS_LOWER.Trim().SubStringPlus(0, 8);

                }


                //analysis method
                //first populate the IDX if it is supplied
                if (aNALYTIC_METHOD_IDX != null)
                    a.AnalyticMethodIdx = aNALYTIC_METHOD_IDX;
                else
                {
                    //if ID is supplied but Context is not, set context to org id 
                    if (!string.IsNullOrEmpty(aNALYTIC_METHOD_ID) && string.IsNullOrEmpty(aNALYTIC_METHOD_CTX))
                        aNALYTIC_METHOD_CTX = orgID;

                    //if we now have values for the ID and context
                    if (!string.IsNullOrEmpty(aNALYTIC_METHOD_ID) && !string.IsNullOrEmpty(aNALYTIC_METHOD_CTX))
                    {
                        //see if matching collection method exists
                        TWqxRefAnalMethod am = db_Ref.GetT_WQX_REF_ANAL_METHODByIDandContext(aNALYTIC_METHOD_ID.Trim(), aNALYTIC_METHOD_CTX.Trim());
                        if (am != null)
                            a.AnalyticMethodIdx = am.AnalyticMethodIdx;
                        else  //no matching anal method lookup found                            
                        {
                            if (autoImportRefDataInd == true)
                            {
                                db_Ref.InsertOrUpdateT_WQX_REF_ANAL_METHOD(null, aNALYTIC_METHOD_ID.Trim(), aNALYTIC_METHOD_CTX.Trim(), aNALYTIC_METHOD_NAME.Trim(), "", true);
                            }
                            else
                            { sTATUS_CD = "F"; sTATUS_DESC += "No matching Analysis Method found - please add it at the Reference Data screen first. "; }
                        }

                        //****************************************
                        a.AnalyticMethodId = aNALYTIC_METHOD_ID.Trim().SubStringPlus(0, 20);
                        a.AnalyticMethodCtx = aNALYTIC_METHOD_CTX.Trim().SubStringPlus(0, 120);

                        if (!string.IsNullOrEmpty(aNALYTIC_METHOD_NAME))
                            a.AnalyticMethodName = aNALYTIC_METHOD_NAME.Trim().SubStringPlus(0, 120);
                    }
                    else
                    {
                        //if IDX, ID, and Context not supplied, lookup the method from the default Org Char reference list

                        TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME.Trim().SubStringPlus(0, 120));
                        if (rco != null)
                        {
                            a.AnalyticMethodIdx = rco.DefaultAnalMethodIdx;
                            if (rco.DefaultAnalMethodIdx != null)
                            {
                                TWqxRefAnalMethod anal = db_Ref.GetT_WQX_REF_ANAL_METHODByIDX(rco.DefaultAnalMethodIdx.ConvertOrDefault<int>());
                                if (anal != null)
                                {
                                    a.AnalyticMethodId = anal.AnalyticMethodId;
                                    a.AnalyticMethodName = anal.AnalyticMethodName;
                                    a.AnalyticMethodCtx = anal.AnalyticMethodCtx;
                                }
                            }
                        }

                    }
                }

                //********** LABORATORY **********
                if (lAB_IDX != null)
                    a.LabIdx = lAB_IDX;
                else
                {
                    if (!string.IsNullOrEmpty(lAB_NAME))
                    {
                        a.LabName = lAB_NAME;

                        //see if matching lab name exists for this org
                        TWqxRefLab lab = db_Ref.GetT_WQX_REF_LAB_ByIDandContext(lAB_NAME, orgID);
                        if (lab == null)
                        {
                            if (autoImportRefDataInd == true)
                            {
                                db_Ref.InsertOrUpdateT_WQX_REF_LAB(null, lAB_NAME.Trim(), null, null, orgID, true);
                            }
                            else { sTATUS_CD = "F"; sTATUS_DESC += "No matching Lab Name found - please add it at the Reference Data screen first. "; }
                        }
                        else
                            a.LabIdx = lab.LabIdx;
                    }
                }


                if (lAB_ANALYSIS_START_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_ANALYSIS_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_ANALYSIS_START_DT = null;

                    a.LabAnalysisStartDt = lAB_ANALYSIS_START_DT;
                }
                if (lAB_ANALYSIS_END_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_ANALYSIS_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_ANALYSIS_END_DT = null;

                    a.LabAnalysisEndDt = lAB_ANALYSIS_END_DT;
                }


                if (!string.IsNullOrEmpty(lAB_ANALYSIS_TIMEZONE))
                {
                    a.LabAnalysisTimezone = lAB_ANALYSIS_TIMEZONE.Trim().SubStringPlus(0, 4);
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("TimeZone", lAB_ANALYSIS_TIMEZONE.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "TimeZone not valid. "; }
                }
                else
                {
                    //put in Timezone if missing
                    if (lAB_ANALYSIS_START_DT != null || lAB_ANALYSIS_END_DT != null)
                        a.LabAnalysisTimezone = Utils.GetWQXTimeZoneByDate(a.LabAnalysisTimezone.ConvertOrDefault<DateTime>(), httpContextAccessor);
                }

                if (!string.IsNullOrEmpty(rESULT_LAB_COMMENT_CODE))
                    a.ResultLabCommentCode = rESULT_LAB_COMMENT_CODE.Trim().SubStringPlus(0, 3);

                if (!string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL))
                    a.MethodDetectionLevel = mETHOD_DETECTION_LEVEL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(lAB_REPORTING_LEVEL))
                    a.LabReportingLevel = lAB_REPORTING_LEVEL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(pQL))
                    a.Pql = pQL.Trim().SubStringPlus(0, 12);

                if (!string.IsNullOrEmpty(lOWER_QUANT_LIMIT))
                    a.LowerQuantLimit = lOWER_QUANT_LIMIT.Trim().SubStringPlus(0, 12);

                //if result is PBQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (rESULT_DETECT_CONDITION == "Present Below Quantification Limit" && string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL) && string.IsNullOrEmpty(lAB_REPORTING_LEVEL) && string.IsNullOrEmpty(pQL) && string.IsNullOrEmpty(lOWER_QUANT_LIMIT))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME);
                    if (rco != null)
                        a.LowerQuantLimit = rco.DefaultLowerQuantLimit;

                    //if still null, then error
                    if (a.LowerQuantLimit == null)
                    { sTATUS_CD = "F"; sTATUS_DESC += "No Lower Quantification limit reported or default value specified. "; }
                }

                if (!string.IsNullOrEmpty(uPPER_QUANT_LIMIT))
                    a.UpperQuantLimit = uPPER_QUANT_LIMIT.Trim().SubStringPlus(0, 12);

                //if result is PAQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (rESULT_DETECT_CONDITION == "Present Above Quantification Limit" && string.IsNullOrEmpty(mETHOD_DETECTION_LEVEL) && string.IsNullOrEmpty(lAB_REPORTING_LEVEL) && string.IsNullOrEmpty(pQL) && string.IsNullOrEmpty(uPPER_QUANT_LIMIT))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, cHAR_NAME);
                    if (rco != null)
                        a.UpperQuantLimit = rco.DefaultUpperQuantLimit;

                    //if still null, then error
                    if (a.UpperQuantLimit == null)
                    { sTATUS_CD = "F"; sTATUS_DESC += "No Upper Quantification limit reported. "; }
                }

                if (!string.IsNullOrEmpty(dETECTION_LIMIT_UNIT))
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey("MeasureUnit", dETECTION_LIMIT_UNIT.Trim()) == false) { sTATUS_CD = "F"; sTATUS_DESC += "Detection Level Unit not valid. "; }
                    a.DetectionLimitUnit = dETECTION_LIMIT_UNIT.Trim().SubStringPlus(0, 12);
                }


                //********** LAB SAMPLE PREP
                if (lAB_SAMP_PREP_IDX != null)
                    a.LabSampPrepIdx = lAB_SAMP_PREP_IDX;
                else
                {
                    if (!string.IsNullOrEmpty(lAB_SAMP_PREP_ID))
                    {
                        //set context to org id if none is provided 
                        if (string.IsNullOrEmpty(lAB_SAMP_PREP_CTX))
                            lAB_SAMP_PREP_CTX = orgID;

                        a.LabSampPrepId = lAB_SAMP_PREP_ID.Trim().SubStringPlus(0, 20);
                        a.LabSampPrepCtx = lAB_SAMP_PREP_CTX.Trim().SubStringPlus(0, 120);

                        //see if matching lab prep method exists for this org
                        TWqxRefSampPrep ppp = db_Ref.GetT_WQX_REF_SAMP_PREP_ByIDandContext(lAB_SAMP_PREP_ID, lAB_SAMP_PREP_CTX);
                        if (ppp == null) //no match found
                        {
                            if (autoImportRefDataInd == true)
                            {
                                db_Ref.InsertOrUpdateT_WQX_REF_SAMP_PREP(null, lAB_SAMP_PREP_ID.Trim(), lAB_SAMP_PREP_CTX.Trim(), lAB_SAMP_PREP_ID.Trim(), "", true);
                            }
                            else
                            { sTATUS_CD = "F"; sTATUS_DESC += "No matching Lab Sample Prep ID found - please add it at the Reference Data screen first. "; }
                        }
                        else  //match found
                            a.LabSampPrepIdx = ppp.SampPrepIdx;

                    }
                }

                if (lAB_SAMP_PREP_START_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_SAMP_PREP_START_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_SAMP_PREP_START_DT = null;

                    a.LabSampPrepStartDt = lAB_SAMP_PREP_START_DT;
                }

                if (lAB_SAMP_PREP_END_DT != null)
                {
                    //fix improperly formatted datetime
                    if (lAB_SAMP_PREP_END_DT.ConvertOrDefault<DateTime>().Year < 1900)
                        lAB_SAMP_PREP_END_DT = null;

                    a.LabSampPrepEndDt = lAB_SAMP_PREP_END_DT;
                }

                if (!string.IsNullOrEmpty(dILUTION_FACTOR))
                    a.DilutionFactor = dILUTION_FACTOR.Trim().SubStringPlus(0, 12);


                if (sTATUS_CD != null) a.ImportStatusCd = sTATUS_CD;
                if (sTATUS_DESC != null) a.ImportStatusDesc = sTATUS_DESC.SubStringPlus(0, 100);

                if (insInd) //insert case
                {
                    _db.TWqxImportTempResult.Add(a);
                }
                else
                {
                    _db.TWqxImportTempResult.Update(a);
                }

                _db.SaveChanges();

                return a.TempResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //cofigFilePath = HttpContext.Current.Server.MapPath("~/App_Docs/ImportColumnsConfig.xml")
        public static int InsertWQX_IMPORT_TEMP_RESULT_New(int tEMP_SAMPLE_IDX, Dictionary<string, string> colVals, string orgID, string configFilePath, IHttpContextAccessor httpContextAccessor)
        {
            try
            {

                TWqxImportTempResult a = new TWqxImportTempResult();

                a.TempSampleIdx = tEMP_SAMPLE_IDX;
                a.ImportStatusCd = "P";
                a.ImportStatusDesc = "";

                //get import config rules
                List<ConfigInfoType> _allRules = Utils.GetAllColumnInfo("S", configFilePath);

                //******************* PRE VALIDATION *************************************
                //special rule: set values of ND, etc
                string _rdc = Utils.GetValueOrDefault(colVals, "RESULT_DETECT_CONDITION");
                string _res = Utils.GetValueOrDefault(colVals, "RESULT_MSR");
                if (_rdc == "DNQ" || _res == "DNQ") { colVals["RESULT_DETECT_CONDITION"] = "Detected Not Quantified"; colVals["RESULT_MSR"] = "DNQ"; }
                if (_rdc == "ND" || _res == "ND") { colVals["RESULT_DETECT_CONDITION"] = "Not Detected"; colVals["RESULT_MSR"] = "ND"; }
                if (_rdc == "NR" || _res == "NR") { colVals["RESULT_DETECT_CONDITION"] = "Not Reported"; colVals["RESULT_MSR"] = "NR"; }
                if (_rdc == "PAQL" || _res == "PAQL") { colVals["RESULT_DETECT_CONDITION"] = "Present Above Quantification Limit"; colVals["RESULT_MSR"] = "PAQL"; }
                if (_rdc == "PBQL" || _res == "PBQL") { colVals["RESULT_DETECT_CONDITION"] = "Present Below Quantification Limit"; colVals["RESULT_MSR"] = "PBQL"; }
                // ******************* END PRE VALIDATION *********************************


                //******************* DEFAULT VALIDATION *************************************
                List<string> rFields = new List<string>(new string[] { "DATA_LOGGER_LINE","RESULT_DETECT_CONDITION","CHAR_NAME", "METHOD_SPECIATION_NAME",
                        "RESULT_SAMP_FRACTION", "RESULT_MSR","RESULT_MSR_UNIT","RESULT_MSR_QUAL","RESULT_STATUS","STATISTIC_BASE_CODE","RESULT_VALUE_TYPE","WEIGHT_BASIS",
                        "TIME_BASIS","TEMP_BASIS","PARTICLESIZE_BASIS","PRECISION_VALUE","BIAS_VALUE","CONFIDENCE_INTERVAL_VALUE","UPPER_CONFIDENCE_LIMIT","LOWER_CONFIDENCE_LIMIT",
                            "RESULT_COMMENT","DEPTH_HEIGHT_MSR","DEPTH_HEIGHT_MSR_UNIT","DEPTHALTITUDEREFPOINT","BIO_INTENT_NAME","BIO_INDIVIDUAL_ID","BIO_SUBJECT_TAXONOMY",
                            "BIO_UNIDENTIFIED_SPECIES_ID","BIO_SAMPLE_TISSUE_ANATOMY","GRP_SUMM_COUNT_WEIGHT_MSR","GRP_SUMM_COUNT_WEIGHT_MSR_UNIT","TAX_DTL_CELL_FORM",
                            "TAX_DTL_CELL_SHAPE","TAX_DTL_HABIT","TAX_DTL_VOLTINISM","TAX_DTL_POLL_TOLERANCE","TAX_DTL_POLL_TOLERANCE_SCALE","TAX_DTL_TROPHIC_LEVEL",
                            "TAX_DTL_FUNC_FEEDING_GROUP1","TAX_DTL_FUNC_FEEDING_GROUP2","TAX_DTL_FUNC_FEEDING_GROUP3","FREQ_CLASS_CODE","FREQ_CLASS_UNIT","FREQ_CLASS_UPPER",
                            "FREQ_CLASS_LOWER","ANALYTIC_METHOD_IDX","ANALYTIC_METHOD_ID","ANALYTIC_METHOD_CTX","LAB_NAME","LAB_ANALYSIS_START_DT","LAB_ANALYSIS_END_DT",
                            "RESULT_LAB_COMMENT_CODE","METHOD_DETECTION_LEVEL","LAB_REPORTING_LEVEL","PQL","LOWER_QUANT_LIMIT","UPPER_QUANT_LIMIT","DETECTION_LIMIT_UNIT",
                            "LAB_SAMP_PREP_IDX","LAB_SAMP_PREP_ID","LAB_SAMP_PREP_CTX","LAB_SAMP_PREP_START_DT","LAB_SAMP_PREP_END_DT","DILUTION_FACTOR" });

                foreach (KeyValuePair<string, string> entry in colVals)
                    if (rFields.Contains(entry.Key))
                        WQX_IMPORT_TEMP_RESULT_GenVal(ref a, _allRules, colVals, entry.Key);
                //******************* END DEFAULT VALIDATION *************************************


                //******************* POST CUSTOM VALIDATION *************************************
                if (!string.IsNullOrEmpty(a.CharName))
                    if (db_Ref.GetT_WQX_REF_CHARACTERISTIC_ExistCheck(a.CharName) == false) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Characteristic Name not valid. "; }

                //Sample Fraction handling
                if (string.IsNullOrEmpty(a.ResultSampFraction) && !string.IsNullOrEmpty(a.CharName))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultSampFraction = (string.IsNullOrEmpty(rco.DefaultSampFraction) ? null : rco.DefaultSampFraction);
                }
                if (db_Ref.GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(a.CharName) == true && string.IsNullOrEmpty(a.ResultSampFraction)) { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Sample Fraction must be reported."; }


                //Result Status handling
                if (string.IsNullOrEmpty(a.ResultStatus) && !string.IsNullOrEmpty(a.CharName))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultStatus = (string.IsNullOrEmpty(rco.DefaultResultStatus) ? null : rco.DefaultResultStatus);
                }


                //Result Value Type handling
                if (string.IsNullOrEmpty(a.ResultValueType) && !string.IsNullOrEmpty(a.CharName))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultValueType = (string.IsNullOrEmpty(rco.DefaultResultValueType) ? null : rco.DefaultResultValueType);
                }


                if (!string.IsNullOrEmpty(a.ResultMsr))
                    a.ResultMsr = a.ResultMsr.Replace(",", "");
                else
                    if (string.IsNullOrEmpty(a.ResultDetectCondition))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Either Result Measure or Result Detection Condition must be reported."; }

                //if result is reported, but no unit is reported, grab unit from REF_CHAR_ORG default
                if (!string.IsNullOrEmpty(a.ResultMsr) && string.IsNullOrEmpty(a.ResultMsrUnit))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.ResultMsrUnit = rco.DefaultUnit;
                }

                //if result is ND, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (a.ResultDetectCondition == "Not Detected" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.UpperQuantLimit))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.DetectionLimitUnit = (string.IsNullOrEmpty(rco.DefaultDetectLimit) ? null : rco.DefaultDetectLimit);

                    //if still null, then error
                    if (a.DetectionLimitUnit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Upper Quantification limit or default value reported. "; }
                }


                //if result is PBQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from REF_CHAR_ORG default
                if (a.ResultDetectCondition == "Present Below Quantification Limit" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.LowerQuantLimit))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.LowerQuantLimit = (string.IsNullOrEmpty(rco.DefaultLowerQuantLimit) ? null : rco.DefaultLowerQuantLimit);

                    //if still null, then error
                    if (a.LowerQuantLimit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Lower Quantification limit or default value specified. "; }
                }

                //if result is PAQL, but no value has been reported for MDL, LRL, PQL, or Lower Quant Limit, then grab from Org Char default
                if (a.ResultDetectCondition == "Present Above Quantification Limit" && string.IsNullOrEmpty(a.MethodDetectionLevel) && string.IsNullOrEmpty(a.LabReportingLevel) && string.IsNullOrEmpty(a.Pql) && string.IsNullOrEmpty(a.UpperQuantLimit))
                {

                    TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                    if (rco != null)
                        a.UpperQuantLimit = (string.IsNullOrEmpty(rco.DefaultUpperQuantLimit) ? null : rco.DefaultUpperQuantLimit); ;

                    //if still null, then error
                    if (a.UpperQuantLimit == null)
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No Upper Quantification limit or default value reported. "; }
                }



                if (string.IsNullOrEmpty(a.BioIntentName) != string.IsNullOrEmpty(a.BioSubjectTaxonomy))
                { a.ImportStatusCd = "F"; a.ImportStatusDesc += "Taxonomy must be reported when bio intent is reported. "; }


                //analysis method
                if (a.AnalyticMethodIdx == null)
                {
                    //if ID is supplied but Context is not, set context to org id 
                    if (!string.IsNullOrEmpty(a.AnalyticMethodId) && string.IsNullOrEmpty(a.AnalyticMethodCtx))
                        a.AnalyticMethodCtx = orgID;

                    //if we now have values for the ID and context
                    if (!string.IsNullOrEmpty(a.AnalyticMethodId) && !string.IsNullOrEmpty(a.AnalyticMethodCtx))
                    {
                        //see if matching collection method exists

                        TWqxRefAnalMethod am = db_Ref.GetT_WQX_REF_ANAL_METHODByIDandContext(a.AnalyticMethodId, a.AnalyticMethodCtx);
                        if (am != null)
                            a.AnalyticMethodIdx = am.AnalyticMethodIdx;
                        else  //no matching anal method lookup found                            
                        { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Analysis Method found - please add it at the Reference Data screen first. "; }
                    }
                    else
                    {
                        //if IDX, ID, and Context not supplied, lookup the method from the default Org Char reference list

                        TWqxRefCharOrg rco = db_Ref.GetT_WQX_REF_CHAR_ORGByName(orgID, a.CharName);
                        if (rco != null)
                        {
                            a.AnalyticMethodIdx = rco.DefaultAnalMethodIdx;
                            if (rco.DefaultAnalMethodIdx != null)
                            {

                                TWqxRefAnalMethod anal = db_Ref.GetT_WQX_REF_ANAL_METHODByIDX(rco.DefaultAnalMethodIdx.ConvertOrDefault<int>());
                                if (anal != null)
                                {
                                    a.AnalyticMethodId = anal.AnalyticMethodId;
                                    a.AnalyticMethodName = anal.AnalyticMethodName;
                                    a.AnalyticMethodCtx = anal.AnalyticMethodCtx;
                                }
                            }
                        }
                    }
                }



                if (!string.IsNullOrEmpty(a.LabName))
                {

                    TWqxRefLab lab = db_Ref.GetT_WQX_REF_LAB_ByIDandContext(a.LabName, orgID);
                    if (lab != null)
                        a.LabIdx = lab.LabIdx;
                    else
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Lab Name found - please add it at the Reference Data screen first. "; }
                }


                //put in Timezone if missing
                if (a.LabAnalysisStartDt != null || a.LabAnalysisEndDt != null)
                    a.LabAnalysisTimezone = Utils.GetWQXTimeZoneByDate(a.LabAnalysisStartDt.ConvertOrDefault<DateTime>(), httpContextAccessor);


                //********** LAB SAMPLE PREP*************************
                if (a.LabSampPrepIdx == null && !string.IsNullOrEmpty(a.LabSampPrepId))
                {
                    //set context to org id if none is provided 
                    if (string.IsNullOrEmpty(a.LabSampPrepCtx))
                        a.LabSampPrepCtx = orgID;

                    //see if matching lab prep method exists for this org

                    TWqxRefSampPrep ppp = db_Ref.GetT_WQX_REF_SAMP_PREP_ByIDandContext(a.LabSampPrepId, a.LabSampPrepCtx);
                    if (ppp != null)
                        a.LabSampPrepIdx = ppp.SampPrepIdx;
                    else
                    { a.ImportStatusCd = "F"; a.ImportStatusDesc += "No matching Lab Sample Prep ID found - please add it at the Reference Data screen first. "; }
                }


                a.ImportStatusDesc = a.ImportStatusDesc.SubStringPlus(0, 200);
                _db.TWqxImportTempResult.Add(a);
               _db.SaveChanges();

                return a.TempResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static void WQX_IMPORT_TEMP_RESULT_GenVal(ref TWqxImportTempResult a, List<ConfigInfoType> t, Dictionary<string, string> colVals, string f)
        {
            
            var _rules = t.Find(item => item._name == f);   //import validation rules for this field
            if (_rules == null)
                return;

            string _value = Utils.GetValueOrDefault(colVals, f); //supplied value for this field

            if (!string.IsNullOrEmpty(_value)) //if value is supplied
            {
                _value = _value.Trim();

                //if this field has another field which gets added to it (used for Date + Time fields)
                if (!string.IsNullOrEmpty(_rules._addfield))
                    _value = _value + " " + Utils.GetValueOrDefault(colVals, _rules._addfield);

                //strings: field length validation and substring 
                if (_rules._datatype == "" && _rules._length != null)
                {
                    if (_value.Length > _rules._length)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " length (" + _rules._length + ") exceeded. ");

                        _value = _value.SubStringPlus(0, (int)_rules._length);
                    }
                }

                //integers: check type
                if (_rules._datatype == "int")
                {
                    int n;
                    if (int.TryParse(_value, out n) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not numeric. ");
                    }
                }

                //datetime: check type
                if (_rules._datatype == "datetime")
                {
                    if (_value.ConvertOrDefault<DateTime>().Year < 1900)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not properly formatted. ");
                    }
                }


                //ref data lookup
                if (_rules._fkey.Length > 0)
                {
                    if (db_Ref.GetT_WQX_REF_DATA_ByKey(_rules._fkey, _value) == false)
                    {
                        a.ImportStatusCd = "F";
                        a.ImportStatusDesc = (a.ImportStatusDesc + f + " not valid. ");
                    }
                }
            }
            else
            {
                //required check
                if (_rules._req == "Y")
                {
                    if (_rules._datatype == "")
                        _value = "-";
                    else if (_rules._datatype == "datetime")
                        _value = new DateTime(1900, 1, 1).ToString();
                    a.ImportStatusCd = "F";
                    a.ImportStatusDesc = (a.ImportStatusDesc + "Required field " + f + " missing. ");
                }
            }

            //finally set the value before returning
            try
            {
                
                if (_rules._datatype == "")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value);
                else if (_rules._datatype == "int")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<int?>());
                else if (_rules._datatype == "datetime" && _rules._req == "Y")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime>());
                else if (_rules._datatype == "datetime" && _rules._req == "N")
                    typeof(TWqxImportTempResult).GetProperty(f).SetValue(a, _value.ConvertOrDefault<DateTime?>());
            }
            catch { }
        }

        public static List<ImportSampleResultDisplay> GetWQX_IMPORT_TEMP_SAMP_RESULT_Disp(string UserID)
        {
            try
            {
                return (from a in _db.TWqxImportTempSample
                        join b in _db.TWqxImportTempResult on a.TempSampleIdx equals b.TempSampleIdx into tjoin
                        where a.UserId == UserID
                        orderby a.ActivityIdx
                        from b in tjoin.DefaultIfEmpty()
                        select new ImportSampleResultDisplay
                        {
                            TEMP_SAMPLE_IDX = a.TempSampleIdx,
                            ORG_ID = a.OrgId,
                            PROJECT_ID = a.ProjectId,
                            MONLOC_ID = a.MonlocId,
                            ACTIVITY_ID = a.ActivityId,
                            ACT_TYPE = a.ActType,
                            ACT_MEDIA = a.ActMedia,
                            ACT_SUBMEDIA = a.ActSubmedia,
                            ACT_START_DT = a.ActStartDt,
                            ACT_END_DT = a.ActEndDt,
                            ACT_TIME_ZONE = a.ActTimeZone,
                            RELATIVE_DEPTH_NAME = a.RelativeDepthName,
                            ACT_DEPTHHEIGHT_MSR = a.ActDepthheightMsr,
                            ACT_DEPTHHEIGHT_MSR_UNIT = a.ActDepthheightMsrUnit,
                            TOP_DEPTHHEIGHT_MSR = a.TopDepthheightMsr,
                            TOP_DEPTHHEIGHT_MSR_UNIT = a.TopDepthheightMsrUnit,
                            BOT_DEPTHHEIGHT_MSR = a.BotDepthheightMsr,
                            BOT_DEPTHHEIGHT_MSR_UNIT = a.BotDepthheightMsrUnit,
                            DEPTH_REF_POINT = a.DepthRefPoint,
                            ACT_COMMENT = a.ActComment,
                            BIO_ASSEMBLAGE_SAMPLED = a.BioAssemblageSampled,
                            BIO_DURATION_MSR = a.BioDurationMsr,
                            BIO_DURATION_MSR_UNIT = a.BioDurationMsrUnit,
                            BIO_SAMP_COMPONENT = a.BioSampComponent,
                            BIO_SAMP_COMPONENT_SEQ = a.BioSampComponentSeq,
                            SAMP_COLL_METHOD_ID = a.SampCollMethodId,
                            SAMP_COLL_METHOD_CTX = a.SampCollMethodCtx,
                            SAMP_COLL_EQUIP = a.SampCollEquip,
                            SAMP_COLL_EQUIP_COMMENT = a.SampCollEquipComment,
                            SAMP_PREP_ID = a.SampPrepId,
                            SAMP_PREP_CTX = a.SampPrepCtx,
                            TEMP_RESULT_IDX = b.TempResultIdx,
                            DATA_LOGGER_LINE = b.DataLoggerLine,
                            RESULT_DETECT_CONDITION = b.ResultDetectCondition,
                            CHAR_NAME = b.CharName,
                            METHOD_SPECIATION_NAME = b.MethodSpeciationName,
                            RESULT_SAMP_FRACTION = b.ResultSampFraction,
                            RESULT_MSR = b.ResultMsr,
                            RESULT_MSR_UNIT = b.ResultMsrUnit,
                            RESULT_MSR_QUAL = b.ResultMsrQual,
                            RESULT_STATUS = b.ResultStatus,
                            STATISTIC_BASE_CODE = b.StatisticBaseCode,
                            RESULT_VALUE_TYPE = b.ResultValueType,
                            WEIGHT_BASIS = b.WeightBasis,
                            TIME_BASIS = b.TimeBasis,
                            TEMP_BASIS = b.TempBasis,
                            PARTICLESIZE_BASIS = b.ParticlesizeBasis,
                            PRECISION_VALUE = b.PrecisionValue,
                            BIAS_VALUE = b.BiasValue,
                            RESULT_COMMENT = b.ResultComment,

                            BIO_INTENT_NAME = b.BioIntentName,
                            BIO_INDIVIDUAL_ID = b.BioIndividualId,
                            BIO_SUBJECT_TAXONOMY = b.BioSubjectTaxonomy,
                            BIO_UNIDENTIFIED_SPECIES_ID = b.BioUnidentifiedSpeciesId,
                            BIO_SAMPLE_TISSUE_ANATOMY = b.BioSampleTissueAnatomy,
                            GRP_SUMM_COUNT_WEIGHT_MSR = b.GrpSummCountWeightMsr,
                            GRP_SUMM_COUNT_WEIGHT_MSR_UNIT = b.GrpSummCountWeightMsrUnit,
                            FREQ_CLASS_CODE = b.FreqClassCode,
                            FREQ_CLASS_UNIT = b.FreqClassUnit,
                            ANAL_METHOD_ID = b.AnalyticMethodId,
                            ANAL_METHOD_CTX = b.AnalyticMethodCtx,
                            LAB_NAME = b.LabName,
                            ANAL_START_DT = b.LabAnalysisStartDt,
                            ANAL_END_DT = b.LabAnalysisEndDt,
                            LAB_COMMENT_CODE = b.ResultLabCommentCode,
                            DETECTION_LIMIT = b.MethodDetectionLevel,
                            LAB_REPORTING_LEVEL = b.LabReportingLevel,
                            PQL = b.Pql,
                            LOWER_QUANT_LIMIT = b.LowerQuantLimit,
                            UPPER_QUANT_LIMIT = b.UpperQuantLimit,
                            DETECTION_LIMIT_UNIT = b.DetectionLimitUnit,
                            LAB_SAMP_PREP_START_DT = b.LabSampPrepStartDt,
                            DILUTION_FACTOR = b.DilutionFactor,
                            IMPORT_STATUS_CD = (a.ImportStatusCd == "F" || b.ImportStatusCd == null) ? a.ImportStatusCd : b.ImportStatusCd,
                            IMPORT_STATUS_DESC = (a.ImportStatusDesc ?? " ") + " " + (b.ImportStatusDesc ?? "")
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        // *************************** XML GENERATION ********************************
        // ***************************************************************************
        //TODO: Need to verify StoredProcedure call and return value
        public static string SP_GenWQXXML_Single(string TypeText, int recordIDX)
        {
            try
            {
                //return ctx.GenWQXXML_Single(TypeText, recordIDX).First();
                return _db.Database.ExecuteSqlCommand("GenWQXXML_Single @p0, @p1", parameters: new[] { TypeText, recordIDX.ToString() }).ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string SP_GenWQXXML_Single_Delete(string TypeText, int recordIDX)
        {
            //TODO: STOREDPROCEDURE
            return "";
            //try
            //{
            //    return ctx.GenWQXXML_Single_Delete(TypeText, recordIDX).First();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public static string SP_GenWQXXML_Org(string orgID)
        {
            try
            {
                //return ctx.GenWQXXML_Org(orgID).First();
                return _db.Database.ExecuteSqlCommand("GenWQXXML_Org @p0", parameters: new[] { orgID }).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // *************************** ANALYSIS *********************************
        //***********************************************************************
        //TODO: fix this
        public static List<WQXAnalysis_Result> SP_WQXAnalysis(string TypeText, string OrgID, int? MonLocIDX, string charName, DateTime? startDt, DateTime? endDt, string DataIncludeInd)
        {
            try
            {

                //return ctx.WQXAnalysis(TypeText, OrgID, MonLocIDX, charName, startDt, endDt, DataIncludeInd).ToList();
                //return _db.Database.ExecuteSqlCommand("WQXAnalysis @p0, @p1, @p2, @p3, @p4, @p5, @p6", parameters: new[] { TypeText, OrgID.ToString(), MonLocIDX.ToString(), charName, startDt.ToString(), endDt.ToString(), DataIncludeInd });
                return new List<WQXAnalysis_Result>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<VWqxActivityLatest> GetV_WQX_ACTIVITY_LATEST(string OrgID)
        {
            try
            {
                return (from a in _db.VWqxActivityLatest
                        where (OrgID != null ? a.OrgId == OrgID : true)
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static VWqxActivityLatest GetV_WQX_ACTIVITY_LATESTByMonLocID(int MonLocIDX)
        {
            try
            {
                return (from a in _db.VWqxActivityLatest
                        where a.MonlocIdx == MonLocIDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}