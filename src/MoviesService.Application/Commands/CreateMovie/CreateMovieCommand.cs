using System.Text.Json.Serialization;
using MediatR;
using MoviesService.Domain.Entities;


namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<MovieDto>
    {
        public string Name { get; }
        public string Description { get; }

        [JsonConstructor]
        public CreateMovieCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
