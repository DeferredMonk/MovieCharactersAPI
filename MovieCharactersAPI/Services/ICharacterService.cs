using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface ICharacterService
    {
        /// <summary>
        /// Gets all the characters listed in the characters table.
        /// </summary>
        /// <returns>An IEnumerable of all the characters.</returns>
        Task<IEnumerable<Character>> GetAllCharacters();
        /// <summary>
        /// Gets one character based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A character</returns>
        Task<Character> GetCharacterById(int id);
        /// <summary>
        /// Adds a character to the character table.
        /// </summary>
        /// <param name="character">The character to add</param>
        /// <returns>Added character</returns>
        Task<Character> AddCharacter(Character character);
        /// <summary>
        /// Deletes a character from the character table based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted character</returns>
        Task<Character> DeleteCharacter(int id);
        /// <summary>
        /// Updates the data of a character
        /// </summary>
        /// <param name="character"></param>
        /// <returns>The updated character</returns>
        Task<Character> UpdateCharacter(Character character);
    }
}
