using Ejercicio_estructurado.Bll.Player;
using Ejercicio_estructurado.Bll.Team;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Player;
using Ejercicio_estructurado.Models.Team;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        ITeamBll bll;

        public TeamController(ITeamBll bll)
        {
            this.bll = bll;
        }


        // GET: api/<PlayerController>
        [HttpGet]
        public ResponseGeneralModel<List<TeamsAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<TeamsAllResponse>>(200, bll.GetTeams(), "");
        }

        [HttpGet("detail")]
        public ResponseGeneralModel<List<TeamWithPlayerAllResponse>> GetDetail()
        {
            return new ResponseGeneralModel<List<TeamWithPlayerAllResponse>>(200, bll.GetTeamWithPlayer(), "");
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public ResponseGeneralModel<List<TeamsAllResponse>> Get(int id)
        {
            return new ResponseGeneralModel<List<TeamsAllResponse>>(200, bll.GetTeams(), "");
        }

        // POST api/<PlayerController>
        [HttpPost]
        public ResponseGeneralModel<string?> Post([FromBody] TeamAddRequest value)
        {
            try
            {
                bool isOk = bll.SaveTeam(value);
                return new ResponseGeneralModel<string?>(isOk ? 200 : 500, null, isOk ? "Ok" : "Error");
            } catch (Exception ex)
            {
                return new ResponseGeneralModel<string?>(500, null, Message.errorGeneral);
            }
        }

        [HttpPut("{id}/student")]
        public ResponseGeneralModel<string?> AddStudent(string id, [FromBody] PlayerAddTeamRequest value)
        {
            try
            {
                return bll.AddTeamToPlayer(id, value);
            }
            catch (Exception ex)
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
