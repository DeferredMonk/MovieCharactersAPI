using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task<Movie> AddMovie(Movie movie);
        Task DeleteMovie(int id);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> AddCharactersToMovie(int id, List<int> CharsToAdd);
        Task<ICollection<Character>> GetAllCharactersInAMovies(int id);
    }
}
