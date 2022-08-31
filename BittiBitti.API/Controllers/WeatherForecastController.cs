using BittiBitti.Core.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BittiBitti.API.Controllers
{
    public class WeatherForecastController : ControllerBase
    {



        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
