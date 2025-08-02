using Ejercicio_estructurado.Models.Device;

namespace Ejercicio_estructurado.Models.Person
{
    public class PersonModel
    {
        private string id;
        private string name;
        private string role;
        private List<DeviceModel> devices;

        public PersonModel(string name, string role)
        {
            Guid guid = Guid.NewGuid();
            this.id = guid.ToString();
            this.name = name;
            this.role = role;
            this.devices = new List<DeviceModel>();
        }

        public void AddDevice(DeviceModel device)
        {
            devices.Add(device);
        }


        public string GetId() { return  id; }

        public string GetName() { return name; }

        public string GetRole() { return role; }

        public List<DeviceModel> GetDevices() {  return devices; }
    }

}
