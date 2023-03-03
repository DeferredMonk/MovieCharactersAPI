using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IFranchiseService
    {
        /// <summary>
        /// Gets all the franchises listed in the franchises table.
        /// </summary>
        /// <returns>An IEnumerable of all the franchises.</returns>
        Task<IEnumerable<Franchise>> GetAllFranchises();
        /// <summary>
        /// Gets one franchise based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A franchise</returns>
        Task<Franchise> GetFranchiseById(int id);
        /// <summary>
        /// Adds a franchise to the franchise table.
        /// </summary>
        /// <param name="Franchise">The movie to add</param>
        /// <returns>Added franchise</returns>
        Task<Franchise> AddFranchise(Franchise Franchise);
        /// <summary>
        /// Deletes a franchise from the franchise table based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted franchise</returns>
        Task<Franchise> DeleteFranchise(int id);
        /// <summary>
        /// Updates the data of a franchise
        /// </summary>
        /// <param name="Franchise"></param>
        /// <returns>The updated franchise</returns>
        Task<Franchise> UpdateFranchise(Franchise Franchise);
        /// <summary>
        /// Adds movies to the franchise.
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <param name="moviesToAdd">Movies Id's to add to the franchise</param>
        /// <returns>franchise that the Movies have been added to</returns>
        Task<Franchise> AddMoviesToFranchise(int id, List<int> moviesToAdd);
        /// <summary>
        /// Gets all Movies that are part of a franchise.
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns>ICollection of movies</returns>
        Task<ICollection<Movie>> GetAllMoviesOfFranchises(int id);
        /// <summary>
        /// Gets all characters that participated in a certain franchise.
        /// </summary>
        /// <param name="id">Id of the franchise</param>
        /// <returns>ICollection of characters</returns>
        Task<ICollection<Character>> GetAllCharactersInAFranchises(int id);
    }
}
