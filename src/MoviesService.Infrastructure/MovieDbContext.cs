using Microsoft.EntityFrameworkCore;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) :
            base(options)
        {
        }

        public DbSet<MovieDto> Movies { get; set; }
    }
}
