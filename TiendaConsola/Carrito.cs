using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class Carrito
{
    public TADVector<ElementoCarrito> Items { get; } = new TADVector<ElementoCarrito>();
    
    public void Agregar(string codigo, int cantidad ,Inventario bodega)
    {
        Producto? productoDeBodega = bodega.Retirar(codigo, cantidad);

        if (productoDeBodega != null) return;

        ElementoCarrito? itemExistente = null;
        for (int i = 0; i < Items.Longitud; i++)
        {
            if (Items.ObtenerElemento(i).Producto.Codigo == codigo)
            {
                itemExistente = Items.ObtenerElemento(i);
                break;
            }
        }

        if (itemExistente != null)
        {
            itemExistente.Cantidad += cantidad;
        }
        else
        {
            ElementoCarrito nuevoElemento = new ElementoCarrito(productoDeBodega!, cantidad);
            Items.AgregarElemento(nuevoElemento);
        }
        Console.WriteLine($"¡{cantidad}x {productoDeBodega!.Nombre} añadidos al carrito!");
    }
}