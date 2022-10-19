using MediatR;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieDto>
    {
        private readonly ICommandMovieRepository _repository;
        public CreateMovieHandler(ICommandMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovieDto> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = new MovieDto() { Id = command.Id, Name = command.Name, Description = command.Description };
            var created = await _repository.CreateMovie(movie);

            return created;
        }
    }
}
