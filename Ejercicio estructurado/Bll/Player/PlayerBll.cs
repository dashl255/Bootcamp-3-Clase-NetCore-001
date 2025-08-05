using Ejercicio_estructurado.Models.Player;
using Ejercicio_estructurado.Repository;
using Microsoft.Extensions.Configuration;

namespace Ejercicio_estructurado.Bll.Player
{
    public class PlayerBll
    {
        PlayerRepository repository = new PlayerRepository();

        IConfiguration _configuration;

        public PlayerBll(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<PlayerAllResponse> GetPlayers()
        {
            var tmp1 = _configuration.GetSection("MiConfiguracion");
            return repository.GetPlayers().Select((item) => MapPlayer(item)).ToList();
        }

        public bool SavePlayer(PlayerAddRequest requestModel)
        {
            PlayerModel model = new PlayerModel(requestModel.name);
            return repository.SavePlayer(model);
        }

        public PlayerAllResponse MapPlayer(PlayerModel player)
        {
            PlayerAllResponse result = new PlayerAllResponse();
            result.id = player.GetId();
            result.name = player.GetName();
            return result;
        }
    }
}
