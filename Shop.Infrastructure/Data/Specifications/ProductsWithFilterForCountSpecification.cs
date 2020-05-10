using Shop.Core.Entities;

namespace Shop.Infrastructure.Data.Specifications
{
    public class ProductsWithFilterForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFilterForCountSpecification(ProductsSpecificationParameters productSpecificationParameters)  : base(x => 
        (string.IsNullOrEmpty(productSpecificationParameters.Search) || x.Name.Contains(productSpecificationParameters.Search)) &&
        (!productSpecificationParameters.CategoryId.HasValue || x.CategoryId == productSpecificationParameters.CategoryId))
        {

        }
    }
}

