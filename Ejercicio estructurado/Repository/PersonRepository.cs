using Ejercicio_estructurado.Models.Device;
using Ejercicio_estructurado.Models.Person;

namespace Ejercicio_estructurado.Repository
{
    public class PersonRepository
    {
        static List<PersonModel> persons = new List<PersonModel>();

        public List<PersonModel> GetPersons()
        {
            return persons;
        }

        public PersonModel? GetPersonById(string id)
        {
            return persons.FirstOrDefault((x) => x.GetId() == id);
        }

        public bool AddPerson(PersonModel person)
        {
            persons.Add(person);
            return true;
        }

        public bool AddDeviceToPerson(string idPerson, DeviceModel modelDevice)
        {
            PersonModel personFind = persons.FirstOrDefault((person) => person.GetId() == idPerson);
            if(personFind != null)
            {
                personFind.AddDevice(modelDevice);
                return true;
            } else
            {
                return false;
            }
        }
    }
}
