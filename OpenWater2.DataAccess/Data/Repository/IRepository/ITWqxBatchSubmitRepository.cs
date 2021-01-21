using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxBatchSubmitRepository: IRepository<TWqxBatchSubmit>
    {
        public Task<List<TWqxBatchSubmit>> GetPendingWqxBatchesByOrgId4StatusAsync(string OrgId);
        public Task<List<TWqxBatchSubmit>> GetPendingWqxBatchesByOrgIdAsync(string OrgId);
        public Task<int> InsertOrUpdateBatchSubmitAsync(int? bmsId,
                                            string cdxSubmitTransId,
                                            string cdxSubmitStatus,
                                            string cdxSubmitType,
                                            string orgId,
                                            string isBatchInProcess,
                                            int? submitAttempt,
                                            int? statusAttempt,
                                            DateTime? submitDate);
    }
}
