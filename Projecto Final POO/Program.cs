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
            Console.Write("Placa: ");
            string placa = Console.ReadLine();
    
            Console.Write("Marca: ");
            string marca = Console.ReadLine();
    
            Console.Write("Color: ");
            string color = Console.ReadLine();
    
            Vehiculo nuevo = new Vehiculo(placa, marca, color);
        
            vehiculos.Add(nuevo);
        
            Console.WriteLine("Vehículo agregado.");
        break;

        case 2:
            Console.Write("Digite la placa: ");
            placa = Console.ReadLine();
        
            bool encontrado = false;
        
            foreach (Vehiculo v in vehiculos)
            {
                if (v.Placa == placa)
                {
                    Console.WriteLine("Placa: " + v.Placa);
                    Console.WriteLine("Marca: " + v.Marca);
                    Console.WriteLine("Color: " + v.Color);
        
                    encontrado = true;
                    break;
                }
            }
        
            if (encontrado == false)
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        break;

        case 3:
            Console.Write("Digite la placa: ");
            placa = Console.ReadLine();
        
            encontrado = false;
        
            foreach (Vehiculo v in vehiculos)
            {
                if (v.Placa == placa)
                {
                    Console.Write("Nueva marca: ");
                    v.Marca = Console.ReadLine();
        
                    Console.Write("Nuevo color: ");
                    v.Color = Console.ReadLine();
        
                    Console.WriteLine("Vehículo modificado.");
        
                    encontrado = true;
                    break;
                 }
                }
            
                if (encontrado == false)
                {
                    Console.WriteLine("Vehículo no encontrado.");
                }

        break;
            
        case 4:
            Console.Write("Digite la placa: ");
            placa = Console.ReadLine();
        
            encontrado = false;
        
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (vehiculos[i].Placa == placa)
                {
                    vehiculos.RemoveAt(i);
        
                    Console.WriteLine("Vehículo eliminado.");
        
                    encontrado = true;
                    break;
                }
            }
        
            if (encontrado == false)
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
        break;

        case 5:
          
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
            }
            else
            {
                foreach (Vehiculo v in vehiculos)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Placa: " + v.Placa);
                    Console.WriteLine("Marca: " + v.Marca);
                    Console.WriteLine("Color: " + v.Color);
                }
            }
    
        break;
    
        case 6:
                Console.Write("Digite la placa: ");
                placa = Console.ReadLine();
            
                Vehiculo vehiculo = null;
            
                foreach (Vehiculo v in vehiculos)
                {
                    if (v.Placa == placa)
                    {
                        vehiculo = v;
                        break;
                    }
                }
            
                if (vehiculo == null)
                {
                    Console.WriteLine("Vehículo no encontrado.");
                    break;
                }
            
                foreach (EspacioParqueo e in espacios)
                {
                    if (e.Ocupado == false)
                    {
                        e.Ocupado = true;
            
                        Ticket ticket = new Ticket(vehiculo, e);
            
                        tickets.Add(ticket);
            
                        Console.WriteLine("Entrada registrada.");
                        Console.WriteLine("Espacio asignado: " + e.Numero);
            
                        break;
                    }
                }
        break;

        case 7:
                    Console.Write("Digite la placa: ");
                    placa = Console.ReadLine();
                
                    encontrado = false;
                
                    foreach (Ticket t in tickets)
                    {
                        if (t.Vehiculo.Placa == placa && t.HoraSalida == DateTime.MinValue)
                        {
                            t.HoraSalida = DateTime.Now;
                
                            t.Espacio.Ocupado = false;
                
                            TimeSpan tiempo = t.HoraSalida - t.HoraEntrada;
                
                            Console.WriteLine("Salida registrada.");
                            Console.WriteLine("Tiempo: " + tiempo.TotalMinutes + " minutos.");
                
                            encontrado = true;
                            break;
                        }
                    }
                
                    if (encontrado == false)
                    {
                        Console.WriteLine("Ese vehículo no está parqueado.");
                    }
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

// Debo revisarlo para pensar en buenas practicas como validaciones y unos cuentos ciclos While.


