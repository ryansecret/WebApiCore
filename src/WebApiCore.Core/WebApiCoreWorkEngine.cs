
using NDaisy.Core;
using Autofac;
using NDaisy.Core.Utility;

namespace WebApiCore.Core
{
    public class WebApiCoreWorkEngine:WorkEngine
    {
        private readonly IContainer _containerManager;
        public WebApiCoreWorkEngine(IContainer containerManager)
        {
            _containerManager = containerManager;
        }

        public override void RegisterDependencies()
        {

            var builder = new ContainerBuilder();

            var types = Typefinder.GetTypeEndWith( "Repository", "WebApiCore.Repository");
            foreach (var type in types)
            {
                builder.RegisterType(type).AsImplementedInterfaces().SingleInstance();
            }
            types = Typefinder.GetTypeEndWith("Application", "WebApiCore.Application");
            foreach (var type in types)
            {
                builder.RegisterType(type).SingleInstance().PropertiesAutowired(); ;
            }
            builder.Update(_containerManager);
        }
        public override void Initialize()
        {
            base.Initialize();
            
        }

        public override string[] GetTaskAssembly()
        {
            return new[] { "WebApiCore.Application" };
        }
    }
}
