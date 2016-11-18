using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApiCore.Application.Application;
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;
using Swashbuckle.SwaggerGen.Annotations;

namespace WebApiCore.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    /// <seealso cref="WebApiCore.Controllers.BaseController" />
    [AllowAnonymous]
    public class ValuesController : BaseController
    {
        /// <summary>
        /// The _ball application
        /// </summary>
        private readonly BallApplication _ballApplication;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValuesController"/> class.
        /// </summary>
        /// <param name="ballApplication">The ball application.</param>
        public ValuesController(BallApplication ballApplication)
        {
            _ballApplication = ballApplication;
        }

        // GET api/values
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        [HttpGet]
        
        public IEnumerable<string> Get()
        {
            var cache = Request.HttpContext.RequestServices.GetService<IDistributedCache>();

            cache.SetString("chen", "net core test",
                new DistributedCacheEntryOptions {SlidingExpiration = TimeSpan.FromHours(1)});
            var ball = new Ball {Name = "test", Color = "111"};
            var data = JsonConvert.SerializeObject(ball);
            cache.Set("dataByte", Encoding.UTF8.GetBytes(data));

            return new[] {cache.GetString("chen")};
        }
         
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [HttpPost]
        public bool Save()
        {
            _ballApplication.Save(new Ball {Name = "Basketball"});
            return true;
        }

        /// <summary>
        /// Helloes this instance.
        /// </summary>
        /// <returns>ResultWithData&lt;System.String&gt;.</returns>
        [HttpGet]
        public ResultWithData<string> Hello()
        {
            return _ballApplication.SayHello(new Ball {Color = "red"});
        }

        /// <summary>
        /// Gets the action result.
        /// </summary>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult GetActionResult()
        {
            return Json("ryan");
        }

        // GET api/values/5
        /// <summary>
        /// Gets the specified identifier.hhhhhadfadsf
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        /// <summary>
        /// Posts the specified value.HHHHaa
        /// </summary>
        /// <param name="ball">The ball.</param>
        [HttpPost]
        [Route("gggo")]     
        [SwaggerResponse(System.Net.HttpStatusCode.OK, Type = typeof(Ball))]
        public void Post([FromBody] Ball ball)
        {
        }

        // PUT api/values/5
        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="value">The value.</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}