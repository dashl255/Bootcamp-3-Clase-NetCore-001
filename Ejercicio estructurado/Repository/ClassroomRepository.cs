using Ejercicio_estructurado.Models.Classroom;

namespace Ejercicio_estructurado.Repository
{
    public class ClassroomRepository
    {

        static List<ClassroomModel> classrooms = new List<ClassroomModel>();



        public List<ClassroomModel> GetList()
        {
            return classrooms;
        }

        public ClassroomModel? GetClassroomById(string id)
        {
            foreach (var model in classrooms)
            {
                if(model.GetId() == id)
                {
                    return model;
                }
            }

            return null;
        }

        public bool EditYearClassroom(string id, int year)
        {
            ClassroomModel? model = GetClassroomById(id);
            if (model == null) return false;
            model.SetYear(year);
            return true;
        }

        public ClassroomModel? GetLastClassroom()
        {
            int countClass = classrooms.Count();
            if (countClass == 0) return null;
            return classrooms[countClass - 1];
        }

        //public int GetNewId()
        //{
        //    ClassroomModel? classM =  GetLastClassroom();
        //    return (classM == null) ? 1 : classM.GetId() + 1;
        //}

        public bool AddNewClassroom(ClassroomModel model)
        {
            //int newId = GetNewId();

            classrooms.Add(model);

            //model.SetId(newId);

            return true;
        }

        public bool RemoveClassroom(string id)
        {
            ClassroomModel? model = GetClassroomById(id);
            if (model == null) return false;
            return classrooms.Remove(model);
        }
    }
}
