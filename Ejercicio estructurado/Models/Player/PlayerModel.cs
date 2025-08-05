namespace Ejercicio_estructurado.Models.Player
{
    public class PlayerModel
    {
        private string id;
        private string name;

        public PlayerModel(string name)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
        }

        public string GetId() { return id; }
        public string GetName() { return name; }
    }
}
