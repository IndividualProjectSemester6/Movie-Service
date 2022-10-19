using MediatR;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.UpdateMovie
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, MovieDto>
    {
        private readonly ICommandMovieRepository _repository;

        public UpdateMovieHandler(ICommandMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDto> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
        {
            return await _repository.UpdateMovie(command.ExistingMovie);
        }
    }
}
