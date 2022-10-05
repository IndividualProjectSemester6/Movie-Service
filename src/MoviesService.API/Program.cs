using MoviesService.Application.Commands.CreateMovie;
using MoviesService.Application.Interfaces.Logic.Commands;
using MoviesService.Application.Interfaces.Queries;
using MoviesService.Application.Queries;
using MoviesService.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injections:
builder.Services.AddScoped<ICommandHandler<CreateMovie>, CreateMovieHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllMovies, IEnumerable<Movie>>, GetAllMoviesHandler>();

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
