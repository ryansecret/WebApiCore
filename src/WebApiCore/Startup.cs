using System;

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


using System.Reflection;
using WebApiCore.Core.Utility;
using NDaisy.Core.ServiceLocator;
using WebApiCore.Core;
using WebApiCore.Application.Models.Converter;
using NDaisy.Core;
using WebApiCore.Application.Application;
using WebApiCore.Controllers;
 
using WebApiCore.Repository.Repository.WebApiCore;

namespace WebApiCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
           
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        
        public IConfigurationRoot Configuration { get; }

        public IContainer Container { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConfigurationRoot>(Configuration);

         
            var containerBuilder = new ContainerBuilder();
              
            containerBuilder.Populate(services);
            this.Container = containerBuilder.Build();
            
            var sl = new AutofacServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => sl);

            containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.RegisterType<ValuesController>();
            containerBuilder.Update(this.Container);

            WebApiCoreWorkEngine workEngin = new WebApiCoreWorkEngine(this.Container);
            workEngin.Initialize();
            return new AutofacServiceProvider(this.Container);
        }
         
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
               
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
        
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Values}/{action=Hello}/{id?}");

            });

           // appLifetime?.ApplicationStopped.Register(() => this.Container.Dispose());
        }
    }
}
