namespace ProyectoEFCore.Entidades;

public class TicketInfo
{
    public int Id { get; set; }
    public string NumeroFactura { get; set; }
    public string FechaVenta { get; set; }
    public decimal Total { get; set; }
    public string NombreCine { get; set; }
    public string NombrePelicula { get; set; }
}