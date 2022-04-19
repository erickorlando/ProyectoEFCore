namespace ProyectoEFCore.Entidades;

public class Genero : EntityBase
{
    public string NombreGenero { get; set; }
    public HashSet<Pelicula> Peliculas { get; set; }
}