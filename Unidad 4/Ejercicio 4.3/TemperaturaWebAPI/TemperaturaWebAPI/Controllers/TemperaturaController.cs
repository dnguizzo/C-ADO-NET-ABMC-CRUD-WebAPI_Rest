using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TemperaturaWebAPI.Controllers
{
    [Route("api/[controller]")] // POlitca de ruteo que corresponde una URL con metodos del lado del servidor.
    [ApiController]
    public class TemperaturaController : ControllerBase
    {
        private static readonly List<Temperatura> lst = new List<Temperatura>();

        // GET: api/Fecha
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // GET api/<Temperatura>/IOT Le pasamos un paràmetro especìfico.

        [HttpGet("{cod}")]
        public IActionResult Get(int cod)
        {
            foreach (Temperatura x in lst)
            {
                if (x.IOT.Equals(cod))
                {
                    return Ok(x);
                }
            }
            return NotFound("Temperartura no registrada!");
        }
 
       // POST api/Temperatura/IOT
        [HttpPost]
        public IActionResult Post([FromBody] Temperatura value)
        {
            if (value == null || string.IsNullOrEmpty(value.IOT))
                return BadRequest("Error, objeto Temperatura incorrecto");

            lst.Add(value);
            return Ok(value);
        }


       

    }



}
