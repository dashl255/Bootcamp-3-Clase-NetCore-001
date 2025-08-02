using Ejercicio_estructurado.Models.Device;
using Ejercicio_estructurado.Repository;

namespace Ejercicio_estructurado.Bll.Device
{
    public class DeviceBll
    {

        private DeviceRepository repository = new DeviceRepository();

        public List<DeviceAllResponse> GetDevices()
        {
            List<DeviceModel> deviceM = repository.GetDevices();
            return deviceM.Select((item) => MapDeviceReponse(item)).ToList();
        }

        public bool AddDevice(DeviceAddRequest requestModel)
        {
            DeviceModel modelAdd = new DeviceModel(requestModel.type);
            return repository.AddDevice(modelAdd);
        }

        public DeviceAllResponse MapDeviceReponse(DeviceModel model) {
            DeviceAllResponse deviceResp = new DeviceAllResponse();
            deviceResp.id = model.GetId();
            deviceResp.type = model.GetType();
            return deviceResp;
        }
    }
}
