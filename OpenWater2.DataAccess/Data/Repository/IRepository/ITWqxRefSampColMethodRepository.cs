using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefSampColMethodRepository : IRepository<TWqxRefSampColMethod>
    {
        public TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDandContext(string ID, string Context);
        public TWqxRefSampColMethod GetT_WQX_REF_SAMP_COL_METHOD_ByIDX(int? IDX);
        public int InsertOrUpdateT_WQX_REF_SAMP_COL_METHOD(global::System.Int32? sAMP_COLL_METHOD_IDX, global::System.String sAMP_COLL_METHOD_ID,
            string sAMP_COLL_METHOD_CTX, string sAMP_COLL_METHOD_NAME, string sAMP_COLL_METHOD_DESC, bool aCT_IND);
        public void Update(TWqxRefSampColMethod wqxRefSampColMethod);
    }
}
