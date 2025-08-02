using Ejercicio_estructurado.Bll.Device;
using Ejercicio_estructurado.Bll.Person;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Models.Device;
using Ejercicio_estructurado.Models.Person;
using Ejercicio_estructurado.Models.Student;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonBll bll = new PersonBll();

        // GET: api/<DeviceController>
        [HttpGet]
        public ResponseGeneralModel<List<PersonAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<PersonAllResponse>>(200, bll.GetPersons(), "");
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeviceController>
        [HttpPost]
        public ResponseGeneralModel<string?> Post([FromBody] PersonAddRequest requestModel)
        {
            try
            {
                bool isOk = bll.AddPerson(requestModel);
                return new ResponseGeneralModel<string?>(isOk ? 200 : 500, null, "Agregado");
            } catch
            {
                return new ResponseGeneralModel<string?>(500, null, "Error");
            }
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}/device")]
        public ResponseGeneralModel<string?> Put(string id, [FromBody] PersonAddDeviceRequest requestModel)
        {
            try
            {
                bool isOk = bll.AddDeviceToPerson(id, requestModel);
                return new ResponseGeneralModel<string?>(isOk ? 200 : 500, null, "Agregado");
            }
            catch
            {
                return new ResponseGeneralModel<string?>(500, null, "Error");
            }
        }

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
