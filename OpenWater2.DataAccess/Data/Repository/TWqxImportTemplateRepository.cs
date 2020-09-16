using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTemplateRepository : Repository<TWqxImportTemplate>, ITWqxImportTemplateRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportTemplateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public int DeleteT_WQX_IMPORT_TEMPLATE(int TemplateID)
        {
            int actResult = 0;
            try
            {
                var importTemplate = _db.TWqxImportTemplate.Where(t => t.TemplateId == TemplateID).FirstOrDefault();
                if(importTemplate != null)
                {
                    _db.TWqxImportTemplate.Remove(importTemplate);
                    _db.SaveChanges();
                    actResult = 1;
                }
            }
            catch
            {
                actResult = 0;
            }
            return actResult;
        }

        public List<TWqxImportTemplate> GetWQX_IMPORT_TEMPLATE(string OrgID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplate
                        where a.OrgId == OrgID
                        orderby a.TemplateId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateWQX_IMPORT_TEMPLATE(int? templateId, string orgId, string typeCd, string templateName, string createUser = "system")
        {
            Boolean insInd = false;
            try
            {
                
                if (templateId == 0) templateId = null;

                TWqxImportTemplate a = new TWqxImportTemplate();

                if (templateId != null)
                    a = (from c in _db.TWqxImportTemplate
                         where c.TemplateId == templateId
                         select c).FirstOrDefault();

                if (templateId == null) //insert case
                    insInd = true;
                if (orgId != null) a.OrgId = orgId;
                if (typeCd != null) a.TypeCd = typeCd;
                if (templateName != null) a.TemplateName = templateName;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = createUser;
                    _db.TWqxImportTemplate.Add(a);
                }

                _db.SaveChanges();

                return a.TemplateId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxImportTemplate wqxImportTemplate)
        {
            try
            {
                if(wqxImportTemplate != null)
                {
                    _db.TWqxImportTemplate.Update(wqxImportTemplate);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
