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

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDto>>> GetFranchises()
        {
            return Ok(_mapper.Map<IEnumerable<FranchiseDto>>(await FranchiseService.GetAllFranchises()));
        }

        // GET: api/Franchises/5
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

        // Get All Movies in Franchise
        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<ICollection<MovieDto>>> GetAllMoviesOfFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<MovieDto>>(await FranchiseService.GetAllMoviesOfFranchises(id)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }
        // Get All Movies in Franchise
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<ICollection<CharacterDto>>> GetAllCharactersInAFranchise(int id)
        {
            try
            {
                return Ok(_mapper.Map<ICollection<CharacterDto>>(await FranchiseService.GetAllCharactersInAFranchises(id)));
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
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.UpdateFranchise(franchise)));
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
                return Ok(_mapper.Map<FranchiseDto>(await FranchiseService.AddMoviesToFranchise(id, moviesToAdd)));
            }
            catch (FranchiseNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        // POST: api/Franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FranchiseDto>> PostFranchise(Franchise franchise)
        {
            return CreatedAtAction("GetFranchise", new { id = franchise.Id }, _mapper.Map<FranchiseDto>(await FranchiseService.AddFranchise(franchise)));
        }

        // DELETE: api/Franchises/5
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
