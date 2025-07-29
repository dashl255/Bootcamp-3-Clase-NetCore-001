using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Ejercicio_estructurado.Models.ClassroomStudent;
using Ejercicio_estructurado.Models.Student;
using Ejercicio_estructurado.Repository;

namespace Ejercicio_estructurado.Bll
{
    public class ClassroomBll
    {
        ClassroomRepository repository = new ClassroomRepository();

        public List<ClassroomAllResponse> GetClassrooms()
        {
            List<ClassroomAllResponse> list = new List<ClassroomAllResponse>();
            foreach (ClassroomModel model in repository.GetList()) {
                ClassroomAllResponse response = ModelToResponse(model);

                list.Add(response);
            }

            return list;
        }

        public ResponseGeneralModel<ClassroomAllResponse?> GetClassroomById(string id)
        {
            ClassroomModel? model = repository.GetClassroomById(id);

            if (model == null)
            {
                return new ResponseGeneralModel<ClassroomAllResponse?>(404, null, Message.getClassroomByIdNotFound);
            }

            ClassroomAllResponse response = ModelToResponse(model);

            return new ResponseGeneralModel<ClassroomAllResponse?>(200, response, Message.getClassroomByIdOk);
        }

        public List<ClassroomWithStudentReponse> ListClassroomWithStudent()
        {
            List<ClassroomWithStudentReponse> response = new List<ClassroomWithStudentReponse>();

            List<ClassroomModel> listClassroom = repository.GetList();

            foreach(ClassroomModel model in listClassroom)
            {
                List<StudentAllResponse> studentResponse = new List<StudentAllResponse>();

                List<ClassroomStudentModel> listClaStud = (new ClassroomStudentRepository()).GetStudentByClassroomId(model.GetId());
                foreach(ClassroomStudentModel classStud in listClaStud)
                {
                    StudentModel studModel = (new StudentRepository()).GetStudentsById(classStud.GetStudent());
                    StudentAllResponse studRespModel = new StudentAllResponse();
                    studRespModel.id = studModel.GetId();
                    studRespModel.name = studModel.GetName();
                    studRespModel.lastName = studModel.GetLastName();
                    studRespModel.year = studModel.GetYear();
                    studentResponse.Add(studRespModel);
                }

                ClassroomWithStudentReponse responseModel = new ClassroomWithStudentReponse();
                responseModel.classromId = model.GetId();
                responseModel.name = model.GetName();
                responseModel.year = model.GetYear();
                responseModel.students = studentResponse;
                response.Add(responseModel);
            }
            return response;
        }

        public ResponseGeneralModel<List<ClassroomModel>> AddClassroom(ClassroomAddRequest request)
        {
            ClassroomModel modelF = repository.GetClassroomByName(request.name);

            if(modelF == null)
            {
                ClassroomModel model = new ClassroomModel(request.name, request.year);

                bool isAdd = repository.AddNewClassroom(model);

                return new ResponseGeneralModel<List<ClassroomModel>>((isAdd) ? 200 : 500, null, (isAdd) ? Message.addClassroomOk : Message.addClassroomError);
            } else
            {
                return new ResponseGeneralModel<List<ClassroomModel>>(400, null, Message.addClassroomDuplicate);
            }
        }


        public bool EditYearClassroom(string id, int year)
        {
            return repository.EditYearClassroom(id, year);
        }

        public bool DeleteClassroom(string id)
        {
            return repository.RemoveClassroom(id);
        }

        private ClassroomAllResponse ModelToResponse(ClassroomModel model)
        {
            ClassroomAllResponse response = new ClassroomAllResponse();
            response.id = model.GetId();
            response.name = model.GetName();
            response.year = model.GetYear();
            response.dateReg = model.GetDateReg();
            return response;
        }
    }
}
