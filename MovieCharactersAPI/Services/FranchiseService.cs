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

        public async Task AddMoviesToFranchise(int id, List<int> moviesToAdd)
        {
            Franchise FranchiseToUpdateMovies = await _context.Franchises
                .Include(m => m.Movies)
                .Where(m => m.Id == id)
                .FirstAsync();

            foreach (var movieId in moviesToAdd)
            {
                Movie movie = await _context.Movies.FindAsync(movieId);
                if (movie == null)
                {
                    throw new MovieNotFoundException(movieId);
                }
                movie.FranchiseId = id;
            }
            //FranchiseToUpdateMovies.Movies = Movies;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.Include(x => x.Movies).FirstOrDefaultAsync(x => x.Id == id);

            if (franchise == null) { throw new FranchiseNotFoundException(id); }
            _ = franchise.Movies.Select(x => x.FranchiseId = null);

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Franchise>> GetAllFranchises()
        {
            return await _context.Franchises.ToListAsync();
        }

        public async Task<ICollection<Movie>> GetAllMoviesOfFranchises(int id)
        {
            var searchedFranchiseMovies = await _context.Movies
                .Where(x => x.FranchiseId == id).ToListAsync();


            if (searchedFranchiseMovies == null)
            {
                throw new FranchiseNotFoundException(id);
            }

            return searchedFranchiseMovies;
        }

        public async Task<ICollection<Character>> GetAllCharactersInAFranchises(int id)
        {

            List<Character> allChars = new List<Character>();
            var selectedMovieChars = await _context.Movies
                .Include(x => x.Characters)
                .Where(x => x.FranchiseId == id)
                .Select(x => x.Characters)
                .ToListAsync();

            foreach (var characterC in selectedMovieChars)
            {
                foreach (var chars in characterC)
                {
                    if (!allChars.Contains(chars))
                        allChars.Add(chars);
                }
            }

            if (allChars.Count == 0)
                throw new CharacterNotFoundException(id);

            return allChars;
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
