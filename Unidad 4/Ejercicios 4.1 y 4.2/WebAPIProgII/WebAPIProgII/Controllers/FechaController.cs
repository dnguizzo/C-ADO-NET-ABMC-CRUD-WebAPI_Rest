using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIProgII.Models;

namespace WebAPIProgII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechaController : ControllerBase
    {
        private static readonly List<Fecha> lst = new List<Fecha>();

        // GET: api/Fecha
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(lst);
        }
    }
}
