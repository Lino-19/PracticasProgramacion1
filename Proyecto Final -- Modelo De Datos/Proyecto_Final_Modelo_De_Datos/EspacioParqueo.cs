namespace SistemaControlParqueos;

public class EspacioParqueo
{
    public int EspacioId { get; set; }
    public string Numero { get; set; }
    public bool EstaOcupado { get; set; }

    public EspacioParqueo(int espacioId, string numero, bool estaOcupado)
    {
        EspacioId = espacioId;
        Numero = numero;
        EstaOcupado = estaOcupado;
    }

    public void MostrarEstado()
    {
        string estado = EstaOcupado ? "Ocupado" : "Disponible";
        Console.WriteLine($"Espacio {Numero}: {estado}");
    }
}
