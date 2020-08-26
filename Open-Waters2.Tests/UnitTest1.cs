using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;
using OpenWater2.DataAccess.Data.Repository;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;
using Microsoft.Data.Sqlite;
using TestSupport.EfHelpers;
using Microsoft.Extensions.Logging;

namespace Open_Waters2.Tests
{
    public class UnitTest1
    {
        
        public class Test1
        {
            private readonly ILoggerFactory _loggerFactory;
            public Test1(ILoggerFactory loggerFactory)
            {
                _loggerFactory = loggerFactory;
            }
            [Fact]
            public void TestMethod1()
            {
                
                //This creates the SQLite connection string to in-memory database
                var connectionStringBuilder = new SqliteConnectionStringBuilder
                { DataSource = ":memory:" };
                var connectionString = connectionStringBuilder.ToString();

                //This creates a SqliteConnectionwith that string
                var connection = new SqliteConnection(connectionString);

                //The connection MUST be opened here
                connection.Open();

                var option2 = new DbContextOptionsBuilder<ApplicationDbContext>()
                                   .UseSqlite(connection)
                                   .Options;
                var option = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase("dbname")
                                .Options;
                var option1 = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseSqlServer("data source=DESKTOP-5ANGL4D;initial catalog=OpenEnvironment;integrated security=True")
                                .Options;
                
                IOptions<OperationalStoreOptions> operationalStoreOptions
                    = Options.Create(new OperationalStoreOptions());
                SetupTestData(option, operationalStoreOptions);

                var mydb = SqliteInMemory.CreateOptions<ApplicationDbContext>();
                //var _db2 = new ApplicationDbContext(mydb, operationalStoreOptions);

                var _db = new ApplicationDbContext(option1, operationalStoreOptions);
                using(var _db2 = new ApplicationDbContext(mydb, operationalStoreOptions))
                {
                    _db2.Database.EnsureCreated();
                    
                    UnitOfWork unitOfWork = new UnitOfWork(_db2, _loggerFactory);
                    var result = unitOfWork.wqxOrganizationRepository.GetAll();
                }
                
            }

           
        }
        public static void SetupTestData(DbContextOptions<ApplicationDbContext> option, IOptions<OperationalStoreOptions> operationalStoreOptions)
        {
            using (var context = new ApplicationDbContext(option, operationalStoreOptions))
            {
                context.TWqxOrganization.AddRange(getOrganizations());
                context.SaveChanges();
            }
        }

        public static TWqxOrganization[] getOrganizations()
        {
            var orgs = new TWqxOrganization[]
            {
                new TWqxOrganization
                {
                    OrgFormalName = "abc",
                    OrgId = "123"
                }
            };
            return orgs;
        }

        
    }

}
