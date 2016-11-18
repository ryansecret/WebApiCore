using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}