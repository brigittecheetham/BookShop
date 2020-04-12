using AutoMapper;
using BookShop.Api.Dtos;
using BookShop.Core.Entities;

namespace BookShop.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book,BookToReturnDto>()
            .ForMember(b => b.Genre, o => o.MapFrom(s => s.Genre.Name));
        }
    }
}