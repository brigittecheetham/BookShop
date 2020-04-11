using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Core.Entities;
using BookShop.Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly ShopContext _shopContext;

        public BookRepository(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _shopContext.Books
            .Include(b => b.Genre)
            .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IReadOnlyList<Book>> GetBooksAsync()
        {
            return await _shopContext.Books
                .Include(b => b.Genre)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<Genre>> GetGenres()
        {
            return await _shopContext.Genres.ToListAsync();
        }
    }
}