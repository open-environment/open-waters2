using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefLabRepository : IRepository<TWqxRefLab>
    {
        public TWqxRefLab GetT_WQX_REF_LAB_ByIDandContext(string Name, string OrgID);
        public void Update(TWqxRefLab wqxRefLab);
    }
}
