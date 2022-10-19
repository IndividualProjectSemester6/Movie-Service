using MediatR;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.DeleteMovie
{
    public class DeleteMovieCommand : IRequest<MovieDto>
    {
        public Guid Id { get; set; }

        public DeleteMovieCommand(Guid id)
        {
            Id = id;
        }
    }
}
