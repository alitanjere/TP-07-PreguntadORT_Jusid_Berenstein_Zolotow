public class Juego
{
    public static string username;
    public static int puntajeActual;
    private static int cantidadPreguntasCorrectas;
    public static List<Pregunta> ListPreguntas = new List<Pregunta>();
    public static List<Respuesta> ListRespuestas = new List<Respuesta>();

    public static void InicializarJuego()
    {
        username = "";
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
    }

    public static List<Categorias> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string Username, int dificultad, int categoria)
    {
        username = Username;
        ListPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
        ListRespuestas = BD.ObtenerRespuestas(ListPreguntas);
    }

  public static Pregunta ObtenerProximaPregunta()
{
    if (ListPreguntas.Count == 0)
        return null; 

    Random NumRand = new Random();
    int numRand = NumRand.Next(0, ListPreguntas.Count);

    Pregunta preguntaSeleccionada = ListPreguntas[numRand];

    ListPreguntas.RemoveAt(numRand);

    return preguntaSeleccionada;
}




    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
{
    var respuestas = ListRespuestas.Where(rep => rep.IdPregunta == idPregunta).ToList();
    // Aleatorizar las respuestas
    Random random = new Random();
    return respuestas.OrderBy(x => random.Next()).ToList();
}


    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
{
    Respuesta respuestaSeleccionada = ListRespuestas.FirstOrDefault(r => r.IdRespuesta == idRespuesta);    
    if (respuestaSeleccionada != null && respuestaSeleccionada.Correcta)
    {
        cantidadPreguntasCorrectas++;
        puntajeActual += 10;
        return true;
    }

    return false;
}

}
