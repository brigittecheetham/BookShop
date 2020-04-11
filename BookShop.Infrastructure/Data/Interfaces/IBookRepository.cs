using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop.Core.Entities;

namespace BookShop.Infrastructure.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<IReadOnlyList<Book>> GetBooksAsync();
        Task<IReadOnlyList<Genre>> GetGenres();
    }
}