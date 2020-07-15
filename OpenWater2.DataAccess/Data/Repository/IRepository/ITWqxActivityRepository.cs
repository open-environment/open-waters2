using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxActivityRepository : IRepository<TWqxActivity>
    {
        IEnumerable<SelectListItem> GetTWqxActvityForDropDown();
        void Update(TWqxActivity wqxActivity);
        public List<TWqxActivity> GetWQX_ACTIVITY(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX);
        public int GetT_WQX_RESULTCount(string OrgID);
        public int GetWQX_ACTIVITY_MyOrgCount(int UserID);
        public List<ActivityListDisplay> GetWQX_ACTIVITYDisplay(bool ActInd, string OrgID, int? MonLocIDX, DateTime? startDt, DateTime? endDt, string ActType, bool WQXPending, int? ProjectIDX, string WQXStatus);
        public int DeleteT_WQX_ACTIVITY(int ActivityIDX, string UserID);
    }
}
