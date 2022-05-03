namespace ProyectoEFCore.Entidades;

public class ProductoMerchandising : Producto
{
    public int CantidadSaldo { get; set; }
    public bool ConExistencias { get; set; }
    public string DescripcionPromocion { get; set; }
}