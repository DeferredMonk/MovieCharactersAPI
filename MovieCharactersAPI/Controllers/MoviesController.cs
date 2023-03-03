using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;
using MovieCharactersAPI.Models.DTOs;
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

        /// <summary>
        /// Get all movie resources
        /// </summary>
        /// <returns>List of movies</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(await _movieService.GetAllMovies()));
        }

        /// <summary>
        /// Get all characters in the movie
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <returns>List of characters in the movie</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<ICollection<CharacterDto>>> GetAllCharactersInAMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<CharacterDto>>(await _movieService.GetAllCharactersInAMovies(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Get a specific movie based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <returns>A movie resource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.GetMovieById(id)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Updates a specific movie based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <param name="movie">Movie entity</param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates characters to movie
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <param name="characters">List of characters</param>
        /// <returns></returns>
        [HttpPut("{id}/characters")]
        public async Task<IActionResult> AddCharactersToMovie(int id, List<int> characters)
        {
            try
            {
                return Ok(_mapper.Map<MovieDto>(await _movieService.AddCharactersToMovie(id, characters)));
            }
            catch (MovieNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Creates a new movie resource to database
        /// </summary>
        /// <param name="movie">Movie entity</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie(Movie movie)
        {
            return CreatedAtAction("GetMovie", new { id = movie.Id }, _mapper.Map<MovieDto>(await _movieService.AddMovie(movie)));
        }

        /// <summary>
        /// Deletes a movie resource with unique identifier from database
        /// </summary>
        /// <param name="id">A unique identifier for a movie resource</param>
        /// <returns></returns>
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
