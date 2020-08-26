using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefSampPrepRepository : IRepository<TWqxRefSampPrep>
    {
        public TWqxRefSampPrep GetT_WQX_REF_SAMP_PREP_ByIDandContext(string ID, string Context);
        public void Update(TWqxRefSampPrep wqxRefSampPrep);
    }
}
