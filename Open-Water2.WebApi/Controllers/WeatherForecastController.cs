using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWater2.DataAccess.Data.Repository.IRepository;

namespace Open_Water2.WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _env;
        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IWebHostEnvironment env,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _env = env;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("api/test/getProjs")]
        public IActionResult GetWQX_Projects()
        {
            var result = _unitOfWork.tWqxProjectRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("api/test/getPath")]
        public ContentResult Get()
        {
            string configFilePath = _env.WebRootPath + @"\xml\ImportColumnsConfig.xml";
            OpenWater2.DataAccess.UtilityHelper.GetColumnMapping("", new string[1], configFilePath);
            return Content(configFilePath);
        }
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
