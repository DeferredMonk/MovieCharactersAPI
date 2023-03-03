using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile: Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseDto>();
        }
    }
}
