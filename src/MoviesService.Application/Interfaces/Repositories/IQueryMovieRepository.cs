using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Interfaces.Repositories
{
    public interface IQueryMovieRepository
    {
        Task<IEnumerable<MovieDto>> GetAll();
        Task<MovieDto> Get(Guid id);

    }
}
