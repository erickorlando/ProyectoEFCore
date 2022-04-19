namespace ProyectoEFCore.Entidades;

public class Ticket : EntityBase
{
    public DateTime FechaVenta { get; set; }
    public string Cliente { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }

}