using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Repositories
{
    public class MockCommandMovieRepository : ICommandMovieRepository
    {
        private readonly MockQueryMovieRepository _repository;

        public MockCommandMovieRepository()
        {
            _repository = new MockQueryMovieRepository();
        }
        public void CreateMovie(Movie movie)
        {
            _repository.MovieList.Add(movie);
        }
    }
}
