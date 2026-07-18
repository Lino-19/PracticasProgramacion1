public class Ticket
{
    public Vehiculo Vehiculo { get; set; }
    public EspacioParqueo Espacio { get; set; }

    public DateTime HoraEntrada { get; set; }
    public DateTime HoraSalida { get; set; }

    public Ticket(Vehiculo vehiculo, EspacioParqueo espacio)
    {
        Vehiculo = vehiculo;
        Espacio = espacio;
        HoraEntrada = DateTime.Now;
    }
}
