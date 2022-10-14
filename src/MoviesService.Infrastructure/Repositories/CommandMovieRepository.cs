using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;
using MoviesService.Infrastructure.Contexts;
using Z.EntityFramework.Plus;

namespace MoviesService.Infrastructure.Repositories
{
    public class CommandMovieRepository : ICommandMovieRepository
    {
        private readonly MovieDbContext _context;

        public CommandMovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public async Task<MovieDto> CreateMovie(MovieDto movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<MovieDto> DeleteMovie(Guid id)
        {
            MovieDto movie = new MovieDto() { Id = id };
            await Task.WhenAll(_context.Movies.Where(m => m.Id == id).DeleteAsync(), _context.SaveChangesAsync());
            return movie;
        }
    }
}
