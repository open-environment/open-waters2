using Microsoft.AspNetCore.Mvc.Rendering;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TEpaOrgsRepository : Repository<TEpaOrgs>, ITEpaOrgsRepository
    {
        private readonly ApplicationDbContext _db;
        public TEpaOrgsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_EPA_ORGS()
        {
            try
            {
                //TODO: Ok for small tables, need to refactor
                // if required
                _db.TEpaOrgs.RemoveRange(_db.TEpaOrgs);
                _db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public IEnumerable<SelectListItem> GetTEpaOrgsForDropDown()
        {
            throw new NotImplementedException();
        }

        public string GetT_EPA_ORGS_LastUpdateDate()
        {
            string actResult = string.Empty;
            try
            {
                DateTime? dt = (from a in _db.TEpaOrgs
                                select a.UpdateDt).Max();
                if (dt != null && dt.HasValue)
                {
                    actResult = dt.Value.ToString(@"dd-MM-yyyy HH:mm:ss");
                }
            }
            catch (Exception ex)
            {
                actResult = "";
            }
            return actResult;
        }

        public int InsertOrUpdateT_EPA_ORGS(string orgId, string orgName)
        {
            try
            {
                TEpaOrgs a = new TEpaOrgs();
                a.OrgId = orgId;
                if (orgName != null) a.OrgFormalName = orgName;
                a.UpdateDt = System.DateTime.Now;
                _db.TEpaOrgs.Add(a);
                _db.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TEpaOrgs tEpaOrgs)
        {
            throw new NotImplementedException();
        }
    }
}
