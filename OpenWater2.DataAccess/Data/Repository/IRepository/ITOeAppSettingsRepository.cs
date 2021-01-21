using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITOeAppSettingsRepository : IRepository<TOeAppSettings>
    {
        IEnumerable<SelectListItem> GetTOeAppSettingsForDropDown();
        void Update(TOeAppSettings oeAppSettings);

        string GetT_OE_APP_SETTING(string settingName);
        Task<string> GetT_OE_APP_SETTINGAsync(string v);
    }
}
