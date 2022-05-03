using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services;

public interface IProductoService
{
    Task<ICollection<Producto>> GetAllProductos();

    Task<ICollection<ProductoServicio>> GetAllServicios();

    Task<ICollection<ProductoMerchandising>> GetAllMerchandising();
}