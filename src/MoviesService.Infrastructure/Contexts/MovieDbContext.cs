using Microsoft.EntityFrameworkCore;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Contexts
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieDto>().ToTable("Movies");

            modelBuilder.Entity<MovieDto>().HasData(
                new MovieDto() {Id = Guid.NewGuid(), Name = "Star Wars VI: Return of the Jedi", Description = "A Star Wars movie"},
                new MovieDto() {Id = Guid.NewGuid(), Name = "Dune", Description = "A Dune movie"},
                new MovieDto() {Id = Guid.NewGuid(), Name = "Harry Potter & The Deathly Hallows Part 1", Description = "A Harry Potter movie"}
                );
        }

        public DbSet<MovieDto> Movies { get; set; }
    }
}
