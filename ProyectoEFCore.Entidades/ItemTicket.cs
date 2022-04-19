namespace ProyectoEFCore.Entidades;

public class ItemTicket : EntityBase
{
    public Ticket Ticket { get; set; }
    public int TicketId { get; set; }
    public string NroAsiento { get; set; }
    public TipoAsiento TipoAsiento { get; set; }
    public decimal PrecioUnitario { get; set; }
}