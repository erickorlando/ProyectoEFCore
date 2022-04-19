using System.ComponentModel.DataAnnotations;

namespace ProyectoEFCore.Dto.Request;

public class PeliculaDto
{
    [Required]
    public string NombrePelicula { get; set; }
    
    [Required]
    public string PaisOrigen { get; set; }

    [Required] 
    public string FechaEstreno { get; set; }

    // Los generos se separan con comas
    [Required] 
    public string Generos { get; set; }
}