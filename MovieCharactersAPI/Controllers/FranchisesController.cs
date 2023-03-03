using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;
using MovieCharactersAPI.Services;
using System.Net.Mime;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class FranchisesController : ControllerBase
    {
        private readonly IFranchiseService FranchiseService;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService service, IMapper mapper)
        {
            FranchiseService = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchise resources
        /// </summary>
        /// <returns>List of franchises</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseDto>>(await FranchiseService.GetAllFranchises()));
        }

        /// <summary>
        /// Get a specific franchise based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <returns>A franchise resource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDto>> GetFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.GetFranchiseById(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Get all movies in the franchise
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <returns>List of movies related to franchise</returns>
        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<ICollection<Movie>>> GetAllMoviesOfFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<Movie>>(await FranchiseService.GetAllMoviesOfFranchises(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Get all characters related to franchise
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <returns>List of characters related franchise</returns>
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<ICollection<Character>>> GetAllCharactersInAFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<Character>>(await FranchiseService.GetAllCharactersInAFranchises(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Updates a specific franchise based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <param name="franchise">franchise entity</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.UpdateFranchise(franchise)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Creates movies to franchise
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <param name="moviesToAdd">List of movies to add</param>
        /// <returns></returns>
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> AddMoviesToFranchise(int id, List<int> moviesToAdd)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.AddMoviesToFranchise(id, moviesToAdd)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Creates a new franchise resource to database
        /// </summary>
        /// <param name="franchise">franchise entity</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, _mapper.Map<FranchiseDto>(await FranchiseService.AddFranchise(franchise)));
        }

        /// <summary>
        /// Deletes a franchise resource with unique identifier from database
        /// </summary>
        /// <param name="id">A unique identifier for a franchise resource</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.DeleteFranchise(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }
    }
}
