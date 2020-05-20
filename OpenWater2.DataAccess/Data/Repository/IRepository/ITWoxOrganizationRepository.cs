using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxOrganizationRepository : IRepository<TWqxOrganization>
    {
        IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown();
        void Update(TWqxOrganization wqxOrganization);
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd);
    }
}
