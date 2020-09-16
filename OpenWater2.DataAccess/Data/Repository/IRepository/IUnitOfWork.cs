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
        ITWqxImportTempActivityMetricRepository tWqxImportTempActivityMetricRepository { get;  }
        ITWqxImportTempMonlocRepository tWqxImportTempMonlocRepository { get;  }
        ITWqxImportTempResultRepository tWqxImportTempResultRepository { get;  }
        ITWqxImportTempSampleRepository tWqxImportTempSampleRepository { get;  }
        ITWqxImportTranslateRepository tWqxImportTranslateRepository { get; }
        ITWqxRefCharacteristicRepository tWqxRefCharacteristicRepository { get;  }
        ITWqxRefLabRepository tWqxRefLabRepository { get; }
        ITWqxRefSampColMethodRepository tWqxRefSampColMethodRepository { get;  }
        ITWqxRefSampPrepRepository tWqxRefSampPrepRepository { get;  }
        ITWqxImportTempBioIndexRepository tWqxImportTempBioIndexRepository { get;  }
        ITWqxImportTemplateDtlRepository tWqxImportTemplateDtlRepository { get; }
        IWqxImportRepository wqxImportRepository { get;  }
        ITWqxImportLogRepository tWqxImportLogRepository { get; }
        ITWqxImportTemplateRepository tWqxImportTemplateRepository { get;  }

        ITWqxTransactionLogRepository tWqxTransactionLogRepository { get;  }
        ITWqxPendingRecordsRepository tWqxPendingRecordsRepository { get;  }

        IOeAppTasksRepository oeAppTasksRepository { get; }
        ITOeSysLogRepository tOeSysLogRepository { get;  }

        ITWqxSubmitRepository tWqxSubmitRepository { get;  }
        
        ITWqxRefDefaultTimeZoneRepository tWqxRefDefaultTimeZoneRepository { get; }
        void Save();
    }
}
