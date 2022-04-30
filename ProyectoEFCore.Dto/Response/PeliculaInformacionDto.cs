namespace ProyectoEFCore.Dto.Response;

public class PeliculaInformacionDto
{
    public string NombrePelicula { get; set; }
    public string FechaEstreno { get; set; }
    public decimal PresupuestoInicial { get; set; }
    public string Sinopsis { get; set; }
    public ICollection<string> Generos { get; set; }
    public ICollection<string> Cines { get; set; }
}