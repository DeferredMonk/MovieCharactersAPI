using System.ComponentModel.DataAnnotations;

namespace MovieCharactersAPI.Models.Dtos
{
    public class FranchiseDto
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
