using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace asp.net_core.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("home")]
        public IActionResult OtherMethod()
        {
            return View("Index");
        }
    }
}
