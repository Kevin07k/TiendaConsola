namespace TiendaConsola;

public class PresentacionTienda
{
    public static void MostrarInventario(Inventario inventario)
    {
        Console.WriteLine("\n--- PRODUCTOS EN BODEGA ---");
        foreach (var p in inventario.ProductosBase)
        {
            int stockActual = inventario.Cantidades[p.Codigo];
            Console.WriteLine($"{p} | Stock: {stockActual}");
        }
    }
}