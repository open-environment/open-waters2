using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxUserOrgsRepository : IRepository<TEpaOrgs>
    {
        IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown();
        void Update(TWqxUserOrgs wqxUserOrgs);
    }
}
