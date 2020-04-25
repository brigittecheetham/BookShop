using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Entities;
using BookShop.Infrastructure.Data.Specifications;

namespace BookShop.Infrastructure.Data.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        public Task<T> GetByIdAsync(int id);
        public Task<IReadOnlyList<T>> ListAllAsync();
        public Task<T> GetBySpecAsync(ISpecification<T> specification);
        public Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification);
        public Task<int> CountAsync(ISpecification<T> specification);
    }
}