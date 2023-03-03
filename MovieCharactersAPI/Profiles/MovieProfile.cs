using AutoMapper;
using MovieCharactersAPI.Models;
using MovieCharactersAPI.Models.Dtos;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
        }
    }
}
