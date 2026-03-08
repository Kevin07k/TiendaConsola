using TiendaConsola.EstructurasDeDatos;

namespace TiendaConsola;

public class Inventario
{
    public readonly Dictionary<string, int> Cantidades = new Dictionary<string, int>();
    public readonly TADVector ProductosBase = new TADVector();

    public void AgregarProducto(Producto p, int cantidadInicial)
    {
        ProductosBase.AgregarElemento(p);
        Cantidades[p.Codigo] = cantidadInicial;
    }
    
}