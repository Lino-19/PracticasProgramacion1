using static System.Runtime.InteropServices.JavaScript.JSType;
class Program{
        static void Main(string[] args){
        string entrada;
        Console.Write("\nIngrese texto: ");
        entrada = Console.ReadLine();
        while (int.TryParse (entrada, out _)){
            Console.WriteLine("Ingrese solo texto");
            Console.ReadKey();
            Console.Write("\nIngrese texto: ");
            entrada = Console.ReadLine();
        }

        Console.WriteLine("El texto insertado fue " + entrada);
        


        //entrada = int.TryParse(Console.ReadLine());
        //int contador = 0;
        //        for (int i = 1; i <= entrada; i++){
        //            if (i % 2 == 0){
        //                Console.WriteLine(i);
        //                contador++; 
        //            }
        //        }
        //        Console.WriteLine("\nCantidad de numeros pares: " + contador);
    }
}
