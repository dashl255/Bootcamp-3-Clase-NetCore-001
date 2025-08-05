using Ejercicio_estructurado.Models.Player;

namespace Ejercicio_estructurado.Repository
{
    public class PlayerRepository
    {
        private static List<PlayerModel> _players = new List<PlayerModel>();

        public List<PlayerModel> GetPlayers()
        {
            return _players;
        }

        public PlayerModel? PlayerById(string id)
        {
            return _players.FirstOrDefault((item) => item.GetId() == id);
        }

        public bool SavePlayer(PlayerModel requestModel)
        {
            _players.Add(requestModel);
            return true;
        }
    }
}
