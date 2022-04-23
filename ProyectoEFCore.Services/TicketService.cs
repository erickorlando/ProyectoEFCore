using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProyectoEFCore.AccesoDatos;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services;

public class TicketService : ITicketService
{
    private readonly CinePlexDbContext _context;
    private readonly IMapper _mapper;

    public TicketService(CinePlexDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<BaseResponseGeneric<int>> CreateAsync(TicketDto request)
    {
        var response = new BaseResponseGeneric<int>();

        var transaccion = await _context.Database.BeginTransactionAsync();

        try
        {
            var ticket = _mapper.Map<Ticket>(request);
            var cantidad = await _context.Set<Ticket>().CountAsync() + 1;

            ticket.FechaVenta = Convert.ToDateTime($"{request.FechaVenta} {request.HoraVenta}");
            ticket.NumeroFactura = $"F{cantidad:0000}";

            await _context.Set<Ticket>().AddAsync(ticket);

            await _context.SaveChangesAsync();
            await transaccion.CommitAsync();

            response.Resultado = ticket.Id;
            response.Success = true;
        }
        catch (DbUpdateException exception)
        {
            await transaccion.RollbackAsync();

            response.Success = false;
            response.Error = Utils.GetFriendlyMessage(exception);
        }

        return response;
    }

    public BaseResponseGeneric<ICollection<TicketInfo>> ListAsync(string fechaInicio, string fechaFin)
    {
        var response = new BaseResponseGeneric<ICollection<TicketInfo>>();

        try
        {


                var dateInit = Convert.ToDateTime(fechaInicio);
                var dateEnd = Convert.ToDateTime(fechaFin);

                //response.Resultado = await _context.Set<Ticket>()
                //        .Include(p => p.Cine)
                //        .Include(p => p.Pelicula)
                //        .Where(p => dateInit <= p.FechaVenta
                //                    && dateEnd >= p.FechaVenta)
                //        .Select(p => _mapper.Map<TicketResponseDto>(p))
                //        .ToListAsync();

                response.Resultado = _context.Set<TicketInfo>()
                    .FromSqlRaw("EXEC uspSelectTickets {0}, {1}", dateInit, dateEnd)
                    .ToList();

                response.Success = true;
        }
        catch (Exception ex)
        {
            response.Error = ex.Message;
            response.Success = false;
        }

        return response;
    }
}