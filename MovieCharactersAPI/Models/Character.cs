using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string? Alias { get; set; }
        [MaxLength(15)]
        public string Gender { get; set; }
        [Url]
        public string Picture { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
