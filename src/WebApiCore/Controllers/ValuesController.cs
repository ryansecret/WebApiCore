using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApiCore.Application.Application;
 
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;

namespace WebApiCore.Controllers
{
 
    public class ValuesController : BaseController
    {

       
        private readonly BallApplication _ballApplication;
        public ValuesController( BallApplication ballApplication)
        {
           
            _ballApplication = ballApplication;
        }
        // GET api/values
        [HttpGet]
        [ResponseCache(Duration =60*60,NoStore = false,Location= ResponseCacheLocation.Any)]
        public IEnumerable<string> Get()
        {

            var cache= Request.HttpContext.RequestServices.GetService<IDistributedCache>();
            
            cache.SetString("chen","net core test",new DistributedCacheEntryOptions() {SlidingExpiration =TimeSpan.FromHours(1) });
            var ball=new Ball() {Name = "test",Color ="111"};
            var data = JsonConvert.SerializeObject(ball);
            cache.Set("dataByte",Encoding.UTF8.GetBytes(data));
            
            return new string[] { cache.GetString("chen")};
        }
        [HttpPost]
        public bool Save()
        {
            _ballApplication.Save(new Ball() {Name = "Basketball"});
            return true;
        }
        [HttpGet]
        public ResultWithData<string> Hello()
        {
            return _ballApplication.SayHello(new Ball() { Color = "red"});
        }
        [HttpGet]
        public IActionResult GetActionResult()
        {
            return Json("ryan");
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
