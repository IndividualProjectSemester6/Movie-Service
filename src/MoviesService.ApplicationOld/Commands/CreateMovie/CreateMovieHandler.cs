using Convey.CQRS.Commands;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovieHandler : ICommandHandler<CreateMovieCommand>
    {
        private readonly ICommandMovieRepository _repository;
        public CreateMovieHandler(ICommandMovieRepository repository)
        {
            _repository = repository;
        }

        public Task HandleAsync(CreateMovieCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var movie = new MovieDto() {Id = command.Id, Name = command.Name, Description = command.Description};
            _repository.CreateMovie(movie);
            return Task.CompletedTask;
        }
    }
}
