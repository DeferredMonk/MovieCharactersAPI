using Microsoft.EntityFrameworkCore;

namespace MovieCharactersAPI.Models
{
    public class MoviesDbContext: DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Character> Characters { get; set; }

        public MoviesDbContext(DbContextOptions options): base(options)
        {

        }
        
    }
}
