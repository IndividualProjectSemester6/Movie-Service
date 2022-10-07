using MediatR;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<MovieDto>
    {
        public Guid Id { get; }

        public GetMovieQuery(Guid id)
        {
            Id = id;
        }
    }
}
