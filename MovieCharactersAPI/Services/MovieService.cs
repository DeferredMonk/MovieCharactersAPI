using Microsoft.EntityFrameworkCore;
using MovieCharactersAPI.Exceptions;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly MoviesDbContext _context;

        public MovieService(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> AddCharactersToMovie(int id, List<int> CharsToAdd)
        {
            Movie MovieToUpdateChars = await _context.Movies
                .Include(c => c.Characters)
                .Where(c => c.Id == id)
                .FirstAsync();

            List<Character> Chars = new List<Character>();
            foreach (int charId in CharsToAdd)
            {
                Character character = await _context.Characters.FindAsync(charId);
                if (character == null)
                {
                    throw new CharacterNotFoundException(charId);
                }
                Chars.Add(character);
            }
            MovieToUpdateChars.Characters = Chars;
            await _context.SaveChangesAsync();

            return MovieToUpdateChars;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<ICollection<Character>> GetAllCharactersInAMovies(int id)
        {
            var selectedMovieChars = await _context.Movies
                .Include(x => x.Characters)
                .Where(x => x.Id == id)
                .Select(x => x.Characters)
                .SingleAsync();

            return selectedMovieChars;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }
            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var searchedMovie = await _context.Movies.AnyAsync(x => x.Id == movie.Id);
            if (!searchedMovie) { throw new MovieNotFoundException(movie.Id);}

            _context.Entry(movie).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
