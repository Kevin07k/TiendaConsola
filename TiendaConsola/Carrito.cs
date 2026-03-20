using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class Carrito
{
    private TADVector<ElementoCarrito> _items = new TADVector<ElementoCarrito>();
    
    public void Agregar(string codigo, int cantidad ,Inventario bodega)
    {
        Producto? productoDeBodega = bodega.Retirar(codigo, cantidad);

        if (productoDeBodega != null) return;

        ElementoCarrito? itemExistente = null;
        for (int i = 0; i < _items.Longitud; i++)
        {
            if (_items.ObtenerElemento(i).Producto.Codigo == codigo)
            {
                itemExistente = _items.ObtenerElemento(i);
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
            _items.AgregarElemento(nuevoElemento);
        }
        Console.WriteLine($"¡{cantidad}x {productoDeBodega!.Nombre} añadidos al carrito!");
    }
    
    public void MostrarCarrito()
    {
        Console.WriteLine("\n===============================");
        Console.WriteLine("       CARRITO DE COMPRAS      ");
        Console.WriteLine("===============================");
        
        double totalFinal = 0;

        for (int i = 0; i < _items.Longitud; i++)
        {
            ElementoCarrito elemento = _items.ObtenerElemento(i);
            double subtotal = elemento.CalcularSubtotal();
            totalFinal += subtotal;

            Console.WriteLine($"{elemento.Cantidad,-3} x {elemento.Producto.Nombre,-15} | Subtotal: {subtotal,8}Bs");
        }

        Console.WriteLine("-------------------------------");
        Console.WriteLine($"TOTAL A PAGAR: {totalFinal,14}Bs");
        Console.WriteLine("===============================\n");
    }
}