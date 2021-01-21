using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TOeAppSettingsRepository : Repository<TOeAppSettings>, ITOeAppSettingsRepository
    {
        private readonly ApplicationDbContext _db;

        public TOeAppSettingsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<string> GetT_OE_APP_SETTINGAsync(string settingName)
        {
            TOeAppSettings x = await _db.TOeAppSettings.Where(x => x.SettingName == settingName).FirstOrDefaultAsync().ConfigureAwait(false);
            if (x != null) return x.SettingValue;
            return string.Empty;
        }
        public string GetT_OE_APP_SETTING(string settingName)
        {
            return _db.TOeAppSettings.Where(x => x.SettingName == settingName).FirstOrDefault().SettingValue;
        }

        public IEnumerable<SelectListItem> GetTOeAppSettingsForDropDown()
        {
            throw new NotImplementedException();
        }

        public void Update(TOeAppSettings oeAppSettings)
        {
            try
            {
                if (oeAppSettings != null)
                {
                    TOeAppSettings objFromDb = _db.TOeAppSettings.Where(x => x.SettingIdx == oeAppSettings.SettingIdx).FirstOrDefault();
                    if (objFromDb != null)
                    {
                        if(oeAppSettings.SettingName != null) objFromDb.SettingName = oeAppSettings.SettingName;
                        if(oeAppSettings.SettingDesc != null) objFromDb.SettingDesc = oeAppSettings.SettingDesc;
                        if(oeAppSettings.SettingValue != null) objFromDb.SettingValue = oeAppSettings.SettingValue;
                        if(oeAppSettings.EncryptInd != null) objFromDb.EncryptInd = oeAppSettings.EncryptInd;
                        if(oeAppSettings.SettingValueSalt != null) objFromDb.SettingValueSalt = oeAppSettings.SettingValueSalt;
                        if(oeAppSettings.ModifyUserid != null) objFromDb.ModifyUserid = oeAppSettings.ModifyUserid;
                        objFromDb.ModifyDt = DateTime.Now;
                        _db.TOeAppSettings.Update(objFromDb);
                        _db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Could not update data!");
                    }
                }else
                {
                    throw new Exception("Could not update data!");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
