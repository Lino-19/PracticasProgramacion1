namespace SistemaControlParqueos;

public class Ticket
{
    public int TicketId { get; set; }
    public Vehiculo Vehiculo { get; set; }
    public EspacioParqueo Espacio { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSalida { get; set; }

    public Ticket(int ticketId, Vehiculo vehiculo, EspacioParqueo espacio,
        DateTime horaEntrada, DateTime? horaSalida)
    {
        TicketId = ticketId;
        Vehiculo = vehiculo;
        Espacio = espacio;
        HoraEntrada = horaEntrada;
        HoraSalida = horaSalida;
    }

    public int CalcularMinutos()
    {
        DateTime horaFinal = HoraSalida ?? DateTime.Now;
        TimeSpan tiempo = horaFinal - HoraEntrada;
        return (int)Math.Ceiling(tiempo.TotalMinutes);
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Ticket: #{TicketId}");
        Console.WriteLine($"Placa: {Vehiculo.Placa}");
        Console.WriteLine($"Espacio: {Espacio.Numero}");
        Console.WriteLine($"Entrada: {HoraEntrada:dd/MM/yyyy HH:mm}");

        if (HoraSalida != null)
        {
            Console.WriteLine($"Salida: {HoraSalida.Value:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Tiempo: {CalcularMinutos()} minuto(s)");
        }
        else
        {
            Console.WriteLine("Estado: El vehículo sigue dentro del parqueo.");
        }
    }
}
