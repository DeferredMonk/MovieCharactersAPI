using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(30)]
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        [MaxLength(30)]
        public string Director { get; set; }
        [Url]
        public string Picture { get; set; }
        [Url]
        public string Trailer { get; set; }
        public int? FranchiseId { get; set; }
        public ICollection<Character> Characters { get; set; }
        public Franchise Franchise { get; set; }

    }
}
