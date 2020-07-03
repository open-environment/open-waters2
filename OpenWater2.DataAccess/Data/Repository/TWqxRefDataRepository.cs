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
