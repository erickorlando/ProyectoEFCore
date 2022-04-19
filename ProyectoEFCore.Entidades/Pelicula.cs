namespace ProyectoEFCore.Entidades;

public class Pelicula : EntityBase
{
    public string NombrePelicula { get; set; }
    public string PaisOrigen { get; set; }
    public DateTime FechaEstreno { get; set; }
    public HashSet<Genero> Generos { get; set; }

    public Pelicula()
    {
        Generos = new HashSet<Genero>();
    }
}