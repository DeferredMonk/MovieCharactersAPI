using Microsoft.EntityFrameworkCore;

namespace MovieCharactersAPI.Models
{
    public class MoviesDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Character> Characters { get; set; }

        public MoviesDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>()
                .HasData(
                new Franchise
                {
                    Id = 1,
                    Name = "Marvel Cinematic Universe",
                    Description = "The Marvel Cinematic Universe (MCU) is an American media franchise."
                },
                new Franchise
                {
                    Id = 2,
                    Name = "Family Guy",
                    Description = "Funny cartoons for family."
                },
                new Franchise
                {
                    Id = 3,
                    Name = "The Simpsons",
                    Description = "Funny cartoons for family."
                });

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Harry Plopper and the bacon in the owen",
                    Genre = "Sci-fi, Fantasy, Food",
                    ReleaseYear = 2099,
                    Director = "Kristian Wink",
                    Picture = "https://static.simpsonswiki.com/images/archive/7/7a/20110905195950%21Plopper.png",
                    Trailer = "https://www.youtube.com/watch?v=MQBUfxrDN4Q&themeRefresh=1",
                    FranchiseId = 3
                },
                new Movie
                {
                    Id = 2,
                    Title = "Spider-Ham: Caught in a Ham",
                    Genre = "Sci-fi, Fantasy, Horror",
                    ReleaseYear = 2080,
                    Director = "Marco Angeli",
                    Picture = "https://static.wikia.nocookie.net/marveldatabase/images/f/f6/Spider-Ham_Vol_1_1_Textless.jpg/revision/latest/scale-to-width-down/1000?cb=20190911100619",
                    Trailer = "https://www.youtube.com/watch?v=MY15_rcd-IQ",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 3,
                    Title = "Spider-Ham 2: Revenge of the pork",
                    Genre = "Sci-fi, Fantasy, Horror",
                    ReleaseYear = 2081,
                    Director = "Marco Angeli",
                    Picture = "http://www.localhero.org.uk/wp-content/uploads/2011/06/ringohamblack.jpg",
                    Trailer = "https://www.youtube.com/watch?v=MY15_rcd-IQ",
                    FranchiseId = 1
                },
                new Movie
                {
                    Id = 4,
                    Title = "Family Guy: Star wars",
                    Genre = "Animation, Comedy",
                    ReleaseYear = 2080,
                    Director = "Greg Colton",
                    Picture = "https://www.wired.com/images_blogs/underwire/2009/12/familyguy_somethingsomethin.jpg",
                    Trailer = "https://www.imdb.com/video/vi4188209433/?playlistId=tt0888817&ref_=tt_pr_ov_vi",
                    FranchiseId = 2
                });

            modelBuilder.Entity<Character>().HasData(
                new Character
                {
                    Id = 1,
                    Name = "Peter Porker",
                    Alias = "Spider Ham",
                    Gender = "Pig",
                    Picture = "https://www.shutterstock.com/image-vector/cartoon-pig-thumb-up-vector-260nw-277426448.jpg",
                },
                new Character
                {
                    Id = 2,
                    Name = "Harry Porker",
                    Alias = "Harry Plopper",
                    Gender = "Pig",
                    Picture = "https://static.simpsonswiki.com/images/7/7a/Plopper.png",
                },
                new Character
                {
                    Id = 3,
                    Name = "Peter Griffin",
                    Alias = "Peter",
                    Gender = "Pig",
                    Picture = "https://static.wikia.nocookie.net/familyguy/images/a/aa/FamilyGuy_Single_PeterDrink_R7.jpg/revision/latest/scale-to-width-down/1000?cb=20200526171842",
                },
                new Character
                {
                    Id = 4,
                    Name = "Lois Griffin",
                    Alias = "Lois",
                    Gender = "Female",
                    Picture = "https://static.wikia.nocookie.net/familyguy/images/7/7c/FamilyGuy_Single_LoisPose_R7.jpg/revision/latest/scale-to-width-down/1000?cb=20200526171843",
                },
                new Character
                {
                    Id = 5,
                    Name = "Meg Griffin",
                    Alias = "Meg",
                    Gender = "Unknown",
                    Picture = "https://static.wikia.nocookie.net/familyguy/images/1/1b/FamilyGuy_Single_MegMakeup_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171840",
                },
                new Character
                {
                    Id = 6,
                    Name = "Chris Griffin",
                    Alias = "Chris",
                    Gender = "Male",
                    Picture = "https://static.wikia.nocookie.net/familyguy/images/e/ee/FamilyGuy_Single_ChrisText_R7.jpg/revision/latest/scale-to-width-down/350?cb=20200526171839",
                }
                );

            //MovieCharacter
            modelBuilder.Entity<Movie>()
               .HasMany(movie => movie.Characters)
               .WithMany(character => character.Movies)
               .UsingEntity<Dictionary<string, object>>(
                   "MovieCharacter",
                   l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                   r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                   je =>
                   {
                       je.HasKey("MovieId", "CharacterId");
                       je.HasData(
                           new { MovieId = 1, CharacterId = 2 },
                           new { MovieId = 2, CharacterId = 1 },
                           new { MovieId = 3, CharacterId = 1 },
                           new { MovieId = 4, CharacterId = 3 },
                           new { MovieId = 4, CharacterId = 4 },
                           new { MovieId = 4, CharacterId = 5 },
                           new { MovieId = 4, CharacterId = 6 }
                           );
                   }
               );

        }
    }
}
