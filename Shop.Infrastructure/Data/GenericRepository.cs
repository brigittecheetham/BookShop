using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Core.Entities;
using Shop.Infrastructure.Data.Interfaces;
using Shop.Infrastructure.Data.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ShopContext _shopContext;

        public GenericRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _shopContext.Set<T>().FindAsync(id);
        }

        public Task<T> GetBySpecAsync(ISpecification<T> specification)
        {
            return ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _shopContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_shopContext.Set<T>().AsQueryable(), specification);
        }
    }
}