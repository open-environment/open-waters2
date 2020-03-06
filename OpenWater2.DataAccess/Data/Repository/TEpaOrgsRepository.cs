using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TEpaOrgsRepository : Repository<TEpaOrgs>, ITEpaOrgsRepository
    {
        private readonly ApplicationDbContext _db;
        public TEpaOrgsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetTEpaOrgsForDropDown()
        {
            throw new NotImplementedException();
        }

        public void Update(TEpaOrgs tEpaOrgs)
        {
            throw new NotImplementedException();
        }
    }
}
