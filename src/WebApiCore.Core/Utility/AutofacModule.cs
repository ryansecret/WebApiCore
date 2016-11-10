using Autofac;
using Microsoft.Extensions.Logging;
using NDaisy.Core.ServiceLocator;

namespace WebApiCore.Core.Utility
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {

            var logfactory = ServiceLocator.Current.GetInstance<ILoggerFactory>();
            containerBuilder.RegisterInstance(logfactory.CreateLogger(WebApiContants.LogInfo)).Named<ILogger>(WebApiContants.LogInfo).SingleInstance();
            containerBuilder.RegisterInstance(logfactory.CreateLogger(WebApiContants.LogError)).Named<ILogger>(WebApiContants.LogError).SingleInstance();
            
        }
    }
}
