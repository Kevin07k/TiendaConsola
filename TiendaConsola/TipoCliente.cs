using TiendaConsola.EstructuraDeDatos;

namespace TiendaConsola;

public class TipoCliente
{
    public String NombreTipo { get; set; }
    public TADVector<Descuento> Descuentos { get; set; }

    public TipoCliente(string nombreTipo)
    {
        NombreTipo = nombreTipo;
        Descuentos = new TADVector<Descuento>();
    }

    // Metodos

    public void AgregarDescuentos(double montoMin, double porcentajeDesc)
    {
        Descuento nuevoDescuento = new Descuento(montoMin, porcentajeDesc);
        Descuentos.AgregarElemento(nuevoDescuento);
    }

    public void QuitarDescuento(int pos)
    {
        Descuentos.EliminarElemento(pos);
    }

    public double AplicarDescuento(double subtotal)
    {
        foreach (var descuento in Descuentos)
        {
            if (descuento.MontoMin > subtotal)
            {
                subtotal *= (descuento.PorcentajeDescuento / 100);
            }
        }
        return  subtotal;
    }
}