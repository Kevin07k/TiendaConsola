using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class Inventario
{
    private TADVector<ElementoInventario> _listaElementos = new TADVector<ElementoInventario>();

    public void AgregarProducto(Producto p, int cantidadInicial)
    {
        ElementoInventario nuevoElemento = new ElementoInventario(p, cantidadInicial);
        _listaElementos.AgregarElemento(nuevoElemento);
    }

    public Producto? Retirar(string codigo, int cantidadPedida)
    {
        ElementoInventario? itemEncontrado = null;

        //* Iteramos hasta encontrar
        foreach (var item in _listaElementos)
        {
            if (item.Producto.Codigo == codigo)
            {
                itemEncontrado = item;
                break;
            }
        }

        //* Verificamos si existe
        if (itemEncontrado == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: El producto con ese codigo no existe");
            Console.ResetColor();
            return null;
        }

        //* Verificamos el Stock
        if (itemEncontrado.Cantidad < cantidadPedida)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Stock insufieciente. Solo quedan {itemEncontrado.Cantidad} unidades.");
            Console.ResetColor();
            return null;
        }

        itemEncontrado.Cantidad -= cantidadPedida;
        return itemEncontrado.Producto;
    }
    
    public void EliminarProducto(string codigo)
    {
        for (int i = 0; i < _listaElementos.Longitud; i++)
        {
            if (_listaElementos.ObtenerElemento(i).Producto.Codigo == codigo)
            {
                _listaElementos.EliminarElemento(i);
                Console.WriteLine("Producto eliminado con éxito.");
                return;
            }
        }
        Console.WriteLine("Producto no encontrado.");
    }

    public void ActualizarProducto(string codigo, string nuevoNombre, double nuevoPrecio)
    {
        foreach (var item in _listaElementos)
        {
            if (item.Producto.Codigo == codigo)
            {
                item.Producto.Nombre = nuevoNombre;
                item.Producto.Precio = nuevoPrecio;
                Console.WriteLine("Producto actualizado.");
                return;
            }
        }
        Console.WriteLine("Producto no encontrado.");
    }

    public void MostrarTodo()
    {
        foreach (var item in _listaElementos)
        {
            Console.WriteLine($"{item.Producto.Codigo} | {item.Producto.Nombre} | {item.Producto.Precio}Bs | Stock: {item.Cantidad}");
        }
    }
}