using Convey.CQRS.Commands;
using Convey.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using MoviesService.API.Models;
using MoviesService.Application.Commands.CreateMovie;
using MoviesService.Application.Queries;

namespace MoviesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IQueryDispatcher _qDispatcher;
        private readonly ICommandDispatcher _cDispatcher;

        public MoviesController(IQueryDispatcher qDispatcher, ICommandDispatcher cDispatcher)
        {
            _qDispatcher = qDispatcher;
            _cDispatcher = cDispatcher;
        }

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
            var result = await _qDispatcher.QueryAsync(new GetMovieQuery(movieId));
            var movie = new Movie() {Id = result.Id, Name = result.Name, Description = result.Description};

            return new OkObjectResult(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> Create(string name, string description)
        {
            Movie movie = new Movie(Guid.NewGuid(), name, description);
            var cmc = new CreateMovieCommand(movie.Id, movie.Name, movie.Description);
            //var result = await _cDispatcher.SendAsync(cmc);
            return new OkResult();
        }


    }
}
