using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesService.API.Models;

namespace MoviesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>A list of Movies</returns>
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves a movie by ID.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>A Movie object</returns>
        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> Get(Guid movieId)
        {
            throw new NotImplementedException();
        }
    }
}
