using ERP.Bll.User;
using ERP.CoreDB;
using ERP.Helper.Data;
using ERP.Helper.Helper;
using ERP.Helper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ERP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        IUserBll userBll;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserBll userBll)
        {
            _logger = logger;
            this.userBll = userBll;
        }

        [HttpGet("EncryptPass")]
        public ResponseGeneralModel<string> EncryptPass(string text)
        {
            return (new MethodsHelper<string>()).EncryptDataByMethod("passUser", text);
        }

        [HttpGet("testDb")]
        public ResponseGeneralModel<List<Usuario>?> TestDb()
        {
            try
            {
                return new ResponseGeneralModel<List<Usuario>?>(200, userBll.GetUsers(), "");
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<List<Usuario>?>(500, null, MessageHelper.errorGeneral, ex.ToString());
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
