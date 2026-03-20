namespace TiendaConsola;

public class ElementoInventario
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }

    public ElementoInventario(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public ElementoInventario(Producto producto)
    {
        Producto = producto;
        Cantidad = 0;
    }
}