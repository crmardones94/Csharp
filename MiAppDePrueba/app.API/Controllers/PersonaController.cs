
using Microsoft.AspNetCore.Mvc;

namespace app.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        [HttpGet]
        public String GetPersona()
        {
            return "Hola";
        }

        [HttpGet("/{id}")]
        public String GetPersona(int id)
        {
            return "Hola "+id;
        }

        [HttpGet("/{id}/{nombre?}")]
        public String PostPersona(int id, string nombre) 
        {
            return "Hola "+id+" "+nombre;
        }
    }
}
