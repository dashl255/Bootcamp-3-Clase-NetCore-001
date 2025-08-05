using Ejercicio_estructurado.Models.TeamPlayer;

namespace Ejercicio_estructurado.Repository
{
    public class PlayerTeamRepository
    {
        private static List<TeamPlayerModel> _teamPlayer = new List<TeamPlayerModel>();
        
        public List<TeamPlayerModel> GetAllData()
        {
            return _teamPlayer;
        }

        public List<TeamPlayerModel> GetDataByIdTeam(string teamId)
        {
            return _teamPlayer.Where((item) => item.GetTeamId() == teamId).ToList();
        }

        public bool SaveData(TeamPlayerModel model)
        {
            _teamPlayer.Add(model);
            return true;
        }
    }
}
