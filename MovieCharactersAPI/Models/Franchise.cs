using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public class Franchise
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
