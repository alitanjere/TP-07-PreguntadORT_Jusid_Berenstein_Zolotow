public class Juego
{
    public static string username;
    public static int puntajeActual;
    private static int cantidadPreguntasCorrectas;
    private static List<Pregunta> ListPreguntas = new List<Pregunta>();
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
        Random NumRand = new Random();
        int numRand = NumRand.Next(0, ListPreguntas.Count);
        return ListPreguntas[numRand];
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        List<Respuesta> respuestas = new List<Respuesta>();
        foreach (Respuesta rep in ListRespuestas)
        {
            if (rep.IdPregunta == idPregunta)
            {
                respuestas.Add(rep);
            }
        }
        return respuestas;
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        if (ListPreguntas[idPregunta].IdPregunta == ListRespuestas[idPregunta].IdPregunta)
        {
            ListPreguntas.RemoveAt(idPregunta);
            ListPreguntas.RemoveAt(idRespuesta);
            puntajeActual += 10;
            return true;
        }
        else
        {
            return false;
        }
    }
    public static Respuesta BuscarRespuesta(int idPregunta, int idRespuesta)
    {
        Respuesta respuesta = null;
        foreach (Respuesta rep in Juego.ListRespuestas)
        {
            if (VerificarRespuesta(rep.IdPregunta, rep.IdRespuesta))
            {
                respuesta = rep;
            }
        }
        return respuesta;
    }

}


