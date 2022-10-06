using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Application.Interfaces.Services;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _repository.GetAll();
            return movies;
        }

        public async Task<MovieDto> Get(Guid id)
        {
            var movie = await _repository.Get(id);
            return movie;
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Create(MovieDto entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(MovieDto entity)
        {
            throw new NotImplementedException();
        }
    }
}