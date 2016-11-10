using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NDaisy.Core.Utility;
using WebApiCore;

namespace UnitTest
{
    public class TestStartup:Startup
    {
        
        public TestStartup(IHostingEnvironment env) : base(env)
        {
            
        }

        public IServiceProvider ConfigureTestServices(IServiceCollection services)
        {
            var types = Typefinder.GetTypeEndWith("Repository", "WebApiCore.Repository");
            foreach (var type in types)
            {
                var interfaces = type.GetInterfaces().Where(d => !d.IsConstructedGenericType).ToList();
                services.AddSingleton(interfaces[0], type);
            }
            types = Typefinder.GetTypeEndWith("Application", "WebApiCore.Application");
            foreach (var type in types)
            {
                services.AddSingleton(type);

            }
            
            return base.ConfigureServices(services);

        }
    }
}