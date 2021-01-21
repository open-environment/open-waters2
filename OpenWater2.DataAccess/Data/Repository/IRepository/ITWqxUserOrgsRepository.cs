using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using OpwnWater2.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxUserOrgsRepository : IRepository<TEpaOrgs>
    {
        IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown();
        void Update(TWqxUserOrgs wqxUserOrgs);
        public Task<List<TOeUsers>> GetWQX_USER_ORGS_AdminsByOrgAsync(string OrgID);
        public List<TOeUsers> GetWQX_USER_ORGS_AdminsByOrg(string OrgID);
        public int InsertT_WQX_USER_ORGS(global::System.String oRG_ID, global::System.Int32 uSER_IDX, string rOLE_CD, String cREATE_USER = "system");
        public List<TWqxOrganization> GetWQX_USER_ORGS_ByUserIDX(int UserIDX, bool excludePendingInd);

        public List<UserOrgDisplay> GetT_OE_USERSPending(string OrgID);
    }
}
