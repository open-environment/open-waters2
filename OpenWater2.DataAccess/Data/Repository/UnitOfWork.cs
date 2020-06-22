using java.util;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWater2.DataAccess.Data.Repository
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            tEpaOrgsRepository = new TEpaOrgsRepository(_db);
            wqxOrganizationRepository = new TWqxOrganizationRepository(_db);
            oeUsersRepostory = new TOeUsersRepository(_db);
            oeUserRolesRepository = new TOeUserRolesRepository(_db);
            oeAppSettingsRepository = new TOeAppSettingsRepository(_db);
            tWqxMonLocRepository = new TWqxMonLocRepository(_db);
            tWqxProjectRepository = new TWqxProjectRepository(_db);
            tWqxRefDataRepository = new TWqxRefDataRepository(_db);
            UserOrgsRepository = new TWqxUserOrgsRepository(_db);
            tWqxActivityRepository = new TWqxActivityRepository(_db);
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
