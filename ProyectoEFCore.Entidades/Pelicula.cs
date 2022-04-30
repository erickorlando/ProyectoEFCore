namespace ProyectoEFCore.Entidades;

public class Pelicula : EntityBase
{
    public string NombrePelicula { get; set; }
    public string PaisOrigen { get; set; }
    public DateTime FechaEstreno { get; set; }
    public string? Sinopsis { get; set; }
    
    public HashSet<Genero> Generos { get; set; }
    
    public PeliculaDetalle PeliculaDetalle { get; set; }
    
    public HashSet<CinePeliculas> CinePeliculas { get; set; }
    
    public Pelicula()
    {
        Generos = new HashSet<Genero>();
        CinePeliculas = new HashSet<CinePeliculas>();
    }
}