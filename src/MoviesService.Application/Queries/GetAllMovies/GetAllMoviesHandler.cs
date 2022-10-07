using MediatR;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetAllMovies
{
    public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDto>>
    {
        private readonly IQueryMovieRepository _repository;

        public GetAllMoviesHandler(IQueryMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<MovieDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movieList = await _repository.GetAll();
            return movieList;
        }
    }
}
