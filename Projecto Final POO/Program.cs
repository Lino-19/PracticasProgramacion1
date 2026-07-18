using SistemaControlParqueos;

List<EspacioParqueo> espacios = new List<EspacioParqueo>
{
    new EspacioParqueo("A1"),
    new EspacioParqueo("A2"),
    new EspacioParqueo("A3"),
    new EspacioParqueo("B1"),
    new EspacioParqueo("B2")
};

List<Ticket> tickets = new List<Ticket>();
int proximoNumeroTicket = 1;
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

    switch (opcion)
    {
        case "1":
            RegistrarEntrada(espacios, tickets, ref proximoNumeroTicket);
            break;
        case "2":
            RegistrarSalida(tickets);
            break;
        case "3":
            MostrarEspacios(espacios);
            break;
        case "4":
            MostrarTicketsActivos(tickets);
            break;
        case "5":
            MostrarTodosLosTickets(tickets);
            break;
        case "6":
            Console.WriteLine("Programa finalizado.");
            break;
        default:
            Console.WriteLine("Opción no válida.");
            Pausar();
            break;
    }
}
while (opcion != "6");

static void RegistrarEntrada(List<EspacioParqueo> espacios, List<Ticket> tickets, ref int proximoNumeroTicket)
{
    EspacioParqueo? espacioDisponible = espacios.Find(espacio => !espacio.EstaOcupado);

    if (espacioDisponible == null)
    {
        Console.WriteLine("No hay espacios disponibles.");
        Pausar();
        return;
    }

    Console.Clear();
    Console.WriteLine("=== REGISTRAR ENTRADA ===");
    Console.Write("Placa: ");
    string placa = Console.ReadLine() ?? "";

    Ticket? ticketExistente = tickets.Find(ticket =>
        ticket.Vehiculo.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase) && ticket.HoraSalida == null);

    if (ticketExistente != null)
    {
        Console.WriteLine("Este vehículo ya tiene una entrada activa.");
        Pausar();
        return;
    }

    Console.Write("Marca: ");
    string marca = Console.ReadLine() ?? "";
    Console.Write("Color: ");
    string color = Console.ReadLine() ?? "";

    Vehiculo vehiculo = new Vehiculo(placa, marca, color);
    espacioDisponible.Ocupar();

    Ticket ticket = new Ticket(proximoNumeroTicket, vehiculo, espacioDisponible);
    tickets.Add(ticket);
    proximoNumeroTicket++;

    Console.WriteLine($"\nEntrada registrada. Espacio asignado: {espacioDisponible.Numero}");
    Console.WriteLine($"Número de ticket: {ticket.Numero}");
    Pausar();
}

static void RegistrarSalida(List<Ticket> tickets)
{
    Console.Clear();
    Console.WriteLine("=== REGISTRAR SALIDA ===");
    Console.Write("Escribe el número de ticket: ");

    if (!int.TryParse(Console.ReadLine(), out int numeroTicket))
    {
        Console.WriteLine("Debes escribir un número válido.");
        Pausar();
        return;
    }

    Ticket? ticket = tickets.Find(ticket => ticket.Numero == numeroTicket && ticket.HoraSalida == null);

    if (ticket == null)
    {
        Console.WriteLine("No se encontró un ticket activo con ese número.");
        Pausar();
        return;
    }

    ticket.RegistrarSalida();
    ticket.Espacio.Liberar();

    Console.WriteLine("\nSalida registrada correctamente.");
    ticket.MostrarDatos();
    Pausar();
}

static void MostrarEspacios(List<EspacioParqueo> espacios)
{
    Console.Clear();
    Console.WriteLine("=== ESPACIOS DE PARQUEO ===");

    foreach (EspacioParqueo espacio in espacios)
    {
        espacio.MostrarEstado();
    }

    Pausar();
}

static void MostrarTicketsActivos(List<Ticket> tickets)
{
    Console.Clear();
    Console.WriteLine("=== TICKETS ACTIVOS ===");
    List<Ticket> ticketsActivos = tickets.FindAll(ticket => ticket.HoraSalida == null);

    if (ticketsActivos.Count == 0)
    {
        Console.WriteLine("No hay vehículos dentro del parqueo.");
    }
    else
    {
        foreach (Ticket ticket in ticketsActivos)
        {
            ticket.MostrarDatos();
            Console.WriteLine();
        }
    }

    Pausar();
}

static void MostrarTodosLosTickets(List<Ticket> tickets)
{
    Console.Clear();
    Console.WriteLine("=== TODOS LOS TICKETS ===");

    if (tickets.Count == 0)
    {
        Console.WriteLine("Aún no se han creado tickets.");
    }
    else
    {
        foreach (Ticket ticket in tickets)
        {
            ticket.MostrarDatos();
            Console.WriteLine();
        }
    }

    Pausar();
}

static void Pausar()
{
    Console.WriteLine("Presiona una tecla para continuar...");
    Console.ReadKey();
}
