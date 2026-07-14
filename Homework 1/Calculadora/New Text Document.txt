using System;

class Program
{
    static void Main()
    {
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n===== MENU PRINCIPAL =====");
            Console.WriteLine("1. Sumar");
            Console.WriteLine("2. Restar");
            Console.WriteLine("3. Multiplicar");
            Console.WriteLine("4. Dividir");
            Console.WriteLine("5. Verificar si un estudiante aprobó");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            try
            {
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el primer número: ");
                        double suma1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Ingrese el segundo número: ");
                        double suma2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine($"Resultado: {suma1 + suma2}");
                        break;

                    case 2:
                        Console.Write("Ingrese el primer número: ");
                        double resta1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Ingrese el segundo número: ");
                        double resta2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine($"Resultado: {resta1 - resta2}");
                        break;

                    case 3:
                        Console.Write("Ingrese el primer número: ");
                        double mult1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Ingrese el segundo número: ");
                        double mult2 = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine($"Resultado: {mult1 * mult2}");
                        break;

                    case 4:
                        Console.Write("Ingrese el primer número: ");
                        double div1 = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Ingrese el segundo número: ");
                        double div2 = Convert.ToDouble(Console.ReadLine());

                        if (div2 == 0)
                        {
                            Console.WriteLine("Error: No se puede dividir entre cero.");
                        }
                        else
                        {
                            Console.WriteLine($"Resultado: {div1 / div2}");
                        }
                        break;

                    case 5:
                        Console.Write("Ingrese el nombre del estudiante: ");
                        string nombre = Console.ReadLine();

                        Console.Write("Ingrese la calificación final: ");
                        double nota = Convert.ToDouble(Console.ReadLine());

                        if (nota >= 70)
                        {
                            Console.WriteLine($"{nombre} APROBÓ con {nota} puntos.");
                        }
                        else
                        {
                            Console.WriteLine($"{nombre} REPROBÓ con {nota} puntos.");
                        }
                        break;

                    case 6:
                        salir = true;
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Error: Debe ingresar un valor válido.");
            }
        }
    }
}