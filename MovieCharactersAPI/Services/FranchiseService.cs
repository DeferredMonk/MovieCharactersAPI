using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly MoviesDbContext _context;
        public FranchiseService(MoviesDbContext context)
        {
            _context = context;
        }
        public async Task<Franchise> AddFranchise(Franchise Franchise)
        {
            _context.Franchises.Add(Franchise);
            await _context.SaveChangesAsync();

            return Franchise;
        }

        public Task DeleteFranchise(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return franchise;
        }

        public async Task<Franchise> UpdateFranchise(Franchise Franchise)
        {

            var searchedFranchise = await _context.Franchises.AnyAsync(x => x.Id == Franchise.Id);
            if (!searchedFranchise) throw new FranchiseNotFoundException(Franchise.Id);

            _context.Entry(Franchise).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Franchise;
        }
    }
}
