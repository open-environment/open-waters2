using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITEpaOrgsRepository tEpaOrgsRepository { get;  }
        TWqxOrganizationRepository wqxOrganizationRepository { get;  }
        void Save();
    }
}
