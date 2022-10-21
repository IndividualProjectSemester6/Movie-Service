using MediatR;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetMovie
{
    public class GetMovieHandler : IRequestHandler<GetMovieQuery, MovieDto?>
    {
        private readonly IQueryMovieRepository _repository;

        public GetMovieHandler(IQueryMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDto?> Handle(GetMovieQuery query, CancellationToken cancellationToken)
        {
            var movie = await _repository.Get(query.Id);
            return movie;
        }
    }
}
