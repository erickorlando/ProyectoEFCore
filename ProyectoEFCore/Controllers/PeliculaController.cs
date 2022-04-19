using Microsoft.AspNetCore.Mvc;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Services;

namespace ProyectoEFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeliculaController : ControllerBase
{
    private readonly IPeliculaService _service;

    public PeliculaController(IPeliculaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAll());
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllIncludeDeletes()
    {
        return Ok(await _service.GetAllIncludeDeleted());
    }

    [HttpGet]
    [Route("Filter")]
    public async Task<IActionResult> Filter(string? nombre)
    {
        return Ok(await _service.Filter(nombre));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PeliculaDto request)
    {
        var pelicula = await _service.CreateAsync(request);

        return Ok(new
        {
            Id = pelicula
        });
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}