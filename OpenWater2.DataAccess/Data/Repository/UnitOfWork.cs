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
        }

        public ITEpaOrgsRepository tEpaOrgsRepository { get; private set; }

        public TWqxOrganizationRepository wqxOrganizationRepository { get; private set; }

        public TOeUsersRepository oeUsersRepostory { get; private set; }
        public TOeUserRolesRepository oeUserRolesRepository { get; private set; }
        public TOeAppSettingsRepository oeAppSettingsRepository { get; private set; }
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
