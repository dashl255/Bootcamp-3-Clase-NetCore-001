using Ejercicio_estructurado.Bll.Device;
using Ejercicio_estructurado.Models.Device;
using Ejercicio_estructurado.Models.Person;
using Ejercicio_estructurado.Repository;

namespace Ejercicio_estructurado.Bll.Person
{
    public class PersonBll
    {
        PersonRepository repository = new PersonRepository();

        public List<PersonAllResponse> GetPersons()
        {
            return repository.GetPersons().Select((item) => MapModelPerson(item)).ToList();
        }

        public bool AddPerson(PersonAddRequest personModel)
        {
            PersonModel model = new PersonModel(personModel.name, personModel.role);
            return repository.AddPerson(model);
        }

        public bool AddDeviceToPerson(string idPerson, PersonAddDeviceRequest requestModel)
        {
            DeviceModel deviceFind = (new DeviceRepository()).GetDeviceById(requestModel.deviceID);
            if(deviceFind == null) throw new Exception("No existe");
            return repository.AddDeviceToPerson(idPerson, deviceFind);
        }

        public PersonAllResponse MapModelPerson(PersonModel personModel)
        {
            PersonAllResponse personAllResponse = new PersonAllResponse();
            personAllResponse.id = personModel.GetId();
            personAllResponse.name = personModel.GetName();
            personAllResponse.role = personModel.GetRole();
            List<DeviceAllResponse> reponseDevices = personModel.GetDevices().Select((item) =>
                (new DeviceBll()).MapDeviceReponse(item)
            ).ToList();
            personAllResponse.devices = reponseDevices;

            return personAllResponse;
        }
    }
}
