using Ejercicio_estructurado.Models.Student;

namespace Ejercicio_estructurado.Repository
{
    public class StudentRepository
    {
        static List<StudentModel> students = new List<StudentModel>();

        public List<StudentModel> GetStudents()
        {
            return students;
        }

        public StudentModel? GetStudentsById(string id)
        {
            return students.FirstOrDefault((model) => model.GetId() == id);
        }

        public bool EditYearStudent(string id, int year)
        {
            StudentModel? model = GetStudentsById(id);
            if (model == null) return false;
            model.SetYear(year);
            return true;
        }

        public StudentModel? GetLastStudent()
        {
            int countClass = students.Count();
            if (countClass == 0) return null;
            return students[countClass - 1];
        }

        public bool AddNewStudent(StudentModel model)
        {
            students.Add(model);

            return true;
        }

        public bool RemoveStudent(string id)
        {
            StudentModel? model = GetStudentsById(id);
            if (model == null) return false;
            return students.Remove(model);
        }
    }
}
