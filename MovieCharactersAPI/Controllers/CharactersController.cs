using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Services;

namespace MovieCharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharactersController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        GET: api/Characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            
        }

        //// PUT: api/Characters/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCharacter(int id, Character character)
        //{
        //    if (id != character.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(character).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CharacterExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Characters
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Character>> PostCharacter(Character character)
        //{
        //    _context.Characters.Add(character);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
        //}

        //// DELETE: api/Characters/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCharacter(int id)
        //{
        //    var character = await _context.Characters.FindAsync(id);
        //    if (character == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Characters.Remove(character);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
    }
}
