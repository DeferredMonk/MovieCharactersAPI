using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;

namespace MovieCharactersAPI.Profiles
{
    /// <summary>
    /// Profile to map FranchiseDto
    /// </summary>
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseDto>();
        }
    }
}
