using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(30)]
        public int? FranchiseId { get; set; }
    }
}
