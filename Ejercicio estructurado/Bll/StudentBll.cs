using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Ejercicio_estructurado.Models.Student;
using Ejercicio_estructurado.Repository;

namespace Ejercicio_estructurado.Bll
{
    public class StudentBll
    {
        StudentRepository repository = new StudentRepository();

        public List<StudentAllResponse> GetStudents()
        {
            List<StudentAllResponse> list = new List<StudentAllResponse>();
            foreach (StudentModel model in repository.GetStudents())
            {
                StudentAllResponse response = ModelToResponse(model);

                list.Add(response);
            }

            return list;
        }

        public bool AddStudent(StudentAddRequest request)
        {
            StudentModel model = new StudentModel(request.name, request.lastName, request.year);

            return repository.AddNewStudent(model);
        }



        private StudentAllResponse ModelToResponse(StudentModel model)
        {
            StudentAllResponse response = new StudentAllResponse();
            response.id = model.GetId();
            response.name = model.GetName();
            response.lastName = model.GetLastName();
            response.year = model.GetYear();
            response.dateReg = model.GetDateReg();
            return response;
        }
    }
}
