using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenWater2.DataAccess.Data.Repository
{
    public class TWqxBatchSubmitRepository: Repository<TWqxBatchSubmit>, ITWqxBatchSubmitRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxBatchSubmitRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<TWqxBatchSubmit>> GetPendingWqxBatchesByOrgIdAsync(string OrgId)
        {
            try
            {
                return (from a in _db.TWqxBatchSubmit
                         where a.IsBatchInProcess != "Y"
                         && a.CdxSubmitStatus.ToLower() == "Prepared".ToLower()
                        select a).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<TWqxBatchSubmit>> GetPendingWqxBatchesByOrgId4StatusAsync(string OrgId)
        {
            try
            {
                var x= (from a in _db.TWqxBatchSubmit
                        where a.TWqxBatchSubmitTrans.Count > 0
                        && (a.CdxSubmitStatus.ToLower() != "failed" &&
                        a.CdxSubmitStatus.ToLower() != "completed")
                        select a).ToList();
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<int> InsertOrUpdateBatchSubmitAsync(int? bmsId, 
            string cdxSubmitTransId, string cdxSubmitStatus, 
            string cdxSubmitType, string orgId, string isBatchInProcess, 
            int? submitAttempt, int? statusAttempt,
            DateTime? submitDate)
        {
            Boolean insInd = false;
            try
            {
                TWqxBatchSubmit a = new TWqxBatchSubmit();

                if (bmsId != null)
                    a = await (from c in _db.TWqxBatchSubmit
                         where c.Bsmid == bmsId
                         select c).FirstOrDefaultAsync().ConfigureAwait(false);

                if (bmsId == null) //insert case
                {
                    a = new TWqxBatchSubmit();
                    insInd = true;
                }

                if (cdxSubmitTransId != null) a.CdxSubmitTransid     = cdxSubmitTransId;
                if (cdxSubmitStatus != null) a.CdxSubmitStatus = cdxSubmitStatus;
                if (cdxSubmitType != null) a.SubmitType = cdxSubmitType;
                if (orgId != null) a.OrgId = orgId;
                if (isBatchInProcess != null) a.IsBatchInProcess = isBatchInProcess;
                if (submitAttempt != null) a.SubmitAttempt = submitAttempt.GetValueOrDefault();
                if (statusAttempt != null) a.StatusAttempt = statusAttempt.GetValueOrDefault();
                if (submitDate != null) a.SubmitDate = submitDate;

                if (insInd) //insert case
                {
                    _db.TWqxBatchSubmit.Add(a);
                }

                await _db.SaveChangesAsync().ConfigureAwait(false);

                return a.Bsmid;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }

    internal class TWqxBatchSubmitVM
    {
        public TWqxBatchSubmit TWqxBatchSubmit { get; set; }
        public int ChildCount { get; set; }
    }
}
