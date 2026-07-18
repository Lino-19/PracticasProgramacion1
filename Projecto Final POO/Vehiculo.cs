namespace SistemaControlParqueos;

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

    public void MostrarDatos()
    {
        Console.WriteLine($"Placa: {Placa}");
        Console.WriteLine($"Marca: {Marca}");
        Console.WriteLine($"Color: {Color}");
    }
}
