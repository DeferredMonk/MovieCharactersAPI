namespace MovieCharactersAPI.Exceptions
{
    /// <summary>
    /// Custom exception for not finding a character based on Id.
    /// </summary>
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id) : base($"Character with id {id} doesn't exists.")
        {

        }
    }
}
