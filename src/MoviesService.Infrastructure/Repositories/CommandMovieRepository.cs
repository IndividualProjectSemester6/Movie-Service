using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

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
    }
}
