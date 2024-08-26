public class Juegos{
    private static string username;
    private static int puntajeActual;
    private static int cantidadPreguntasCorrectas;
    private static List<Pregunta> ListPreguntas;
    private static List<Respuesta> ListRespuestas;

    public static void InicializarJuego(){
        username="";
        puntajeActual = 0;
        cantidadPreguntasCorrectas = 0;
        ListPreguntas = new List<Pregunta>();
        ListRespuestas = new List<Respuesta>();
    }
}