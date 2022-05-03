namespace ProyectoEFCore.Entidades;

public abstract class Producto : EntityBase
{
    public string Nombre { get; set; }
    public decimal PrecioUnitario { get; set; }
    public string CodigoSku { get; set; }
    public TipoProducto TipoProducto { get; set; }
}

public enum TipoProducto
{
    Servicio,
    Merchandising
}