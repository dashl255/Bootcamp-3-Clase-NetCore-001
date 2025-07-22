using Ejercicio_estructurado.Bll;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        ClassroomBll bll = new ClassroomBll();

        // GET: api/<ClassroomController>
        [HttpGet]
        public ResponseGeneralModel<List<ClassroomAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<ClassroomAllResponse>>(200, bll.getClassrooms(), "");
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClassroomController>
        [HttpPost]
        public ResponseGeneralModel<List<ClassroomModel>> Post([FromBody] ClassroomAddRequest item)
        {
            bool isOk = bll.AddClassroom(item);
            return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.addClassroomOk : Message.addClassroomError);
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{index}")]
        public ResponseGeneralModel<List<ClassroomModel>> Put(int index, [FromBody] ClassroomEditYearRequest value)
        {
            bool isOk = false;
            try
            {
                isOk = bll.EditYearClassroom(index, value.year);
            }
            catch { isOk = false; }

            return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.editClassroomOk : Message.editClassroomError);
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
