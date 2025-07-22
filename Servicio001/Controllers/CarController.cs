using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Servicio001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {

        static List<CarModel> cars = new List<CarModel>()
        {
            //new CarModel("Mazda", "rojo", 2025),
            //new CarModel("Chevrolet", "azul", 2020),
        };

        // GET: api/<CarController>
        [HttpGet]
        public ResponseGeneralModel<List<CarModel>> Get()
        {
            ResponseGeneralModel<List<CarModel>> responseModel = new ResponseGeneralModel<List<CarModel>>(200, cars, "");
            return responseModel;
        }

        // GET api/<CarController>/5
        [HttpGet("{indice}")]
        public ResponseGeneralModel<CarModel> Get(int indice)
        {
            try
            {
                CarModel car = cars[indice];
                ResponseGeneralModel<CarModel> response = new ResponseGeneralModel<CarModel>(200, car, "");
                return response;
            } catch
            {
                ResponseGeneralModel<CarModel> response = new ResponseGeneralModel<CarModel>(500, null, "Ocurrio un error");
                return response;
            }
        }

        // POST api/<CarController>
        [HttpPost]
        public ResponseGeneralModel<List<CarModel>> Post([FromBody] CarModel item)
        {
            cars.Add(item);
            return new ResponseGeneralModel<List<CarModel>>(200, cars, "Se agrego correctamente");
        }

        // PUT api/<CarController>/5
        [HttpPut("{indice}")]
        public ResponseGeneralModel<List<CarModel>> Put(int indice, [FromBody] CarModel item)
        {
            try
            {
                cars[indice].yearOut = item.yearOut;
                return new ResponseGeneralModel<List<CarModel>>(200, cars, "Se modificó correctamente");
            } catch {
                return new ResponseGeneralModel<List<CarModel>>(500, cars, "Ocurrio un error al actualizar");
            }
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{indice}")]
        public ResponseGeneralModel<List<CarModel>> Delete(int indice)
        {
            try
            {
                cars.RemoveAt(indice);
                return new ResponseGeneralModel<List<CarModel>>(200, cars, "Se eliminó correctamente");
            }
            catch
            {
                return new ResponseGeneralModel<List<CarModel>>(500, cars, "Ocurrio un error al eliminar");
            }
        }
    }
}
