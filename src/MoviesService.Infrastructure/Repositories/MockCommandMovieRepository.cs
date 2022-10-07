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
        public void CreateMovie(MovieDto movie)
        {
            _repository.MovieList.Add(movie);
        }
    }
}
