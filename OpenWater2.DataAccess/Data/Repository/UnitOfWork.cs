using java.util;
using Microsoft.Extensions.Logging;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db, ILoggerFactory loggerFactory)
        {
            _db = db;
            tEpaOrgsRepository = new TEpaOrgsRepository(_db);
            wqxOrganizationRepository = new TWqxOrganizationRepository(_db, loggerFactory);
            oeUsersRepostory = new TOeUsersRepository(_db);
            oeUserRolesRepository = new TOeUserRolesRepository(_db);
            oeAppSettingsRepository = new TOeAppSettingsRepository(_db);
            tWqxMonLocRepository = new TWqxMonLocRepository(_db);
            tWqxProjectRepository = new TWqxProjectRepository(_db);
            tWqxRefDataRepository = new TWqxRefDataRepository(_db);
            UserOrgsRepository = new TWqxUserOrgsRepository(_db);
            tWqxActivityRepository = new TWqxActivityRepository(_db);
            tWqxImportLogRepository = new TWqxImportLogRepository(_db);
            tWqxImportTempMonlocRepository = new TWqxImportTempMonlocRepository(_db, 
                                                    tWqxRefDataRepository, 
                                                    tWqxMonLocRepository,
                                                    tWqxImportLogRepository);
            tWqxImportTempActivityMetricRepository = new TWqxImportTempActivityMetricRepository(_db, tWqxRefDataRepository, tWqxActivityRepository);
            tWqxRefCharacteristicRepository = new TWqxRefCharacteristicRepository(_db);
            tWqxRefLabRepository = new TWqxRefLabRepository(_db);
            tWqxRefSampColMethodRepository = new TWqxRefSampColMethodRepository(_db);
            tWqxRefSampPrepRepository = new TWqxRefSampPrepRepository(_db);
            tWqxImportTranslateRepository = new TWqxImportTranslateRepository(_db);
            tWqxRefAnalMethodRepository = new TWqxRefAnalMethodRepository(_db);
            tWqxImportTemplateDtlRepository = new TWqxImportTemplateDtlRepository(_db);
            tWqxImportTempBioIndexRepository = new TWqxImportTempBioIndexRepository(_db);
            tWqxImportTempResultRepository = new TWqxImportTempResultRepository(_db,
                                                                            tWqxRefCharacteristicRepository,
                                                                            tWqxRefDataRepository,
                                                                            tWqxRefAnalMethodRepository,
                                                                            tWqxRefLabRepository,
                                                                            tWqxRefSampPrepRepository);
            tWqxImportTempSampleRepository = new TWqxImportTempSampleRepository(_db,
                                                                            tWqxRefDataRepository,
                                                                            tWqxMonLocRepository,
                                                                            tWqxRefSampColMethodRepository,
                                                                            tWqxRefSampPrepRepository,
                                                                            tWqxProjectRepository,
                                                                            oeUsersRepostory);

            wqxImportRepository = new WqxImportRepository(_db,
                                                        tWqxImportTempMonlocRepository,
                                                        tWqxImportTempSampleRepository,
                                                        tWqxImportTempActivityMetricRepository,
                                                        tWqxImportTempBioIndexRepository,
                                                        tWqxImportTemplateDtlRepository,
                                                        tWqxMonLocRepository,
                                                        tWqxImportTranslateRepository,
                                                        tWqxImportTempResultRepository,
                                                        oeUsersRepostory,
                                                        tWqxProjectRepository);



        }

        public ITEpaOrgsRepository tEpaOrgsRepository { get; private set; }

        public ITWqxOrganizationRepository wqxOrganizationRepository { get; private set; }

        public ITOeUsersRepository oeUsersRepostory { get; private set; }
        public ITOeUserRolesRepository oeUserRolesRepository { get; private set; }
        public ITOeAppSettingsRepository oeAppSettingsRepository { get; private set; }

        public ITWqxMonLocRepository tWqxMonLocRepository {get; private set;}

        public ITWqxProjectRepository tWqxProjectRepository { get; private set; }

        public ITWqxRefDataRepository tWqxRefDataRepository { get; private set; }
        public ITWqxUserOrgsRepository UserOrgsRepository { get; private set; }

        public ITWqxActivityRepository tWqxActivityRepository { get; private set; }
        public ITWqxImportTempMonlocRepository tWqxImportTempMonlocRepository { get; private set; }

        public ITWqxImportTempActivityMetricRepository tWqxImportTempActivityMetricRepository { get; private set; }

        public ITWqxImportTempResultRepository tWqxImportTempResultRepository { get; private set; }

        public ITWqxImportTempSampleRepository tWqxImportTempSampleRepository { get; private set; }

        public ITWqxImportTranslateRepository tWqxImportTranslateRepository { get; private set; }

        public ITWqxRefCharacteristicRepository tWqxRefCharacteristicRepository { get; private set; }

        public ITWqxRefLabRepository tWqxRefLabRepository { get; private set; }

        public ITWqxRefSampColMethodRepository tWqxRefSampColMethodRepository { get; private set; }

        public ITWqxRefSampPrepRepository tWqxRefSampPrepRepository { get; private set; }
        
        public ITWqxRefAnalMethodRepository tWqxRefAnalMethodRepository { get; private set;  }
       
        public IWqxImportRepository wqxImportRepository { get; private set; }

        public ITWqxImportTempBioIndexRepository tWqxImportTempBioIndexRepository { get; private set; }

        public ITWqxImportTemplateDtlRepository tWqxImportTemplateDtlRepository { get; private set; }

        public ITWqxImportLogRepository tWqxImportLogRepository { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
