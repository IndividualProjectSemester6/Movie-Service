using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Logic.Commands;

namespace MoviesService.Application.Commands.CreateMovie
{
    public class CreateMovie : ICommand
    {
        public string Name { get; }

        public string Description { get; }

        [JsonConstructor]
        public CreateMovie(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
