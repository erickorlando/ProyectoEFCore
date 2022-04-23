using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoEFCore.Entidades;

public class Ticket : EntityBase
{
    public string NumeroFactura { get; set; }

    public DateTime FechaVenta { get; set; }
    
    public string Cliente { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioTotal { get; set; }
    
    public Cine Cine { get; set; }

    public int CineFk { get; set; }
    
    public Pelicula Pelicula { get; set; }

    public int? PeliculaIdFk { get; set; }
}