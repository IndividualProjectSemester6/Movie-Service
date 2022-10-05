using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Logic.Commands;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovieHandler : ICommandHandler<CreateMovie>
    {
        private readonly ICommandMovieRepository _repository;
        public CreateMovieHandler(ICommandMovieRepository repository)
        {
            _repository = repository;
        }

        public Task HandleAsync(CreateMovie model)
        {
            if (model == null)
            {
                throw new Exception("Error, please create a movie.");
            }

            Movie movie = new Movie()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description
            };

            this._repository.CreateMovie(movie);
            return Task.CompletedTask;
        }
    }
}
