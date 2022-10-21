using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesService.API.Models;
using MoviesService.Application.Commands.CreateMovie;
using MoviesService.Application.Commands.DeleteMovie;
using MoviesService.Application.Commands.UpdateMovie;
using MoviesService.Application.Queries.GetAllMovies;
using MoviesService.Application.Queries.GetMovie;
using MoviesService.Domain.Entities;

namespace MoviesService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all movies.
        /// </summary>
        /// <returns>A list of Movies</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAll()
        {
            var query = new GetAllMoviesQuery();
            var result = await _mediator.Send(query);
            List<Movie> movies = new List<Movie>();
            foreach (var movie in result)
            {
                movies.Add(new Movie(movie.Id, movie.Name, movie.Description));
            }

            return Ok(movies);
        }

        /// <summary>
        /// Retrieves a movie by ID.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>A Movie object</returns>
        [HttpGet("{movieId}")]
        public async Task<ActionResult<Movie>> Get(Guid movieId)
        {
            var result = await _mediator.Send(new GetMovieQuery(movieId));
            if (result != null)
            {
                var movie = new Movie() { Id = result.Id, Name = result.Name, Description = result.Description };
                return Ok(movie);
            }

            return NotFound();
        }

        /// <summary>
        /// Creates a movie entity.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns>HTTP Status Code 200 on success.</returns>
        [HttpPost]
        public async Task<ActionResult> Create(string name, string description)
        {
            Movie movie = new Movie(Guid.NewGuid(), name, description);
            var command = new CreateMovieCommand(movie.Id, movie.Name, movie.Description);
            var response = await _mediator.Send(command);
            if (response == null)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Updates movie entity
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Response object with the updated record</returns>
        [HttpPut]
        public async Task<ActionResult> Update(Movie movie)
        {
            var dto = new MovieDto() {Id = movie.Id, Name = movie.Name, Description = movie.Description};
            var command = new UpdateMovieCommand(dto);
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        /// <summary>
        /// Deletes a movie entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HTTP Status Code 200</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand(id);
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
