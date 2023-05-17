using Microsoft.AspNetCore.Mvc;
using PokeAppApi.Models;
using PokeAppApi.Services;
using PokeAppApi.Services.Implementacion;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtaqueController : ControllerBase
    {

        IAtaque servicio = new AtaqueService();

        // GET: api/<AtaqueController>
        [HttpGet]
        public IList<Ataque> Get()
        {
            return servicio.listar();
        }

        // GET api/<AtaqueController>/5
        [HttpGet("{id}")]
        public Ataque Get(int id)
        {
            return servicio.Read(id);
        }

        // POST api/<AtaqueController>
        [HttpPost]
        public void Post([FromBody] Ataque objeto)
        {
            servicio.Create(objeto);
        }

        // PUT api/<AtaqueController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ataque value)
        {
            servicio.Update(id, value);
        }

        // DELETE api/<AtaqueController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            servicio.Delete(id);
        }
    }
}
