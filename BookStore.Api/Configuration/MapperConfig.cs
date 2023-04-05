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
            CreateMap<AuthorReadOnlyDTO, Author>().ReverseMap();
            CreateMap<AuthorCreateDTO, Author>().ReverseMap();
            CreateMap<AuthorUpdateDTO, Author>().ReverseMap();
            CreateMap<BookCreateDTO, Book>().ReverseMap();
            CreateMap<BookUpdateDTO, Book>().ReverseMap();

            //Mapping from Book to get author's name
            CreateMap<Book, BookReadOnlyDTO>()
                .ForMember(a => a.AuthorName, 
                           b => b.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();

            //Mapping from Book to get author's name
            CreateMap<Book, BookDetailsDTO>()
                .ForMember(a => a.AuthorName,
                           b => b.MapFrom(map => $"{map.Author.FirstName} {map.Author.LastName}"))
                .ReverseMap();
        }
    }
}
