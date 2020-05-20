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
    }
}
