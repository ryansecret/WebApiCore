using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
