using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Models;
using Ejercicio_estructurado.Models.Classroom;

namespace Ejercicio_estructurado.Bll.Classroom
{
    public interface IClassroomBll
    {
        public List<ClassroomAllResponse> GetClassrooms();
        public List<House> GetHouses();
        public ResponseGeneralModel<ClassroomAllResponse?> GetClassroomById(string id);
        public List<ClassroomWithStudentReponse> ListClassroomWithStudent();
        public ResponseGeneralModel<List<ClassroomModel>> AddClassroom(ClassroomAddRequest request);
        public bool EditYearClassroom(string id, int year);
        public bool DeleteClassroom(string id);
    }
}
