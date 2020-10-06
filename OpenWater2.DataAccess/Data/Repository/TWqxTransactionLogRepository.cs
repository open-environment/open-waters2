using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxTransactionLogRepository : Repository<TWqxTransactionLog>, ITWqxTransactionLogRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxTransactionLogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public List<TWqxTransactionLog> GetV_WQX_TRANSACTION_LOG(string TableCD, DateTime? startDt, DateTime? endDt, string OrgID)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where (OrgID == null ? true : i.OrgId == OrgID)
                        && (TableCD == null ? true : i.TableCd == TableCD)
                        && (startDt == null ? true : i.SubmitDt >= startDt)
                        && (endDt == null ? true : i.SubmitDt <= endDt)
                        orderby i.SubmitDt descending
                        select i).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TWqxTransactionLog> GetWQX_TRANSACTION_LOG(string TableCD, int TableIdx)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where i.TableCd == TableCD
                        && i.TableIdx == TableIdx
                        select i).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TWqxTransactionLog GetWQX_TRANSACTION_LOG_ByLogID(int LogID)
        {
            try
            {
                return (from i in _db.TWqxTransactionLog
                        where i.LogId == LogID
                        select i).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertUpdateWQX_TRANSACTION_LOG(int? logId, string tableCd, int tableIdx, string submitType, byte[] responseFile, string responseText, string cdxSubmitTransId, string cdxSubmitStatus, string orgId)
        {
            try
            {
                TWqxTransactionLog t = new TWqxTransactionLog();
                if (logId != null)
                    t = (from c in _db.TWqxTransactionLog
                         where c.LogId == logId
                         select c).First();

                if (logId == null)
                    t = new TWqxTransactionLog();

                if (tableCd != null) t.TableCd = tableCd;
                t.TableIdx = tableIdx;
                if (submitType != null) t.SubmitType = submitType;
                if (responseFile != null) t.ResponseFile = responseFile;
                if (responseText != null) t.ResponseTxt = responseText;
                if (cdxSubmitTransId != null) t.CdxSubmitTransid = cdxSubmitTransId;
                if (cdxSubmitStatus != null) t.CdxSubmitStatus = cdxSubmitStatus;
                if (orgId != null) t.OrgId = orgId;

                if (logId == null) //insert case
                {
                    t.SubmitDt = System.DateTime.Now;
                    _db.TWqxTransactionLog.Add(t);
                }

                _db.SaveChanges();

                return t.LogId;
            }
            catch
            {
                return 0;
            }
        }

        public void Update(TWqxTransactionLog wqxTransactionLog)
        {
            try
            {
                _db.TWqxTransactionLog.Update(wqxTransactionLog);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
