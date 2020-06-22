using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OpenWater2.Models.Model;
using OpenWater2.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using OpewnWater2.DataAccess;

namespace OpwnWater2.DataAccess
{
    public class AnalMethodDisplay
    {
        public int ANALYTIC_METHOD_IDX { get; set; }
        public string AnalMethodDisplayName { get; set; }
    }

    public class db_Ref
    {
        private static ApplicationDbContext _db;
        public db_Ref(ApplicationDbContext db)
        {
            _db = db;
        }
        //*****************APP SETTINGS**********************************
        public static string GetT_OE_APP_SETTING(string settingName)
        {
            try
            {
                return (from a in _db.TOeAppSettings
                        where a.SettingName == settingName
                        select a).FirstOrDefault().SettingValue;
            }
            catch (Exception ex)
            {
                return "";
            }
        }


        //*****************APP TASKS**********************************
        public static TOeAppTasks GetT_OE_APP_TASKS_ByName(string taskName)
        {
            try
            {
                return (from a in _db.TOeAppTasks
                        where a.TaskName == taskName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateT_OE_APP_TASKS(string tASK_NAME, string tASK_STATUS, int? tASK_FREQ_MS, string mODIFY_USERID)
        {
            try
            {
                TOeAppTasks t = new TOeAppTasks();
                t = (from c in _db.TOeAppTasks
                     where c.TaskName == tASK_NAME
                     select c).First();

                if (tASK_STATUS != null) t.TaskStatus = tASK_STATUS;
                if (tASK_FREQ_MS != null) t.TaskFreqMs = (int)tASK_FREQ_MS;
                if (mODIFY_USERID != null) t.ModifyUserid = mODIFY_USERID;
                t.ModifyDt = System.DateTime.Now;
                _db.TOeAppTasks.Add(t);
                _db.SaveChanges();

                return t.TaskIdx;
            }
            catch
            {
                return 0;
            }

        }


        //*********************** WQX TRANSACTION LOG*******************************
        public static int InsertUpdateWQX_TRANSACTION_LOG(int? lOG_ID, string tABLE_CD, int tABLE_IDX, string sUBMIT_TYPE, byte[] rESPONSE_FILE, 
            string rESPONSE_TXT, string cDX_SUBMIT_TRANS_ID, string cDX_SUBMIT_STATUS, string oRG_ID)
        {
            try
            {

                TWqxTransactionLog t = new TWqxTransactionLog();
                if (lOG_ID != null)
                    t = (from c in _db.TWqxTransactionLog
                         where c.LogId == lOG_ID
                         select c).First();

                if (lOG_ID == null)
                    t = new TWqxTransactionLog();

                if (tABLE_CD != null) t.TableCd = tABLE_CD;
                t.TableIdx = tABLE_IDX;
                if (sUBMIT_TYPE != null) t.SubmitType = sUBMIT_TYPE;
                if (rESPONSE_FILE != null) t.ResponseFile = rESPONSE_FILE;
                if (rESPONSE_TXT != null) t.ResponseTxt = rESPONSE_TXT;
                if (cDX_SUBMIT_TRANS_ID != null) t.CdxSubmitTransid = cDX_SUBMIT_TRANS_ID;
                if (cDX_SUBMIT_STATUS != null) t.CdxSubmitTransid = cDX_SUBMIT_STATUS;
                if (oRG_ID != null) t.OrgId = oRG_ID;

                if (lOG_ID == null) //insert case
                {
                    t.SubmitDt = System.DateTime.Now;
                    _db.TWqxTransactionLog.Add(t);
                }
                else
                {
                    _db.TWqxTransactionLog.Update(t);
                }

                _db.SaveChanges();

                return t.LogId;
            }
            catch
            {
                return 0;
            }
        }

        public static List<TWqxTransactionLog> GetWQX_TRANSACTION_LOG(string TableCD, int TableIdx)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where i.TableCd == TableCD
                        && i.TableIdx == TableIdx
                        select i).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxTransactionLog GetWQX_TRANSACTION_LOG_ByLogID(int LogID)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where i.LogId == LogID
                        select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxTransactionLog> GetV_WQX_TRANSACTION_LOG(string TableCD, DateTime? startDt, DateTime? endDt, string OrgID)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where (OrgID == null ? true : i.OrgId == OrgID)
                        && (TableCD == null ? true : i.TableCd == TableCD)
                        && (startDt == null ? true : i.SubmitDt >= startDt)
                        && (endDt == null ? true : i.SubmitDt <= endDt)
                        orderby i.SubmitDt descending
                        select i).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //******************REF ANAL METHOD ****************************************
        public static List<AnalMethodDisplay> GetT_WQX_REF_ANAL_METHOD(Boolean ActInd)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where (ActInd ? a.ActInd == true : true)
                        orderby a.AnalyticMethodCtx, a.AnalyticMethodId
                        select new AnalMethodDisplay
                        {
                            ANALYTIC_METHOD_IDX = a.AnalyticMethodIdx,
                            AnalMethodDisplayName = a.AnalyticMethodCtx + " - " + a.AnalyticMethodId
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateT_WQX_REF_ANAL_METHOD(global::System.Int32? aNALYTIC_METHOD_IDX, global::System.String aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX,
            string aNALYTIC_METHOD_NAME, string aNALYTIC_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;

                TWqxRefAnalMethod a = new TWqxRefAnalMethod();

                if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodIdx == aNALYTIC_METHOD_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefAnalMethod
                         where c.AnalyticMethodIdx == aNALYTIC_METHOD_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == aNALYTIC_METHOD_ID && o.AnalyticMethodCtx == aNALYTIC_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefAnalMethod
                             where c.AnalyticMethodId == aNALYTIC_METHOD_ID
                             && c.AnalyticMethodCtx == aNALYTIC_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (aNALYTIC_METHOD_ID != null) a.AnalyticMethodId = aNALYTIC_METHOD_ID;
                if (aNALYTIC_METHOD_CTX != null) a.AnalyticMethodCtx = aNALYTIC_METHOD_CTX;
                if (aNALYTIC_METHOD_NAME != null) a.AnalyticMethodName = aNALYTIC_METHOD_NAME;
                if (aNALYTIC_METHOD_DESC != null) a.AnalyticMethodDesc = aNALYTIC_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    _db.TWqxRefAnalMethod.Add(a);
                }
                else
                {
                    _db.TWqxRefAnalMethod.Update(a);
                }

                _db.SaveChanges();
                return a.AnalyticMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDandContext(string ID, string Context)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where a.AnalyticMethodId == ID
                        && a.AnalyticMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDX(int IDX)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where a.AnalyticMethodIdx == IDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //******************REF DATA****************************************
        public static int InsertOrUpdateT_WQX_REF_DATA(global::System.String tABLE, global::System.String vALUE, global::System.String tEXT, global::System.Boolean? UsedInd)
        {
            try
            {
                Boolean insInd = true;

                TWqxRefData a = new TWqxRefData();

                if (_db.TWqxRefData.Any(o => o.Value == vALUE && o.Table == tABLE))
                {
                    //update case
                    a = (from c in _db.TWqxRefData
                         where c.Value == vALUE
                         && c.Table == tABLE
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.Table = tABLE;
                a.Value = vALUE;
                a.Text = Utils.SubStringPlus(tEXT, 0, 200);
                if (UsedInd != null) a.UsedInd = UsedInd;

                a.UpdateDt = System.DateTime.Now;
                a.ActInd = true;

                if (insInd) //insert case
                {
                    if (UsedInd == null) a.UsedInd = true;
                    _db.TWqxRefData.Add(a);
                }
                else
                {
                    _db.TWqxRefData.Update(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int UpdateT_WQX_REF_DATAByIDX(global::System.Int32 IDX, global::System.String vALUE, global::System.String tEXT, Boolean ActInd)
        {
            try
            {

                TWqxRefData a = new TWqxRefData();
                a = (from c in _db.TWqxRefData
                     where c.RefDataIdx == IDX
                     select c).FirstOrDefault();

                if (vALUE != null) a.Value = vALUE;
                if (tEXT != null) a.Text = Utils.SubStringPlus(tEXT, 0, 200);
                a.UpdateDt = System.DateTime.Now;
                a.ActInd = ActInd;
                _db.TWqxRefData.Update(a);
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxRefData> GetT_WQX_REF_DATA(string tABLE, Boolean ActInd, Boolean UsedInd)
        {
            try
            {

                return (from a in _db.TWqxRefData
                        where (ActInd ? a.ActInd == true : true)
                        && (UsedInd ? a.UsedInd == true : true)
                        && a.Table == tABLE
                        orderby a.Value
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxRefData> GetT_WQX_REF_DATA_TaxaSearch(string searchStr)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        where a.ActInd == true
                        && a.UsedInd == true
                        && a.Table == "Taxon"
                        && a.Value.Contains(searchStr)
                        orderby a.Text
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxRefData> GetT_WQX_REF_DATA_ActivityTypeUsed(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        join b in _db.TWqxActivity on a.Value equals b.ActType
                        where a.Table == "ActivityType"
                        && b.OrgId == OrgID
                        orderby a.Text
                        select a).Distinct().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool GetT_WQX_REF_DATA_ByKey(string tABLE, string vALUE)
        {
            try
            {
                int iCount = (from a in _db.TWqxRefData
                              where (a.ActInd == true)
                              && a.Table == tABLE
                              && a.Value == vALUE
                              orderby a.Text
                              select a).Count();

                if (iCount == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static TWqxRefData GetT_WQX_REF_DATA_ByTextGetRow(string tABLE, string tEXT)
        {
            try
            {

                return (from a in _db.TWqxRefData
                        where (a.ActInd == true)
                              && a.Table == tABLE
                              && a.Text.ToUpper() == tEXT.ToUpper()
                        select a).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DateTime? GetT_WQX_REF_DATA_LastUpdate()
        {
            try
            {
                return (from a in _db.TWqxRefData
                        select a.UpdateDt).Max();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static int GetT_WQX_REF_DATA_Count()
        {
            try
            {
                return (from a in _db.TWqxRefData
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //******************REF CHARACTERISTIC****************************************
        public static int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(global::System.String cHAR_NAME, global::System.Decimal? dETECT_LIMIT, global::System.String dEFAULT_UNIT, global::System.Boolean? uSED_IND,
            global::System.Boolean aCT_IND, global::System.String sAMP_FRAC_REQ, global::System.String pICK_LIST)
        {
            try
            {
                Boolean insInd = true;

                TWqxRefCharacteristic a = new TWqxRefCharacteristic();

                if (_db.TWqxRefCharacteristic.Any(o => o.CharName == cHAR_NAME))
                {
                    //update case
                    a = (from c in _db.TWqxRefCharacteristic
                         where c.CharName == cHAR_NAME
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.CharName = cHAR_NAME;
                if (dETECT_LIMIT != null) a.DefaultDetectLimit = dETECT_LIMIT;
                if (dEFAULT_UNIT != null) a.DefaultUnit = dEFAULT_UNIT;
                if (uSED_IND != null) a.UsedInd = uSED_IND;
                if (sAMP_FRAC_REQ != null) a.SampFracReq = sAMP_FRAC_REQ;
                if (pICK_LIST != null) a.PickList = pICK_LIST;

                a.UpdateDt = System.DateTime.Now;
                a.ActInd = true;

                if (insInd) //insert case
                {
                    a.UsedInd = false;
                    _db.TWqxRefCharacteristic.Add(a);
                }
                else
                {
                    _db.TWqxRefCharacteristic.Update(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC(Boolean ActInd, Boolean onlyUsedInd)
        {
            try
            {

                return (from a in _db.TWqxRefCharacteristic
                        where (ActInd ? a.ActInd == true : true)
                        && (onlyUsedInd ? a.UsedInd == true : true)
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefCharacteristic GetT_WQX_REF_CHARACTERISTIC_ByName(string CharName)
        {
            try
            {
                return (from a in _db.TWqxRefCharacteristic
                        where a.CharName == CharName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool GetT_WQX_REF_CHARACTERISTIC_ExistCheck(string CharName)
        {
            try
            {
                int iCount = (from a in _db.TWqxRefCharacteristic
                              where (a.ActInd == true)
                              && a.CharName == CharName
                              select a).Count();

                if (iCount == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(string CharName)
        {
            try
            {
                string SampFrac = (from a in _db.TWqxRefCharacteristic
                                   where (a.ActInd == true)
                              && a.CharName == CharName
                                   select a).FirstOrDefault().SampFracReq;

                if (SampFrac == "Y")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC_ByOrg(string OrgID, Boolean RBPInd)
        {
            try
            {
                return (from a in _db.TWqxRefCharacteristic
                        join b in _db.TWqxRefCharOrg on a.CharName equals b.CharName
                        where b.OrgId == OrgID
                        && (RBPInd == true ? a.CharName.Contains("RBP") : true)
                        && (RBPInd == false ? !a.CharName.Contains("RBP") : true)
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        //******************REF CHAR_ORG ****************************************
        //TODO: verify/fix include clause
        public static List<TWqxRefCharOrg> GetT_WQX_REF_CHAR_ORG(string orgName)
        {
            try
            {
                
                return (from a in _db.TWqxRefCharOrg
                            .Include(TWqxRefAnalMethod => TWqxRefAnalMethod)
                        where a.OrgId == orgName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefCharOrg GetT_WQX_REF_CHAR_ORGByName(string orgName, string charName)
        {
            try
            {
                return (from a in _db.TWqxRefCharOrg
                        where a.OrgId   == orgName
                        && a.CharName == charName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetT_WQX_REF_CHAR_ORG_Count(string orgName)
        {
            try
            {
                return (from a in _db.TWqxRefCharOrg
                        where a.OrgId == orgName
                        select a).Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_REF_CHAR_ORG(string orgName, string charName)
        {
            try
            {

                TWqxRefCharOrg r = new TWqxRefCharOrg();
                r = (from c in _db.TWqxRefCharOrg
                     where c.OrgId == orgName
                     && c.CharName == charName
                     select c).FirstOrDefault();
                _db.TWqxRefCharOrg.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int InsertOrUpdateT_WQX_REF_CHAR_ORG(global::System.String cHAR_NAME, global::System.String oRG_NAME, global::System.String cREATE_USER_ID,
            string dEFAULT_DETECT_LIMIT, string dEFAULT_UNIT, int? dEFAULT_ANAL_METHOD_IDX, string dEFAULT_SAMP_FRACTION, string dEFAULT_RESULT_STATUS, 
            string dEFAULT_RESULT_VALUE_TYPE, string dEFAULT_LOWER_QUANT_LIMIT, string dEFAULT_UPPER_QUANT_LIMIT)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCharOrg a = new TWqxRefCharOrg();

                if (_db.TWqxRefCharOrg.Any(o => o.CharName == cHAR_NAME && o.OrgId == oRG_NAME))
                {
                    //update case
                    a = (from c in _db.TWqxRefCharOrg
                         where c.CharName == cHAR_NAME
                         && c.OrgId == oRG_NAME
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.CharName = cHAR_NAME;
                a.OrgId = oRG_NAME;
                if (dEFAULT_DETECT_LIMIT != null) a.DefaultDetectLimit = dEFAULT_DETECT_LIMIT;
                if (dEFAULT_LOWER_QUANT_LIMIT != null) a.DefaultLowerQuantLimit = dEFAULT_LOWER_QUANT_LIMIT;
                if (dEFAULT_UPPER_QUANT_LIMIT != null) a.DefaultUpperQuantLimit = dEFAULT_UPPER_QUANT_LIMIT;
                if (dEFAULT_UNIT != null) a.DefaultUnit = dEFAULT_UNIT;
                if (dEFAULT_ANAL_METHOD_IDX != null) a.DefaultAnalMethodIdx = dEFAULT_ANAL_METHOD_IDX;
                if (dEFAULT_SAMP_FRACTION != null) a.DefaultSampFraction = dEFAULT_SAMP_FRACTION;
                if (dEFAULT_RESULT_STATUS != null) a.DefaultResultStatus = dEFAULT_RESULT_STATUS;
                if (dEFAULT_RESULT_VALUE_TYPE != null) a.DefaultResultValueType = dEFAULT_RESULT_VALUE_TYPE;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = cREATE_USER_ID;
                    _db.TWqxRefCharOrg.Add(a);

                }
                else
                {
                    _db.TWqxRefCharOrg.Update(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //******************REF CHAR LIMIT****************************************
        public static TWqxRefCharLimits GetT_WQX_REF_CHAR_LIMITS_ByNameUnit(string CharName, string UnitName)
        {
            try
            {

                return (from a in _db.TWqxRefCharLimits
                        where a.CharName == CharName
                        && a.UnitName == UnitName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //******************REF COUNTY ****************************************
        public static int InsertOrUpdateT_WQX_REF_COUNTY(global::System.String sTATE_CODE, global::System.String cOUNTY_CODE, global::System.String cOUNTY_NAME, global::System.Boolean? UsedInd)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCounty a = new TWqxRefCounty();

                if (_db.TWqxRefCounty.Any(o => o.StateCode == sTATE_CODE && o.CountyCode == cOUNTY_CODE))
                {
                    //update case
                    a = (from c in _db.TWqxRefCounty
                         where c.StateCode == sTATE_CODE
                         && c.CountyCode == cOUNTY_CODE
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.StateCode = sTATE_CODE;
                a.CountyCode = cOUNTY_CODE;
                a.CountyName = cOUNTY_NAME;

                if (UsedInd != null) a.UsedInd = UsedInd;

                a.UpdateDt = System.DateTime.Now;
                a.ActInd = true;

                if (insInd) //insert case
                {
                    if (UsedInd == null) a.UsedInd = true;
                    _db.TWqxRefCounty.Add(a);

                }
                else
                {
                    _db.TWqxRefCounty.Update(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static TWqxRefCounty GetT_WQX_REF_COUNTY_ByCountyNameAndState(string sTATE_NAME, string cOUNTY_NAME)
        {
            try
            {
                return (from a in _db.TWqxRefCounty
                        join b in _db.TWqxRefData on a.StateCode equals b.Value
                        where (a.ActInd == true)
                        && b.Table == "State"
                        && b.Text.ToUpper() == sTATE_NAME.ToUpper()
                        && a.CountyName.ToUpper() == cOUNTY_NAME.ToUpper()
                        select a).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<TWqxRefCounty> GetT_WQX_REF_COUNTY(string StateCode)
        {
            try
            {
                return (from a in _db.TWqxRefCounty
                        where a.StateCode == StateCode
                        orderby a.CountyName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //******************REF DEFAULT_TIME_ZONE****************************************
        public static List<TWqxRefDefaultTimeZone> GetT_WQX_REF_DEFAULT_TIME_ZONE()
        {
            try
            {

                return (from a in _db.TWqxRefDefaultTimeZone
                        orderby a.TimeZoneName descending
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefDefaultTimeZone GetT_WQX_REF_DEFAULT_TIME_ZONE_ByName(string TimeZoneName)
        {
            try
            {
                return (from a in _db.TWqxRefDefaultTimeZone
                        where a.TimeZoneName == TimeZoneName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //******************REF LAB****************************************
        public static List<TWqxRefLab> GetT_WQX_REF_LAB(string OrgID)
        {
            try
            {

                return (from a in _db.TWqxRefLab
                        where a.OrgId == OrgID
                        orderby a.LabName descending
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefLab GetT_WQX_REF_LAB_ByIDandContext(string Name, string OrgID)
        {
            try
            {
                return (from a in _db.TWqxRefLab
                        where a.OrgId == OrgID
                        && a.LabName == Name
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateT_WQX_REF_LAB(global::System.Int32? lAB_IDX, global::System.String lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefLab a = new TWqxRefLab();

                if (_db.TWqxRefLab.Any(o => o.LabIdx == lAB_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefLab
                         where c.LabIdx == lAB_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefLab.Any(o => o.LabName == lAB_NAME && o.OrgId == oRG_ID))
                    {
                        //update case
                        a = (from c in _db.TWqxRefLab
                             where c.LabName == lAB_NAME
                             && c.OrgId == oRG_ID
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (lAB_NAME != null) a.LabName = lAB_NAME;
                if (lAB_ACCRED_IND != null) a.LabAccredInd = lAB_ACCRED_IND;
                if (lAB_ACCRED_AUTHORITY != null) a.LabAccredAuthority = lAB_ACCRED_AUTHORITY;
                if (oRG_ID != null) a.OrgId = oRG_ID;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    _db.TWqxRefLab.Add(a);
                }
                else
                {
                    _db.TWqxRefLab.Update(a);
                }

                _db.SaveChanges();
                return a.LabIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        //***************** REF_SAMP_COL_METHOD *********************************************
        public static TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(int? IDX)
        {
            try
            {

                return (from a in _db.TWqxRefSampColMethod
                        where a.SampCollMethodIdx == IDX
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(string ID, string Context)
        {
            try
            {
                return (from a in _db.TWqxRefSampColMethod
                        where a.SampCollMethodId == ID
                        && a.SampCollMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxRefSampColMethod> GetT_WQX_REF_SAMP_COL_METHOD_ByContext(string Context)
        {
            try
            {
                return (from a in _db.TWqxRefSampColMethod
                        where a.SampCollMethodCtx == Context
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(global::System.Int32? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID, 
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampColMethod a = new TWqxRefSampColMethod();

                if (_db.TWqxRefSampColMethod.Any(o => o.SampCollMethodIdx == sAMP_COLL_METHOD_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampColMethod
                         where c.SampCollMethodIdx == sAMP_COLL_METHOD_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefSampColMethod.Any(o => o.SampCollMethodId == sAMP_COLL_METHOD_ID && o.SampCollMethodCtx == sAMP_COLL_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampColMethod
                             where c.SampCollMethodId == sAMP_COLL_METHOD_ID
                             && c.SampCollMethodCtx == sAMP_COLL_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sAMP_COLL_METHOD_ID != null) a.SampCollMethodId = sAMP_COLL_METHOD_ID;
                if (sAMP_COLL_METHOD_CTX != null) a.SampCollMethodCtx = sAMP_COLL_METHOD_CTX;
                if (sAMP_COLL_METHOD_NAME != null) a.SampCollMethodName = sAMP_COLL_METHOD_NAME;
                if (sAMP_COLL_METHOD_DESC != null) a.SampCollMethodDesc = sAMP_COLL_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    _db.TWqxRefSampColMethod.Add(a);

                }
                else
                {
                    _db.TWqxRefSampColMethod.Update(a);
                }

                _db.SaveChanges(); 
                return a.SampCollMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }



        //***************** REF_SAMP_PREP *********************************************
        public static TWqxRefSampPrep GetT_WQX_REF_SAMP_PREP_ByIDandContext(string ID, string Context)
        {
            try
            {

                return (from a in _db.TWqxRefSampPrep
                        where a.SampPrepMethodId == ID
                        && a.SampPrepMethodCtx == Context
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TWqxRefSampPrep> GetT_WQX_REF_SAMP_PREP_ByContext(string Context)
        {
            try
            {
                return (from a in _db.TWqxRefSampPrep
                        where a.SampPrepMethodCtx == Context
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int InsertOrUpdateT_WQX_REF_SAMP_PREP(global::System.Int32? sAMP_PREP_IDX, global::System.String sAMP_PREP_METHOD_ID,
            string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampPrep a = new TWqxRefSampPrep();

                if (_db.TWqxRefSampPrep.Any(o => o.SampPrepIdx == sAMP_PREP_IDX))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampPrep
                         where c.SampPrepIdx == sAMP_PREP_IDX
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefSampPrep.Any(o => o.SampPrepMethodId == sAMP_PREP_METHOD_ID && o.SampPrepMethodCtx == sAMP_PREP_METHOD_CTX))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampPrep
                             where c.SampPrepMethodId == sAMP_PREP_METHOD_ID
                             && c.SampPrepMethodCtx == sAMP_PREP_METHOD_CTX
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sAMP_PREP_METHOD_ID != null) a.SampPrepMethodId = sAMP_PREP_METHOD_ID;
                if (sAMP_PREP_METHOD_CTX != null) a.SampPrepMethodCtx = sAMP_PREP_METHOD_CTX;
                if (sAMP_PREP_METHOD_NAME != null) a.SampPrepMethodName = sAMP_PREP_METHOD_NAME;
                if (sAMP_PREP_METHOD_DESC != null) a.SampPrepMethodDesc = sAMP_PREP_METHOD_DESC;
                if (aCT_IND != null) a.ActInd = aCT_IND;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    _db.TWqxRefSampPrep.Add(a);
                }
                else
                {
                    _db.TWqxRefSampPrep.Update(a);
                }
                _db.SaveChanges();
                return a.SampPrepIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //***************** REF_SYS_LOG *********************************************
        public static int InsertT_OE_SYS_LOG(string logType, string logMsg)
        {
            try
            {

                TOeSysLog e = new TOeSysLog();
                e.LogType = logType;
                if (logMsg != null)
                    e.LogMsg = logMsg.SubStringPlus(0, 1999);
                e.LogDt = System.DateTime.Now;

                _db.TOeSysLog.Add(e);
                _db.SaveChanges();
                return e.SysLogId;
            }
            catch
            {
                return 0;
            }
        }


        //******************REF TAXA_ORG ****************************************
        public static List<TWqxRefTaxaOrg> GetT_WQX_REF_TAXA_ORG(string orgName)
        {
            try
            {

                return (from a in _db.TWqxRefTaxaOrg
                        where a.OrgId == orgName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteT_WQX_REF_TAXA_ORG(string orgName, string charName)
        {
            try
            {

                TWqxRefTaxaOrg r = new TWqxRefTaxaOrg();
                r = (from c in _db.TWqxRefTaxaOrg
                     where c.OrgId == orgName
                     && c.BioSubjectTaxonomy == charName
                     select c).FirstOrDefault();
                _db.TWqxRefTaxaOrg.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        public static int InsertOrUpdateT_WQX_REF_TAXA_ORG(global::System.String bIO_SUBJECT_TAXAONOMY, global::System.String oRG_NAME, global::System.String cREATE_USER_ID)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefTaxaOrg a = new TWqxRefTaxaOrg();

                if (_db.TWqxRefTaxaOrg.Any(o => o.BioSubjectTaxonomy == bIO_SUBJECT_TAXAONOMY && o.OrgId == oRG_NAME))
                {
                    //update case
                    a = (from c in _db.TWqxRefTaxaOrg
                         where c.BioSubjectTaxonomy == bIO_SUBJECT_TAXAONOMY
                         && c.OrgId == oRG_NAME
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.BioSubjectTaxonomy = bIO_SUBJECT_TAXAONOMY;
                a.OrgId = oRG_NAME;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = cREATE_USER_ID;
                    _db.TWqxRefTaxaOrg.Add(a);
                }
                else
                {
                    _db.TWqxRefTaxaOrg.Update(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static List<TWqxRefData> GetT_WQX_REF_TAXA_ByOrg(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        join b in _db.TWqxRefTaxaOrg on a.Value equals b.BioSubjectTaxonomy
                        where b.OrgId == OrgID
                        && a.Table == "Taxon"
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //*********************** IMPORT LOG *******************************
        public static int InsertUpdateWQX_IMPORT_LOG(int? iMPORT_ID, string oRG_ID, string tYPE_CD, string fILE_NAME, int fILE_SIZE, string iMPORT_STATUS, string iMPORT_PROGRESS,
            string iMPORT_PROGRESS_MSG, byte[] iMPORT_FILE, string uSER_ID)
        {
            try
            {

                TWqxImportLog t = new TWqxImportLog();
                if (iMPORT_ID != null)
                    t = (from c in _db.TWqxImportLog
                         where c.ImportId == iMPORT_ID
                         select c).First();

                if (iMPORT_ID == null)
                    t = new TWqxImportLog();

                if (oRG_ID != null) t.OrgId = oRG_ID;
                if (tYPE_CD != null) t.TypeCd = tYPE_CD.Substring(0, 5);
                if (fILE_NAME != null) t.FileName = fILE_NAME;
                t.FileSize = fILE_SIZE;
                if (iMPORT_STATUS != null) t.ImportStatus = iMPORT_STATUS;
                if (iMPORT_PROGRESS != null) t.ImportProgress = iMPORT_PROGRESS;
                if (iMPORT_PROGRESS_MSG != null) t.ImportProgressMsg = iMPORT_PROGRESS_MSG;
                if (iMPORT_FILE != null) t.ImportFile = iMPORT_FILE;
                if (uSER_ID != null) t.CreateUserid = uSER_ID;

                if (iMPORT_ID == null) //insert case
                {
                    t.CreateDt = DateTime.Now;
                    _db.TWqxImportLog.Add(t);
                }
                else
                {
                    _db.TWqxImportLog.Update(t);
                }
                _db.SaveChanges();

                return t.ImportId;
            }
            catch
            {
                return 0;
            }
        }

        public static int UpdateWQX_IMPORT_LOG_MarkPendingSampImportAsComplete(string oRG_ID)
        {
            try
            {

                TWqxImportLog t = new TWqxImportLog();
                t = (from c in _db.TWqxImportLog
                     where c.ImportProgress == "P"
                     && c.TypeCd == "Sample"
                     && c.OrgId == oRG_ID
                     select c).FirstOrDefault();

                t.ImportStatus = "Success";
                t.ImportProgress = "100";
                t.ImportProgressMsg = "Import complete.";
                _db.TWqxImportLog.Update(t);
                _db.SaveChanges();

                return t.ImportId;
            }
            catch
            {
                return 0;
            }
        }

        public static List<TWqxImportLog> GetWQX_IMPORT_LOG(string OrgID)
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.OrgId == OrgID
                        select i).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TWqxImportLog GetWQX_IMPORT_LOG_NewActivity()
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.ImportStatus == "New"
                        && i.TypeCd == "Sample"
                        select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetWQX_IMPORT_LOG_ProcessingCount()
        {
            try
            {
                return (from i in _db.TWqxImportLog
                        where i.ImportStatus == "Processing"
                        && i.TypeCd == "Sample"
                        select i).Count();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int DeleteT_WQX_IMPORT_LOG(int iMPORT_ID)
        {
            try
            {
                TWqxImportLog r = new TWqxImportLog();
                r = (from c in _db.TWqxImportLog
                     where c.ImportId == iMPORT_ID
                     select c).FirstOrDefault();
                _db.TWqxImportLog.Remove(r);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }

    }
}