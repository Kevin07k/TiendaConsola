namespace TiendaConsola;

public class ElementoCarrito
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }
    
    public ElementoCarrito(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public double CalcularSubtotal()
    {
        return Producto.Precio * Cantidad;
    }
}