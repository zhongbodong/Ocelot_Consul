using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ApiServiceA.Controllers
{
    [ApiController]
    [Route("/ApiServiceA/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       

        private readonly ILogger<WeatherForecastController> _logger;

        public IConfiguration Configuration { get; }
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            return HttpContext.Request.Host.Port + " " + Configuration["AppName"] + " " + DateTime.Now.ToString();
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
