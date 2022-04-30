using System.ComponentModel.DataAnnotations;

namespace ProyectoEFCore.Dto.Request;

// Esta clase la utilizaremos para el create.

public class PeliculaDto : PeliculaBaseRequestDto
{
    // Los generos se separan con comas
    [Required] 
    public string Generos { get; set; }
}