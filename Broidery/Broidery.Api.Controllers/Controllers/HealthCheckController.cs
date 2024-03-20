using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Broidery.Api.Controllers.Controllers
{
    public class HealthCheckController : ControllerBase
    {
        [EnableCors("EnableConnection")]
        [AllowAnonymous]
        [HttpGet("health-check")]
        public ActionResult HealthCheck()
        {
            Console.WriteLine("Loki log validation");
            return Ok();
        }
    }
}