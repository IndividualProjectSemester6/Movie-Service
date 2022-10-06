using Convey.CQRS.Queries;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries
{
    public class GetMovieHandler : IQueryHandler<GetMovieQuery, MovieDto>
    {
        private readonly IQueryMovieRepository _repository;

        public GetMovieHandler(IQueryMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDto> HandleAsync(GetMovieQuery query)
        {
            var movie = await _repository.Get(query.Id);
            return movie;
        }
    }
}
