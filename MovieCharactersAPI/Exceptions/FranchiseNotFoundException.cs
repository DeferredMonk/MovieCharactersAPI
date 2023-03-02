namespace MovieCharactersAPI.Exceptions
{
    public class FranchiseNotFoundException : Exception
    {
        public FranchiseNotFoundException(int id) : base($"Franchise with id {id} doesn't exists.")
        {

        }
    }
}
