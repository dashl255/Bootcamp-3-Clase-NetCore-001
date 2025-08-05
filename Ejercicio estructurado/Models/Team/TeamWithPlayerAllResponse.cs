using Ejercicio_estructurado.Models.Player;

namespace Ejercicio_estructurado.Models.Team
{
    public class TeamWithPlayerAllResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public List<PlayerAllResponse> players { get; set; }
    }
}
