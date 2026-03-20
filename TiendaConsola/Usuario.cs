namespace TiendaConsola;

public class Usuario
{
    private static int _contadorId = 1;

    public int Id { get; private set; }
    public string NombreUsuario { get; set; }
    public string Contrasena { get; set; }
    
    public Rol? Perfil { get; set; }

    public Usuario(string nombre, string contrasena, Rol rolAsignado)
    {
        Id = _contadorId++;
        NombreUsuario = nombre;
        Contrasena = contrasena;
        Perfil = rolAsignado;
    }

    public bool TienePermiso(string nombrePermiso)
    {
        if (Perfil == null) return false;
        return Perfil.TieneAccesoA(nombrePermiso);
    }
}