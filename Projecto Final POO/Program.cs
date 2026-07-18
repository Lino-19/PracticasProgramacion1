using System.Data.SqlClient;
using SistemaControlParqueos;

ParqueoRepository repositorio = new ParqueoRepository();
string opcion;

do
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE CONTROL DE PARQUEOS ===");
    Console.WriteLine("1. Registrar entrada de vehículo");
    Console.WriteLine("2. Registrar salida de vehículo");
    Console.WriteLine("3. Ver espacios de parqueo");
    Console.WriteLine("4. Ver tickets activos");
    Console.WriteLine("5. Ver todos los tickets");
    Console.WriteLine("6. Salir");
    Console.Write("Elige una opción: ");
    opcion = Console.ReadLine() ?? "";

    try
    {
        switch (opcion)
        {
            case "1":
                RegistrarEntrada(repositorio);
                break;
            case "2":
                RegistrarSalida(repositorio);
                break;
            case "3":
                MostrarEspacios(repositorio);
                break;
            case "4":
                MostrarTickets(repositorio.ObtenerTicketsActivos(), "TICKETS ACTIVOS");
                break;
            case "5":
                MostrarTickets(repositorio.ObtenerTodosLosTickets(), "TODOS LOS TICKETS");
                break;
            case "6":
                Console.WriteLine("Programa finalizado.");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                Console.WriteLine("Presiona una tecla para continuar...");
                Console.ReadKey();
                break;
        }
    }
    catch (SqlException ex)
    {
        Console.WriteLine($"Error al conectar con SQL Server: {ex.Message}");
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }
}
while (opcion != "6");

static void RegistrarEntrada(ParqueoRepository repositorio)
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR ENTRADA ===");
    Console.Write("Placa: ");
    string placa = Console.ReadLine() ?? "";

    if (string.IsNullOrWhiteSpace(placa))
    {
        Console.WriteLine("La placa es obligatoria.");
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
        return;
    }

    if (repositorio.ExisteTicketActivo(placa))
    {
        Console.WriteLine("Este vehículo ya tiene una entrada activa.");
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
        return;
    }

    Console.Write("Marca: ");
    string marca = Console.ReadLine() ?? "";
    Console.Write("Color: ");
    string color = Console.ReadLine() ?? "";

    Ticket? ticket = repositorio.RegistrarEntrada(placa, marca, color);

    if (ticket == null)
    {
        Console.WriteLine("No hay espacios disponibles.");
    }
    else
    {
        Console.WriteLine("\nEntrada registrada correctamente.");
        ticket.MostrarDatos();
    }

    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
}

static void RegistrarSalida(ParqueoRepository repositorio)
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR SALIDA ===");
    Console.Write("Escribe el número de ticket: ");

    if (!int.TryParse(Console.ReadLine(), out int ticketId))
    {
        Console.WriteLine("Debes escribir un número válido.");
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
        return;
    }

    Ticket? ticket = repositorio.RegistrarSalida(ticketId);

    if (ticket == null)
    {
        Console.WriteLine("No se encontró un ticket activo con ese número.");
    }
    else
    {
        Console.WriteLine("\nSalida registrada correctamente.");
        ticket.MostrarDatos();
    }

    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
}

static void MostrarEspacios(ParqueoRepository repositorio)
{
    Console.Clear();
    Console.WriteLine("=== ESPACIOS DE PARQUEO ===");

    List<EspacioParqueo> espacios = repositorio.ObtenerEspacios();

    foreach (EspacioParqueo espacio in espacios)
    {
        espacio.MostrarEstado();
    }

    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
}

static void MostrarTickets(List<Ticket> tickets, string titulo)
{
    Console.Clear();
    Console.WriteLine($"=== {titulo} ===");

    if (tickets.Count == 0)
    {
        Console.WriteLine("No hay tickets para mostrar.");
    }
    else
    {
        foreach (Ticket ticket in tickets)
        {
            ticket.MostrarDatos();
            Console.WriteLine();
        }
    }

    Console.WriteLine("Presiona una tecla para continuar...");
    Console.ReadKey();
}
