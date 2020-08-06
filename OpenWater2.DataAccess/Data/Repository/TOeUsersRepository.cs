using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TOeUsersRepository : Repository<TOeUsers>, ITOeUsersRepository
    {
        private readonly ApplicationDbContext _db;

        public TOeUsersRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetTOeUsersForDropDown()
        {
            throw new NotImplementedException();
        }

        public TOeUsers GetT_OE_USERSByID(string id)
        {
            try
            {
                return _db.TOeUsers.FirstOrDefault(usr => usr.UserId.ToUpper() == id.ToUpper());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TOeUsers GetT_OE_USERSByIDX(int userIdx)
        {
            try
            {
                return _db.TOeUsers.FirstOrDefault(usr => usr.UserIdx == userIdx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TOeUsers> GetUserByRole(int roleID)
        {
            try
            {
                var users = from itemA in _db.TOeUsers
                            join itemB in _db.TOeUserRoles on itemA.UserIdx equals itemB.UserIdx
                            where itemB.RoleIdx == roleID
                            orderby itemA.UserId
                            select itemA;

                return users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TOeUsers oeUsers)
        {
            TOeUsers objFromDb = _db.TOeUsers.Where(x => x.UserIdx == oeUsers.UserIdx).FirstOrDefault();
            objFromDb.UserIdx = oeUsers.UserIdx;
            objFromDb.UserId = oeUsers.UserId;
            objFromDb.PwdHash = oeUsers.PwdHash;
            objFromDb.PwdSalt = oeUsers.PwdSalt;
            objFromDb.Fname = oeUsers.Fname;
            objFromDb.Lname = oeUsers.Lname;
            objFromDb.Email = oeUsers.Email;
            objFromDb.InitalPwdFlag = oeUsers.InitalPwdFlag;
            objFromDb.EffectiveDt = oeUsers.EffectiveDt;
            objFromDb.LastloginDt = oeUsers.LastloginDt;
            objFromDb.Phone = oeUsers.Phone;
            objFromDb.PhoneExt = oeUsers.PhoneExt;
            objFromDb.DefaultOrgId = oeUsers.DefaultOrgId;
            objFromDb.ActInd = oeUsers.ActInd;
            objFromDb.ModifyUserid = oeUsers.ModifyUserid;
            objFromDb.ModifyDt = oeUsers.ModifyDt;
            _db.TOeUsers.Update(objFromDb);
        }

        public int UpdateT_OE_USERS(int idx, string newPWD_HASH, string newPWD_SALT, string newFNAME, string newLNAME, string newEMAIL, bool? newACT_IND, bool? newINIT_PWD_FLG, DateTime? newEFF_DATE, DateTime? newLAST_LOGIN_DT, string newPHONE, string newPHONE_EXT, string newMODIFY_USR)
        {
            try
            {
                TOeUsers row = new TOeUsers();
                row = (from c in _db.TOeUsers where c.UserIdx == idx select c).First();

                if (newPWD_HASH != null)
                    row.PwdHash = newPWD_HASH;

                if (newPWD_SALT != null)
                    row.PwdSalt = newPWD_SALT;

                if (newFNAME != null)
                    row.Fname = newFNAME;

                if (newLNAME != null)
                    row.Lname = newLNAME;

                if (newEMAIL != null)
                    row.Email = newEMAIL;

                if (newACT_IND != null)
                    row.ActInd = (bool)newACT_IND;

                if (newINIT_PWD_FLG != null)
                    row.InitalPwdFlag = (bool)newINIT_PWD_FLG;

                if (newEFF_DATE != null)
                    row.EffectiveDt = (DateTime)newEFF_DATE;

                if (newLAST_LOGIN_DT != null)
                    row.LastloginDt = (DateTime)newLAST_LOGIN_DT;

                if (newPHONE != null)
                    row.Phone = newPHONE;

                if (newPHONE_EXT != null)
                    row.PhoneExt = newPHONE_EXT;

                if (newMODIFY_USR != null)
                    row.ModifyUserid = newMODIFY_USR;

                row.ModifyDt = System.DateTime.Now;

                _db.SaveChanges();
                return row.UserIdx;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
