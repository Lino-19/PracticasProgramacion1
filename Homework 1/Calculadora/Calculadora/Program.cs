// Nombre: Adrian Paulino -- Matricula: 20251937
// Programa Calculadora

Console.WriteLine("===== MENU =====");
Console.WriteLine("1. Sumar");
Console.WriteLine("2. Restar");
Console.WriteLine("3. Multiplicar");
Console.WriteLine("4. Dividir");
Console.WriteLine("5. Verificar estudiante");
Console.WriteLine("6. Salir");

Console.Write("Seleccione una opcion: ");
int opcion = Convert.ToInt32(Console.ReadLine());

switch (opcion)
{
    case 1:
        Console.Write("Primer numero: ");
        double n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Segundo numero: ");
        double n2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Resultado: " + (n1 + n2));
        break;

    case 2:
        Console.Write("Primer numero: ");
        n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Segundo numero: ");
        n2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Resultado: " + (n1 - n2));
        break;

    case 3:
        Console.Write("Primer numero: ");
        n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Segundo numero: ");
        n2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Resultado: " + (n1 * n2));
        break;

    case 4:
        Console.Write("Primer numero: ");
        n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Segundo numero: ");
        n2 = Convert.ToDouble(Console.ReadLine());

        if (n2 == 0)
        {
            Console.WriteLine("No se puede dividir entre cero.");
        }
        else
        {
            Console.WriteLine("Resultado: " + (n1 / n2));
        }
        break;

    case 5:
        Console.Write("Nombre del estudiante: ");
        string nombre = Console.ReadLine();

        Console.Write("Nota final: ");
        double nota = Convert.ToDouble(Console.ReadLine());

        if (nota >= 70)
        {
            Console.WriteLine(nombre + " APROBO");
        }
        else
        {
            Console.WriteLine(nombre + " REPROBO");
        }
        break;

    case 6:
        Console.WriteLine("Programa finalizado.");
        break;

    default:
        Console.WriteLine("Opcion no valida.");
        break;
}