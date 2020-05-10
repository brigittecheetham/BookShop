using AutoMapper;
using BookShop.Api.Dtos;
using BookShop.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace BookShop.Api.Helpers
{
    public class BookUrlResolver : IValueResolver<Book, BookToReturnDto, string>
    {
        private IConfiguration _configuration;
        public BookUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Book source, BookToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["ApiUrl"] + source.PictureUrl;

            return null;
        }
    }
}