using TiendaConsola;

// 1. Configuración inicial
Inventario bodega = new Inventario();
Carrito miCompra = new Carrito();

bodega.AgregarProducto(new Producto("T01", "Teclado", 150), 5);
bodega.AgregarProducto(new Producto("M02", "Mouse", 80), 10);
bodega.AgregarProducto(new Producto("P03", "Pad", 30), 20);

bool continuar = true;

while (continuar)
{
    Console.Clear();
    Console.WriteLine("=== BIENVENIDO A TIENDA CONSOLA ===");
    Console.WriteLine("1. Ver Inventario");

    Console.WriteLine("2. Salir");
    Console.Write("\nSeleccione una opción: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            PresentacionTienda.MostrarInventario(bodega);
            break;

        case "2":
            continuar = false;
            Console.WriteLine("Gracias por su compra. ¡Vuelva pronto!");
            break;
        
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }

    if (continuar)
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}