using Ejercicio_estructurado.Models.Device;

namespace Ejercicio_estructurado.Models.Person
{
    public class PersonAllResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public List<DeviceAllResponse> devices { get; set; }
    }
}
