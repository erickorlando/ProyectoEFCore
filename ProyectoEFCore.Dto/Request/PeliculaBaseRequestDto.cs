using System.ComponentModel.DataAnnotations;

namespace ProyectoEFCore.Dto.Request;

public class PeliculaBaseRequestDto
{
    [Required]
    public string NombrePelicula { get; set; }

    [Required]
    public string PaisOrigen { get; set; }

    [Required]
    public string FechaEstreno { get; set; }

    [StringLength(1000)]
    public string Sinopsis { get; set; }
}