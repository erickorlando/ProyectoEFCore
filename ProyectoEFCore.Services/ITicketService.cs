using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services;

public interface ITicketService
{
    Task<BaseResponseGeneric<int>> CreateAsync(TicketDto request);

    BaseResponseGeneric<ICollection<TicketInfo>> ListAsync(string fechaInicio, string fechaFin);
}