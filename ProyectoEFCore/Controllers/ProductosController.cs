using Microsoft.AspNetCore.Mvc;
using ProyectoEFCore.Services;

namespace ProyectoEFCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductos()
        {
            return Ok(await _service.GetAllProductos());
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductoServicios()
        {
            return Ok(await _service.GetAllServicios());
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProductoMerchandising()
        {
            return Ok(await _service.GetAllMerchandising());
        }
    }
}
