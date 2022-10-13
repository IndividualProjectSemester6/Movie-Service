using MediatR;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<MovieDto>>
    {
    }
}
