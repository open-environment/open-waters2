using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxBatchSubmitTransRepository: Repository<TWqxBatchSubmitTrans>, ITWqxBatchSubmitTransRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxBatchSubmitTransRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<List<TWqxBatchSubmitTrans>> GetAllByBMSIDAsync(int BMSID)
        {
            try
            {
                return await (from a in _db.TWqxBatchSubmitTrans
                        where a.Bsmid == BMSID
                        select a).ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<TWqxBatchSubmitTrans> GetAllByBMSID(int BMSID)
        {
            try
            {
                return (from a in _db.TWqxBatchSubmitTrans
                        where a.Bsmid == BMSID
                        select a).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> InsertOrUpdateBatchSubmitTransAsync(int? bstId, 
                                                int? bsmId, 
                                                string tableCd, 
                                                int? tableIdx, 
                                                string tableId, 
                                                string cdxSubmitStatus, 
                                                string isInBatchProcess)
        {
            Boolean insInd = false;
            try
            {
                TWqxBatchSubmitTrans a = new TWqxBatchSubmitTrans();

                if (bstId != null)
                    a = await (from c in _db.TWqxBatchSubmitTrans
                         where c.Bstid == bstId
                         select c).FirstOrDefaultAsync().ConfigureAwait(false);

                if (bstId == null) //insert case
                {
                    a = new TWqxBatchSubmitTrans();
                    insInd = true;
                }
                if (bsmId != null) a.Bsmid = bsmId;
                if (tableCd != null) a.TableCd = tableCd;
                if (tableIdx != null) a.TableIdx = tableIdx;
                if (tableId != null) a.TableId = tableId;
                if (cdxSubmitStatus != null) a.CdxSubmitStatus = cdxSubmitStatus;
                if (isInBatchProcess != null) a.IsInBatchProcess = isInBatchProcess;

                if (insInd) //insert case
                {
                    _db.TWqxBatchSubmitTrans.Add(a);
                }

                await _db.SaveChangesAsync().ConfigureAwait(false);

                return a.Bstid;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        
        public async Task<int> UpdateAllStatusByBMSIDAsync(int BMSID, string Status)
        {
            int actResult = 0;
            try
            {
                // SET IS_IN_BATCH_PROCESS TO 'N', Parametrized this if needed
                string query = "UPDATE T_WQX_BATCH_SUBMIT_TRANS SET CDX_SUBMIT_STATUS = @Status, IS_IN_BATCH_PROCESS = 'N' Where BSMID = @BMSID";
                actResult = await _db.Database.ExecuteSqlCommandAsync(query, new SqlParameter("@Status", Status), new SqlParameter("@BMSID", BMSID)).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                actResult = 0;
            }
            return actResult;
        }

        public async Task<int> UpdateBatchSubmitTransAsync(int bstId, string status)
        {
            int actResult = 0;
            try
            {
                
                string query = "UPDATE T_WQX_BATCH_SUBMIT_TRANS SET CDX_SUBMIT_STATUS = @Status Where BSTID = @BSTID";
                actResult = await _db.Database.ExecuteSqlCommandAsync(query, new SqlParameter("@Status", status), new SqlParameter("@BSTID", bstId)).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                throw;
            }
            return actResult;
        }

        [Obsolete]
        public async Task<int> UpdateBatchSubmitTransAsync(string tableCd, string tableId, string status)
        {
            int actResult = 0;
            try
            {
                // SET IS_IN_BATCH_PROCESS TO 'N', Parametrized this if needed
                string query = "UPDATE T_WQX_BATCH_SUBMIT_TRANS SET CDX_SUBMIT_STATUS = @Status, IS_IN_BATCH_PROCESS = 'N' Where TABLE_CD = @TableCd and TABLE_ID = @TableId";
                actResult = await _db.Database.ExecuteSqlCommandAsync(query, new SqlParameter("@Status", status), new SqlParameter("@TableCd", tableCd), new SqlParameter("@TableId",tableId)).ConfigureAwait(false);

            }
            catch (Exception e)
            {
                throw;
            }
            return actResult;
        }
    }
}
