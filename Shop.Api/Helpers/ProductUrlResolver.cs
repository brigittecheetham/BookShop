using AutoMapper;
using Shop.Api.Dtos;
using Shop.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Shop.Api.Helpers
{
    public class ProductsUrlResolver : IValueResolver<Product, ProductsToReturnDto, string>
    {
        public ProductsUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductsToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["ApiUrl"] + source.PictureUrl;

            return null;
        }

        private IConfiguration _configuration;
    }
}