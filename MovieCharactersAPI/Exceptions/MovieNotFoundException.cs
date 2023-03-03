namespace MovieCharactersAPI.Exceptions
{
    /// <summary>
    /// Custom exception for not finding a movie based on Id.
    /// </summary>
    public class MovieNotFoundException : Exception
    {
        public MovieNotFoundException(int id) : base($"Movie with id {id} doesn't exists.")
        {

        }
    }
}
