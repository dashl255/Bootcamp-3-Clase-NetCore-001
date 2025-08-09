using Ejercicio_estructurado.Models.Student;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio_estructurado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private static readonly List<string> Summaries2 = new List<string>()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogDebug("Holaaaaa");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Test")]
        public dynamic GetTest()
        {


            //List<string> listFilter = new List<string>();
            //foreach (string item in Summaries2)
            //{
            //    if (item[0].ToString().ToUpper() == "B")
            //    {
            //        listFilter.Add(item);
            //        break;
            //    }
            //}

            //return listFilter;
            //    var tmp1 = _configuration.GetSection("MiConfiguracion");
            //    return new
            //    {
            //        key = tmp1.GetSection("ApiKey").Get<int>(),
            //        url = tmp1.GetSection("UrlBase").Get<string>(),
            //        numbers = _configuration.GetSection("numbersAllow").Get<List<int>>()
            //};

            return (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("numbersAllow").Get<List<int>>();

            StudentAllResponse model = new StudentAllResponse();
            model.id = "001";
            model.name = "Test";
            model.lastName = "Test";
            model.year = 2025;
            StudentAllResponse model2 = new StudentAllResponse();
            model2.id = "002";
            model2.name = "Test24";
            model2.lastName = "dasdsad";
            model2.year = 2024;

            List<StudentAllResponse> list = new List<StudentAllResponse>()
            {
                model, model2
            };

            return list.OrderBy((item) => item.year).Select((item) => new
            {
                item.id,
                item.year
            }).ToList();

            return (
                from data in list
                where data.lastName[0].ToString().ToUpper() == "D"
                select data
            ).ToList();
        }
    }
}
