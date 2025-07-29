using Ejercicio_estructurado.Bll;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Ejercicio_estructurado.Models.ClassroomStudent;
using Ejercicio_estructurado.Models.Student;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentBll bll = new StudentBll();

        // GET: api/<StudentController>
        [HttpGet]
        public ResponseGeneralModel<List<StudentAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<StudentAllResponse>>(200, bll.GetStudents(), "");
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentController>
        [HttpPost]
        public ResponseGeneralModel<List<StudentAllResponse>> Post([FromBody] StudentAddRequest item)
        {
            bool isOk = bll.AddStudent(item);
            return new ResponseGeneralModel<List<StudentAllResponse>>((isOk) ? 200 : 500, null, (isOk) ? Message.addClassroomOk : Message.addClassroomError);
        }

        [HttpPost("register")]
        public ResponseGeneralModel<string> RegisterStudent([FromBody] ClassroomStudentRegisterRequest request)
        {
            return bll.RegisterStudentInClassroom(request);
            //bool isOk = bll.RegisterStudentInClassroom(request);
            //return new ResponseGeneralModel<string>((isOk) ? 200 : 500, null, (isOk) ? Message.addClassroomOk : Message.addClassroomError);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
