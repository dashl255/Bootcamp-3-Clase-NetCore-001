using Ejercicio_estructurado.Models.Device;

namespace Ejercicio_estructurado.Repository
{
    public class DeviceRepository
    {
        public static List<DeviceModel> devices = new List<DeviceModel>();


        public List<DeviceModel> GetDevices()
        {
            return devices;
        }

        public DeviceModel? GetDeviceById(string id)
        {
            return devices.FirstOrDefault((item) => item.GetId() == id);
        }

        public bool AddDevice(DeviceModel model)
        {
            devices.Add(model);
            return true;
        }
    }
}
