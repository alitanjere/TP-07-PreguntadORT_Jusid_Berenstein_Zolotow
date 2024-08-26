using System.Data.SqlClient;
using Dapper;

public class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=TP07-PreguntadORT; Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias()
    {
        List<Categorias> ListCategorias = new List<Categorias>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Categorias";
            ListCategorias = db.Query<Categorias>(sql).ToList();
        }
        return ListCategorias;
    }

    public static List<Dificultades> ObtenerDificultades()
    {
        List<Dificultades> ListDificultades = new List<Dificultades>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Dificultades";
            ListDificultades = db.Query<Dificultades>(sql).ToList();
        }
        return ListDificultades;
    }

    public static List<Pregunta> ObtenerPreguntas(int dificultad, int categoria)
    {
        List<Pregunta> ListPreguntas = new List<Pregunta>();
        string sql;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            if (dificultad == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdCategoria = @pCategoria";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pCategoria = categoria }).ToList();
            }
            else if (categoria == -1)
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pDificultad = dificultad }).ToList();
            }
            else
            {
                sql = "SELECT * FROM Preguntas WHERE IdDificultad = @pDificultad AND IdCategoria = @pCategoria";
                ListPreguntas = db.Query<Pregunta>(sql, new { @pDificultad = dificultad, @pCategoria = categoria }).ToList();
            }
        }
        return ListPreguntas;
    }

    public static List<Respuesta> ObtenerRespuestas(List<Pregunta> preguntas)
    {
        List<Respuesta> ListRespuestas = new List<Respuesta>();
        string sql = "SELECT * FROM Respuestas INNER JOIN Preguntas ON Preguntas.IdPregunta = Respuestas.IdPregunta WHERE Respuestas.IdPregunta = @pPregunta";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            foreach (Pregunta preg in preguntas)
            {
                List<Respuesta> RespuestaPreguntas = db.Query<Respuesta>(sql, new { @pPregunta = preg.IdPregunta }).ToList();
                ListRespuestas.AddRange(RespuestaPreguntas);
                Console.WriteLine(RespuestaPreguntas);
            }
        }
        return ListRespuestas;
    }

}