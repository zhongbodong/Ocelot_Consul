using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiServiceB.Controllers
{
    [ApiController]
    [Route("ApiServiceB/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public IConfiguration _Configuration { get; }

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration Configuration)
        {
            _logger = logger;
            this._Configuration = Configuration;
        }

        [HttpGet]
        public string  Get()
        {
            return HttpContext.Request.Host.Port + " " + _Configuration["AppName"] + " " + DateTime.Now.ToString();
        }

        ///// <summary>
        ///// 服务健康检查
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("/heart")]
        //public IActionResult Heathle()
        //{
        //    return Ok();
        //}
    }
}
