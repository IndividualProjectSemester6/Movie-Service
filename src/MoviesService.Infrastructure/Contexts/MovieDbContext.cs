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
                new MovieDto() {Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Name = "Star Wars VI: Return of the Jedi", Description = "A Star Wars movie"},
                new MovieDto() {Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Name = "Dune", Description = "A Dune movie"},
                new MovieDto() {Id = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Name = "Harry Potter & The Deathly Hallows Part 1", Description = "A Harry Potter movie"}
                );
        }

        public DbSet<MovieDto> Movies { get; set; }
    }
}
