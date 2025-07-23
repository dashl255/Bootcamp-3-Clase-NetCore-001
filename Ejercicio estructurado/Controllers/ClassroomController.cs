using Ejercicio_estructurado.Bll;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Helpers.Vars;
using Ejercicio_estructurado.Models.Classroom;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{

    // Agregar estudiante con:
    //     - Id
    //     - Nombre
    //     - Edad

    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        ClassroomBll bll = new ClassroomBll();

        // GET: api/<ClassroomController>
        [HttpGet]
        public ResponseGeneralModel<List<ClassroomAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<ClassroomAllResponse>>(200, bll.GetClassrooms(), "");
        }

        // GET api/<ClassroomController>/5
        [HttpGet("{id}")]
        public ResponseGeneralModel<ClassroomAllResponse?> Get(string id)
        {
            try
            {
                return bll.GetClassroomById(id);
            }
            catch (Exception ex)
            {
                return new ResponseGeneralModel<ClassroomAllResponse?>(500, null, Message.errorGeneral);
            }
        }
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        ResponseGeneralModel<ClassroomAllResponse?> data = bll.GetClassroomById(id);
        //        if(data.code == 200)
        //        {
        //            return Ok(data.data);
        //        } else
        //        {
        //            return BadRequest(data.data);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok("");
        //        //return new ResponseGeneralModel<ClassroomAllResponse?>(500, null, Message.errorGeneral);
        //    }
        //}

        // POST api/<ClassroomController>
        [HttpPost]
        public ResponseGeneralModel<List<ClassroomModel>> Post([FromBody] ClassroomAddRequest item)
        {
            bool isOk = bll.AddClassroom(item);
            return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.addClassroomOk : Message.addClassroomError);
        }

        // PUT api/<ClassroomController>/5
        [HttpPut("{id}/year")]
        public ResponseGeneralModel<List<ClassroomModel>> UpdateYearClassroom(string id, [FromBody] ClassroomEditYearRequest value)
        {
            bool isOk = false;
            try
            {
                isOk = bll.EditYearClassroom(id, value.year);
            }
            catch { isOk = false; }

            return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.editClassroomOk : Message.editClassroomError);
        }

        // DELETE api/<ClassroomController>/5
        [HttpDelete("{id}")]
        public ResponseGeneralModel<List<ClassroomModel>> Delete(string id)
        {
            bool isOk = false;
            try
            {
                isOk = bll.DeleteClassroom(id);
            }
            catch { isOk = false; }

            return new ResponseGeneralModel<List<ClassroomModel>>((isOk) ? 200 : 500, null, (isOk) ? Message.deleteClassroomOk : Message.deleteClassroomError);
        }
    }
}
