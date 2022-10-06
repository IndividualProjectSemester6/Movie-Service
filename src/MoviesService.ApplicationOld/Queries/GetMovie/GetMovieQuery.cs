using Convey.CQRS.Queries;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetMovie
{
    public class GetMovieQuery : IQuery<MovieDto>
    {
        public Guid Id { get; }

        public GetMovieQuery(Guid id)
        {
            Id = id;
        }
    }
}
