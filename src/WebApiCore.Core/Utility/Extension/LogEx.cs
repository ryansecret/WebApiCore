using Microsoft.Extensions.Logging;
using NDaisy.Core.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Core.Utility.Extension
{
    public static class LogEx
    {
        public static void LogError(this Exception exception)
        {
            ServiceLocator.Current.GetInstance<ILogger>(WebApiContants.LogError).LogError(exception.ToString());
        }

        public static void LogInfo(this string info)
        {
            
            ServiceLocator.Current.GetInstance<ILogger>(WebApiContants.LogInfo).LogInformation(info);
        }
    }
}
