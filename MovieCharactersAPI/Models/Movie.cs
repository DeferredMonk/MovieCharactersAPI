using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(20)]
        public string Genre { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        [MaxLength(30)]
        public string Director { get; set; }
        [Required]
        [Url]
        public string Picture { get; set; }
        [Required]
        [Url]
        public string Trailer { get; set; }
        [Required]
        public ICollection<Character> Characters { get; set; }
        [Required]
        public Franchise FranchiseId { get; set; }
    }
}
