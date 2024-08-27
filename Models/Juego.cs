public class Juegos
{
    private static string username;
    private static int puntajeActual;
    private static int cantidadPreguntasCorrectas;
    private static List<Pregunta> ListPreguntas;
    private static List<Respuesta> ListRespuestas;

    public static void InicializarJuego()
    {
        username = "";
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
        ListPreguntas = new List<Pregunta>();
        ListRespuestas = new List<Respuesta>();
    }
    public static List<Categorias> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string userName, int dificultad, int categoria)
    {

        username = userName;
        ListPreguntas = BD.ObtenerPreguntas(dificultad, categoria);
        ListRespuestas = BD.ObtenerRespuestas(ListPreguntas);

    }

    public static Pregunta ObtenerProximaPregunta()
    {
        Random NumRand = new Random();
        int numRand = NumRand.Next(0, ListPreguntas.Count());
        return ListPreguntas[numRand];
    }

}