using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MoviesService.Domain.Entities;

namespace MoviesService.Application.Queries.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<List<MovieDto>>
    {
    }
}
