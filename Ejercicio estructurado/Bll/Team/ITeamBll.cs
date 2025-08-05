using Ejercicio_estructurado.Bll.Player;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Models.Player;
using Ejercicio_estructurado.Models.Team;
using Ejercicio_estructurado.Models.TeamPlayer;
using Ejercicio_estructurado.Repository;

namespace Ejercicio_estructurado.Bll.Team
{
    public interface ITeamBll
    {
        public List<TeamsAllResponse> GetTeams();

        public bool SaveTeam(TeamAddRequest requestModel);

        public List<TeamWithPlayerAllResponse> GetTeamWithPlayer();

        public ResponseGeneralModel<string?> AddTeamToPlayer(string teamId, PlayerAddTeamRequest requestModel);
    }
}
