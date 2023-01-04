using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace TESTAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {

        [HttpGet("assembly-version")]
        public ActionResult Version()
        {
            return new JsonResult($"{Assembly.GetExecutingAssembly().GetName().Version}");
        }
    }
}
