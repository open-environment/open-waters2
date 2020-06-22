using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TOeUserRolesRepository : Repository<TOeUserRoles>, ITOeUserRolesRepository
    {
        private readonly ApplicationDbContext _db;
        public TOeUserRolesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetTOeUserRolesForDropDown()
        {
            throw new NotImplementedException();
        }

        public List<TOeRoles> GetT_OE_ROLESInUser(int userIDX)
        {
            try
            {
                var roles = from itemA in _db.TOeRoles
                            join itemB in _db.TOeUserRoles on itemA.RoleIdx equals itemB.RoleIdx
                            where itemB.UserIdx == userIDX
                            select itemA;
                
                return roles.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserInRole(string userName, string roleName, TOeUsers user)
        {
            //string tmpRoleNames = "";
            //TOeUsers _user = _unitOfWork.oeUsersRepostory.GetT_OE_USERSByID(userName);
            if (user != null)
            {
                //foreach (TOeRoles r in GetT_OE_ROLESInUser(_user.UserIdx))
                //    tmpRoleNames += r.RoleName + ",";

                int roleCount = GetT_OE_ROLESInUser(user.UserIdx).Where(x => x.RoleName.ToUpper() == roleName.ToUpper()).Count();
                return roleCount > 0;

                //if (tmpRoleNames.Length > 0)
                //{
                //    tmpRoleNames = tmpRoleNames.Substring(0, tmpRoleNames.Length - 1); // Remove trailing comma.
                //    return tmpRoleNames.Split(',');
                //}
            }
            return false;
            //return new string[0];
        }

        public void Update(TOeUserRoles oeUserRoles)
        {
            TOeUserRoles objFromDb = _db.TOeUserRoles.Where(x => x.UserIdx == oeUserRoles.UserIdx).FirstOrDefault();
            objFromDb.UserIdx = oeUserRoles.UserIdx;
            objFromDb.RoleIdx = oeUserRoles.RoleIdx;
            _db.TOeUserRoles.Update(objFromDb);
        }
    }
}
