using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Services
{
    public interface IMovieService
    {
        /// <summary>
        /// Gets all the movies listed in the movies table.
        /// </summary>
        /// <returns>An IEnumerable of all the movies.</returns>
        Task<IEnumerable<Movie>> GetAllMovies();
        /// <summary>
        /// Gets one movie based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A movie</returns>
        Task<Movie> GetMovieById(int id);
        /// <summary>
        /// Adds a movie to the Movies table.
        /// </summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>Added movie</returns>
        Task<Movie> AddMovie(Movie movie);
        /// <summary>
        /// Deletes a mobie from the movie table based on ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted movie</returns>
        Task<Movie> DeleteMovie(int id);
        /// <summary>
        /// Updates the data of a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>The updated movie</returns>
        Task<Movie> UpdateMovie(Movie movie);
        /// <summary>
        /// Adds a characters and a movie to the linking table.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <param name="CharsToAdd">Character Id's to add to the movie</param>
        /// <returns>Movie that the characters have been added to</returns>
        Task<Movie> AddCharactersToMovie(int id, List<int> CharsToAdd);
        /// <summary>
        /// Gets all characters that participated in a certain movie.
        /// </summary>
        /// <param name="id">Id of the movie</param>
        /// <returns>ICollection of characters</returns>
        Task<ICollection<Character>> GetAllCharactersInAMovies(int id);
    }
}
