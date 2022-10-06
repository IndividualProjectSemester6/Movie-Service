using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Interfaces.Services
{
    public interface IMovieService : IService<MovieDto>
    {
    }
}
