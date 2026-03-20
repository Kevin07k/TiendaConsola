namespace TiendaConsola;

public class PresentacionTienda
{
    private Autenticacion _auth = new Autenticacion();
    private Inventario _bodega = new Inventario();
    private Carrito _carrito = new Carrito();

    public void Ejecutar()
    {
        InicializarDatos();
        while (true)
        {
            if (_auth.UsuarioActual == null)
            {
                MostrarLogin();
            }
            else
            {
                if (_auth.UsuarioActual.TienePermiso("GESTION_INVENTARIO"))
                    MostrarMenuAdmin();
                else
                    MostrarMenuCliente();
            }
        }
    }

    private void MostrarLogin()
    {
        Console.WriteLine("\n--- LOGIN TIENDA ---");
        Console.Write("Usuario: ");
        string user = Console.ReadLine()!;
        Console.Write("Password: ");
        string pass = Console.ReadLine()!;

        if (!_auth.Login(user, pass))
        {
            Console.WriteLine("Credenciales incorrectas. Presione una tecla...");
            Console.ReadKey();
        }
        Console.Clear();
    }

    private void MostrarMenuAdmin()
    {
        Console.Clear();
        Console.WriteLine($"--- PANEL DE ADMINISTRACION | Usuario: {_auth.UsuarioActual!.NombreUsuario} ---");
        Console.WriteLine("---    Opciones Producto    ---");
        Console.WriteLine("1. Listar productos");
        Console.WriteLine("2. Agregar producto");
        Console.WriteLine("3. Actualizar producto");
        Console.WriteLine("4. Eliminar producto");
        Console.WriteLine("---    Opciones Usuario    ---");
        Console.WriteLine("5. Listar usuarios");
        Console.WriteLine("6. Agregar usuario");
        Console.WriteLine("7. Actualizar usuario");
        Console.WriteLine("8. Eliminar usuario");
        Console.WriteLine("---    Opciones Sistema    ---");
        Console.WriteLine("9. Cerrar Sesion");
        Console.WriteLine("0. CERRAR TIENDA (Salir)");
        Console.Write("Opcion: ");

        switch (Console.ReadLine())
        {
            case "1":
                _bodega.MostrarTodo();
                Console.ReadKey();
                break;
            case "2": AgregarStock(); break;
            case "3": ActualizarProductoUI(); break;
            case "4": EliminarProductoUI(); break;
            case "5":
                _auth.ListarUsuarios();
                Console.ReadKey();
                break;
            case "6": AgregarUsuarioUI(); break;
            case "7": ActualizarUsuarioUI(); break;
            case "8": EliminarUsuarioUI(); break;
            case "9": _auth.Logout(); break;
            case "0": Environment.Exit(0); break;
        }
    }

    private void MostrarMenuCliente()
    {
        Console.Clear();
        Console.WriteLine($"--- MODO CLIENTE | Usuario: {_auth.UsuarioActual!.NombreUsuario} ---");
        Console.WriteLine("1. Ver productos disponibles");
        Console.WriteLine("2. Realizar una compra");
        Console.WriteLine("3. Ver carrito");
        Console.WriteLine("9. Cerrar Sesion");
        Console.WriteLine("0. CERRAR TIENDA (Salir)");
        Console.Write("Opcion: ");

        switch (Console.ReadLine())
        {
            case "1":
                _bodega.MostrarTodo();
                Console.ReadKey();
                break;
            case "2": Comprar(); break;
            case "3":
                _carrito.MostrarCarrito();
                Console.ReadKey();
                break;
            case "9": _auth.Logout(); break;
            case "0": Environment.Exit(0); break;
        }
    }

    private void Comprar()
    {
        Console.Clear();
        Console.WriteLine("\n--- PRODUCTOS DISPONIBLES ---");

        _bodega.MostrarTodo();

        Console.Write("\nIngrese el CODIGO del producto: ");
        string codigo = Console.ReadLine()!;

        Console.Write("Cantidad a comprar: ");
        if (int.TryParse(Console.ReadLine(), out int cant))
        {
            _carrito.Agregar(codigo, cant, _bodega);
        }
        else
        {
            Console.WriteLine("Cantidad no valida.");
        }
    }

