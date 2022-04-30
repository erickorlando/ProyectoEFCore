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

        CreateMap<PeliculaBaseRequestDto, Pelicula>()
            .ForMember(dto => dto.NombrePelicula, ent => ent.MapFrom(p => p.NombrePelicula))
            .ForMember(dto => dto.PaisOrigen, ent => ent.MapFrom(p => p.PaisOrigen))
            .ForMember(dto => dto.FechaEstreno, ent => ent.MapFrom(p => p.FechaEstreno))
            .ForMember(dto => dto.Sinopsis, ent => ent.MapFrom(p => p.Sinopsis));

        CreateMap<PeliculaDatosAdicionalesDto, PeliculaDetalle>()
            .ForMember(p => p.NombreDirector, d => d.MapFrom(p => p.NombreDirector))
            .ForMember(p => p.NombreProductor, d => d.MapFrom(p => p.NombreProductor))
            .ForMember(p => p.FechaInicioRodaje, d => d.MapFrom(p => Convert.ToDateTime(p.FechaInicioRodaje)))
            .ForMember(p => p.FechaFinRodaje, d => d.MapFrom(p => Convert.ToDateTime(p.FechaFinRodaje)))
            .ForMember(p => p.PresupuestoInicial, d => d.MapFrom(p => p.PresupuestoInicial));


        CreateMap<Pelicula, PeliculaInformacionDto>()
            .ForMember(p => p.NombrePelicula, x => x.MapFrom(p => p.NombrePelicula))
            .ForMember(p => p.FechaEstreno, x => x.MapFrom(p => p.FechaEstreno.ToLongDateString()))
            .ForMember(p => p.PresupuestoInicial, x => x.MapFrom(p => p.PeliculaDetalle.PresupuestoInicial))
            .ForMember(p => p.Sinopsis, x => x.MapFrom(p => p.Sinopsis))
            .ForMember(p => p.Generos, x => x.MapFrom(p => p.Generos.Select(j => j.NombreGenero)))
            .ForMember(p => p.Cines,
                x => x.MapFrom(p => p.CinePeliculas.Where(j => j.EnCartelera).Select(x => x.Cine.Nombre)));
    }
}