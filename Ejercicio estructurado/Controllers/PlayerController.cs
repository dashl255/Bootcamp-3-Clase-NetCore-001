using Ejercicio_estructurado.Bll.Player;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Player;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        PlayerBll bll;

        IConfiguration _configuration;

        public PlayerController(IConfiguration configuration)
        {
            bll = new PlayerBll(configuration);
        }


        // GET: api/<PlayerController>
        [HttpGet]
        public ResponseGeneralModel<List<PlayerAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<PlayerAllResponse>>(200, bll.GetPlayers(), "");
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public ResponseGeneralModel<List<PlayerAllResponse>> Get(int id)
        {
            return new ResponseGeneralModel<List<PlayerAllResponse>>(200, bll.GetPlayers(), "");
        }

        // POST api/<PlayerController>
        [HttpPost]
        public ResponseGeneralModel<string?> Post([FromBody] PlayerAddRequest value)
        {
            try
            {
                bool isOk = bll.SavePlayer(value);
                return new ResponseGeneralModel<string?>(isOk ? 200 : 500, null, isOk ? "Ok" : "Error");
            } catch (Exception ex)
            {
                return new ResponseGeneralModel<string?>(500, null, Message.errorGeneral);
            }
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
