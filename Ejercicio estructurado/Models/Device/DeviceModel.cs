namespace Ejercicio_estructurado.Models.Device
{
    public class DeviceModel
    {
        private string id;
        private string type;

        public DeviceModel(string type)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.type = type;
        }

        public string GetId() { return id; }

        public string GetType() { return type; }
    }
}
