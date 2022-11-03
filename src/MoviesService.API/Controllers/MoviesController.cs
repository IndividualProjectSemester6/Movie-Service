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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieViewModel>>> GetAll()
        {
            var query = new GetAllMoviesQuery();
            var result = await _mediator.Send(query);
            List<MovieViewModel> movies = new List<MovieViewModel>();
            foreach (var movie in result)
            {
                movies.Add(new MovieViewModel(movie.Id, movie.Name, movie.Description));
            }

            return Ok(movies);
        }

        /// <summary>
        /// Retrieves a movie by ID.
        /// </summary>
        /// <param name="movieId"></param>
        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieViewModel>> Get(Guid movieId)
        {
            var result = await _mediator.Send(new GetMovieQuery(movieId));
            if (result != null)
            {
                var movie = new MovieViewModel() { Id = result.Id, Name = result.Name, Description = result.Description };
                return Ok(movie);
            }

            return NotFound();
        }

        /// <summary>
        /// Creates movie entity.
        /// </summary>
        /// <param name="movie"></param>
        [HttpPost]
        public async Task<ActionResult> Create(CreateMovieViewModel movie)
        {
            Console.WriteLine(movie.Name, movie.Description);
            var command = new CreateMovieCommand(movie.Name, movie.Description);
            var response = await _mediator.Send(command);
            if (response == null)
                return BadRequest();

            return Ok();
        }

        /// <summary>
        /// Updates movie entity.
        /// </summary>
        /// <param name="movie"></param>
        [HttpPut]
        public async Task<ActionResult> Update(MovieViewModel movie)
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
        /// Deletes a movie entity.
        /// </summary>
        /// <param name="movieId"></param>
        [HttpDelete("{movieId}")]
        public async Task<ActionResult> Delete(Guid movieId)
        {
            var command = new DeleteMovieCommand(movieId);
            var response = await _mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
