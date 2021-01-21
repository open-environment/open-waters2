using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using System.Xml;
using OpenEnvironment.gov.epa.cdx;
using cdx.epa.gov;
using System.Xml.Linq;
using Ionic.Zip;
using Microsoft.AspNetCore.Hosting;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxRefDataRepository : Repository<TWqxRefData>, ITWqxRefDataRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        private readonly ITEpaOrgsRepository _epaOrgRepo;
        private readonly ITOeAppSettingsRepository _oeAppSettingsRepo;
        public TWqxRefDataRepository(ApplicationDbContext db,
            IWebHostEnvironment environment,
            ITEpaOrgsRepository epaOrgRepo,
            ITOeAppSettingsRepository oeAppSettingsRepo) : base(db)
        {
            _db = db;
            _environment = environment;
            _epaOrgRepo = epaOrgRepo;
            _oeAppSettingsRepo = oeAppSettingsRepo;
        }

        public int DeleteT_WQX_IMPORT_TRANSLATE(int TranslateID)
        {
            try
            {
                TWqxImportTranslate wqxImportTranslate = _db.TWqxImportTranslate.Where(i => i.TranslateIdx == TranslateID).FirstOrDefault();
                if (wqxImportTranslate != null)
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
                if (r != null)
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

        public List<TWqxRefCounty> GetAllT_WQX_REF_COUNTY()
        {
            try
            {
                return (from a in _db.TWqxRefCounty
                        orderby a.CountyName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxRefData> GetAllT_WQX_REF_DATA()
        {
            return _db.TWqxRefData.ToList();
        }

        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREP()
        {
            return _db.TWqxRefSampPrep.ToList();
        }

        public List<TWqxRefSampPrep> GetAllT_WQX_REF_SAMP_PREPByContext(string Context)
        {
            return _db.TWqxRefSampPrep
                .Where(s => s.SampPrepMethodCtx == Context)
                .ToList();
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

        public List<TWqxRefAnalMethod> GetT_WQX_REF_ANAL_METHODByValue(string value)
        {
            try
            {
                return (from a in _db.TWqxRefAnalMethod
                        where (a.AnalyticMethodId.Contains(value == null ? "" : value)
                        || a.AnalyticMethodCtx.Contains(value == null ? "" : value)
                        || a.AnalyticMethodName.Contains(value == null ? "" : value))
                        select a).ToList();
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

        public List<TWqxRefCharacteristic> GetT_WQX_REF_CHARACTERISTICByCharName(string charName)
        {
            return _db.TWqxRefCharacteristic.Where(c => c.CharName.Contains(string.IsNullOrWhiteSpace(charName) ? "" : charName)).ToList();
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

        public TWqxRefData GetT_WQX_REF_DATA_ByTextGetRow(string table, string text)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        where (a.ActInd == true)
                        && a.Table == table
                        && a.Text.ToUpper() == text.ToUpper()
                        select a).FirstOrDefault();

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<TWqxRefData> GetT_WQX_REF_DATA_ByValueOrText(string table, string value)
        {
            try
            {
                return (from a in _db.TWqxRefData
                        where a.Table == table
                        //&& (a.Value + " " + a.Text).Contains(value == null ? "" : value, StringComparison.CurrentCultureIgnoreCase)
                        && (a.Value.Contains(value == null ? "" : value)
                        || a.Text.Contains(value == null ? "" : value))
                        orderby a.Value
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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

        public string GetT_WQX_REF_DATA_LastUpdate()
        {
            string actResult = string.Empty;
            try
            {
                DateTime? dt = (from a in _db.TWqxRefData
                                select a.UpdateDt).Max();
                if (dt != null && dt.HasValue)
                {
                    actResult = dt.Value.ToString(@"dd-MM-yyyy HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                actResult = "";
            }
            return actResult;
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

        public List<TWqxRefLab> GetT_WQX_REF_LAB_ByOrgId(string OrgId)
        {
            try
            {
                return (from a in _db.TWqxRefLab
                        where a.OrgId == OrgId
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

        public int InsertOrUpdateT_WQX_REF_ANAL_METHOD(int? analyticMethodIdx, string analyticMethodId, string analyticMethodCtx,
            string analyticMethodName, string analyticMethodDesc, bool actInd)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefAnalMethod a = new TWqxRefAnalMethod();

                if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodIdx == analyticMethodIdx))
                {
                    //update case
                    a = (from c in _db.TWqxRefAnalMethod
                         where c.AnalyticMethodIdx == analyticMethodIdx
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefAnalMethod.Any(o => o.AnalyticMethodId == analyticMethodId && o.AnalyticMethodCtx == analyticMethodCtx))
                    {
                        //update case
                        a = (from c in _db.TWqxRefAnalMethod
                             where c.AnalyticMethodId == analyticMethodId
                             && c.AnalyticMethodCtx == analyticMethodCtx
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (analyticMethodId != null) a.AnalyticMethodId = analyticMethodId;
                if (analyticMethodCtx != null) a.AnalyticMethodCtx = analyticMethodCtx;
                if (analyticMethodName != null) a.AnalyticMethodName = analyticMethodName;
                if (analyticMethodDesc != null) a.AnalyticMethodDesc = analyticMethodDesc;
                if (actInd != null) a.ActInd = actInd;

                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    a.ActInd = true;
                    _db.TWqxRefAnalMethod.Add(a);
                }
                _db.SaveChanges();
                return a.AnalyticMethodIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(
            string charName,
            decimal? detectLimit,
            string defaultUnit,
            bool? usedInd,
            bool actInd,
            string sampFracReq,
            string pickList)
        {
            return InsertOrUpdateT_WQX_REF_CHARACTERISTIC(charName,
            detectLimit,
            defaultUnit,
            usedInd,
            actInd,
            sampFracReq,
            pickList, "");
        }
        public int InsertOrUpdateT_WQX_REF_CHARACTERISTIC(
           string charName,
           decimal? detectLimit,
           string defaultUnit,
           bool? usedInd,
           bool actInd,
           string sampFracReq,
           string pickList,
           string methSpecReq)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCharacteristic a = new TWqxRefCharacteristic();

                if (_db.TWqxRefCharacteristic.Any(o => o.CharName == charName))
                {
                    //update case
                    a = (from c in _db.TWqxRefCharacteristic
                         where c.CharName == charName
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.CharName = charName;
                if (detectLimit != null) a.DefaultDetectLimit = detectLimit;
                if (defaultUnit != null) a.DefaultUnit = defaultUnit;
                if (usedInd != null) a.UsedInd = usedInd;
                if (sampFracReq != null) a.SampFracReq = sampFracReq;
                if (pickList != null) a.PickList = pickList;
                // if (methSpecReq != null) a.MethSpecReq = methSpecReq;
                if (actInd != null) a.ActInd = actInd;
                a.UpdateDt = System.DateTime.Now;


                if (insInd) //insert case
                {
                    a.ActInd = true;
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

        public int InsertOrUpdateT_WQX_REF_COUNTY(string stateCode, string countyCode, string countyName, bool? UsedInd)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefCounty a = new TWqxRefCounty();

                if (_db.TWqxRefCounty.Any(o => o.StateCode == stateCode && o.CountyCode == countyCode))
                {
                    //update case
                    a = (from c in _db.TWqxRefCounty
                         where c.StateCode == stateCode
                         && c.CountyCode == countyCode
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.StateCode = stateCode;
                a.CountyCode = countyCode;
                a.CountyName = countyName;

                if (UsedInd != null) a.UsedInd = UsedInd;

                a.UpdateDt = System.DateTime.Now;
                a.ActInd = true;

                if (insInd) //insert case
                {
                    if (UsedInd == null) a.UsedInd = true;
                    _db.TWqxRefCounty.Add(a);
                }
                _db.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int InsertOrUpdateT_WQX_REF_DATA(string table, string value, string text, bool? UsedInd, bool? ActInd)
        {
            return InsertOrUpdateT_WQX_REF_DATA(new TWqxRefData(table, value, text, UsedInd, ActInd));
        }
        public int InsertOrUpdateT_WQX_REF_DATA(TWqxRefData refData)
        {
            try
            {
                if (refData == null) return 0;

                Boolean insInd = true;
                TWqxRefData a = new TWqxRefData();

                if (_db.TWqxRefData.Any(o => o.Value == refData.Value && o.Table == refData.Table))
                {
                    //update case
                    a = (from c in _db.TWqxRefData
                         where c.Value == refData.Value
                         && c.Table == refData.Table
                         select c).FirstOrDefault();
                    insInd = false;
                }

                a.Table = refData.Table == null ? "" : refData.Table;
                a.Value = refData.Value == null ? "" : refData.Value;
                a.ActInd = refData.ActInd == null ? true : refData.ActInd;
                a.Text = refData.Text == null ? "" : UtilityHelper.SubStringPlus(refData.Text, 0, 200);
                a.UsedInd = refData.UsedInd == null ? true : refData.UsedInd;
                a.UpdateDt = System.DateTime.Now;

                if (insInd) //insert case
                {
                    if (refData.ActInd == null) a.ActInd = true;
                    if (refData.UsedInd == null) a.UsedInd = true;
                    _db.TWqxRefData.Add(a);
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

        public int InsertOrUpdateT_WQX_REF_SAMP_PREP(
            int? samPrepIdx, 
            string sampPrepMethodId, 
            string sampPrepMethodCtx, 
            string sampPrepMethodName, 
            string sampPrepMethodDesc, 
            bool actInd)
        {
            try
            {
                Boolean insInd = true;
                TWqxRefSampPrep a = new TWqxRefSampPrep();

                if (_db.TWqxRefSampPrep.Any(o => o.SampPrepIdx == samPrepIdx))
                {
                    //update case
                    a = (from c in _db.TWqxRefSampPrep
                         where c.SampPrepIdx == samPrepIdx
                         select c).FirstOrDefault();
                    insInd = false;
                }
                else
                {
                    if (_db.TWqxRefSampPrep.Any(o => o.SampPrepMethodId == sampPrepMethodId && o.SampPrepMethodCtx == sampPrepMethodCtx))
                    {
                        //update case
                        a = (from c in _db.TWqxRefSampPrep
                             where c.SampPrepMethodId == sampPrepMethodId
                             && c.SampPrepMethodCtx == sampPrepMethodCtx
                             select c).FirstOrDefault();
                        insInd = false;
                    }
                }

                if (sampPrepMethodId != null) a.SampPrepMethodId = sampPrepMethodId;
                if (sampPrepMethodCtx != null) a.SampPrepMethodCtx = sampPrepMethodCtx;
                if (sampPrepMethodName != null) a.SampPrepMethodName = sampPrepMethodName;
                if (sampPrepMethodDesc != null) a.SampPrepMethodDesc = sampPrepMethodDesc;
                if (actInd != null) a.ActInd = actInd;

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

        public int InsertOrUpdateT_WQX_RESULT(int? rESULT_IDX, int aCTIVITY_IDX, string rESULT_DETECT_CONDITION, 
            string cHAR_NAME, string rESULT_SAMP_FRACTION, string rESULT_MSR, string rESULT_MSR_UNIT, 
            string rESULT_STATUS, string rESULT_VALUE_TYPE, string rESULT_COMMENT, string bIO_INTENT_NAME, 
            string bIO_INDIVIDUAL_ID, string bIO_TAXONOMY, string bIO_SAMPLE_TISSUE_ANATOMY, int? aNALYTIC_METHOD_IDX, 
            int? lAB_IDX, DateTime? lAB_ANALYSIS_START_DT, string dETECTION_LIMIT, string pQL, 
            string lOWER_QUANT_LIMIT, string uPPER_QUANT_LIMIT, int? lAB_SAMP_PREP_IDX, 
            DateTime? lAB_SAMP_PREP_START_DT, string dILUTION_FACTOR, string fREQ_CLASS_CODE, string fREQ_CLASS_UNIT,
            string targetCount, decimal? proportionSampProcNumeric, string resultSampPointType, string resultSampPointPlaceInSeries,
            string resultSampPointCommentText, string recordIdentifierUserSupplied, string subjectTaxonomicNameUserSupplied,
            string subjectTaxonomicNameUserSuppliedRefText, string groupSummaryCount, string functionalFeedingGroupName,
            string comparableAnalMethodIdentifier, string comparableAnalMethodIdentifierCtx, string comparableAnalMethodModificationText,
            string labCommentText, string detectionQuantLimitCommentText, string labSampSplitRatio,
            string cREATE_USER = "system")
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

                if (targetCount != null) a.TargetCount = targetCount;
                if (proportionSampProcNumeric != null) a.ProportionSampProcNumeric = proportionSampProcNumeric;
                if (resultSampPointType != null) a.ResultSampPointType = resultSampPointType;
                if (resultSampPointPlaceInSeries != null) a.ResultSampPointPlaceInSeries = resultSampPointPlaceInSeries;
                if (resultSampPointCommentText != null) a.ResultSampPointCommentText = resultSampPointCommentText;
                if (recordIdentifierUserSupplied != null) a.RecordIdentifierUserSupplied = recordIdentifierUserSupplied;
                if (subjectTaxonomicNameUserSupplied != null) a.SubjectTaxonomicNameUserSupplied = subjectTaxonomicNameUserSupplied;
                if (subjectTaxonomicNameUserSuppliedRefText != null) a.SubjectTaxonomicNameUserSuppliedRefText = subjectTaxonomicNameUserSuppliedRefText;
                if (groupSummaryCount != null) a.GroupSummaryCount = groupSummaryCount;
                if (functionalFeedingGroupName != null) a.FunctionalFeedingGroupName = functionalFeedingGroupName;
                if (comparableAnalMethodIdentifier != null) a.ComparableAnalMethodIdentifier = comparableAnalMethodIdentifier;
                if (comparableAnalMethodIdentifierCtx != null) a.ComparableAnalMethodIdentifierCtx = comparableAnalMethodIdentifierCtx;
                if (comparableAnalMethodModificationText != null) a.ComparableAnalMethodModificationText = comparableAnalMethodModificationText;
                if (labCommentText != null) a.LabCommentText = labCommentText;
                if (detectionQuantLimitCommentText != null) a.DetectionQuantLimitCommentText = detectionQuantLimitCommentText;
                if (labSampSplitRatio != null) a.LabSampSplitRatio = labSampSplitRatio;
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
                if (tEXT != null) a.Text = UtilityHelper.SubStringPlus(tEXT, 0, 200);
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

        public int WQXImport_Org()
        {
            int actResult = 0;
            try
            {
                //*******************************************
                //grab latest Organizations from WQX Portal
                //*******************************************
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                WebRequest request = WebRequest.Create("http://www.waterqualitydata.us/Codes/Organization?mimeType=xml");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                //read the response as XML
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(responseFromServer);
                XmlNodeList codes = doc.SelectNodes("Codes")[0].SelectNodes("Code");

                //if we got this far without error, then it's time to delete the previous organizations
                //int SuccID = _db.TEpaOrgs.DeleteT_EPA_ORGS();
                //int SuccID = _epaOrgRepo.DeleteT_EPA_ORGS();
                int SuccID = 1;
                if (SuccID > 0)
                {
                    //iterate through each organization to add to the table
                    //foreach (XmlNode code in codes)
                    //{
                    //    string orgID = code.Attributes[0].Value;
                    //    string orgName = code.Attributes[1].Value;
                    //    _epaOrgRepo.InsertOrUpdateT_EPA_ORGS(orgID, orgName);
                    //}

                    actResult = 1;
                }
                else
                {
                    actResult = 2;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                actResult = 0;
            }
            return actResult;
        }

        public async System.Threading.Tasks.Task<int> WQXImport_RefDataAsync(string tableName)
        {
            int SuccID = 1;
            try
            {
                //******* ORGANIZATION LEVEL *********************
                if (tableName == "ALL" || tableName == "Tribe")
                    SuccID = await GetAndStoreRefTableAsync("Tribe", "Code", "Name", null).ConfigureAwait(false);

                //if it fails on the first, it will likely fail for all - so exit code
                if (SuccID == 0)
                {
                    // lblMsg.Text = "Data retrieval failed";
                    return SuccID;
                }

                // lblMsg.Text = "";

                //******* PROJECT LEVEL *********************
                if (tableName == "ALL" || tableName == "SamplingDesignType")
                    await GetAndStoreRefTableAsync("SamplingDesignType", "Code", "Code", null).ConfigureAwait(false);


                //******* MON LOC LEVEL *********************
                if (tableName == "ALL" || tableName == "County")
                    await GetAndStoreRefTableAsync("County", "CountyFIPSCode", "CountyName", "County").ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Country")
                    await GetAndStoreRefTableAsync("Country", "Code", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "HorizontalCollectionMethod")
                    await GetAndStoreRefTableAsync("HorizontalCollectionMethod", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "HorizontalCoordinateReferenceSystemDatum")
                    await GetAndStoreRefTableAsync("HorizontalCoordinateReferenceSystemDatum", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "MonitoringLocationType")
                    await GetAndStoreRefTableAsync("MonitoringLocationType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "State")
                    await GetAndStoreRefTableAsync("State", "Code", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "VerticalCollectionMethod")
                    await GetAndStoreRefTableAsync("VerticalCollectionMethod", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "VerticalCoordinateReferenceSystemDatum")
                    await GetAndStoreRefTableAsync("VerticalCoordinateReferenceSystemDatum", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "WellFormationType")
                    await GetAndStoreRefTableAsync("WellFormationType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "WellType")
                    await GetAndStoreRefTableAsync("WellType", "Name", "Name", null).ConfigureAwait(false);

                //******* ACTIVITY/RESULTS LEVEL *************            
                if (tableName == "ALL" || tableName == "ActivityMedia")
                    await GetAndStoreRefTableAsync("ActivityMedia", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ActivityMediaSubdivision")
                    await GetAndStoreRefTableAsync("ActivityMediaSubdivision", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ActivityType")
                    await GetAndStoreRefTableAsync("ActivityType", "Code", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ActivityRelativeDepth")
                    await GetAndStoreRefTableAsync("ActivityRelativeDepth", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "AnalyticalMethod")
                    await GetAndStoreRefTableAsync("AnalyticalMethod", "ID", "Name", "AnalMethod").ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Assemblage")
                    await GetAndStoreRefTableAsync("Assemblage", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "BiologicalIntent")
                    await GetAndStoreRefTableAsync("BiologicalIntent", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "CellForm")
                    await GetAndStoreRefTableAsync("CellForm", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "CellShape")
                    await GetAndStoreRefTableAsync("CellShape", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Characteristic")
                    await GetAndStoreRefTableAsync("Characteristic", "Name", "Name", "Characteristic").ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "DetectionQuantitationLimitType")
                    await GetAndStoreRefTableAsync("DetectionQuantitationLimitType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "FrequencyClassDescriptor")
                    await GetAndStoreRefTableAsync("FrequencyClassDescriptor", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Habit")
                    await GetAndStoreRefTableAsync("Habit", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "MeasureUnit")
                    await GetAndStoreRefTableAsync("MeasureUnit", "Code", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "MethodSpeciation")
                    await GetAndStoreRefTableAsync("MethodSpeciation", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "MetricType")
                    await GetAndStoreRefTableAsync("MetricType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "NetType")
                    await GetAndStoreRefTableAsync("NetType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultDetectionCondition")
                    await GetAndStoreRefTableAsync("ResultDetectionCondition", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultLaboratoryComment")
                    await GetAndStoreRefTableAsync("ResultLaboratoryComment", "Code", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultMeasureQualifier")
                    await GetAndStoreRefTableAsync("ResultMeasureQualifier", "Code", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultSampleFraction")
                    await GetAndStoreRefTableAsync("ResultSampleFraction", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultStatus")
                    await GetAndStoreRefTableAsync("ResultStatus", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultTemperatureBasis")
                    await GetAndStoreRefTableAsync("ResultTemperatureBasis", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultTimeBasis")
                    await GetAndStoreRefTableAsync("ResultTimeBasis", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultValueType")
                    await GetAndStoreRefTableAsync("ResultValueType", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultWeightBasis")
                    await GetAndStoreRefTableAsync("ResultWeightBasis", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "SampleCollectionEquipment")
                    await GetAndStoreRefTableAsync("SampleCollectionEquipment", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "SampleContainerColor")
                    await GetAndStoreRefTableAsync("SampleContainerColor", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "SampleContainerType")
                    await GetAndStoreRefTableAsync("SampleContainerType", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "SampleTissueAnatomy")
                    await GetAndStoreRefTableAsync("SampleTissueAnatomy", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "StatisticalBase")
                    await GetAndStoreRefTableAsync("StatisticalBase", "Code", "Code", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Taxon")
                    await GetAndStoreRefTableAsync("Taxon", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ThermalPreservativeUsed")
                    await GetAndStoreRefTableAsync("ThermalPreservativeUsed", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "TimeZone")
                    await GetAndStoreRefTableAsync("TimeZone", "Code", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ToxicityTestType")
                    await GetAndStoreRefTableAsync("ToxicityTestType", "Name", "Name", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "Voltinism")
                    await GetAndStoreRefTableAsync("Voltinism", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "AquiferType")
                    await GetAndStoreRefTableAsync("AquiferType", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "NationalAquifer")
                    await GetAndStoreRefTableAsync("NationalAquifer", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "LocalAquifer")
                    await GetAndStoreRefTableAsync("LocalAquifer", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "LocalAquiferContext")
                    await GetAndStoreRefTableAsync("LocalAquiferContext", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "GearProcedureUnit")
                    await GetAndStoreRefTableAsync("GearProcedureUnit", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "HabitatSelectionMethod")
                    await GetAndStoreRefTableAsync("HabitatSelectionMethod", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "HydrologicCondition")
                    await GetAndStoreRefTableAsync("HydrologicCondition", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "HydrologicEvent")
                    await GetAndStoreRefTableAsync("HydrologicEvent", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "TargetCount")
                    await GetAndStoreRefTableAsync("TargetCount", "Name", "Description", null).ConfigureAwait(false);
                if (tableName == "ALL" || tableName == "ResultSamplingPointType")
                    await GetAndStoreRefTableAsync("ResultSamplingPointType", "Name", "Description", null).ConfigureAwait(false);

                // DisplayDates();

                //if (lblMsg.Text == "")
                //    lblMsg.Text = "Data Retrieval Complete.";
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                // throw;
            }
            return SuccID;
        }

        private async System.Threading.Tasks.Task<int> GetAndStoreRefTableAsync(
            string tableName,
            string ValueString,
            string TextString,
            string CustomParseName)
        {
            try
            {
                //get file

                //DomainValuesService d = new DomainValuesService();
                WQXWebServicesSoapClient.EndpointConfiguration endpointConfiguration
                    = new WQXWebServicesSoapClient.EndpointConfiguration();
                string url = _oeAppSettingsRepo.GetT_OE_APP_SETTING("CDX Ref Data URL");
                WQXWebServicesSoapClient client = new WQXWebServicesSoapClient(endpointConfiguration, url);

                // Get the comma seperated list of available Domain Names 
                //GetDomainNamesRequest dnRequest =
                //    new GetDomainNamesRequest
                //    {
                //        Body = new GetDomainNamesRequestBody
                //        {

                //        }
                //    };
                //GetDomainNamesResponse dnResponse =
                //    await client.GetDomainNamesAsync(dnRequest).ConfigureAwait(false);
                //GetDomainNamesResponseBody dnResponseBody = dnResponse.Body;

                GetDomainValuesRequest request =
                    new GetDomainValuesRequest
                    {
                        Body = new GetDomainValuesRequestBody
                        {
                            domainName = tableName,
                        }
                    };
                GetDomainValuesResponse response = 
                    await client.GetDomainValuesAsync(request).ConfigureAwait(false);
                GetDomainValuesResponseBody responseBody = response.Body;

                //d.Url = db_Ref.GetT_OE_APP_SETTING("CDX Ref Data URL");

                XDocument xdoc = null;

                byte[] b = responseBody.GetDomainValuesResult;

                using (System.IO.Stream stream = new System.IO.MemoryStream(b))
                {
                    using (var zip = ZipFile.Read(stream))
                    {
                        foreach (var entry in zip)
                        {
                            //cleanup any previous files

                            if (File.Exists(Path.Combine(_environment.WebRootPath, "/tmp/" + entry.FileName)))
                                File.Delete(Path.Combine(_environment.WebRootPath, "/tmp/" + entry.FileName));

                            entry.Extract(Path.Combine(_environment.WebRootPath, "/tmp/"));

                            xdoc = XDocument.Load(Path.Combine(_environment.WebRootPath, "/tmp/" + entry.FileName));
                        }
                    }
                }


                // ***************** DEFAULT PARSING **************************************
                if (CustomParseName == null)
                {
                    var lv1s = from lv1 in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRow")
                               select new
                               {
                                   ID = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRowColumn").First(ID2 => ID2.Attribute("colname").Value == ValueString).Attribute("value"),
                                   Text = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == TextString).Attribute("value"),
                               };

                    foreach (var lv1 in lv1s)
                    {

                        InsertOrUpdateT_WQX_REF_DATA(tableName, lv1.ID.Value, lv1.Text.Value, null, null);
                    }

                    var lv1sALT = from lv1 in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRow")
                                  select new
                                  {
                                      ID = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(ID2 => ID2.Attribute("colname").Value == ValueString).Attribute("value"),
                                      Text = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == TextString).Attribute("value"),
                                  };

                    foreach (var lv1 in lv1sALT)
                    {
                        InsertOrUpdateT_WQX_REF_DATA(tableName, lv1.ID.Value, lv1.Text.Value, null, null);
                    }
                }

                // ***************** CUSTOM PARSING for CHARACTERSTIC **************************************
                else if (CustomParseName == "Characteristic")
                {
                    var lv1s = from lv1 in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRow")
                               select new
                               {
                                   ID = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(ID2 => ID2.Attribute("colname").Value == ValueString).Attribute("value"),
                                   SampFracReq = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == "SampleFractionRequired").Attribute("value"),
                                   PickList = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == "PickList").Attribute("value")
                               };

                    foreach (var lv1 in lv1s)
                    {
                        InsertOrUpdateT_WQX_REF_CHARACTERISTIC(lv1.ID.Value, null, null, null, true, lv1.SampFracReq.Value, lv1.PickList.Value);
                    }
                }

                // ***************** CUSTOM PARSING for ANALYTICAL METHOD **************************************
                else if (CustomParseName == "AnalMethod")
                {
                    var lv1s = from lv1 in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRow")
                               select new
                               {
                                   ID = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(ID2 => ID2.Attribute("colname").Value == "ID").Attribute("value"),
                                   Name = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == "Name").Attribute("value"),
                                   CTX = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(CTX2 => CTX2.Attribute("colname").Value == "ContextCode").Attribute("value"),
                                   Desc = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/3}WQXElementRowColumn").First(Desc2 => Desc2.Attribute("colname").Value == "Description").Attribute("value"),
                               };

                    foreach (var lv1 in lv1s)
                    {
                        InsertOrUpdateT_WQX_REF_ANAL_METHOD(null, lv1.ID.Value, lv1.CTX.Value, lv1.Name.Value, lv1.Desc.Value, true);
                    }
                }

                // ***************** CUSTOM PARSING for COUNTY **************************************
                else if (CustomParseName == "County")
                {
                    var lv1s = from lv1 in xdoc.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRow")
                               select new
                               {
                                   ID = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRowColumn").First(ID2 => ID2.Attribute("colname").Value == "CountyFIPSCode").Attribute("value"),
                                   Text = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == "CountyName").Attribute("value"),
                                   State = lv1.Descendants("{http://www.exchangenetwork.net/schema/wqx/2}WQXElementRowColumn").First(Text2 => Text2.Attribute("colname").Value == "StateCode").Attribute("value"),
                               };


                    foreach (var lv1 in lv1s)
                    {
                        InsertOrUpdateT_WQX_REF_COUNTY(lv1.State.Value, lv1.ID.Value, lv1.Text.Value, null);
                    }
                }

                return 1;
            }
            catch (Exception e)
            {
                //lblMsg.Text = "Error" + e.Message;
                return 0;
            }
        }
    }
}
