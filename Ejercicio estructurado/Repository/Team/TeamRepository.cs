using Ejercicio_estructurado.Models.Player;
using Ejercicio_estructurado.Models.Team;

namespace Ejercicio_estructurado.Repository.Team
{
    public class TeamRepository : ITeamRepository
    {
        private static List<TeamModel> _teams = new List<TeamModel>();

        public List<TeamModel> GetTeams()
        {
            return _teams;
        }

        public TeamModel? GetTeamById(string id)
        {
            return _teams.FirstOrDefault((item) => item.GetId() == id);
        }

        public bool SaveTeams(TeamModel requestModel)
        {
            _teams.Add(requestModel);
            return true;
        }
    }
}
