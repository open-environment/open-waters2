using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefAnalMethodRepository : IRepository<TWqxRefAnalMethod>
    {
        public TWqxRefAnalMethod GetT_WQX_REF_ANAL_METHODByIDX(int IDX);
        public void Update(TWqxRefAnalMethod wqxRefAnalMethod);
    }
}
