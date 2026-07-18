namespace SistemaControlParqueos;

public class EspacioParqueo
{
    public string Numero { get; set; }
    public bool EstaOcupado { get; set; }

    public EspacioParqueo(string numero)
    {
        Numero = numero;
        EstaOcupado = false;
    }

    public void Ocupar()
    {
        EstaOcupado = true;
    }

    public void Liberar()
    {
        EstaOcupado = false;
    }

    public void MostrarEstado()
    {
        string estado = EstaOcupado ? "Ocupado" : "Disponible";
        Console.WriteLine($"Espacio {Numero}: {estado}");
    }
}
