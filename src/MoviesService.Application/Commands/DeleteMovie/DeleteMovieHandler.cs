using MediatR;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.DeleteMovie
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand, MovieDto?>
    {
        private readonly ICommandMovieRepository _repository;

        public DeleteMovieHandler(ICommandMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDto?> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _repository.DeleteMovie(request.Id);
            return movie;
        }
    }
}
