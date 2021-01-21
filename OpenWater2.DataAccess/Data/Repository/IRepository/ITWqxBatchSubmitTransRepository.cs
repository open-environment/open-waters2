using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxBatchSubmitTransRepository: IRepository<TWqxBatchSubmitTrans>
    {
        public Task<int> UpdateAllStatusByBMSIDAsync(int BMSID, string status);
        public Task<List<TWqxBatchSubmitTrans>> GetAllByBMSIDAsync(int BMSID);
        public List<TWqxBatchSubmitTrans> GetAllByBMSID(int BMSID);
        public Task<int> UpdateBatchSubmitTransAsync(int bstId, string status);
        public Task<int> UpdateBatchSubmitTransAsync(string TableCd, string TableId, string Status);
        public Task<int> InsertOrUpdateBatchSubmitTransAsync(int? bstId,
                                            int? bsmId,
                                            string tableCd,
                                            int? tableIdx,
                                            string tableId,
                                            string cdxSubmitStatus,
                                            string isInBatchProcess);
    }
}
