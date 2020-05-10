using Shop.Core.Entities;

namespace Shop.Infrastructure.Data.Specifications
{
    public class ProductsWithGenreSpecification : BaseSpecification<Product>
    {
        public ProductsWithGenreSpecification(ProductsSpecificationParameters productSpecificationParameters)  : base(x => 
            (string.IsNullOrEmpty(productSpecificationParameters.Search) || x.Name.Contains(productSpecificationParameters.Search)) &&
            (!productSpecificationParameters.CategoryId.HasValue || x.CategoryId == productSpecificationParameters.CategoryId))
        {
            AddInclude(x => x.Category);
            ApplyPaging(productSpecificationParameters.PageIndex * productSpecificationParameters.PageSize, productSpecificationParameters.PageSize);

            if (string.IsNullOrEmpty(productSpecificationParameters.Sort))
                return;

            switch(productSpecificationParameters.Sort)
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

        public ProductsWithGenreSpecification(int id) : base(b => b.Id == id)
        {
            AddInclude(x => x.Category);
        }
    }
}