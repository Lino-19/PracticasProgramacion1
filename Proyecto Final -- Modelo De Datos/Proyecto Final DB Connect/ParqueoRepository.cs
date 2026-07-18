using System.Data.SqlClient;
using System.Net.Sockets;

namespace SistemaControlParqueos;

public class ParqueoRepository
{
    public bool ExisteTicketActivo(string placa)
    {
        string sql = @"
            SELECT COUNT(*)
            FROM Tickets t
            INNER JOIN Vehiculos v ON t.VehiculoId = v.VehiculoId
            WHERE v.Placa = @Placa AND t.HoraSalida IS NULL";

        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Placa", placa);
                int cantidad = (int)comando.ExecuteScalar();
                return cantidad > 0;
            }
        }
    }

    public Ticket? RegistrarEntrada(string placa, string marca, string color)
    {
        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlTransaction transaccion = conexion.BeginTransaction())
            {
                try
                {
                    Vehiculo vehiculo = ObtenerOInsertarVehiculo(conexion, transaccion, placa, marca, color);
                    EspacioParqueo? espacio = ObtenerEspacioDisponible(conexion, transaccion);

                    if (espacio == null)
                    {
                        transaccion.Rollback();
                        return null;
                    }

                    ActualizarEstadoEspacio(conexion, transaccion, espacio.EspacioId, true);
                    int ticketId = CrearTicket(conexion, transaccion, vehiculo.VehiculoId, espacio.EspacioId);

                    transaccion.Commit();
                    espacio.EstaOcupado = true;
                    return new Ticket(ticketId, vehiculo, espacio, DateTime.Now, null);
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }

    public Ticket? RegistrarSalida(int ticketId)
    {
        Ticket? ticket = ObtenerTicketActivoPorId(ticketId);

        if (ticket == null)
        {
            return null;
        }

        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlTransaction transaccion = conexion.BeginTransaction())
            {
                try
                {
                    string sqlSalida = "UPDATE Tickets SET HoraSalida = GETDATE() WHERE TicketId = @TicketId";

                    using (SqlCommand comando = new SqlCommand(sqlSalida, conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@TicketId", ticketId);
                        comando.ExecuteNonQuery();
                    }

                    ActualizarEstadoEspacio(conexion, transaccion, ticket.Espacio.EspacioId, false);
                    transaccion.Commit();

                    ticket.HoraSalida = DateTime.Now;
                    ticket.Espacio.EstaOcupado = false;
                    return ticket;
                }
                catch
                {
                    transaccion.Rollback();
                    throw;
                }
            }
        }
    }

    public List<EspacioParqueo> ObtenerEspacios()
    {
        List<EspacioParqueo> espacios = new List<EspacioParqueo>();
        string sql = "SELECT EspacioId, Numero, EstaOcupado FROM EspaciosParqueo ORDER BY Numero";

        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlCommand comando = new SqlCommand(sql, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    espacios.Add(new EspacioParqueo(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetBoolean(2)));
                }
            }
        }

        return espacios;
    }

    public List<Ticket> ObtenerTicketsActivos()
    {
        return ObtenerTickets(true);
    }

    public List<Ticket> ObtenerTodosLosTickets()
    {
        return ObtenerTickets(false);
    }

    private Vehiculo ObtenerOInsertarVehiculo(SqlConnection conexion, SqlTransaction transaccion,
        string placa, string marca, string color)
    {
        string sqlBuscar = "SELECT VehiculoId, Placa, Marca, Color FROM Vehiculos WHERE Placa = @Placa";

        using (SqlCommand comando = new SqlCommand(sqlBuscar, conexion, transaccion))
        {
            comando.Parameters.AddWithValue("@Placa", placa);

            using (SqlDataReader lector = comando.ExecuteReader())
            {
                if (lector.Read())
                {
                    return new Vehiculo(
                        lector.GetInt32(0),
                        lector.GetString(1),
                        lector.GetString(2),
                        lector.GetString(3));
                }
            }
        }

        string sqlInsertar = @"
            INSERT INTO Vehiculos (Placa, Marca, Color)
            VALUES (@Placa, @Marca, @Color);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using (SqlCommand comando = new SqlCommand(sqlInsertar, conexion, transaccion))
        {
            comando.Parameters.AddWithValue("@Placa", placa);
            comando.Parameters.AddWithValue("@Marca", marca);
            comando.Parameters.AddWithValue("@Color", color);

            int vehiculoId = (int)comando.ExecuteScalar();
            return new Vehiculo(vehiculoId, placa, marca, color);
        }
    }

    private EspacioParqueo? ObtenerEspacioDisponible(SqlConnection conexion, SqlTransaction transaccion)
    {
        string sql = @"
            SELECT TOP 1 EspacioId, Numero, EstaOcupado
            FROM EspaciosParqueo
            WHERE EstaOcupado = 0
            ORDER BY EspacioId";

        using (SqlCommand comando = new SqlCommand(sql, conexion, transaccion))
        using (SqlDataReader lector = comando.ExecuteReader())
        {
            if (lector.Read())
            {
                return new EspacioParqueo(
                    lector.GetInt32(0),
                    lector.GetString(1),
                    lector.GetBoolean(2));
            }
        }

        return null;
    }

    private int CrearTicket(SqlConnection conexion, SqlTransaction transaccion, int vehiculoId, int espacioId)
    {
        string sql = @"
            INSERT INTO Tickets (VehiculoId, EspacioId, HoraEntrada)
            VALUES (@VehiculoId, @EspacioId, GETDATE());
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        using (SqlCommand comando = new SqlCommand(sql, conexion, transaccion))
        {
            comando.Parameters.AddWithValue("@VehiculoId", vehiculoId);
            comando.Parameters.AddWithValue("@EspacioId", espacioId);
            return (int)comando.ExecuteScalar();
        }
    }

    private void ActualizarEstadoEspacio(SqlConnection conexion, SqlTransaction transaccion,
        int espacioId, bool estaOcupado)
    {
        string sql = "UPDATE EspaciosParqueo SET EstaOcupado = @EstaOcupado WHERE EspacioId = @EspacioId";

        using (SqlCommand comando = new SqlCommand(sql, conexion, transaccion))
        {
            comando.Parameters.AddWithValue("@EstaOcupado", estaOcupado);
            comando.Parameters.AddWithValue("@EspacioId", espacioId);
            comando.ExecuteNonQuery();
        }
    }

    private Ticket? ObtenerTicketActivoPorId(int ticketId)
    {
        string sql = @"
            SELECT t.TicketId, v.VehiculoId, v.Placa, v.Marca, v.Color,
                   e.EspacioId, e.Numero, e.EstaOcupado,
                   t.HoraEntrada, t.HoraSalida
            FROM Tickets t
            INNER JOIN Vehiculos v ON t.VehiculoId = v.VehiculoId
            INNER JOIN EspaciosParqueo e ON t.EspacioId = e.EspacioId
            WHERE t.TicketId = @TicketId AND t.HoraSalida IS NULL";

        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@TicketId", ticketId);

                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        return CrearTicketDesdeLector(lector);
                    }
                }
            }
        }

        return null;
    }

    private List<Ticket> ObtenerTickets(bool soloActivos)
    {
        List<Ticket> tickets = new List<Ticket>();
        string condicion = soloActivos ? "WHERE t.HoraSalida IS NULL" : "";
        string sql = $@"
            SELECT t.TicketId, v.VehiculoId, v.Placa, v.Marca, v.Color,
                   e.EspacioId, e.Numero, e.EstaOcupado,
                   t.HoraEntrada, t.HoraSalida
            FROM Tickets t
            INNER JOIN Vehiculos v ON t.VehiculoId = v.VehiculoId
            INNER JOIN EspaciosParqueo e ON t.EspacioId = e.EspacioId
            {condicion}
            ORDER BY t.TicketId DESC";

        using (SqlConnection conexion = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            conexion.Open();

            using (SqlCommand comando = new SqlCommand(sql, conexion))
            using (SqlDataReader lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    tickets.Add(CrearTicketDesdeLector(lector));
                }
            }
        }

        return tickets;
    }

    private Ticket CrearTicketDesdeLector(SqlDataReader lector)
    {
        Vehiculo vehiculo = new Vehiculo(
            lector.GetInt32(1),
            lector.GetString(2),
            lector.GetString(3),
            lector.GetString(4));

        EspacioParqueo espacio = new EspacioParqueo(
            lector.GetInt32(5),
            lector.GetString(6),
            lector.GetBoolean(7));

        DateTime? horaSalida = lector.IsDBNull(9) ? null : lector.GetDateTime(9);

        return new Ticket(
            lector.GetInt32(0),
            vehiculo,
            espacio,
            lector.GetDateTime(8),
            horaSalida);
    }
}
