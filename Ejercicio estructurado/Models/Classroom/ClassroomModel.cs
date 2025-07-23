namespace Ejercicio_estructurado.Models.Classroom
{
    public class ClassroomModel
    {
        private string id;
        private string name;
        private int year;
        private DateTime dateReg;

        public ClassroomModel(string name, int year)
        {
            Guid guid = Guid.NewGuid();

            this.id = guid.ToString();
            this.name = name;
            this.year = year;
            this.dateReg = DateTime.Now;
        }

        public string GetId() { return id; }

        public string GetName() { return name; }

        public int GetYear() { return year; }

        public DateTime GetDateReg() {  return dateReg; }


        public void SetYear(int year) { this.year = year;}

        //public void SetId(int id)
        //{
        //    if(this.id == 0)
        //    {
        //        this.id = id;
        //    }
        //}
    }
}
