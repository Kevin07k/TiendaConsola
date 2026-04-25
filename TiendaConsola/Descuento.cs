namespace TiendaConsola;

public class Descuento
{
    public double PorcentajeDescuento { get; set; }
    public double MontoMin { get; set; }

    public Descuento(double montoMin, double porcentajeDescuento)
    {
        PorcentajeDescuento = porcentajeDescuento;
        MontoMin = montoMin;
    }
}