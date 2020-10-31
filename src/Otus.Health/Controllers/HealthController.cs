using Microsoft.AspNetCore.Mvc;

namespace Otus.Homework1.Controllers
{
    [Route("/")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("health")]
        public IActionResult Health()
        {
            return new JsonResult(new {status = "OK"});
        }
    }
}