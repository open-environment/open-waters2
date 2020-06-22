using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeUserRolesRepository : IRepository<TOeUserRoles>
    {
        IEnumerable<SelectListItem> GetTOeUserRolesForDropDown();
        void Update(TOeUserRoles oeUserRoles);

        public bool IsUserInRole(string userName, string roleName, TOeUsers user);
        public List<TOeRoles> GetT_OE_ROLESInUser(int userIDX);
    }
}
