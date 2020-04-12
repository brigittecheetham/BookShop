using BookShop.Core.Entities;

namespace BookShop.Infrastructure.Data.Specifications
{
    public class BookWithGenreSpecification : BaseSpecification<Book>
    {
        public BookWithGenreSpecification()
        {
            AddInclude(x => x.Genre);
        }

        public BookWithGenreSpecification(int id) : base(b => b.Id == id)
        {
            AddInclude(x => x.Genre);
        }
    }
}