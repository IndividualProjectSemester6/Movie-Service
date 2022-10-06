
using Microsoft.AspNetCore.Mvc;
using MoviesService.API.Models;
using MoviesService.Application.Interfaces.Services;

namespace MoviesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>A list of Movies</returns>
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetAll()
        {
            List<Movie> result = new List<Movie>();
            //var movieList = await _mediator.Send(new GetAllMoviesQuery());
            var movieList = await _movieService.GetAll();
            foreach (var movie in movieList)
            {
                result.Add(new Movie(movie.Id, movie.Name, movie.Description));
            }

            return result;
        }

        
        /// <summary>
        /// Retrieves a movie by ID.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>A Movie object</returns>
        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> Get(Guid movieId)
        {
            //var result = await _qDispatcher.QueryAsync(new GetMovieQuery(movieId));
            var result = await _movieService.Get(movieId);
            var movie = new Movie() {Id = result.Id, Name = result.Name, Description = result.Description};

            return new OkObjectResult(movie);
        }

        /*
        [HttpPost]
        public async Task<ActionResult<Movie>> Create(string name, string description)
        {
            Movie movie = new Movie(Guid.NewGuid(), name, description);
            var cmc = new CreateMovieCommand(movie.Id, movie.Name, movie.Description);
            //var result = await _cDispatcher.SendAsync(cmc);
            return new OkResult();
        }*/


    }
}
