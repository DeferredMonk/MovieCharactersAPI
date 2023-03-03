using Microsoft.AspNetCore.Mvc;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;
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

        public FranchisesController(IFranchiseService service)
        {
            FranchiseService = service;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(await FranchiseService.GetAllFranchises());
        }

        // GET: api/Franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            try
            {
                return await FranchiseService.GetFranchiseById(id);
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // Get All Movies in Franchise
        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<ICollection<Movie>>> GetAllMoviesOfFranchise(int id)
        {
            try
            {
                return Ok(await FranchiseService.GetAllMoviesOfFranchises(id));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }
        // Get All Movies in Franchise
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<ICollection<Character>>> GetAllCharactersInAFranchise(int id)
        {
            try
            {
                return Ok(await FranchiseService.GetAllCharactersInAFranchises(id));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(await FranchiseService.UpdateFranchise(franchise));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // PUT: api/Franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/movies")]
        public async Task<IActionResult> AddMoviesToFranchise(int id, List<int> moviesToAdd)
        {
            try
            {
                await FranchiseService.AddMoviesToFranchise(id, moviesToAdd);
                return Ok();
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, await FranchiseService.AddFranchise(franchise));
        }

        // DELETE: api/Franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            try
            {
                await FranchiseService.DeleteFranchise(id);

            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
            return Ok();
        }

    }
}

