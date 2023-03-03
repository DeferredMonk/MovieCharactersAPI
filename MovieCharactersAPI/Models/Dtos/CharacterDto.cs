using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.Dtos
{
    public class CharacterDto
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string? Alias { get; set; }
    }
}
