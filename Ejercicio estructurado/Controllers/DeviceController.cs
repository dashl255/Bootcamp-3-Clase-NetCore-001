using Ejercicio_estructurado.Bll.Device;
using Ejercicio_estructurado.Helpers.Models;
using Ejercicio_estructurado.Models.Device;
using Ejercicio_estructurado.Models.Student;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio_estructurado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private DeviceBll bll = new DeviceBll();

        // GET: api/<DeviceController>
        [HttpGet]
        public ResponseGeneralModel<List<DeviceAllResponse>> Get()
        {
            return new ResponseGeneralModel<List<DeviceAllResponse>>(200, bll.GetDevices(), "");
        }

        // GET api/<DeviceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DeviceController>
        [HttpPost]
        public ResponseGeneralModel<string?> Post([FromBody] DeviceAddRequest requestModel)
        {
            try
            {
                bool isOk = bll.AddDevice(requestModel);
                return new ResponseGeneralModel<string?>(isOk ? 200 : 500, null, isOk ? "Agregado": "No agregado");
            } catch
            {
                return new ResponseGeneralModel<string?>(500, null, "Error");
            }
        }

        // PUT api/<DeviceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DeviceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
