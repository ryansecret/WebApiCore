using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;
using WebApiCore.Application.Application;
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;

/// <summary>
/// The Controllers namespace.
/// </summary>
namespace WebApiCore.Controllers
{
    /// <summary>
    /// Class ShowController.
    /// </summary>
    /// <seealso cref="WebApiCore.Controllers.BaseController" />
    [Route("api/[controller]")]
    public class ShowController : BaseController
    {
        /// <summary>
        /// The _ball application
        /// </summary>
        private readonly BallApplication _ballApplication;
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowController"/> class.
        /// </summary>
        /// <param name="ballApplication">The ball application.</param>
        public ShowController(BallApplication ballApplication)
        {
            _ballApplication = ballApplication;
        }
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ResultWithData&lt;System.String&gt;.</returns>
        [HttpGet]
        public ResultWithData<string> Index()
        {
            return new ResultWithData<string>("hello from ryan");
        }

        /// <summary>
        /// Helloes the specified ball.
        /// </summary>
        /// <param name="ball">The ball.</param>
        /// <returns>ResultWithData&lt;System.String&gt;.</returns>
        [HttpGet]
        [Route("Hello")]
        public ResultWithData<string> Hello([FromQuery]Ball ball = null)
        {
            return _ballApplication.SayHello(ball ?? new Ball { Color = "red" });
        }

        /// <summary>
        /// Saves the ball.
        /// </summary>
        /// <param name="ball">The ball.</param>
        /// <returns>ResultWithData&lt;System.Boolean&gt;.</returns>
        [HttpPost]
        [Route("SaveBall")]
        
        public ResultWithData<bool> SaveBall([FromBody] Ball ball)
        {
            return _ballApplication.Save(ball);
        }
    }
}