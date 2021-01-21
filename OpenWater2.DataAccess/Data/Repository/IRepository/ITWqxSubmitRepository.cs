using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxSubmitRepository : IRepository<TWqxTransactionLog>
    {
        public string SP_GenWQXXML_Single_Delete(string TypeText, int recordIDX);
        public string SP_GenWQXXML_Single(string TypeText, int recordIDX);
        public string SP_GenWQXXML_Single2(string TypeText, int recordIDX,
                                            string OrgId, int BsmId);
        public Task<bool> SP_ProcessBatchAsync(string TransId, string OrgId, int ActCount);
        public Task WQX_MasterAsync(string OrgID);
        public Task<CDXCredentials> GetCDXSubmitCredentials2Async(string OrgID);
        public Task WQX_Submit_OneByOneAsync(string typeText, int RecordIDX, string userID, string credential, string NodeURL, string orgID, bool? InsUpdIndicator);
        public Task<bool> WQX_MasterAllOrgsAsync();
        public Task<bool> WQX_MasterAllOrgsTaskStatusAsync();
    }
}
