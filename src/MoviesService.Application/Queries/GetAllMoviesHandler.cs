using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Application.Interfaces.Queries;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries
{
    public class GetAllMoviesHandler : IQueryHandler<GetAllMovies, IEnumerable<Movie>>
    {
        private readonly IQueryMovieRepository _repository;

        public GetAllMoviesHandler(IQueryMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Movie>> HandleAsync(GetAllMovies query)
        {
            var list = _repository.GetAll();
            return Task.FromResult(list);
        }
    }
}
