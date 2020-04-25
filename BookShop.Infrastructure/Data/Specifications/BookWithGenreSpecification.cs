using BookShop.Core.Entities;

namespace BookShop.Infrastructure.Data.Specifications
{
    public class BookWithGenreSpecification : BaseSpecification<Book>
    {
        public BookWithGenreSpecification(BookSpecificationParameters bookSpecificationParameters)  : base(x => 
            (string.IsNullOrEmpty(bookSpecificationParameters.Search) || x.Name.Contains(bookSpecificationParameters.Search)) &&
            (!bookSpecificationParameters.GenreId.HasValue || x.GenreId == bookSpecificationParameters.GenreId))
        {
            AddInclude(x => x.Genre);
            ApplyPaging(bookSpecificationParameters.PageIndex * bookSpecificationParameters.PageSize - 1, bookSpecificationParameters.PageSize);

            if (string.IsNullOrEmpty(bookSpecificationParameters.Sort))
                return;

            switch(bookSpecificationParameters.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                case "nameAsc":
                    AddOrderBy(n => n.Name);
                    break;
                case "nameDesc":
                    AddOrderByDescending(n => n.Name);
                    break;
            }
        }

        public BookWithGenreSpecification(int id) : base(b => b.Id == id)
        {
            AddInclude(x => x.Genre);
        }
    }
}