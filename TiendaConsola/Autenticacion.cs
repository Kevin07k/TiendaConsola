using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class Autenticacion
{
    private TADVector<Usuario> _usuariosRegistrados = new TADVector<Usuario>();
    private TADVector<Rol> _rolesDisponibles = new TADVector<Rol>();
    
    public void RegistrarRol(Rol r) => _rolesDisponibles.AgregarElemento(r);
    public Usuario? UsuarioActual { get; private set; }

    public void RegistrarUsuario(Usuario u) => _usuariosRegistrados.AgregarElemento(u);
    
    public void ActualizarUsuario(int id, string nuevoNombre, string nuevaPass, Rol nuevoRol)
    {
        foreach (var u in _usuariosRegistrados)
        {
            if (u.Id == id)
            {
                u.NombreUsuario = nuevoNombre;
                u.Contrasena = nuevaPass;
                u.Perfil = nuevoRol;
                Console.WriteLine("Datos de usuario actualizados correctamente.");
                return;
            }
        }
        Console.WriteLine("Usuario no encontrado.");
    }
    
    public void ListarUsuarios()
    {
        Console.WriteLine("\n--- LISTA DE USUARIOS ---");
        foreach (var u in _usuariosRegistrados)
        {
            Console.WriteLine($"ID: {u.Id} | Usuario: {u.NombreUsuario} | Rol: {u.Perfil.Nombre}");
        }
    }

    public void EliminarUsuario(int id)
    {
        for (int i = 0; i < _usuariosRegistrados.Longitud; i++)
        {
            if (_usuariosRegistrados.ObtenerElemento(i).Id == id)
            {
                _usuariosRegistrados.EliminarElemento(i);
                Console.WriteLine("Usuario eliminado.");
                return;
            }
        }
        Console.WriteLine("Usuario no encontrado.");
    }
    
    public void ListarRoles()
    {
        Console.WriteLine("\n--- ROLES DISPONIBLES ---");
        foreach (var r in _rolesDisponibles)
        {
            Console.WriteLine($"ID: {r.Id} | Nombre: {r.Nombre}");
        }
    }
    
    public Rol? ObtenerRolPorId(int id)
    {
        foreach (var r in _rolesDisponibles)
        {
            if (r.Id == id) return r;
        }
        return null;
    }
    
    public bool Login(string nombre, string pass)
    {
        foreach (var u in _usuariosRegistrados)
        {
            if (u.NombreUsuario == nombre && u.Contrasena == pass)
            {
                UsuarioActual = u;
                return true;
            }
        }
        return false;
    }

    public void Logout()
    {
        UsuarioActual = null;
        Console.WriteLine("Sesión cerrada con éxito. ¡Volvé pronto!");
    }
}