using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Servicio001.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PruebaController : ControllerBase
    {
        static List<string> fruit = new List<string>()
        {
            "manzana", "pera", "sandía"
        };

        // GET: <PruebaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return fruit;
        }

        // GET <PruebaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                return fruit[id];
            } catch
            {
                return "El indice no existe";
            }
        }

        // POST <PruebaController>
        [HttpPost]
        public List<string> Post([FromBody] TestModel value)
        {
            fruit.Add(value.name);

            return fruit;
        }

        // PUT api/<PruebaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TestModel value)
        {
            fruit[id] = value.name;
        }

        // DELETE api/<PruebaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            fruit.RemoveAt(id);
        }
    }
}
