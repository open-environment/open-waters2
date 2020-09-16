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
        public Task WQX_MasterAsync(string OrgID);
        public CDXCredentials GetCDXSubmitCredentials2(string OrgID);
        public Task WQX_Submit_OneByOneAsync(string typeText, int RecordIDX, string userID, string credential, string NodeURL, string orgID, bool? InsUpdIndicator);
    }
}
