using System;
using Autofac;
using Microsoft.Extensions.Configuration;
using NDaisy.Core.ServiceLocator;
using WebApiCore.Core;
using WebApiCore.Core.Utility;

namespace UnitTest.Repository
{
    public class BaseRepository
    {
        public BaseRepository()
        {
            
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            var configuration = builder.Build();
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterInstance<IConfigurationRoot>(configuration).SingleInstance();
            var container = containerBuilder.Build();
            var sl = new AutofacServiceLocator(container);

            ServiceLocator.SetLocatorProvider(() => sl);
            containerBuilder.RegisterModule<AutofacModule>();

            var workEngin = new WebApiCoreWorkEngine(container);
            workEngin.Initialize();
        }
    }
}