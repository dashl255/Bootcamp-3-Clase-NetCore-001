using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
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

        public bool AddClassroom(ClassroomAddRequest request)
        {
            ClassroomModel model = new ClassroomModel(request.name, request.year);

            return repository.AddNewClassroom(model);
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
