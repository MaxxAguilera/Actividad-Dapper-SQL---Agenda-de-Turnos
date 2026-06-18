namespace TurnosPeluqueria_EJ06.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using TurnosPeluqueria_EJ06.Models;


public static class BD
{
    private static string _connectionString = @"Server=localhost; DataBase=Turnos;Integrated Security=True;TrustServerCertificate=True;";

    public static List<Turno> ObtenerTurnos()
    {
        List<Turno> turnos = new List<Turno>();
        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            string query = "SELECT * FROM Turnos ORDER BY FechaHora ASC";
            turnos = conn.Query<string>(query).ToList();
        }
        return turnos;

    }

    public static void AgregarTurno(Turno t)
    {
        string query = "INSERT INTO Turnos (NombreCliente, Servicio, FechaHora, Estado)VALUES (@pNombreCliente, @pServicio, @pFechaHora, @pEstado)";

        using(SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Execute(query, new {pNombreCliente = t.NombreCliente, pServicio = t.Servicio, pFechaHora = t.FechaHora, pEstado = t.Estado});
        }
    }


    
    public static int CambiarEstado(int id, string nuevoEstado)
    {
       

    }
    
}