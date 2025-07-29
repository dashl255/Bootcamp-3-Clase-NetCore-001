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

        public List<ClassroomStudentModel> GetStudentByClassroomId(string classroomId)
        {
            List<ClassroomStudentModel> reponse = new List<ClassroomStudentModel>();
            foreach (var classStud in classroomStudent) {
                if(classStud.GetClassroom() == classroomId)
                {
                    reponse.Add(classStud);
                }
            }
            return reponse;
        }
    }
}
