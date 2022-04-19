namespace ProyectoEFCore.Entidades;

public class Sala : EntityBase
{
    public Cine Cine { get; set; }
    public int CineId { get; set; }
    public string NombreSala { get; set; }

    /// <summary>
    /// 0 = 2D, 1 = 3D, 2 = IMAX
    /// </summary>
    public EnumTipoSala TipoSala { get; set; }
}