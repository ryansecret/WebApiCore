using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.Application.Application;
using WebApiCore.Application.Models;
using WebApiCore.Application.Models.Ball;

namespace WebApiCore.Controllers
{
    /// <summary>
    ///     Class ShowController.
    /// </summary>
    /// <seealso cref="WebApiCore.Controllers.BaseController" />
    [Route("api/[controller]")]
    public class ShowController : BaseController
    {
        /// <summary>
        ///     The _ball application
        /// </summary>
        private readonly BallApplication _ballApplication;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ShowController" /> class.
        /// </summary>
        /// <param name="ballApplication">The ball application.</param>
        public ShowController(BallApplication ballApplication)
        {
            _ballApplication = ballApplication;
        }

        /// <summary>
        ///     Indexes this instance.
        /// </summary>
        /// <returns>OutputWithData&lt;System.String&gt;.</returns>
        [HttpGet]
        public OutputWithData<string> Index()
        {
            return new OutputWithData<string>("hello from ryan");
        }

        /// <summary>
        ///     Helloes the specified ball.
        /// </summary>
        /// <param name="ball">The ball.</param>
        /// <returns>OutputWithData&lt;System.String&gt;.</returns>
        [HttpGet]
        [Route("Hello")]
        public OutputWithData<string> Hello([FromQuery] Ball ball = null)
        {
            return _ballApplication.SayHello(ball ?? new Ball {Color = "red"});
        }

        [HttpGet("HelloAsnyc")]
        public async Task<OutputWithData<string>> HelloAsync()
        {
            var result = await Task.FromResult("hello");
            return new OutputWithData<string>($"{result} from ryan");
        }

        /// <summary>
        ///     Saves the ball.
        /// </summary>
        /// <param name="ball">The ball.</param>
        /// <returns>OutputWithData&lt;System.Boolean&gt;.</returns>
        [HttpPost]
        [Route("SaveBall")]
        public OutputWithData<bool> SaveBall([FromBody] Ball ball)
        {
            return _ballApplication.Save(ball);
        }
    }
}