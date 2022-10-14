using MoviesService.Domain.Entities;

namespace MoviesService.Application.Interfaces.Repositories
{
    public interface ICommandMovieRepository
    {
        Task<MovieDto> CreateMovie(MovieDto movie);
        Task<MovieDto> DeleteMovie(Guid id);
    }
}
