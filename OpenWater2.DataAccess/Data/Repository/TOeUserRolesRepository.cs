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

        public void Update(TOeUserRoles oeUserRoles)
        {
            TOeUserRoles objFromDb = _db.TOeUserRoles.Where(x => x.UserIdx == oeUserRoles.UserIdx).FirstOrDefault();
            objFromDb.UserIdx = oeUserRoles.UserIdx;
            objFromDb.RoleIdx = oeUserRoles.RoleIdx;
            _db.TOeUserRoles.Update(objFromDb);
        }
    }
}
