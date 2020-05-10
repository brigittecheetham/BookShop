using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Core.Entities;

namespace Shop.Infrastructure.Data.Interfaces
{
    public interface IGetProductsRepository
    {
        Task<Product> GetGetProductsByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetGetProductssAsync();
        Task<IReadOnlyList<Category>> GetGenres();
    }
}