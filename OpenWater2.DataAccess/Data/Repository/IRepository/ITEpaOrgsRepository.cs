using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITEpaOrgsRepository : IRepository<TEpaOrgs>
    {
        IEnumerable<SelectListItem> GetTEpaOrgsForDropDown();
        void Update(TEpaOrgs tEpaOrgs);
    }
}
