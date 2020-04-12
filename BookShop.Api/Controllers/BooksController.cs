using BookShop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShop.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop.Infrastructure.Data.Interfaces;
using BookShop.Infrastructure.Data.Specifications;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Genre> _genreRepository;

        public BooksController(IGenericRepository<Book> bookRepository, IGenericRepository<Genre> genreRepository)
        {
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {

            var specification = new BookWithGenreSpecification();
            var books = await _bookRepository.ListAllAsync(specification);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var specification = new BookWithGenreSpecification(id);
            var book = await _bookRepository.GetBySpecAsync(specification);
            return Ok(book);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
        {
            var genres = await _genreRepository.ListAllAsync();
            return Ok(genres);
        }
    }
}