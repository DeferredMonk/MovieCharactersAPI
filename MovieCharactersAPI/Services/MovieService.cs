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

        public async Task<Movie> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new MovieNotFoundException(id);
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
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
            if (!searchedMovie)
            {
                throw new MovieNotFoundException(movie.Id);
            }

            await _context.SaveChangesAsync();
            return movie;
        }
    }
}
