﻿using Microsoft.EntityFrameworkCore;
using ProyectoEFCore.AccesoDatos;
using ProyectoEFCore.Dto.Request;
using ProyectoEFCore.Dto.Response;
using ProyectoEFCore.Entidades;

namespace ProyectoEFCore.Services
{
    public class PeliculaService : IPeliculaService
    {
        private readonly CinePlexDbContext _context;

        public PeliculaService(CinePlexDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Pelicula>> GetAll()
        {
            return await _context.Set<Pelicula>()
                //.AsTracking() // Sobreescribe la configuracion inicial
                //.Where(p => p.Status) // Ya lo puse en el QueryFilter
                .ToListAsync();
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