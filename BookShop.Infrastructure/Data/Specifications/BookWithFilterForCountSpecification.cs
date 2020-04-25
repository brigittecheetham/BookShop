using BookShop.Core.Entities;

namespace BookShop.Infrastructure.Data.Specifications
{
    public class BookWithFilterForCountSpecification : BaseSpecification<Book>
    {
        public BookWithFilterForCountSpecification(BookSpecificationParameters bookSpecificationParameters)  : base(x => 
        (string.IsNullOrEmpty(bookSpecificationParameters.Search) || x.Name.Contains(bookSpecificationParameters.Search)) &&
        (!bookSpecificationParameters.GenreId.HasValue || x.GenreId == bookSpecificationParameters.GenreId))
        {

        }
    }
}

