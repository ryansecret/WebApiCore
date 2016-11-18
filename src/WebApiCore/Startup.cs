using System;
using System.Collections.Generic;
using System.Security.Claims;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NDaisy.Core.ServiceLocator;
using WebApiCore.Controllers;
using WebApiCore.Core;
using WebApiCore.Core.Utility;
using WebApiCore.MiddleWare;
using WebApiCore.Utility;

namespace WebApiCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            HostingEnvironment = env;
        }

          IConfigurationRoot Configuration { get; }
          IHostingEnvironment HostingEnvironment { get; }
          IContainer Container { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddSingleton(HostingEnvironment);
            var redis = Configuration.GetSection("Redis");
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = redis.GetValue<string>("configuration");
                option.InstanceName = redis.GetValue<string>("instance");
                ;
            });
            var containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);
            Container = containerBuilder.Build();

            var sl = new AutofacServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => sl);

            containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.RegisterType<ValuesController>();
            containerBuilder.Update(Container);

            var workEngin = new WebApiCoreWorkEngine(Container);
            workEngin.Initialize();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
 
            app.UseJwtBearerAuthentication(Jwt.GetJwtOptions());
            app.UseCors(p =>
            {
                p.WithOrigins("");
            });
             
            app.Map("/auth/test", appbuilder =>
            {
                appbuilder.Run(d =>
                {
                    var token= Jwt.SignToken(new List<Claim>() {new Claim("name", "ryan")});
                   
                    return d.Response.WriteAsync(token);
                });
            });
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "api/{controller=Values}/{action=Hello}/{id?}");
            });
             
            // appLifetime?.ApplicationStopped.Register(() => this.Container.Dispose());
        }
    }
}