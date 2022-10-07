using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Repositories
{
    public class MockQueryMovieRepository : IQueryMovieRepository
    {

        public List<MovieDto> MovieList { get; set; }

        public MockQueryMovieRepository()
        {
            MovieList = new List<MovieDto>()
            {
                new MovieDto()
                {
                    Id = new Guid("93a87c60-7e94-48e9-8bec-5a23b81f8631"),
                    Name = "Star Wars VI: Return of the Jedi",
                    Description = "Star Wars"
                },
                new MovieDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Dune",
                    Description = "Dune"
                },
                new MovieDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Justice League",
                    Description = "Justice League"
                }
            };
        }

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            return MovieList;
        }

        public async Task<MovieDto> Get(Guid id)
        {
            MovieDto movie = null;
            foreach (var m in MovieList)
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