    private void AgregarStock()
    {
        Console.Clear();
        Console.WriteLine("\n--- NUEVO PRODUCTO ---");
        Console.Write("Codigo: ");
        string cod = Console.ReadLine()!;
        Console.Write("Nombre: ");
        string nom = Console.ReadLine()!;
        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine()!);
        Console.Write("Stock: ");
        int stock = int.Parse(Console.ReadLine()!);

        _bodega.AgregarProducto(new Producto(cod, nom, precio), stock);
        Console.WriteLine("Producto agregado. Presione una tecla...");
        Console.ReadKey();
    }

    private void EliminarProductoUI()
    {
        Console.Write("Ingrese el codigo del producto a eliminar: ");
        string cod = Console.ReadLine()!;
        _bodega.EliminarProducto(cod);
        Console.ReadKey();
    }

    private void ActualizarProductoUI()
    {
        Console.Write("Codigo del producto a modificar: ");
        string cod = Console.ReadLine()!;
        Console.Write("Nuevo Nombre: ");
        string nom = Console.ReadLine()!;
        Console.Write("Nuevo Precio: ");
        double pre = double.Parse(Console.ReadLine()!);
        _bodega.ActualizarProducto(cod, nom, pre);
        Console.ReadKey();
    }

    private void AgregarUsuarioUI()
    {
        Console.Clear();
        Console.WriteLine("--- REGISTRO DE USUARIO ---");
        Console.Write("Nombre de Usuario: "); string user = Console.ReadLine()!;
        Console.Write("Contraseña: "); string pass = Console.ReadLine()!;
    
        _auth.ListarRoles(); // Mostramos los roles para que elija
        Console.Write("Seleccione el ID del Rol: ");
        int rolId = int.Parse(Console.ReadLine()!);
        Rol? rolElegido = _auth.ObtenerRolPorId(rolId);

        if (rolElegido != null) {
            _auth.RegistrarUsuario(new Usuario(user, pass, rolElegido));
            Console.WriteLine("Usuario creado con exito.");
        } else {
            Console.WriteLine("Rol no valido. Registro cancelado.");
        }
        Console.ReadKey();
    }
    
    private void ActualizarUsuarioUI()
    {
        Console.Clear();
        _auth.ListarUsuarios();
        Console.Write("\nID del usuario a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Console.Write("Nuevo Nombre: "); string nom = Console.ReadLine()!;
            Console.Write("Nueva Pass: "); string pass = Console.ReadLine()!;
        
            _auth.ListarRoles();
            Console.Write("Nuevo Rol (ID): ");
            int rolId = int.Parse(Console.ReadLine()!);
            Rol? nuevoRol = _auth.ObtenerRolPorId(rolId);

            if (nuevoRol != null) {
                _auth.ActualizarUsuario(id, nom, pass, nuevoRol);
            } else {
                Console.WriteLine("Rol invalido.");
            }
        }
        Console.ReadKey();
    }

    private void EliminarUsuarioUI()
    {
        _auth.ListarUsuarios();
        Console.Write("\nIngrese el ID del usuario a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id))
            _auth.EliminarUsuario(id);
        Console.ReadKey();
    }

    private void InicializarDatos()
    {
        // 1. Roles y Permisos
        Permiso pCompra = new Permiso(1, "COMPRAR");
        Permiso pGestion = new Permiso(2, "GESTION_INVENTARIO");

        Rol adminRol = new Rol(1, "Administrador");
        _auth.RegistrarRol(adminRol);
        adminRol.AgregarPermiso(pCompra);
        adminRol.AgregarPermiso(pGestion);

        Rol clienteRol = new Rol(2, "Cliente");
        _auth.RegistrarRol(clienteRol);
        clienteRol.AgregarPermiso(pCompra);

        // 2. Usuarios: Un Admin y un Normal
        _auth.RegistrarUsuario(new Usuario("brandon", "123", adminRol));
        _auth.RegistrarUsuario(new Usuario("cliente", "456", clienteRol));

        // 3. Productos
        _bodega.AgregarProducto(new Producto("P01", "Audifonos Sony", 250), 10);
        _bodega.AgregarProducto(new Producto("P02", "Mouse Logitech", 120), 5);
    }
}