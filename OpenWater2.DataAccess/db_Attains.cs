using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OpwnWater2.DataAccess
{
    public class AssessDisplay
    {
        public int ATTAINS_ASSESS_IDX { get; set; }
        public string REPORTING_CYCLE { get; set; }
        public string REPORT_STATUS { get; set; }
        public int ATTAINS_ASSESS_UNIT_IDX { get; set; }
        public string ASSESS_UNIT_NAME { get; set; }
        public string AGENCY_CODE { get; set; }
        public string CYCLE_LAST_ASSESSED { get; set; }
        public string CYCLE_LAST_MONITORED { get; set; }
    }

    public class db_Attains
    {
        private static ApplicationDbContext _db;
        public db_Attains(ApplicationDbContext db)
        {
            _db = db;
        }
        //***************************** ATTAINS_REPORT ************************************************
        public static List<TAttainsReport> GetT_ATTAINS_REPORT_byORG_ID(string OrgID)
        {
            try
            {
                return (from a in _db.TAttainsReport
                        where a.OrgId == OrgID
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TAttainsReport GetT_ATTAINS_REPORT_byID(int ReportID)
        {
            try
            {
                return (from a in _db.TAttainsReport
                        where a.AttainsReportIdx == ReportID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateATTAINS_REPORT(int? aTTAINS_REPORT_IDX, string oRG_ID, string rEPORT_NAME, DateTime? dATA_FROM, DateTime? dATA_TO,
            bool? aTTAINS_IND, string aTTAINS_SUBMIT_STATUS, DateTime? aTTAINS_UPDATE_DT, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                TAttainsReport a = new TAttainsReport();

                if (aTTAINS_REPORT_IDX != null)
                    a = (from c in _db.TAttainsReport
                         where c.AttainsReportIdx == aTTAINS_REPORT_IDX
                         select c).FirstOrDefault();

                if (aTTAINS_REPORT_IDX == null) //insert case
                {
                    insInd = true;
                }

                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (rEPORT_NAME != null) a.ReportName = rEPORT_NAME;
                if (dATA_FROM != null) a.DataFrom = dATA_FROM;
                if (dATA_TO != null) a.DataTo = dATA_TO;
                if (aTTAINS_IND != null) a.AttainsInd = aTTAINS_IND;
                if (aTTAINS_SUBMIT_STATUS != null) a.AttainsSubmitStatus = aTTAINS_SUBMIT_STATUS;
                if (aTTAINS_UPDATE_DT != null) a.AttainsUpdateDt = aTTAINS_UPDATE_DT;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TAttainsReport.Add(a);
                }
                else
                {
                    _db.TAttainsReport.Update(a);
                }
                _db.SaveChanges();

                return a.AttainsReportIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_ATTAINS_REPORT(int aTTAINS_REPORT_IDX)
        {
            try
            {
                TAttainsReport r = (from c in _db.TAttainsReport
                                    where c.AttainsReportIdx == aTTAINS_REPORT_IDX
                                    select c).FirstOrDefault();

                if (r.AttainsSubmitStatus == "Y" || r.AttainsSubmitStatus == "U")
                    return -1;
                _db.TAttainsReport.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }


        //***************************** ATTAINS_REPORT_LOG **************************************************
        public static int InsertOrUpdateATTAINS_REPORT_LOG(int? aTTAINS_LOG_IDX, int? aTTAINS_REPORT_IDX, DateTime? sUBMIT_DT,
            string sUBMIT_FILE, byte[] rESPONSE_FILE, string rESPONSE_TXT, string cDX_SUBMIT_TRANSID, string cDX_SUBMIT_STATUS, string cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TAttainsReportLog a = new TAttainsReportLog();

                if (aTTAINS_LOG_IDX != null)
                    a = (from c in _db.TAttainsReportLog
                         where c.AttainsLogIdx == aTTAINS_LOG_IDX
                         select c).FirstOrDefault();

                if (aTTAINS_REPORT_IDX == null) //insert case
                {
                    insInd = true;
                }

                if (aTTAINS_REPORT_IDX != null) a.AttainsReportIdx = aTTAINS_REPORT_IDX.ConvertOrDefault<int>();
                if (sUBMIT_DT != null) a.SubmitDt = sUBMIT_DT.ConvertOrDefault<DateTime>();
                if (sUBMIT_FILE != null) a.SubmitFile = sUBMIT_FILE;
                if (rESPONSE_FILE != null) a.ResponseFile = rESPONSE_FILE;
                if (rESPONSE_TXT != null) a.ResponseTxt = rESPONSE_TXT;
                if (cDX_SUBMIT_TRANSID != null) a.CdxSubmitTransid = cDX_SUBMIT_TRANSID;
                if (cDX_SUBMIT_STATUS != null) a.CdxSubmitStatus = cDX_SUBMIT_STATUS;

                if (insInd) //insert case
                {
                    _db.TAttainsReportLog.Add(a);
                }
                else
                {
                    _db.TAttainsReportLog.Update(a);
                }

                _db.SaveChanges();

                return a.AttainsLogIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        //***************************** ATTAINS_ASSESS **************************************
        public static List<AssessDisplay> GetT_ATTAINS_ASSESS_byReportID(int ReportID)
        {
            try
            {

                return (from a in _db.TAttainsAssess
                        join b in _db.TAttainsAssessUnits on a.AttainsAssessUnitIdx equals b.AttainsAssessUnitIdx
                        where b.AttainsReportIdx == ReportID
                        select new AssessDisplay
                        {
                            ATTAINS_ASSESS_IDX = a.AttainsAssessIdx,
                            REPORTING_CYCLE = a.ReportingCycle,
                            REPORT_STATUS = a.ReportStatus,
                            ATTAINS_ASSESS_UNIT_IDX = a.AttainsAssessUnitIdx,
                            ASSESS_UNIT_NAME = b.AssessUnitName,
                            AGENCY_CODE = a.AgencyCode,
                            CYCLE_LAST_ASSESSED = a.CycleLastAssessed,
                            CYCLE_LAST_MONITORED = a.CycleLastMonitored
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TAttainsAssess GetT_ATTAINS_ASSESS_byID(int AssessID)
        {
            try
            {
                
                return (from a in _db.TAttainsAssess
                        where a.AttainsAssessIdx == AssessID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateATTAINS_ASSESS(int? aTTAINS_ASSESS_IDX, string rEPORTING_CYCLE, string rEPORT_STATUS, int aTTAINS_ASSESS_UNIT_IDX,
            string aGENCY_CODE, string cYCLE_LAST_ASSESSED, string cYCLE_LAST_MONITORED, string tROPHIC_STATUS_CODE, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                if (aTTAINS_ASSESS_IDX == -1) aTTAINS_ASSESS_IDX = null;

                TAttainsAssess a = null;

                if (aTTAINS_ASSESS_IDX != null)
                    a = (from c in _db.TAttainsAssess
                         where c.AttainsAssessIdx == aTTAINS_ASSESS_IDX
                         select c).FirstOrDefault();

                if (a == null)
                {
                    a = new TAttainsAssess();
                    insInd = true;
                }

                if (rEPORTING_CYCLE != null) a.ReportingCycle = rEPORTING_CYCLE;
                if (rEPORT_STATUS != null) a.ReportStatus = rEPORT_STATUS;
                a.AttainsAssessUnitIdx = aTTAINS_ASSESS_UNIT_IDX;
                if (aGENCY_CODE != null) a.AgencyCode = aGENCY_CODE;
                if (cYCLE_LAST_ASSESSED != null) a.CycleLastAssessed = cYCLE_LAST_ASSESSED;
                if (cYCLE_LAST_MONITORED != null) a.CycleLastMonitored = cYCLE_LAST_MONITORED;
                if (tROPHIC_STATUS_CODE != null) a.TrophicStatusCode = tROPHIC_STATUS_CODE;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TAttainsAssess.Add(a);
                }
                else
                {
                    a.ModifyUserid = cREATE_USER.ToUpper();
                    a.ModifyDt = System.DateTime.Now;
                    _db.TAttainsAssess.Update(a);
                }

                _db.SaveChanges();

                return a.AttainsAssessIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_ATTAINS_ASSESS(int aSSESS_IDX)
        {
            try
            {
                TAttainsAssess r = (from c in _db.TAttainsAssess
                                    where c.AttainsAssessIdx == aSSESS_IDX
                                      select c).FirstOrDefault();
                _db.TAttainsAssess.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }


        //***************************** ATTAINS_ASSESSMENT_UNIT **************************************
        public static List<TAttainsAssessUnits> GetT_ATTAINS_ASSESS_UNITS_byReportID(int ReportID)
        {
            try
            {

                return (from a in _db.TAttainsAssessUnits
                        where a.AttainsReportIdx == ReportID
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TAttainsAssessUnits GetT_ATTAINS_ASSESS_UNITS_byID(int? AssessUnitID)
        {
            try
            {
                return (from a in _db.TAttainsAssessUnits
                        where a.AttainsAssessUnitIdx == AssessUnitID
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateATTAINS_ASSESS_UNITS(int? aTTAINS_ASSESS_UNIT_IDX, int? aTTAINS_REPORT_IDX, string aSSESS_UNIT_ID, string aSSESS_UNIT_NAME,
            string lOCATION_DESC, string aGENCY_CODE, string sTATE_CODE, string aCT_IND, string wATER_TYPE_CODE, decimal? wATER_SIZE, string wATER_UNIT_CODE,
            string uSE_CLASS_CODE, string uSE_CLASS_NAME, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {
                if (aTTAINS_ASSESS_UNIT_IDX == -1) aTTAINS_ASSESS_UNIT_IDX = null;

                TAttainsAssessUnits a = null;

                if (aTTAINS_ASSESS_UNIT_IDX != null)
                    a = (from c in _db.TAttainsAssessUnits
                         where c.AttainsAssessUnitIdx == aTTAINS_ASSESS_UNIT_IDX
                         select c).FirstOrDefault();

                if (a == null)
                {
                    a = new TAttainsAssessUnits();
                    insInd = true;
                }

                if (aTTAINS_REPORT_IDX != null) a.AttainsReportIdx = aTTAINS_REPORT_IDX.ConvertOrDefault<int>();
                if (aSSESS_UNIT_ID != null) a.AssessUnitId = aSSESS_UNIT_ID;
                if (aSSESS_UNIT_NAME != null) a.AssessUnitName = aSSESS_UNIT_NAME;
                if (lOCATION_DESC != null) a.LocationDesc = lOCATION_DESC;
                if (aGENCY_CODE != null) a.AgencyCode = aGENCY_CODE;
                if (sTATE_CODE != null) a.StateCode = sTATE_CODE;
                if (aCT_IND != null) a.ActInd = aCT_IND;
                if (wATER_TYPE_CODE != null) a.WaterTypeCode = wATER_TYPE_CODE;
                if (wATER_SIZE != null) a.WaterSize = wATER_SIZE;
                if (wATER_UNIT_CODE != null) a.WaterUnitCode = wATER_UNIT_CODE;
                if (uSE_CLASS_CODE != null) a.UseClassCode = uSE_CLASS_CODE;
                if (uSE_CLASS_NAME != null) a.UseClassName = uSE_CLASS_NAME;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TAttainsAssessUnits.Add(a);
                }
                else
                {
                    a.ModifyUserid = cREATE_USER.ToUpper();
                    a.ModifyDt = System.DateTime.Now;
                    _db.TAttainsAssessUnits.Update(a);
                }

                _db.SaveChanges();

                return a.AttainsAssessUnitIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_ATTAINS_ASSESS_UNITS(int aSSESS_UNIT_IDX)
        {
            try
            {
                TAttainsAssessUnits r = (from c in _db.TAttainsAssessUnits
                                         where c.AttainsAssessUnitIdx == aSSESS_UNIT_IDX
                                         select c).FirstOrDefault();
                _db.TAttainsAssessUnits.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        //***************************** ATTAINS_ASSESS_UNITS_MLOC **************************************
        public static int InsertOrUpdateATTAINS_ASSESS_UNITS_MLOC(int aSSESS_UNIT_IDX, int mONLOC_IDX, String cREATE_USER = "system")
        {
            Boolean insInd = false;
            try
            {

                TAttainsAssessUnitsMloc a = (from c in _db.TAttainsAssessUnitsMloc
                                             where c.AttainsAssessUnitIdx == aSSESS_UNIT_IDX
                                                 && c.MonlocIdx == mONLOC_IDX
                                             select c).FirstOrDefault();

                if (a == null)
                {
                    a = new TAttainsAssessUnitsMloc();
                    insInd = true;
                }

                a.AttainsAssessUnitIdx = aSSESS_UNIT_IDX;
                a.MonlocIdx = mONLOC_IDX;

                if (insInd) //insert case
                {
                    a.CreateUserid = cREATE_USER.ToUpper();
                    a.CreateDt = System.DateTime.Now;
                    _db.TAttainsAssessUnitsMloc.Add(a);
                }
                else
                {
                    _db.TAttainsAssessUnitsMloc.Update(a);
                }

                _db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxMonloc> GetT_ATTAINS_ASSESS_UNITS_MLOC_byAssessUnit(int? AssessUnitID)
        {
            try
            {
                return (from a in _db.TAttainsAssessUnitsMloc
                        join b in _db.TWqxMonloc on a.MonlocIdx equals b.MonlocIdx
                        where a.AttainsAssessUnitIdx == AssessUnitID
                        select b).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_ATTAINS_ASSESS_UNITS_MLOC(int aSSESS_UNIT_IDX, int mONLOC_IDX)
        {
            try
            {

                TAttainsAssessUnitsMloc r = (from c in _db.TAttainsAssessUnitsMloc
                                             where c.AttainsAssessUnitIdx == aSSESS_UNIT_IDX
                                                 && c.MonlocIdx == mONLOC_IDX
                                             select c).FirstOrDefault();
                _db.TAttainsAssessUnitsMloc.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }


        //***************************** ATTAINS_REF_WATER_TYPE **************************************
        public static List<TAttainsRefWaterType> GetT_ATTAINS_REF_WATER_TYPE()
        {
            try
            {

                return (from a in _db.TAttainsRefWaterType
                        orderby a.WaterTypeCode
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //***************************** SP ***********************************************
        //TODO: verify/fix stored procedure call
        public static string SP_GenATTAINSXML(int reportIDX)
        {
            try
            {
                //return ctx.GenATTAINSXML(reportIDX).First();
                return _db.Database.ExecuteSqlCommand("GenATTAINSXML @p0", parameters: new[] { reportIDX }).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
