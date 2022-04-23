using System.ComponentModel.DataAnnotations;

namespace ProyectoEFCore.Dto.Request;

public class TicketDto
{
    [Required]
    public string Cliente { get; set; }

    [RegularExpression("^(19|20)\\d\\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$")]
    public string FechaVenta { get; set; }

    public string HoraVenta { get; set; }

    public int CantidadEntradas { get; set; }

    public decimal VentaTotal { get; set; }

    public int IdCine { get; set; }

    public int IdPelicula { get; set; }
}