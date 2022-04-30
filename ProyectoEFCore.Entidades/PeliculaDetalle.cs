using System.ComponentModel.DataAnnotations;

namespace ProyectoEFCore.Entidades;

public class PeliculaDetalle
{
    public int Id { get; set; }

    [Required]
    public string NombreDirector { get; set; }

    public string NombreProductor { get; set; }
    public DateTime FechaInicioRodaje { get; set; }
    public DateTime FechaFinRodaje { get; set; }
    public decimal PresupuestoInicial { get; set; }
    public Pelicula Pelicula { get; set; }
}