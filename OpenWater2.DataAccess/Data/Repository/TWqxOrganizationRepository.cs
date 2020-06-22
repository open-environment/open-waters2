using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxOrganizationRepository : Repository<TWqxOrganization>, ITWqxOrganizationRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxOrganizationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        {
            return _db.TWqxOrganization.Select(i => new SelectListItem()
            {
                 Text = i.OrgFormalName,
                 Value = i.OrgId
            });
        }
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd)
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
                return null;
            }
        }
        public List<VWqxAllOrgs> GetV_WQX_ALL_ORGS()
        {
            try
            {
                return (from a in _db.VWqxAllOrgs
                        orderby a.OrgFormalName
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void Update(TWqxOrganization wqxOrganization)
        {
            TWqxOrganization objFromDb = _db.TWqxOrganization.Where(i => i.OrgId == wqxOrganization.OrgId).FirstOrDefault();
            objFromDb.OrgFormalName = wqxOrganization.OrgFormalName;
            //TODO: implement rest of the properties
            _db.SaveChanges();
        }

        public TWqxOrganization GetWQX_ORGANIZATION_ByID(string OrgID)
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

        public TEpaOrgs GetT_EPA_ORGS_ByOrgID(string OrgID)
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

        public int InsertOrUpdateT_WQX_ORGANIZATION(string oRG_ID, string oRG_NAME, string oRG_DESC, string tRIBAL_CODE, string eLECTRONIC_ADDRESS, string eLECTRONICADDRESSTYPE, string tELEPHONE_NUM, string tELEPHONE_NUM_TYPE, string TELEPHONE_EXT, string cDX_SUBMITTER_ID, string cDX_SUBMITTER_PWD, bool? cDX_SUBMIT_IND, string dEFAULT_TIMEZONE, string cREATE_USER = "system", string mAIL_ADDRESS = null, string mAIL_ADD_CITY = null, string mAIL_ADD_STATE = null, string mAIL_ADD_ZIP = null)
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
                }

                _db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int ApproveRejectT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX, string ApproveRejectCode)
        {
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
                    _db.SaveChanges();

                    return 1;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int DeleteT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX)
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
    }
}
