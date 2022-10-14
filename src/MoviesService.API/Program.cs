using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Infrastructure;
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

/*builder.Services.AddEntityFrameworkMySql().AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("WebApiDatabase"));
});*/

// Inject normal dependencies:
builder.Services.AddScoped<ICommandMovieRepository, CommandMovieRepository>();
builder.Services.AddScoped<IQueryMovieRepository, QueryMovieRepository>();

// Add Entity Framework for MySQL to project:
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
    b => b.MigrationsAssembly("MoviesService.API"))
);

//builder.Services.AddDbContext<MovieDbContext>(options => options.UseMySQL(configuration.GetConnectionString("WebApiDatabase"), 
//b => b.MigrationsAssembly("MoviesService.API")));
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

// Replace 'YourDbContext' with the name of your own DbContext derived class.
//builder.Services.AddDbContext<MovieDbContext>(
    //dbContextOptions => dbContextOptions
        //.UseMySQL(configuration.GetConnectionString("WebApiDatabase"), b => b.MigrationsAssembly("MoviesService.API")));



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
