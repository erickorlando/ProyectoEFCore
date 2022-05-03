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

    [HttpGet("incluirtodo")]
    public async Task<IActionResult> GetPeliculas()
    {
        return Ok(await _service.GetAllInformacion());
    }
    
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllIncludeDeletes()
    {
        return Ok(await _service.GetAllIncludeDeleted());
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetPeliculasResumidas()
    {
        return Ok(await _service.GetPeliculasResumido());
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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] PeliculaBaseRequestDto request)
    {
        await _service.UpdateAsync(id, request);
        return Ok();
    }
    
    [HttpPut("datosadicionales/{id:int}")]
    public async Task<IActionResult> Put(int id, [FromBody] PeliculaDatosAdicionalesDto request)
    {
        await _service.UpdateAsync(id, request);
        return Ok();
    }


    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Patch(int id, [FromBody] PeliculaPatchDto request)
    {
        await _service.PatchAsync(id, request);
        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok();
    }
}