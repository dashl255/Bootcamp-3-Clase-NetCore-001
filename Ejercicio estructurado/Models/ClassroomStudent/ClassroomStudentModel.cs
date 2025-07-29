using Ejercicio_estructurado.Models.Classroom;
using Ejercicio_estructurado.Models.Student;

namespace Ejercicio_estructurado.Models.ClassroomStudent
{
    public class ClassroomStudentModel
    {
        private string id { get; set; }
        private string classroomId { get; set; }
        private string studentId { get; set; }


        public ClassroomStudentModel(string classroomId, string studentId)
        {
            Guid guid = Guid.NewGuid();

            this.id = guid.ToString();
            this.classroomId = classroomId;
            this.studentId = studentId;
        }

        public string GetId() { return id; }

        public string GetClassroom() { return classroomId; }

        public string GetStudent() {  return studentId; }
    }
}
