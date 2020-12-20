using System;
using Microsoft.AspNetCore.Mvc;

namespace Otus.Crud.Controllers
{
    [Route("api/check")]
    public class CheckController : ControllerBase
    {
        [HttpPost]
        [Route("connection-string")]
        public IActionResult CheckConnectionString()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("ConnectionString"));

            return Ok(Environment.GetEnvironmentVariable("ConnectionString"));
        }  
    }
}