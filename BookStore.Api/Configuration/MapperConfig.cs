using AutoMapper;
using BookStore.Api.DTOS.Author;
using BookStore.Api.Models;

namespace BookStore.Api.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
        }
    }
}
