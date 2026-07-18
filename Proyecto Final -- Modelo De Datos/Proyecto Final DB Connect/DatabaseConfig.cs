namespace SistemaControlParqueos;

// Contiene los datos necesarios para conectarse a SQL Server LocalDB.
public static class DatabaseConfig
{
    public static string ConnectionString =
        @"Server=(LocalDB)\MSSQLLocalDB;
          Database=SistemaParqueosDB;
          Trusted_Connection=true;
          MultipleActiveResultSets=true";
}
