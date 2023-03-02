namespace MovieCharactersAPI.Exceptions
{
    public class CharacterNotFoundException: Exception
    {
        public CharacterNotFoundException(int id) : base($"Character with id {id} doesn't exists.")
        {

        }
    }
}
