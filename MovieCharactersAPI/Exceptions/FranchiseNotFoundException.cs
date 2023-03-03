namespace MovieCharactersAPI.Exceptions
{
    /// <summary>
    /// Custom exception for not finding a franchise based on Id.
    /// </summary>
    public class FranchiseNotFoundException : Exception
    {
        public FranchiseNotFoundException(int id) : base($"Franchise with id {id} doesn't exists.")
        {

        }
    }
}
