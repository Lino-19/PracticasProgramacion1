namespace SistemaControlParqueos;

public class Ticket
{
    public int Numero { get; set; }
    public Vehiculo Vehiculo { get; set; }
    public EspacioParqueo Espacio { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSalida { get; set; }

    public Ticket(int numero, Vehiculo vehiculo, EspacioParqueo espacio)
    {
        Numero = numero;
        Vehiculo = vehiculo;
        Espacio = espacio;
        HoraEntrada = DateTime.Now;
        HoraSalida = null;
    }

    public void RegistrarSalida()
    {
        HoraSalida = DateTime.Now;
    }

    public double CalcularMinutos()
    {
        DateTime horaFinal = HoraSalida ?? DateTime.Now;
        TimeSpan tiempo = horaFinal - HoraEntrada;
        return Math.Ceiling(tiempo.TotalMinutes);
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Ticket: #{Numero}");
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
