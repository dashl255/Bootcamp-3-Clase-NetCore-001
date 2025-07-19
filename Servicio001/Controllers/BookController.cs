using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Servicio001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        static List<BookModel> book = new List<BookModel>()
        {
            new BookModel("Libro001", "José", 2000)
        };

        // GET: api/<BookController>
        [HttpGet]
        public ResponseGeneralModel<List<BookModel>> Get()
        {
            return new ResponseGeneralModel<List<BookModel>>(200, book, "");
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public ResponseGeneralModel<BookModel> Get(int id)
        {
            try
            {
                return new ResponseGeneralModel<BookModel>(200, book[id], "");
            } catch
            {
                return new ResponseGeneralModel<BookModel>(500, null, "Ocurrio un error");
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
