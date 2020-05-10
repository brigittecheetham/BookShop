using AutoMapper;
using Shop.Api.Dtos;
using Shop.Core.Entities;
using Shop.Infrastructure.Data.Specifications;

namespace Shop.Api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductsToReturnDto>()
            .ForMember(b => b.Category, o => o.MapFrom(s => s.Category.Name))
            .ForMember(b => b.PictureUrl, o => o.MapFrom<ProductsUrlResolver>());
            
            CreateMap<ProductsRetrievalDto, ProductsSpecificationParameters>();
        }
    }
}