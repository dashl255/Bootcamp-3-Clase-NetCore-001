using Ejercicio_estructurado.Models.ClassroomStudent;
using System.Collections.Generic;

namespace Ejercicio_estructurado.Repository
{
    public class ClassroomStudentRepository
    {

        public static List<ClassroomStudentModel> classroomStudent = new List<ClassroomStudentModel>();

        public bool SaveClassroomStudent(ClassroomStudentModel model)
        {
            classroomStudent.Add(model);
            return true;
        }

        public List<ClassroomStudentModel> GetStudent()
        {
            return classroomStudent;
        }

        public List<ClassroomStudentModel> GetStudentByClassroomId(string classroomId)
        {
            return classroomStudent.Where((classStud) => classStud.GetClassroom() == classroomId).ToList();
        }
    }
}
