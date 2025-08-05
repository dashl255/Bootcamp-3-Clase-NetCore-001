using Ejercicio_estructurado.Bll.Player;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Models.Player;
using Ejercicio_estructurado.Models.Team;
using Ejercicio_estructurado.Models.TeamPlayer;
using Ejercicio_estructurado.Repository;
using Ejercicio_estructurado.Repository.Team;

namespace Ejercicio_estructurado.Bll.Team
{
    public class TeamBll : ITeamBll
    {
        ITeamRepository repository;
        IConfiguration _configuration;

        public TeamBll(ITeamRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this._configuration = configuration;
        }

        public List<TeamsAllResponse> GetTeams()
        {
            return repository.GetTeams().Select((item) => MapPlayer(item)).ToList();
        }

        public bool SaveTeam(TeamAddRequest requestModel)
        {
            TeamModel model = new TeamModel(requestModel.name, requestModel.color);
            return repository.SaveTeams(model);
        }

        public List<TeamWithPlayerAllResponse> GetTeamWithPlayer()
        {
            return repository.GetTeams().Select((item) =>
            {
                TeamWithPlayerAllResponse response = new TeamWithPlayerAllResponse();
                response.id = item.GetId();
                response.name = item.GetName();
                response.color = item.GetColor();
                List<TeamPlayerModel> teamPlayModel = (new PlayerTeamRepository()).GetDataByIdTeam(item.GetId());
                response.players = teamPlayModel.Select((item2) =>
                {
                    PlayerModel playM = (new PlayerRepository()).PlayerById(item2.GetPlayerId());
                    return (new PlayerBll(_configuration)).MapPlayer(playM);
                }).ToList();
                return response;

            }).ToList();
        }

        public ResponseGeneralModel<string?> AddTeamToPlayer(string teamId, PlayerAddTeamRequest requestModel)
        {
            TeamModel? teamM = repository.GetTeamById(teamId);
            if (teamM == null) return new ResponseGeneralModel<string?>(400, null, "El equipo no existe");

            PlayerModel? playerM = (new PlayerRepository()).PlayerById(requestModel.playerId);
            if (playerM == null) return new ResponseGeneralModel<string?>(400, null, "El jugador no existe");

            TeamPlayerModel model = new TeamPlayerModel(requestModel.playerId, teamId);
            (new PlayerTeamRepository()).SaveData(model);

            return new ResponseGeneralModel<string?>(200, null, "Agregado");
        }

        public TeamsAllResponse MapPlayer(TeamModel team)
        {
            TeamsAllResponse result = new TeamsAllResponse();
            result.id = team.GetId();
            result.name = team.GetName();
            result.color = team.GetColor();
            return result;
        }
    }
}
