using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TOeAppSettingsRepository : Repository<TOeAppSettings>, ITOeAppSettingsRepository
    {
        private readonly ApplicationDbContext _db;

        public TOeAppSettingsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
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
            TOeAppSettings objFromDb = _db.TOeAppSettings.Where(x => x.SettingIdx == oeAppSettings.SettingIdx).FirstOrDefault();
            objFromDb.SettingName = oeAppSettings.SettingName;
            objFromDb.SettingDesc = oeAppSettings.SettingDesc;
            objFromDb.SettingValue = oeAppSettings.SettingValue;
            objFromDb.EncryptInd = oeAppSettings.EncryptInd;
            objFromDb.SettingValueSalt = oeAppSettings.SettingValueSalt;
            objFromDb.ModifyUserid = oeAppSettings.ModifyUserid;
            objFromDb.ModifyDt = DateTime.Now;
            _db.TOeAppSettings.Update(objFromDb);
        }
    }
}
