namespace RegistroPacientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PacienteDAO pacienteDAO = new PacienteDAO();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();

                Console.WriteLine("====================================");
                Console.WriteLine(" SISTEMA DE REGISTRO DE PACIENTES");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Buscar paciente");
                Console.WriteLine("3. Mostrar pacientes");
                Console.WriteLine("4. Modificar paciente");
                Console.WriteLine("5. Eliminar paciente");
                Console.WriteLine("6. Salir");
                Console.WriteLine("====================================");

                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        Paciente paciente = new Paciente();

                        Console.Write("Nombre: ");
                        paciente.Nombre = Console.ReadLine();

                        Console.Write("Apellido: ");
                        paciente.Apellido = Console.ReadLine();

                        Console.Write("Edad: ");
                        paciente.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Sexo: ");
                        paciente.Sexo = Console.ReadLine();

                        Console.Write("Telefono: ");
                        paciente.Telefono = Console.ReadLine();

                        Console.Write("Direccion: ");
                        paciente.Direccion = Console.ReadLine();

                        pacienteDAO.RegistrarPaciente(paciente);

                        break;

                    case "2":

                        Console.Write("Digite el Id del paciente: ");
                        int idBuscar = Convert.ToInt32(Console.ReadLine());

                        pacienteDAO.BuscarPaciente(idBuscar);

                        break;

                    case "3":

                        pacienteDAO.MostrarPacientes();

                        break;

                    case "4":

                        Paciente pacienteModificar = new Paciente();

                        Console.Write("Id del paciente: ");
                        pacienteModificar.Id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Nombre: ");
                        pacienteModificar.Nombre = Console.ReadLine();

                        Console.Write("Apellido: ");
                        pacienteModificar.Apellido = Console.ReadLine();

                        Console.Write("Edad: ");
                        pacienteModificar.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Sexo: ");
                        pacienteModificar.Sexo = Console.ReadLine();

                        Console.Write("Telefono: ");
                        pacienteModificar.Telefono = Console.ReadLine();

                        Console.Write("Direccion: ");
                        pacienteModificar.Direccion = Console.ReadLine();

                        pacienteDAO.ModificarPaciente(pacienteModificar);

                        break;

                    case "5":

                        Console.Write("Digite el Id del paciente a eliminar: ");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());

                        pacienteDAO.EliminarPaciente(idEliminar);

                        break;

                    case "6":

                        salir = true;

                        Console.WriteLine("Gracias por utilizar el sistema.");

                        break;

                    default:

                        Console.WriteLine("Opción no válida.");

                        break;
                }

                if (!salir)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}