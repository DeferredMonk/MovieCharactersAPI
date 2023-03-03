using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;
using MovieCharactersAPI.Services;
using System.Net.Mime;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(await _movieService.GetAllMovies()));
        }
        // Get All Characters in Movie
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<ICollection<Character>>> GetAllCharactersInAMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<Character>>(await _movieService.GetAllCharactersInAMovies(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.GetMovieById(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message});
            }
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.UpdateMovie(movie))); //kesken
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> AddCharactersToMovie(int id, List<int> characters)
        {
            //try
            //{
            //    await _movieService.AddCharactersToMovie(id, characters);
            //}
            //catch (MovieNotFoundException ex)
            //{
            //    return NotFound(new ProblemDetails
            //    {
            //        Detail = ex.Message,
            //    });
            //}
            //catch (CharacterNotFoundException ex)
            //{
            //    return NotFound(new ProblemDetails
            //    {
            //        Detail = ex.Message,
            //    });
            //}

            //return Ok();
            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.AddCharactersToMovie(id, characters)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            return CreatedAtAction("GetMovie", new { id = movie.Id }, _mapper.Map<MovieDto>(await _movieService.AddMovie(movie)));
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.DeleteMovie(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }
    }
}
