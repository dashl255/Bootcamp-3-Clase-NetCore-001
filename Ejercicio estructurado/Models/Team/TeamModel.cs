namespace Ejercicio_estructurado.Models.Team
{
    public class TeamModel
    {
        private string id;
        private string name;
        private string color;

        public TeamModel(string name, string color)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.color = color;
        }

        public string GetId() { return id; }
        public string GetName() { return name; }
        public string GetColor() { return color; }
    }
}
