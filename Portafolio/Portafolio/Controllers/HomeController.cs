using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //ViewBag.Nombre = "Cristian Mardones"; //viewbag es dinamico, solo sirve para pasar informacion a la vista

            var persona = new Persona()
            {
                Nombre = "Cristian Mardones",
                Edad = 15
            };

            //return View(); busca en las carpetas home y shared el archivo index si no lo encuentra arroja error
            return View("index2",persona); //busca en las carpetas home y shared el nombre del archivo que se le asigna en los parentesis, despues de indicar el
            //index se puede asignar un model el para que la ventana index reciba ese valor esto se conoce como modelos fuertemente tipados
        }

        private List<Proyecto> ObtenerProyecto()
        {
            return new List<Proyecto>() { new Proyecto
            {
                titulo = "Amazon",
                Descripcion = "e-commerce realizando en Asp.net",
                link = "Https://amazon.com",
                ImagenUrl = ""
            }, 
                new Proyecto
            {
                titulo = "New york Time",
                Descripcion = "Paginas de noticias en React",
                link = "Https://nytimes.com",
                ImagenUrl = ""
            },
                new Proyecto
            {
                titulo = "Reddit",
                Descripcion = "Red social para compartir en comunidades",
                link = "Https://reddit.com",
                ImagenUrl = ""
            },
                new Proyecto
            {
                titulo = "Steam",
                Descripcion = "Tienda en lineas para comprar videojuegos",
                link = "Https://Steam.com",
                ImagenUrl = ""
            } };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}