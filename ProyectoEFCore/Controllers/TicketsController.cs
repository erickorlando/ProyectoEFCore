using Microsoft.AspNetCore.Mvc;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Services;

namespace ProyectoEFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketsController(ITicketService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(string fechaInicio, string fechaFin)
    {
        return Ok(_service.ListAsync(fechaInicio, fechaFin));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TicketDto request)
    {
        return Ok(await _service.CreateAsync(request));
    }
}