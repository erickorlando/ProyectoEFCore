using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services;

public interface IPeliculaService
{
    Task<ICollection<PeliculaSingularDto>> GetAll();

    Task<ICollection<PeliculaInformacionDto>> GetAllInformacion();

    Task<ICollection<Pelicula>> GetAllIncludeDeleted();
    Task<ICollection<PeliculaResponseDto>> Filter(string? nombrePelicula);

    Task<int> CreateAsync(PeliculaDto entity);

    Task DeleteAsync(int id);
    
    Task UpdateAsync(int id, PeliculaBaseRequestDto request);

    Task UpdateAsync(int id, PeliculaDatosAdicionalesDto request);
    
    Task PatchAsync(int id, PeliculaPatchDto request);

    Task<ICollection<PeliculaInfo>> GetPeliculasResumido();


}