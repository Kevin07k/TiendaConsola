namespace TiendaConsola;

public class Producto
{
    public string Codigo { get; init; }
    public string Nombre { get; set; }

    private double _precio;

    public double Precio
    {
        get => _precio;
        set => _precio = value < 0 ? 0 : value;
    }

    public Producto(string codigo, string nombre, double precio)
    {
        Codigo = codigo;
        Nombre = nombre;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"[{Codigo}] {Nombre} - {Precio:C0}";
    }
}