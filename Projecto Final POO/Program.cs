// Nombre: Adrian Paulino -- Matricula: 20251937

List<Vehiculo> vehiculos = new List<Vehiculo>();
List<EspacioParqueo> espacios = new List<EspacioParqueo>();
List<Ticket> tickets = new List<Ticket>();

for (int i = 1; i <= 10; i++)
{
    espacios.Add(new EspacioParqueo(i));
}


bool salir = false;

while (!salir)
{
    Console.WriteLine("===== SISTEMA DE CONTROL DE PARQUEOS =====");
    Console.WriteLine("1. Agregar vehículo");
    Console.WriteLine("2. Buscar vehículo");
    Console.WriteLine("3. Modificar vehículo");
    Console.WriteLine("4. Eliminar vehículo");
    Console.WriteLine("5. Listar vehículos");
    Console.WriteLine("6. Registrar entrada");
    Console.WriteLine("7. Registrar salida");
    Console.WriteLine("8. Salir");

    int opcion = Convert.ToInt32(Console.ReadLine());

    switch (opcion)
    {
        case 1:
            break;

        case 2:
            break;

        case 3:
            break;

        case 4:
            break;

        case 5:
            break;

        case 6:
            break;

        case 7:
            break;

        case 8:
            salir = true;
            break;
    }
}


public class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Color { get; set; }

    public Vehiculo(string placa, string marca, string color)
    {
        Placa = placa;
        Marca = marca;
        Color = color;
    }
}

public class EspacioParqueo
{
    public int Numero { get; set; }
    public bool Ocupado { get; set; }

    public EspacioParqueo(int numero)
    {
        Numero = numero;
        Ocupado = false;
    }
}

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




