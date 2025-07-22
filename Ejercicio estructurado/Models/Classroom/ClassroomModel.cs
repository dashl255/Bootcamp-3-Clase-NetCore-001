namespace Ejercicio_estructurado.Models.Classroom
{
    public class ClassroomModel
    {
        private string name;
        private int year;

        public ClassroomModel(string name, int year)
        {
            this.name = name;
            this.year = year;
        }

        public string getName() { return name; }

        public int getYear() { return year; }


        public void setYear(int year) { this.year = year;}
    }
}
