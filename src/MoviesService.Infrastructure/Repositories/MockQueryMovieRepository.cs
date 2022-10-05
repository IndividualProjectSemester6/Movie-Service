using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Repositories
{
    public class MockQueryMovieRepository : IQueryMovieRepository
    {

        public List<Movie> MovieList { get; set; }

        public MockQueryMovieRepository()
        {
            MovieList = new List<Movie>()
            {
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Star Wars VI: Return of the Jedi",
                    Description = "Star Wars"
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dune",
                    Description = "Dune"
                },
                new Movie()
                {
                    Id = Guid.NewGuid(),
                    Name = "Justice League",
                    Description = "Justice League"
                }
            };
        }

        public IEnumerable<Movie> GetAll()
        {
            return MovieList;
        }

        public Movie Get(Guid id)
        {
            Movie movie = null;
            foreach (Movie m in MovieList)
            {
                if (m.Id == id)
                {
                    movie = m;
                }
            }

            return movie;
        }
    }
}
