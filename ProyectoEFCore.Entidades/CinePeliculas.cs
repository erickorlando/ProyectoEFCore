namespace ProyectoEFCore.Entidades;

public class CinePeliculas
{
    public int Id { get; set; }
    public Cine Cine { get; set; }
    public int CineId { get; set; }
    public Pelicula Pelicula { get; set; }
    public int PeliculaId { get; set; }
    public bool EnCartelera { get; set; }

    public CinePeliculas()
    {
        EnCartelera = true;
    }
}