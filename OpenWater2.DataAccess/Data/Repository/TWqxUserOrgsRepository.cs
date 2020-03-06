using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxUserOrgsRepository : Repository<TEpaOrgs>, ITWqxUserOrgsRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxUserOrgsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetTWqxUserOrgsForDropDown()
        {
            throw new NotImplementedException();
        }

        public void Update(TWqxUserOrgs wqxUserOrgs)
        {
            throw new NotImplementedException();
        }
    }
}
