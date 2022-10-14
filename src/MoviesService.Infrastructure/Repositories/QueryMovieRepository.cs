using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoviesService.Application.Interfaces.Repositories;
using MoviesService.Domain.Entities;

namespace MoviesService.Infrastructure.Repositories
{
    public class QueryMovieRepository : IQueryMovieRepository
    {
        private readonly MovieDbContext _context;

        public QueryMovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<MovieDto> Get(Guid id)
        {
            return await _context.Movies.FindAsync(id);
        }
    }
}
