using OpenWater2.DataAccess.Data.Repository.IRepository;
using OpenWater2.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OpenWater2.DataAccess.Data.Repository
{
    class TWqxRefCharacteristicRepository : Repository<TWqxRefCharacteristic>, ITWqxRefCharacteristicRepository
    {
        private readonly ApplicationDbContext _db;
        public TWqxRefCharacteristicRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public bool GetT_WQX_REF_CHARACTERISTIC_ExistCheck(string CharName)
        {
            try
            {
                int iCount = (from a in _db.TWqxRefCharacteristic
                              where (a.ActInd == true)
                              && a.CharName == CharName
                              select a).Count();

                if (iCount == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool GetT_WQX_REF_CHARACTERISTIC_SampFracReqCheck(string CharName)
        {
            try
            {
                if (string.IsNullOrEmpty(CharName)) return false;
                string SampFrac = (from a in _db.TWqxRefCharacteristic
                                   where (a.ActInd == true)
                                   && a.CharName == CharName
                                   select a).FirstOrDefault().SampFracReq;

                if (SampFrac == "Y")
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Update(TWqxRefCharacteristic wqxRefCharacteristic)
        {
            throw new NotImplementedException();
        }
    }
}
