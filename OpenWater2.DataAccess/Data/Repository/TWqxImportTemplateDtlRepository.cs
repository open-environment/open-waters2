using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxImportTemplateDtlRepository : Repository<TWqxImportTemplateDtl>, ITWqxImportTemplateDtlRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxImportTemplateDtlRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int DeleteT_WQX_IMPORT_TEMPLATE_DTL(int TemplateDtlID)
        {
            int actResult = 0;
            try
            {
                var d = _db.TWqxImportTemplateDtl.Where(d => d.TemplateDtlId == TemplateDtlID).FirstOrDefault();
                if(d != null)
                {
                    _db.TWqxImportTemplateDtl.Remove(d);
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

        public TWqxImportTemplateDtl GetWQX_IMPORT_TEMPLATE_DTL_byFieldMap(int TemplateID, string FieldMap)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == FieldMap
                        select a).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_CharsByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.FieldMap == "CHAR"
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_DynamicByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.ColNum > 0
                        orderby a.ColNum
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TWqxImportTemplateDtl> GetWQX_IMPORT_TEMPLATE_DTL_HardCodeByTemplateID(int TemplateID)
        {
            try
            {
                return (from a in _db.TWqxImportTemplateDtl
                        where a.TemplateId == TemplateID
                        && a.ColNum == 0
                        orderby a.TemplateDtlId
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertOrUpdateWQX_IMPORT_TEMPLATE_DTL(int? templateDtlId, int? templateId, int? colNum, string fieldMap, string charName, string charDefaultUnit, string createUser = "system", string charDefaultSampFraction = null)
        {
            Boolean insInd = false;
            try
            {
                TWqxImportTemplateDtl a = new TWqxImportTemplateDtl();

                if (templateId != null)
                    a = (from c in _db.TWqxImportTemplateDtl
                         where c.TemplateDtlId == templateDtlId
                         select c).FirstOrDefault();

                if (a == null) //insert case
                {
                    insInd = true;
                    a = new TWqxImportTemplateDtl();
                }

                if (templateId != null) a.TemplateId = templateId.ConvertOrDefault<int>();
                if (colNum != null) a.ColNum = colNum.ConvertOrDefault<int>();
                if (fieldMap != null) a.FieldMap = fieldMap;
                if (charName != null) a.CharName = charName;
                if (charDefaultUnit != null) a.CharDefaultUnit = charDefaultUnit;
                if (charDefaultSampFraction != null) a.CharDefaultSampFraction = charDefaultSampFraction;

                if (insInd) //insert case
                {
                    a.CreateDt = System.DateTime.Now;
                    a.CreateUserid = createUser;
                    _db.TWqxImportTemplateDtl.Add(a);
                }

                _db.SaveChanges();

                return a.TemplateDtlId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Update(TWqxImportTemplateDtl wqxImportTemplateDtl)
        {
            try
            {
                if(wqxImportTemplateDtl != null)
                {
                    _db.TWqxImportTemplateDtl.Update(wqxImportTemplateDtl);
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
