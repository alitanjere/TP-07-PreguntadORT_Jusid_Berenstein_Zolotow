using Microsoft.AspNetCore.Mvc;
using PreguntadORT.Models; // Asegúrate de que el modelo esté en el espacio de nombres correcto

namespace PreguntadORT.Controllers
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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ConfigurarJuego()
        {
            Juego.InicializarJuego();
            ViewBag.ListaDificultades = Juego.ObtenerDificultades();
            ViewBag.Categorias = Juego.ObtenerCategorias();
            return View("ConfigurarJuego");
        }

        public IActionResult Comenzar(string username, int dificultad, int categoria)
        {
            Juego.CargarPartida(username, dificultad, categoria);

            if (Juego.ObtenerProximaPregunta() == null)
            {
                return RedirectToAction("ConfigurarJuego");
            }

            return RedirectToAction("Jugar");
        }

        public IActionResult Jugar()
        {
            Pregunta pregunta = Juego.ObtenerProximaPregunta();
            if (pregunta == null)
            {
                return RedirectToAction("Fin");
            }

            ViewBag.PregJugar = pregunta;
            ViewBag.RespuestaJugar = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
            ViewBag.CategoriaImagen = ObtenerNombreImagenCategoria(pregunta.IdCategoria);

            return View("Juego");
        }

        private string ObtenerNombreImagenCategoria(int idCategoria)
        {
            switch(idCategoria)
            {
                case 1: return "Historia.png";
                case 2: return "Ciencia.png";
                case 3: return "Geografia.png";
                case 4: return "Arte.png";
                case 5: return "Deportes.png";
                default: return "default.png"; 
            }
        }

        [HttpPost]
        public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
        {
            bool esCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);

            Pregunta pregunta = Juego.ObtenerProximaPregunta();
            if (pregunta == null)
            {
                return RedirectToAction("Fin");
            }

            ViewBag.PregJugar = pregunta;
            ViewBag.RespuestaJugar = Juego.ObtenerProximasRespuestas(pregunta.IdPregunta);
            ViewBag.CategoriaImagen = ObtenerNombreImagenCategoria(pregunta.IdCategoria);
            ViewBag.EsCorrecta = esCorrecta;

            return View("Respuesta");
        }
    }
}
