using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PreguntadORT.Models;

namespace PreguntadORT.Controllers;

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
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

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
        
        if (BD.ObtenerPreguntas(dificultad, categoria) == null)
        {
            RedirectToAction("ConfigurarJuego");
        }
        
        return RedirectToAction("Jugar"); 
    }

    public  IActionResult Jugar(){
        ViewBag.PregJugar = Juego.ObtenerProximaPregunta();
        int idJugar = ViewBag.PregJugar.IdPregunta;
        //ViewBag.FotoJugar = pregJugar.Foto;        
        //ViewBag.EnunciadoJugar = pregJugar.Enunciado;
        //ViewBag.RespuestasJugar = Juego.ObtenerProximasRespuestas(pregJugar.IdPregunta);
        if(ViewBag.PregJugar == null )
        {
            return View ("Fin");
        }
        else{
            ViewBag.RespuestaJugar = Juego.ObtenerProximasRespuestas(idJugar);
            return View ("Juego");
        }
        
    }
    [HttpPost] public  IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        ViewBag.esCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        return View ("Respuesta");
    }
}
