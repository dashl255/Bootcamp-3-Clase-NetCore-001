using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Ejercicio_estructurado.Models.ClassroomStudent;
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

        public ResponseGeneralModel<string> RegisterStudentInClassroom(ClassroomStudentRegisterRequest request)
        {
            StudentModel? studentFind = repository.GetStudentsById(request.studentId);
            if (studentFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveClassromStudentErrorIdStudent, Message.saveClassromStudentErrorIdStudent);

            ClassroomModel? classroomFind = (new ClassroomRepository()).GetClassroomById(request.classroomId);
            if (classroomFind == null) return new ResponseGeneralModel<string>(400, null, Message.saveClassromStudentErrorIdClassroom, Message.saveClassromStudentErrorIdClassroom);


            ClassroomStudentModel modelSave = new ClassroomStudentModel(request.classroomId, request.studentId);
            bool isOk = (new ClassroomStudentRepository()).SaveClassroomStudent(modelSave);

            return new ResponseGeneralModel<string>((isOk) ? 200 : 500, null, (isOk) ? Message.saveClassromStudentOk : Message.errorGeneral, "");
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
