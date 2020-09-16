using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxTransactionLogRepository : IRepository<TWqxTransactionLog>
    {
        public int InsertUpdateWQX_TRANSACTION_LOG(int? logId,
                                    string tableCd,
                                    int tableIdx,
                                    string submitType,
                                    byte[] responseFile,
                                    string responseText,
                                    string cdxSubmitTransId,
                                    string cdxSubmitStatus,
                                    string orgId);

        public List<TWqxTransactionLog> GetV_WQX_TRANSACTION_LOG(string TableCD, DateTime? startDt, DateTime? endDt, string OrgID);
        public TWqxTransactionLog GetWQX_TRANSACTION_LOG_ByLogID(int LogID);
        public void Update(TWqxTransactionLog wqxTransactionLog);
    }
}
