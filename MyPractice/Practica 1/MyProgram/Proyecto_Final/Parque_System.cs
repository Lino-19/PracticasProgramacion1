using System;

class Vehiculo
{
    public string Placa;
    public string Marca;
    public string Color;
}

class Program
{
    static void Main()
    {
        Vehiculo[] vehiculos = new Vehiculo[100];
        int cantidad = 0;

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== SISTEMA DE CONTROL DE PARQUEOS =====");
            Console.WriteLine("1. Agregar Vehículo");
            Console.WriteLine("2. Buscar Vehículo");
            Console.WriteLine("3. Modificar Vehículo");
            Console.WriteLine("4. Eliminar Vehículo");
            Console.WriteLine("5. Listar Vehículos");
            Console.WriteLine("6. Salir");

            Console.Write("Seleccione una opción: ");

            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Vehiculo nuevo = new Vehiculo();

                        Console.Write("Placa: ");
                        nuevo.Placa = Console.ReadLine();

                        Console.Write("Marca: ");
                        nuevo.Marca = Console.ReadLine();

                        Console.Write("Color: ");
                        nuevo.Color = Console.ReadLine();

                        vehiculos[cantidad] = nuevo;
                        cantidad++;

                        Console.WriteLine("Vehículo agregado correctamente.");
                        break;

                    case 2:

                        Console.Write("Ingrese la placa: ");
                        string placaBuscar = Console.ReadLine();

                        bool encontrado = false;

                        for (int i = 0; i < cantidad; i++)
                        {
                            if (vehiculos[i].Placa == placaBuscar)
                            {
                                Console.WriteLine("\nVehículo encontrado");
                                Console.WriteLine("Placa: " + vehiculos[i].Placa);
                                Console.WriteLine("Marca: " + vehiculos[i].Marca);
                                Console.WriteLine("Color: " + vehiculos[i].Color);

                                encontrado = true;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine("Vehículo no encontrado.");
                        }

                        break;

                    case 3:

                        Console.Write("Ingrese la placa a modificar: ");
                        string placaModificar = Console.ReadLine();

                        bool modificado = false;

                        for (int i = 0; i < cantidad; i++)
                        {
                            if (vehiculos[i].Placa == placaModificar)
                            {
                                Console.Write("Nueva marca: ");
                                vehiculos[i].Marca = Console.ReadLine();

                                Console.Write("Nuevo color: ");
                                vehiculos[i].Color = Console.ReadLine();

                                Console.WriteLine("Vehículo modificado.");

                                modificado = true;
                            }
                        }

                        if (!modificado)
                        {
                            Console.WriteLine("Vehículo no encontrado.");
                        }

                        break;

                    case 4:

                        Console.Write("Ingrese la placa a eliminar: ");
                        string placaEliminar = Console.ReadLine();

                        bool eliminado = false;

                        for (int i = 0; i < cantidad; i++)
                        {
                            if (vehiculos[i].Placa == placaEliminar)
                            {
                                for (int j = i; j < cantidad - 1; j++)
                                {
                                    vehiculos[j] = vehiculos[j + 1];
                                }

                                cantidad--;

                                Console.WriteLine("Vehículo eliminado.");

                                eliminado = true;
                                break;
                            }
                        }

                        if (!eliminado)
                        {
                            Console.WriteLine("Vehículo no encontrado.");
                        }

                        break;

                    case 5:

                        if (cantidad == 0)
                        {
                            Console.WriteLine("No hay vehículos registrados.");
                        }
                        else
                        {
                            Console.WriteLine("\n===== LISTA DE VEHÍCULOS =====");

                            for (int i = 0; i < cantidad; i++)
                            {
                                Console.WriteLine("----------------");
                                Console.WriteLine("Placa: " + vehiculos[i].Placa);
                                Console.WriteLine("Marca: " + vehiculos[i].Marca);
                                Console.WriteLine("Color: " + vehiculos[i].Color);
                            }
                        }

                        break;

                    case 6:

                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error: dato inválido.");
            }
        }
    }
}