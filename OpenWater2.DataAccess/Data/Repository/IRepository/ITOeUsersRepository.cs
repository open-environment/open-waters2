using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeUsersRepository : IRepository<TOeUsers>
    {
        IEnumerable<SelectListItem> GetTOeUsersForDropDown();
        void Update(TOeUsers oeUsers);

        List<TOeUsers> GetUserByRole(int RoleID);
    }
}
