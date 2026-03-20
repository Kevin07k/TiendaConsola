namespace TiendaConsola;

public class Permiso
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public Permiso(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }

    public override string ToString() => $"[{Id}] {Nombre}";
}