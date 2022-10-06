using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Application.Interfaces.Services;
using MoviesService.Application.Services;
using MoviesService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injections via Convey:
/*builder.Services.AddConvey()
    .AddCommandHandlers()
    .AddInMemoryCommandDispatcher()
    .AddQueryHandlers()
    .AddInMemoryQueryDispatcher(); */

// DI via MediatR
//builder.Services.AddMediatR(typeof(Program).Assembly);
//builder.Services.AddMediatR(typeof(IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>));
//builder.Services.AddScoped<IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>, GetAllMoviesHandler>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MockQueryMovieRepository>();

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
