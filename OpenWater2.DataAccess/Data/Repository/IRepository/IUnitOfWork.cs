using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITEpaOrgsRepository tEpaOrgsRepository { get;  }
        ITWqxOrganizationRepository wqxOrganizationRepository { get;  }
        ITOeUsersRepository oeUsersRepostory { get;  }
        ITOeUserRolesRepository oeUserRolesRepository { get;  }
        ITOeAppSettingsRepository oeAppSettingsRepository { get;  }
        ITWqxMonLocRepository tWqxMonLocRepository { get;  }
        ITWqxProjectRepository tWqxProjectRepository { get;  }
        ITWqxRefDataRepository tWqxRefDataRepository { get;  }
        ITWqxUserOrgsRepository UserOrgsRepository { get;  }
        ITWqxActivityRepository tWqxActivityRepository { get;  }
        void Save();
    }
}
