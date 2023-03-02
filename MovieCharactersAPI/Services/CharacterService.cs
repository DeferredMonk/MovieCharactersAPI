using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly MoviesDbContext _context;
        public async Task<Character> AddCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCharacter(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Character>> GetAllCharacters()
        {
            return await _context.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null)
            {
                throw new Chara
            }

            return character;
        }

        public async Task<Character> UpdateCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
