using java.util;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UnitOfWork(ApplicationDbContext db,
            ILoggerFactory loggerFactory,
            IWebHostEnvironment webHostEnvironment)
        {

            _db = db;
            _webHostEnvironment = webHostEnvironment;

            tEpaOrgsRepository = new TEpaOrgsRepository(_db);
            oeAppSettingsRepository = new TOeAppSettingsRepository(_db);
            oeUsersRepostory = new TOeUsersRepository(_db);
            oeUserRolesRepository = new TOeUserRolesRepository(_db);
            
            UserOrgsRepository = new TWqxUserOrgsRepository(_db);
            tWqxImportLogRepository = new TWqxImportLogRepository(_db);
            tWqxImportTemplateRepository = new TWqxImportTemplateRepository(_db);
            tWqxPendingRecordsRepository = new TWqxPendingRecordsRepository(_db);
            tOeSysLogRepository = new TOeSysLogRepository(_db);
            tWqxRefDefaultTimeZoneRepository = new TWqxRefDefaultTimeZoneRepository(_db);
            
            tWqxImportTempActivityMetricRepository = new TWqxImportTempActivityMetricRepository(_db, tWqxRefDataRepository, tWqxActivityRepository);
            tWqxRefCharacteristicRepository = new TWqxRefCharacteristicRepository(_db);
            tWqxRefLabRepository = new TWqxRefLabRepository(_db);
            tWqxRefSampColMethodRepository = new TWqxRefSampColMethodRepository(_db);
            tWqxRefSampPrepRepository = new TWqxRefSampPrepRepository(_db);
            tWqxImportTranslateRepository = new TWqxImportTranslateRepository(_db);
            tWqxRefAnalMethodRepository = new TWqxRefAnalMethodRepository(_db);
            tWqxImportTemplateDtlRepository = new TWqxImportTemplateDtlRepository(_db);
            tWqxImportTempBioIndexRepository = new TWqxImportTempBioIndexRepository(_db);
            tWqxTransactionLogRepository = new TWqxTransactionLogRepository(_db);
            oeAppTasksRepository = new TOeAppTasksRepository(_db);


            
            
            wqxOrganizationRepository = new TWqxOrganizationRepository(_db,
                                                                    loggerFactory,
                                                                    oeAppSettingsRepository,
                                                                    tOeSysLogRepository);
            tWqxProjectRepository = new TWqxProjectRepository(_db,
                                                        oeAppSettingsRepository,
                                                        wqxOrganizationRepository,
                                                        tOeSysLogRepository);
            tWqxImportTempProjectRepository = new TWqxImportTempProjectRepository(_db,
                                                                    tWqxProjectRepository,
                                                                    tWqxImportLogRepository);
            tWqxRefDataRepository = new TWqxRefDataRepository(_db,
                                        _webHostEnvironment,
                                        tEpaOrgsRepository,
                                        oeAppSettingsRepository);
            tWqxMonLocRepository = new TWqxMonLocRepository(_db,
                                            oeAppSettingsRepository,
                                            wqxOrganizationRepository,
                                            tOeSysLogRepository,
                                            tWqxRefDataRepository);

            tWqxImportTempMonlocRepository = new TWqxImportTempMonlocRepository(_db,
                                                    tWqxRefDataRepository,
                                                    tWqxMonLocRepository,
                                                    tWqxImportLogRepository);

            tWqxActivityRepository = new TWqxActivityRepository(_db,
                                                                wqxOrganizationRepository,
                                                                oeAppSettingsRepository,
                                                                tWqxRefDefaultTimeZoneRepository);

            tWqxSubmitRepository = new TWqxSubmitRepository(_db,
                                                            tOeSysLogRepository,
                                                            oeAppSettingsRepository,
                                                            wqxOrganizationRepository,
                                                            UserOrgsRepository,
                                                            tWqxMonLocRepository,
                                                            tWqxProjectRepository,
                                                            tWqxActivityRepository,
                                                            tWqxTransactionLogRepository);
            tWqxImportTempResultRepository = new TWqxImportTempResultRepository(_db,
                                                                            tWqxRefCharacteristicRepository,
                                                                            tWqxRefDataRepository,
                                                                            tWqxRefAnalMethodRepository,
                                                                            tWqxRefLabRepository,
                                                                            tWqxRefSampPrepRepository,
                                                                            wqxOrganizationRepository,
                                                                            oeAppSettingsRepository,
                                                                            tWqxRefDefaultTimeZoneRepository);
            tWqxImportTempSampleRepository = new TWqxImportTempSampleRepository(_db,
                                                                            tWqxRefDataRepository,
                                                                            tWqxMonLocRepository,
                                                                            tWqxRefSampColMethodRepository,
                                                                            tWqxRefSampPrepRepository,
                                                                            tWqxProjectRepository,
                                                                            oeUsersRepostory,
                                                                            wqxOrganizationRepository,
                                                                            oeAppSettingsRepository,
                                                                            tWqxRefDefaultTimeZoneRepository,
                                                                            tWqxImportLogRepository,
                                                                            tOeSysLogRepository,
                                                                            tWqxImportTempResultRepository);
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

        public ITWqxMonLocRepository tWqxMonLocRepository { get; private set; }

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

        public ITWqxRefAnalMethodRepository tWqxRefAnalMethodRepository { get; private set; }

        public IWqxImportRepository wqxImportRepository { get; private set; }

        public ITWqxImportTempBioIndexRepository tWqxImportTempBioIndexRepository { get; private set; }

        public ITWqxImportTemplateDtlRepository tWqxImportTemplateDtlRepository { get; private set; }

        public ITWqxImportLogRepository tWqxImportLogRepository { get; private set; }

        public ITWqxImportTemplateRepository tWqxImportTemplateRepository { get; private set; }

        public ITWqxTransactionLogRepository tWqxTransactionLogRepository { get; private set; }

        public ITWqxPendingRecordsRepository tWqxPendingRecordsRepository { get; private set; }

        public IOeAppTasksRepository oeAppTasksRepository { get; private set; }

        public ITOeSysLogRepository tOeSysLogRepository { get; private set; }

        public ITWqxSubmitRepository tWqxSubmitRepository { get; private set; }

        public ITWqxRefDefaultTimeZoneRepository tWqxRefDefaultTimeZoneRepository { get; private set; }

        public ITWqxImportTempProjectRepository tWqxImportTempProjectRepository { get; private set; }

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
