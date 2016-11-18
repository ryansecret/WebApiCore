using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebApiCore.Core.Utility.Extension;

namespace WebApiCore.MiddleWare
{
    public class LogMiddlerware
    {
        public RequestDelegate _next;

        public LogMiddlerware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
             context.Request.Path.ToString().LogInfo();
             await _next.Invoke(context);
             
        }
    }
}