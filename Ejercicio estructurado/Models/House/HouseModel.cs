using Ejercicio_estructurado.Models.Person;

namespace Ejercicio_estructurado.Models.House
{
    public class HouseModel
    {
        private int id;
        private string address;
        private string color;
        private List<PersonModel> persons;

        public HouseModel(int id, string address, string color)
        {
            this.id = id;
            this.address = address;
            this.color = color;
        }

        public void AddPersons(PersonModel person)
        {
            persons.Add(person);
        }

        public int GetId() { return  id; }

        public string GetAddress() { return address; }

        public string GetColor() { return color; }

        public List<PersonModel> GetPersons() {  return persons; }
    }
}
