using Microsoft.EntityFrameworkCore;
using ProyectoEFCore.AccesoDatos;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services;

public class ProductoService : IProductoService
{
    private readonly CinePlexDbContext _dbContext;

    public ProductoService(CinePlexDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ICollection<Producto>> GetAllProductos()
    {
        return await _dbContext.Set<Producto>().ToListAsync();
    }

    public async Task<ICollection<ProductoServicio>> GetAllServicios()
    {
        return await _dbContext.Set<Producto>()
            .OfType<ProductoServicio>()
            .ToListAsync();
    }

    public async Task<ICollection<ProductoMerchandising>> GetAllMerchandising()
    {
        return await _dbContext.Set<Producto>()
            .OfType<ProductoMerchandising>()
            .ToListAsync();
    }
}