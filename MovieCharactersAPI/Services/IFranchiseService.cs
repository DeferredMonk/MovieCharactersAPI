using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IFranchiseService
    {
        Task<IEnumerable<Franchise>> GetAllFranchises();
        Task<Franchise> GetFranchiseById(int id);
        Task<Franchise> AddFranchise(Franchise Franchise);
        Task DeleteFranchise(int id);
        Task<Franchise> UpdateFranchise(Franchise Franchise);
        Task AddMoviesToFranchise(int id, List<int> moviesToAdd);
        Task<ICollection<Movie>> GetAllMoviesOfFranchises(int id);
    }
}
