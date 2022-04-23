using AutoMapper;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services.Profiles;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Preparar el Map para el ProjectTo

        //CreateMap<Pelicula, PeliculaSingularDto>();
        
        // Preparar el Map mas personalizado
        CreateMap<Pelicula, PeliculaSingularDto>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(p => p.Id))
            .ForMember(dto => dto.Nombre, ent => ent.MapFrom(p => p.NombrePelicula))
            .ForMember(dto => dto.Estreno, ent => ent.MapFrom(p => p.FechaEstreno.ToShortDateString()));


        CreateMap<Ticket, TicketDto>()
            .ForMember(dto => dto.Cliente, ent => ent.MapFrom(p => p.Cliente))
            .ForMember(dto => dto.CantidadEntradas, ent => ent.MapFrom(p => p.Cantidad))
            .ForMember(dto => dto.FechaVenta, ent => ent.MapFrom(p => p.FechaVenta))
            .ForMember(dto => dto.VentaTotal, ent => ent.MapFrom(p => p.PrecioTotal))
            .ForMember(dto => dto.IdCine, ent => ent.MapFrom(p => p.CineFk))
            .ForMember(dto => dto.IdPelicula, ent => ent.MapFrom(p => p.PeliculaIdFk))
            .ReverseMap();

        CreateMap<Ticket, TicketResponseDto>()
            .ForMember(dto => dto.Id, ent => ent.MapFrom(p => p.Id))
            .ForMember(dto => dto.NumeroFactura, ent => ent.MapFrom(p => p.NumeroFactura))
            .ForMember(dto => dto.FechaVenta, ent => ent.MapFrom(p => p.FechaVenta.ToString("yyyy-MM-dd")))
            .ForMember(dto => dto.Total, ent => ent.MapFrom(p => p.PrecioTotal))
            .ForMember(dto => dto.NombrePelicula, ent => ent.MapFrom(p => p.Pelicula.NombrePelicula ?? string.Empty))
            .ForMember(dto => dto.NombreCine, ent => ent.MapFrom(p => p.Cine.Nombre));

        CreateMap<TicketInfo, TicketResponseDto>();
    }
}