using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpewnWater2.DataAccess;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefDataRepository : Repository<TWqxRefData>, ITWqxRefDataRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefDataRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_WQX_IMPORT_TRANSLATE(int TranslateID)
        {
            try
            {
                TWqxImportTranslate wqxImportTranslate = _db.TWqxImportTranslate.Where(i => i.TranslateIdx == TranslateID).FirstOrDefault();
                if(wqxImportTranslate != null)
                {
                    _db.TWqxImportTranslate.Remove(wqxImportTranslate);
                    _db.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteT_WQX_REF_CHAR_ORG(string orgName, string charName)
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

        public int DeleteT_WQX_REF_TAXA_ORG(string orgName, string charName)
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

        public int DeleteT_WQX_RESULT(int ResultIDX)
        {
            try
            {
                TWqxResult r = new TWqxResult();
                r = (from c in _db.TWqxResult where c.ResultIdx == ResultIDX select c).FirstOrDefault();
                if(r != null)
                {
                    _db.TWqxResult.Remove(r);
                    _db.SaveChanges();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }

        public List<TWqxRefAnalMethod> GetAllT_WQX_REF_ANAL_METHOD()
        {
            return _db.TWqxRefAnalMethod.ToList();
        }

        public List<TWqxRefCharacteristic> GetAllT_WQX_REF_CHARACTERISTIC()
        {
            return _db.TWqxRefCharacteristic.ToList();
        }

        public List<TWqxRefData> GetAllT_WQX_REF_DATA()
        {
            return _db.TWqxRefData.ToList();
        }

        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREP()
        {
            return _db.TWqxRefSampPrep.ToList();
        }

        public List<AnalMethodDisplay> GetT_WQX_REF_ANAL_METHOD(bool ActInd)
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

        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDandContext(string ID, string Context)
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

        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC(bool ActInd, bool onlyUsedInd)
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

        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTIC_ByOrg(string OrgID, bool RBPInd)
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

        public TWqxRefCharLimits GetT_WQX_REF_CHAR_LIMITS_ByNameUnit(string CharName, string UnitName)
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

        public List<TWqxRefCharOrg> GetT_WQX_REF_CHAR_ORG(string orgName)
        {
            try
            {
                return (from a in _db.TWqxRefCharOrg
                            .Include("DefaultAnalMethodIdxNavigation")
                        where a.OrgId == orgName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxRefCharOrg GetT_WQX_REF_CHAR_ORGByName(string orgName, string charName)
        {
            try
            {
                return (from a in _db.TWqxRefCharOrg
                        where a.OrgId == orgName
                        && a.CharName == charName
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetT_WQX_REF_CHAR_ORG_Count(string orgName)
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

        public List<TWqxRefCounty> GetT_WQX_REF_COUNTY(string StateCode)
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

        public TWqxRefCounty GetT_WQX_REF_COUNTY_ByCountyNameAndState(string stateName, string countyName)
        {
            try
            {
                return (from a in _db.TWqxRefCounty
                        join b in _db.TWqxRefData on a.StateCode equals b.Value
                        where (a.ActInd == true)
                        && b.Table == "State"
                        && b.Text.ToUpper() == stateName.ToUpper()
                        && a.CountyName.ToUpper() == countyName.ToUpper()
                        select a).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TWqxRefData> GetT_WQX_REF_DATA(string tABLE, bool ActInd, bool UsedInd)
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

        public bool GetT_WQX_REF_DATA_ByKey(string table, string value)
        {
            try
            {
                int iCount = (from a in _db.TWqxRefData
                              where (a.ActInd == true)
                              && a.Table == table
                              && a.Value == value
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

        public int GetT_WQX_REF_DATA_Count()
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

        public List<TWqxRefDefaultTimeZone> GetT_WQX_REF_DEFAULT_TIME_ZONE()
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

        public List<TWqxRefSampColMethod> GetT_WQX_REF_SAMP_COL_METHOD_ByContext(string Context)
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

        public List<TWqxRefData> GetT_WQX_REF_TAXA_ByOrg(string OrgID)
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

        public List<TWqxRefTaxaOrg> GetT_WQX_REF_TAXA_ORG(string orgName)
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

        public int InsertOrUpdateT_WQX_REF_ANAL_METHOD(int? aNALYTIC_METHOD_IDX, string aNALYTIC_METHOD_ID, string aNALYTIC_METHOD_CTX, string aNALYTIC_METHOD_NAME, string aNALYTIC_METHOD_DESC, bool aCT_IND)
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
                    _db.TWqxRefAnalMethod.Add(a);

                _db.SaveChanges();
                return a.AnalyticMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(string cHAR_NAME, decimal? dETECT_LIMIT, string dEFAULT_UNIT, bool? uSED_IND, bool aCT_IND, string sAMP_FRAC_REQ, string pICK_LIST)
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
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_CHAR_ORG(string charName, string orgName, string createUserId, string defaultDetectLimit, string defaultUnit, int? defaultAnalMethodIdx, string defaultSampFraction, string defaultResultStatus, string defaultResultTypeValue, string defaultLowerQuantLimit, string defaultUpperQuantLimit)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCharOrg a = new TWqxRefCharOrg();

                if (_db.TWqxRefCharOrg.Any(o => o.CharName == charName && o.OrgId == orgName))
                {
                    //update case
                    a = (from c in _db.TWqxRefCharOrg
                         where c.CharName == charName
                         && c.OrgId == orgName
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.CharName = charName;
                a.OrgId = orgName;
                if (defaultDetectLimit != null) a.DefaultDetectLimit = defaultDetectLimit;
                if (defaultLowerQuantLimit != null) a.DefaultLowerQuantLimit = defaultLowerQuantLimit;
                if (defaultUpperQuantLimit != null) a.DefaultUpperQuantLimit = defaultUpperQuantLimit;
                if (defaultUnit != null) a.DefaultUnit = defaultUnit;
                if (defaultAnalMethodIdx != null) a.DefaultAnalMethodIdx = defaultAnalMethodIdx;
                if (defaultSampFraction != null) a.DefaultSampFraction = defaultSampFraction;
                if (defaultResultStatus != null) a.DefaultResultStatus = defaultResultStatus;
                if (defaultResultTypeValue != null) a.DefaultResultValueType = defaultResultTypeValue;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = createUserId;
                    _db.TWqxRefCharOrg.Add(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_LAB(int? lAB_IDX, string lAB_NAME, string lAB_ACCRED_IND, string lAB_ACCRED_AUTHORITY, string oRG_ID, bool aCT_IND)
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

                _db.SaveChanges();
                return a.LabIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(int? sAMP_COLL_METHOD_IDX, string sAMP_COLL_METHOD_ID, string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND)
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
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == sAMP_COLL_METHOD_ID && o.AnalyticMethodCtx == sAMP_COLL_METHOD_CTX))
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
                    _db.TWqxRefSampColMethod.Add(a);

                _db.SaveChanges();
                return a.SampCollMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_SAMP_PREP(int? sAMP_PREP_IDX, string sAMP_PREP_METHOD_ID, string sAMP_PREP_METHOD_CTX, string sAMP_PREP_METHOD_NAME, string sAMP_PREP_METHOD_DESC, bool aCT_IND)
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
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == sAMP_PREP_METHOD_ID && o.AnalyticMethodCtx == sAMP_PREP_METHOD_CTX))
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
                    _db.TWqxRefSampPrep.Add(a);

                _db.SaveChanges();
                return a.SampPrepIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_TAXA_ORG(string bIO_SUBJECT_TAXAONOMY, string oRG_NAME, string cREATE_USER_ID)
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
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_RESULT(int? rESULT_IDX, int aCTIVITY_IDX, string rESULT_DETECT_CONDITION, string cHAR_NAME, string rESULT_SAMP_FRACTION, string rESULT_MSR, string rESULT_MSR_UNIT, string rESULT_STATUS, string rESULT_VALUE_TYPE, string rESULT_COMMENT, string bIO_INTENT_NAME, string bIO_INDIVIDUAL_ID, string bIO_TAXONOMY, string bIO_SAMPLE_TISSUE_ANATOMY, int? aNALYTIC_METHOD_IDX, int? lAB_IDX, DateTime? lAB_ANALYSIS_START_DT, string dETECTION_LIMIT, string pQL, string lOWER_QUANT_LIMIT, string uPPER_QUANT_LIMIT, int? lAB_SAMP_PREP_IDX, DateTime? lAB_SAMP_PREP_START_DT, string dILUTION_FACTOR, string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT, string cREATE_USER = "system")
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
                    _db.TWqxResult.Add(a);

                _db.SaveChanges();

                return a.ResultIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateWQX_IMPORT_TRANSLATE(int? tRANSLATE_IDX, string oRG_ID, string cOL_NAME, string dATA_FROM, string dATA_TO, string cREATE_USER = "system")
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

                _db.SaveChanges();

                return a.TranslateIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int UpdateT_WQX_REF_DATAByIDX(int IDX, string vALUE, string tEXT, bool ActInd)
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
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        
    }
}
