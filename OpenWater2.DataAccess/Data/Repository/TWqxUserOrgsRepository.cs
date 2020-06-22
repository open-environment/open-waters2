using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OpwnWater2.DataAccess;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxUserOrgsRepository : Repository<TEpaOrgs>, ITWqxUserOrgsRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxUserOrgsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        {
            throw new NotImplementedException();
        }

        public List<UserOrgDisplay> GetT_OE_USERSPending(string OrgID)
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

        public List<TOeUsers> GetWQX_USER_ORGS_AdminsByOrg(string OrgID)
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
                throw ex;
            }
        }

        public int InsertT_WQX_USER_ORGS(string oRG_ID, int uSER_IDX, string rOLE_CD, string cREATE_USER = "system")
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

        public void Update(TWqxUserOrgs wqxUserOrgs)
        {
            throw new NotImplementedException();
        }
        
    }
}
