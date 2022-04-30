namespace ProyectoEFCore.Dto.Request;

public class PeliculaDatosAdicionalesDto : PeliculaBaseRequestDto
{
    public string NombreDirector { get; set; }
    public string NombreProductor { get; set; }
    public string FechaInicioRodaje { get; set; }
    public string FechaFinRodaje { get; set; }
    public decimal PresupuestoInicial { get; set; }
}