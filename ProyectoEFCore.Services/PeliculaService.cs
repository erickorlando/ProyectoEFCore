using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProyectoEFCore.AccesoDatos;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly CinePlexDbContext _context;
        private readonly IMapper _mapper;

        public PeliculaService(CinePlexDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<PeliculaSingularDto>> GetAll()
        {
            //return await _context.Set<Pelicula>()
            //    //.AsTracking() // Sobreescribe la configuracion inicial
            //    //.Where(p => p.Status) // Ya lo puse en el QueryFilter
            //    .ToListAsync();


            // Manera simple con AutoMapper
            //return await _context.Set<Pelicula>()
            //    .ProjectTo<PeliculaSingularDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync();

            // Manera compleja con AutoMapper
            return await _context.Set<Pelicula>()
                .Select(p => _mapper.Map<PeliculaSingularDto>(p))
                .ToListAsync();

        }

        public async Task<ICollection<PeliculaInformacionDto>> GetAllInformacion()
        {
            // Mostrar todas las peliculas con sus generos y sus cines que esten en cartelera.
            var query = _context.Set<Pelicula>()
                .Include(p => p.PeliculaDetalle)
                .Include(p => p.Generos)
                .Include(p => p.CinePeliculas)
                .ThenInclude(p => p.Cine)
                .Where(s => s.CinePeliculas
                    .Any(p => p.EnCartelera))
                .Select(p => _mapper.Map<PeliculaInformacionDto>(p));
                //.Select(p => new PeliculaInformacionDto
                //{
                //    NombrePelicula = p.NombrePelicula,
                //    FechaEstreno = p.FechaEstreno.ToLongDateString(),
                //    PresupuestoInicial = p.PeliculaDetalle.PresupuestoInicial,
                //    Sinopsis = p.Sinopsis,
                //    Cines = p.CinePeliculas.Where(j => j.EnCartelera).Select(x => x.Cine.Nombre).ToList(),
                //    Generos = p.Generos.Select(x => x.NombreGenero).ToList(),
                //});

            return await query.ToListAsync();

        }

        public async Task<ICollection<Pelicula>> GetAllIncludeDeleted()
        {
            return await _context.Set<Pelicula>()
                .IgnoreQueryFilters()
                .ToListAsync();
        }
        public async Task<ICollection<PeliculaResponseDto>> Filter(string? nombrePelicula)
        {
            var query = await _context.Set<Pelicula>()
                .Where(p => p.NombrePelicula.StartsWith(nombrePelicula ?? string.Empty))
                .OrderBy(p => p.NombrePelicula)
                .Select(p => new
                {
                    p.NombrePelicula,
                    p.FechaEstreno,
                    p.Generos
                })
                .ToListAsync();

            var response = new List<PeliculaResponseDto>();

            foreach (var item in query)
            {
                response.Add(new PeliculaResponseDto
                {
                    NombrePelicula = item.NombrePelicula,
                    FechaEstreno = item.FechaEstreno.ToShortDateString(),
                    Generos = new List<string>(item.Generos
                        .OrderBy(p => p.NombreGenero)
                        .Select(p => p.NombreGenero))
                });
            }

            return response;
        }

        public async Task<int> CreateAsync(PeliculaDto entity)
        {
            // Separemos los generos.
            var coleccionGeneros = entity.Generos.Split(',');
            var pelicula = new Pelicula();
            pelicula.NombrePelicula = entity.NombrePelicula;
            pelicula.PaisOrigen = entity.PaisOrigen;
            pelicula.FechaEstreno = Convert.ToDateTime(entity.FechaEstreno);

            foreach (var item in coleccionGeneros)
            {
                var objetoGenero = await _context.Set<Genero>()
                    .AsTracking()
                    .FirstOrDefaultAsync(p => p.NombreGenero == item);

                if (objetoGenero == null)
                {
                    var nuevoGenero = new Genero()
                    {
                        NombreGenero = item,
                        Status = true
                    };
                    await _context.Set<Genero>().AddAsync(nuevoGenero);
                    pelicula.Generos.Add(nuevoGenero);
                }
                else
                {
                    pelicula.Generos.Add(objetoGenero);
                }
            }

            // Se quita porque el Status deberia ser true por default.
            //pelicula.Status = true;

            await _context.Set<Pelicula>().AddAsync(pelicula);
            await _context.SaveChangesAsync();

            return pelicula.Id;
        }

        public async Task UpdateAsync(int id, PeliculaBaseRequestDto request)
        {
            // Modelo Conectado de EF Core.
            // Primero buscamos el registro que pretendemos actualizar.
            var pelicula = await _context.Set<Pelicula>()
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
                return;

            _mapper.Map(request, pelicula);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, PeliculaDatosAdicionalesDto request)
        {
            // Modelo Conectado de EF Core.
            // Primero buscamos el registro que pretendemos actualizar.
            var pelicula = await _context.Set<Pelicula>()
                .Include(p => p.PeliculaDetalle)
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null)
                return;

            _mapper.Map(request, pelicula);
            _mapper.Map(request, pelicula.PeliculaDetalle);

            await _context.SaveChangesAsync();
        }

        public async Task PatchAsync(int id, PeliculaPatchDto request)
        {
            var pelicula = await _context.Set<Pelicula>()
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula == null) return;

            foreach (var requestCine in request.Cines)
            {
                var cinePeliculas = new CinePeliculas
                {
                    Pelicula = pelicula,
                    CineId = requestCine
                };
                pelicula.CinePeliculas.Add(cinePeliculas);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Al buscar por llave primaria, se usa FindAsync
            var pelicula = await _context.Set<Pelicula>()
                .AsTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pelicula != null)
            {
                pelicula.Status = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}