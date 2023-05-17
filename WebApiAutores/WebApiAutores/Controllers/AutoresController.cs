using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.ObjectPool;
using WebApiAutores.Entidades;
using WebApiAutores.Servicios;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]//ruta del controlador
    //[Route("api/[controller]")] //se usa para tomar el nombre del controlador por defecto
    public class AutoresController: ControllerBase //heredando de clase base la cual es la clase tipica de web api
    {
        private readonly AplicationDBcontext context;
        private readonly IServicio servicio;
        private readonly ServicioTransient servicioTransient;
        private readonly ServicioScoped servicioScoped;
        private readonly ServicioSingleton servicioSingleton;

        public AutoresController(AplicationDBcontext context, IServicio servicio, ServicioTransient servicioTransient, ServicioScoped servicioScoped, ServicioSingleton servicioSingleton)
        {
            this.context = context;   
            this.servicio = servicio;
            this.servicioTransient = servicioTransient;
            this.servicioScoped = servicioScoped;
            this.servicioSingleton = servicioSingleton;
        }

        [HttpGet("GUID")]
        public ActionResult obtenerGuid()
        {
            return Ok(new
            {
                AutoresControllerTransient = servicioTransient.guid,
                AutoresControllerScoped = servicioScoped.guid,
                AutoresControllerSingleton = servicioSingleton.guid,
                ServicioA_transient = servicio.obtenerTransient(),
                ServicioA_Scoped = servicio.obtenerScoped(),
                ServicioA_Singleton = servicio.obtenerSingleton()

            });

        }

        [HttpGet] //hereda de la ruta del controlador api/autores
        [HttpGet("Listado")] //se agrega a la liena del controlador api/autores/listado
        [HttpGet("/Listado")] //quita el autores de la linea del controlador api/listado
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();
        }

        [HttpGet("primero")] //api/autores/primero?nombre=nombre& las query string parte desde el signo ? y si se quiere agregar otro debe ir un &
        public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int miValor, [FromQuery] string nombre) //action result permite retornar un action result o cualquier tipo de dato que este dentro de <>
        {
            return await context.Autores.FirstOrDefaultAsync();
        }

        [HttpGet("{id:int}/{param2?}")] //con las llaves {} se puede asignar parametros a la consulta get, con el signo ? se vuelve un parametro opcional
        //[HttpGet("{id:int}/{param2=algo}")] //asginar valor por defecto
        public async Task<ActionResult<Autor>> Get(int id,string param2)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if(autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpGet("{nombre}")] //con las llaves {} se puede asignar parametros a la consulta get
        public async Task<ActionResult<Autor>> Get([FromRoute] string nombre)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            var existeAutor = await context.Autores.AnyAsync(x => x.Nombre == autor.Nombre); //validacion si existe en la base de datos

            if (existeAutor)
            {
                return BadRequest($"Ya existe un autor con el nombre {autor.Nombre}"); //returna el error correspondiente
            }


            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/1
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }
            var existe = await context.Autores.AnyAsync(x => x.Id == id); //verificar si existe el autor
            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/autores/2
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x=>x.Id == id); //verificar si existe el autor
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });    
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
