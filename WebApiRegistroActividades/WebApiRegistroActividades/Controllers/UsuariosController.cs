using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.ObjectPool;
using WebApiRegistroActividades.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiRegistroActividades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public UsuariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await context.usuarios.ToListAsync();
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await context.usuarios.FirstOrDefaultAsync(x => x.id == id);

            if(usuario == null)
            {
                return BadRequest($"No Existe en usuario con el id buscado {id}");
            }
            return usuario; 
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {

            var existeUsuario = await context.usuarios.AnyAsync(x => x.rut == usuario.rut);
            if (existeUsuario)
            {
                return BadRequest($"ya existe usuario con el {usuario.rut} asignado: {usuario.nombre} {usuario.apellidoPaterno}");
            }
            context.Add(usuario);
            await context.SaveChangesAsync();
            return Ok();

        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.usuarios.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Usuario() { id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
