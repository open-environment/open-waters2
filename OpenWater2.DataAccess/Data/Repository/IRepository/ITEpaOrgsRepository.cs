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
        public string GetT_EPA_ORGS_LastUpdateDate();
        public int InsertOrUpdateT_EPA_ORGS(string orgId, string orgName);
        public int DeleteT_EPA_ORGS();
        void Update(TEpaOrgs tEpaOrgs);
    }
}
