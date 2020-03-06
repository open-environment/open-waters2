using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxOrganizationRepository : Repository<TWqxOrganization>, ITWqxOrganizationRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxOrganizationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        {
            return _db.TWqxOrganization.Select(i => new SelectListItem()
            {
                 Text = i.OrgFormalName,
                 Value = i.OrgId
            });
        }

        public void Update(TWqxOrganization wqxOrganization)
        {
            TWqxOrganization objFromDb = _db.TWqxOrganization.Where(i => i.OrgId == wqxOrganization.OrgId).FirstOrDefault();
            objFromDb.OrgFormalName = wqxOrganization.OrgFormalName;
            //TODO: implement rest of the properties
            _db.SaveChanges();
        }
    }
}
