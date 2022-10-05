using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Queries;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries
{
    public class GetAllMovies : IQuery<Movie>, IQuery<IEnumerable<Movie>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
