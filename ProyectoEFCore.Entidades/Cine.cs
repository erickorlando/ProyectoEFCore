namespace ProyectoEFCore.Entidades
{
    public class Cine : EntityBase
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public HashSet<Sala> Salas { get; set; }

        public HashSet<CinePeliculas> CinePeliculas { get; set; }
    }
}