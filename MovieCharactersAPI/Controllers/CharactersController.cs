
﻿using AutoMapper;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;
        public CharactersController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all character resources from database
        /// </summary>
        /// <returns>List of characters</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<CharacterDto>>(await _characterService.GetAllCharacters()));
        }

        /// <summary>
        /// Get a specific character based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a character resource</param>
        /// <returns>A character resource</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterDto>(await _characterService.GetCharacterById(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Updates a specific character based on a unique identifier 
        /// </summary>
        /// <param name="id">A unique identifier for a character resource</param>
        /// <param name="character">Character entity</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }
            try
            {
                return Ok(_mapper.Map<CharacterDto>(await _characterService.UpdateCharacter(character)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }

        /// <summary>
        /// Creates a new character resource to database
        /// </summary>
        /// <param name="character">Character entity</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CharacterDto>> PostCharacter(Character character)
        {
            return CreatedAtAction("GetCharacter", new { id = character.Id }, _mapper.Map<CharacterDto>(await _characterService.AddCharacter(character)));
        }

        /// <summary>
        /// Deletes a character resource with unique identifier from database
        /// </summary>
        /// <param name="id">A unique identifier for a character resource</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterDto>(await _characterService.DeleteCharacter(id)));
            }
            catch (CharacterNotFoundException ex)
            {
                return NotFound(new ProblemDetails { Detail = ex.Message });
            }
        }
    }
}
