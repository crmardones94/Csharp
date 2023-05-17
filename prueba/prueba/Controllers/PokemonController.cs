using Microsoft.AspNetCore.Mvc;
using prueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {

        IList<pokemon> listaPokemon = new List<pokemon>();


        // GET: api/<PokemonController>
        [HttpGet]
        public IEnumerable<pokemon> Get()
        {
            return listaPokemon;
        }

        // GET api/<PokemonController>/5
        [HttpGet("{id}")]
        public pokemon Get(int id)
        {
            return listaPokemon.FirstOrDefault(x => x.id == id);
        }

        // POST api/<PokemonController>
        [HttpPost]
        public void Post([FromBody] pokemon obj)
        {
            listaPokemon.Add(obj);
        }

        // PUT api/<PokemonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] pokemon obj)
        {
            listaPokemon.Remove(listaPokemon.First(x => x.id == id));
            listaPokemon.Add(obj);
        }

        // DELETE api/<PokemonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            listaPokemon.Remove(listaPokemon.First(x=> x.id == id));
        }
    }
}
