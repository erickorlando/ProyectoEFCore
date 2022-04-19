using Microsoft.EntityFrameworkCore;
using ProyectoEFCore.AccesoDatos;
using ProyectoEFCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CinePlexDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CinePlex"));
    options.LogTo(Console.WriteLine);
    
    // OJO: SOLO USARSE EN DESARROLLO
    options.EnableSensitiveDataLogging(); // Que se muestren los parametros.

    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddTransient<IPeliculaService, PeliculaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
