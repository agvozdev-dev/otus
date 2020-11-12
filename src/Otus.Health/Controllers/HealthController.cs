using Microsoft.AspNetCore.Mvc;

namespace Otus.Health.Controllers
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