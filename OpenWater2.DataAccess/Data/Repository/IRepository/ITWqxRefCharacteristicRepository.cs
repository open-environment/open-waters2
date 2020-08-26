using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface ITWqxRefCharacteristicRepository : IRepository<TWqxRefCharacteristic>
    {
        public bool GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(string CharName);
        public bool GetT_WQX_REF_CHARACTERISTIC_ExistCheck(string CharName);
        public void Update(TWqxRefCharacteristic wqxRefCharacteristic);
    }
}
