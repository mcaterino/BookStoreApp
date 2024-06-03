using AutoMapper;
using BookStore.Api.DTOS.Author;
using BookStore.Api.DTOS.AuthorBooks;
using BookStore.Api.DTOS.Book;
using BookStore.Api.DTOS.Publisher;
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
        CreateMap<Publisher, PublisherReadOnlyDTO>().ReverseMap();
        CreateMap<Publisher, PublisherCreateDTO>().ReverseMap();
        CreateMap<Publisher, PublisherUpdateDTO>().ReverseMap();


        //Mapping from Book to get the first author's name
        CreateMap<Book, BookReadOnlyDTO>()
          .ForMember(a => a.AuthorName, 
            b => b.MapFrom(map => $"{map.AuthorBooks.FirstOrDefault().Author.FirstName} {map.AuthorBooks.FirstOrDefault().Author.LastName}"))
          .ReverseMap();

        //Mapping from Book to get all author's names
        CreateMap<Book, BookDetailsDTO>()
          .ForMember(a => a.AuthorName,
            b => b.MapFrom(map => string.Join(", ", map.AuthorBooks.Select(ab => $"{ab.Author.FirstName} {ab.Author.LastName}"))))
          .ReverseMap();

        CreateMap<AuthorBook, AuthorBooksDTO>()
        .ForMember(ab => ab.AuthorId, map => map.MapFrom(ab => ab.Author.Id))
        .ForMember(ab => ab.AuthorName, map => map.MapFrom(ab => $"{ab.Author.FirstName} {ab.Author.LastName}"))
        .ForMember(ab => ab.BookId, map => map.MapFrom(ab => ab.Book.Id))
        .ForMember(ab => ab.BookTitle, map => map.MapFrom(ab => ab.Book.Title));
      }
    }
}