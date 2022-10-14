using MediatR;
using Microsoft.EntityFrameworkCore;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Infrastructure.Contexts;
using MoviesService.Infrastructure.Repositories;
using CommandsMediatR = MoviesService.Application.Commands;
using QueriesMediatR = MoviesService.Application.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injections via MediatR:
builder.Services.AddMediatR(new Type[]
{
    typeof(CommandsMediatR.CreateMovie.CreateMovieCommand),
    typeof(QueriesMediatR.GetAllMovies.GetAllMoviesQuery),
    typeof(QueriesMediatR.GetMovie.GetMovieQuery)
});

// Inject normal dependencies:
builder.Services.AddScoped<ICommandMovieRepository, CommandMovieRepository>();
builder.Services.AddScoped<IQueryMovieRepository, QueryMovieRepository>();

// Add Entity Framework for SQL to project:
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
    b => b.MigrationsAssembly("MoviesService.API"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
