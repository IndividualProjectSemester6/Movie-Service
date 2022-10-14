using System.Text.Json.Serialization;
using MediatR;
using MoviesService.Domain.Entities;


namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<MovieDto>
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public CreateMovieCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
