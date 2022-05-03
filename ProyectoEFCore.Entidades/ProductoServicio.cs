namespace ProyectoEFCore.Entidades;

public class ProductoServicio : Producto
{
    public string Observaciones { get; set; }

    public DateTime? FechaServicio { get; set; }
}