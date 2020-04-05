using BookShop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShop.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ShopContext _shopContext;

        public BooksController(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _shopContext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _shopContext.Books.FindAsync(id);
            return Ok(book);
        }
    }
}