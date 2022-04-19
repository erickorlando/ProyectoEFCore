namespace ProyectoEFCore.Dto.Response;

public class PeliculaResponseDto
{
    public string NombrePelicula { get; set; }
    public string FechaEstreno { get; set; }
    public ICollection<string> Generos { get; set; }
}