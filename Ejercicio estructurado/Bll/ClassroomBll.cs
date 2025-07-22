using Ejercicio_estructurado.Models.Classroom;

namespace Ejercicio_estructurado.Bll
{
    public class ClassroomBll
    {

        static List<ClassroomModel> classrooms = new List<ClassroomModel>();


        public List<ClassroomAllResponse> getClassrooms()
        {
            List<ClassroomAllResponse> list = new List<ClassroomAllResponse>();
            foreach (ClassroomModel model in classrooms) {
                ClassroomAllResponse response = new ClassroomAllResponse();
                response.name = model.getName();
                response.year = model.getYear();

                list.Add(response);
            }

            return list;
        }

        public bool AddClassroom(ClassroomAddRequest request)
        {
            ClassroomModel model = new ClassroomModel(request.name, request.year);
            classrooms.Add(model);

            return true;
        }


        public bool EditYearClassroom(int index, int year)
        {
            classrooms[index].setYear(year);

            return true;
        }
    }
}
