using System.Data.SqlClient;
namespace RegistroPacientes
{
    internal class Conexion
    {
        string cadena = @"Server=(localdb)\MSSQLLocalDB;Database=RegistroPacientesDB;Trusted_Connection=True;";

        public SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            return conexion;
        }
    }
}