using AutoMapper;
using BookStore.Api.DTOS.Author;
using BookStore.Api.DTOS.Book;
using BookStore.Api.Models;

namespace BookStore.Api.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<AuthorReadOnlyDTO, Author>().ReverseMap();
            CreateMap<BookCreateDTO, Book>().ReverseMap();
        }
    }
}
