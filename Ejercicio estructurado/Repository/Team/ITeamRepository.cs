using Ejercicio_estructurado.Models.Team;

namespace Ejercicio_estructurado.Repository.Team
{
    public interface ITeamRepository
    {

        public List<TeamModel> GetTeams();

        public TeamModel? GetTeamById(string id);

        public bool SaveTeams(TeamModel requestModel);
    }
}
