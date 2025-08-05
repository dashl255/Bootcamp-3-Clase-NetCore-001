namespace Ejercicio_estructurado.Models.TeamPlayer
{
    public class TeamPlayerModel
    {
        private string id;
        private string playerId;
        private string teamId;

        public TeamPlayerModel(string playerId, string teamId)
        {
            this.id = Guid.NewGuid().ToString();
            this.playerId = playerId;
            this.teamId = teamId;
        }

        public string GetId() { return id; }
        public string GetPlayerId() {  return playerId; }
        public string GetTeamId() {  return teamId; }
    }
}
