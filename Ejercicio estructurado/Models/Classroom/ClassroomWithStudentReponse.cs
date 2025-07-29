using Ejercicio_estructurado.Models.Student;

namespace Ejercicio_estructurado.Models.Classroom
{
    public class ClassroomWithStudentReponse
    {
        public string classromId { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public List<StudentAllResponse> students { get; set; }
    }
}
