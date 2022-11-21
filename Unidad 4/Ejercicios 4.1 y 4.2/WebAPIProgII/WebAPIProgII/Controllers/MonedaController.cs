using Microsoft.AspNetCore.Mvc;
using WebAPIProgII.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        // Atributo de la clase:
        private static readonly List<Moneda> lst = new List<Moneda>(); // Se carga aqui como statico para que no pierda el valo cargado y lo agregue a una nueva lista sino que use la misma. La direccion de memoria no cambia mas.

        // GET: api/Moneda
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(lst);
        }

        // GET api/<Moneda>/Dolar Le pasamos un paràmetro especìfico.
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
            foreach(Moneda x in lst)
            {
                if (x.Nombre.Equals(nombre))
                {
                    return Ok(x);
                }
            }
            return NotFound("Moneda no registrada!");
        }

        // POST api/Moneda/Dolar
        [HttpPost]
        public IActionResult Post([FromBody] Moneda value)
        {
            if (value == null || string.IsNullOrEmpty(value.Nombre))
                return BadRequest("Error, objeto Moneda incorrecto");

            lst.Add(value);
            return Ok(value);
        }


        // PUT api/Moneda/Dolar
        [HttpPut]
        public IActionResult Put (Moneda oMoneda)
        {
            foreach (Moneda mon in lst)
            {
                if (mon.Nombre==oMoneda.Nombre)
                {
                    mon.Nombre = oMoneda.Nombre; // Actualizo los atributos del objeto encontrado.
                    mon.ValorEnPesos = oMoneda.ValorEnPesos;
                    
                    return Ok(oMoneda);  // me devuelve el objeto actualizado
                }
            }
            return NotFound("Moneda no encontrada!");


        }

        // DELETE api/Moneda/Dolar
        [HttpDelete("{Nombre}")]
        public IActionResult Delete(Moneda oMoneda)
        {
            foreach (Moneda mon in lst)
            {
                if (mon.Nombre == oMoneda.Nombre)
                {

                    lst.Remove(mon); // Elimino el inidice encontrado
                    
                   return Ok("Se elimino la moneda");  // me devuelve un comentario
                }
            }
            return NotFound("Moneda no encontrada!");


        }


    }
}
