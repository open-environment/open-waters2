using Autofac;
using Autofac.Core;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenWater2.DataAccess.Data;
using OpenWater2.DataAccess.Data.Repository;
using OpenWater2.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Topshelf;
using Topshelf.Autofac;

namespace OpenWaterSvcCore
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseSqlServer("data source=QUBITS-ASUS-DUO;initial catalog=OpenEnvironment;integrated security=True")
                                .Options;
            LoggerFactory loggerFactory = new LoggerFactory();
            IOptions<OperationalStoreOptions> operationalStoreOptions
                    = Options.Create(new OperationalStoreOptions());
            // Create your container
            var builder = new ContainerBuilder();
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ApplicationDbContext) && pi.Name == "db",
                   (pi, ctx) => new ApplicationDbContext(options, operationalStoreOptions)
                ));
            parameters.Add(new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(ILoggerFactory) && pi.Name == "loggerFactory",
                   (pi, ctx) => loggerFactory
                ));
            parameters.Add(new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(IWebHostEnvironment) && pi.Name == "webHostEnvironment",
                   (pi, ctx) => null
                ));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .WithParameters(parameters);
            builder.RegisterType<OWService>();
            var container = builder.Build();

            HostFactory.Run(configure =>
            {
                configure.UseAutofacContainer(container);

                configure.Service<OWService>(service =>
                {
                    // service.ConstructUsing(s => new OWService());
                    service.ConstructUsingAutofacContainer();
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("OWWQXSubmitServiceCore");
                configure.SetDisplayName("OWWQXSubmitServiceCore");
                configure.SetDescription("DotNet Core windows service for WQX Submission.");
            });
        }
    }
}
