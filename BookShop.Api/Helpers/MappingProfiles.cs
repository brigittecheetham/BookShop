using AutoMapper;
using BookShop.Api.Dtos;
using BookShop.Core.Entities;
using BookShop.Infrastructure.Data.Specifications;

namespace BookShop.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book,BookToReturnDto>()
            .ForMember(b => b.Genre, o => o.MapFrom(s => s.Genre.Name))
            .ForMember(b => b.PictureUrl, o => o.MapFrom<BookUrlResolver>());
            
            CreateMap<BooksRetrievalDto, BookSpecificationParameters>();
        }
    }
}