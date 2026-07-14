// Adrian Paulino // 2025-1937

List<string> placas = new List<string>();

bool salir = false;

while (salir == false)
{
    Console.WriteLine();
    Console.WriteLine("===== SISTEMA DE CONTROL DE PARQUEOS =====");
    Console.WriteLine("1. Agregar vehículo");
    Console.WriteLine("2. Buscar vehículo");
    Console.WriteLine("3. Modificar vehículo");
    Console.WriteLine("4. Eliminar vehículo");
    Console.WriteLine("5. Listar vehículos");
    Console.WriteLine("6. Registrar entrada");
    Console.WriteLine("7. Registrar salida");
    Console.WriteLine("8. Salir");
    Console.Write("Seleccione una opción: ");

    int opcion = 0;

    try
    {
        opcion = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Debe escribir un número.");
    }

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Agregar vehículo");
            break;

        case 2:
            Console.WriteLine("Buscar vehículo");
            break;

        case 3:
            Console.WriteLine("Modificar vehículo");
            break;

        case 4:
            Console.WriteLine("Eliminar vehículo");
            break;

        case 5:
            Console.WriteLine("Listar vehículos");
            break;

        case 6:
            Console.WriteLine("Registrar entrada");
            break;

        case 7:
            Console.WriteLine("Registrar salida");
            break;

        case 8:
            salir = true;
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}