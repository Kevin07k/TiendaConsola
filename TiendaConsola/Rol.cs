using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class Rol
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    private TADVector<Permiso> _listaPermisos;

    public Rol(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
        _listaPermisos = new TADVector<Permiso>();
    }

    public void AgregarPermiso(Permiso p)
    {
        _listaPermisos.AgregarElemento(p);
    }

    public bool TieneAccesoA(string nombrePermiso)
    {
        foreach (var p in _listaPermisos)
        {
            if (p.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }
}