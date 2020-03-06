using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using OpenWater2.DataAccess.Data;
using OpenWater2.Models.Model;
using OpenWater2.DataAccess.Data.Repository;
using Microsoft.Extensions.Options;
using IdentityServer4.EntityFramework.Options;

namespace Open_Waters2.Tests
{
    public class UnitTest1
    {
        public class Test1
        {
            [Fact]
            public void TestMethod1()
            {
                var option = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseInMemoryDatabase("dbname")
                                .Options;
                var option1 = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseSqlServer("data source=DESKTOP-5ANGL4D;initial catalog=OpenEnvironment;integrated security=True")
                                .Options;
                IOptions<OperationalStoreOptions> operationalStoreOptions
                    = Options.Create(new OperationalStoreOptions());
                SetupTestData(option, operationalStoreOptions);

                var _db = new ApplicationDbContext(option1, operationalStoreOptions);
                UnitOfWork unitOfWork = new UnitOfWork(_db);
                var result = unitOfWork.wqxOrganizationRepository.GetAll();
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
