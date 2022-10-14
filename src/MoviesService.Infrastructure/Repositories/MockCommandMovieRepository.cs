using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Repositories
{
    public class MockCommandMovieRepository : ICommandMovieRepository
    {
        private readonly MockQueryMovieRepository _repository;

        public MockCommandMovieRepository()
        {
            _repository = new MockQueryMovieRepository();
        }
        public async Task<MovieDto> CreateMovie(MovieDto movie)
        {
            _repository.MovieList.Add(movie);
            return movie;
        }
    }
}
