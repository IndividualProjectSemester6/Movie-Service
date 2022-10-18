using MediatR;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest<MovieDto>
    {
        public MovieDto ExistingMovie { get; }

        public UpdateMovieCommand(MovieDto existingMovie)
        {
            ExistingMovie = existingMovie;
        }
    }
}
