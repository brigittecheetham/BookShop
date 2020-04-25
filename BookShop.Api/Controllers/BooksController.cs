using BookShop.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShop.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop.Infrastructure.Data.Interfaces;
using BookShop.Infrastructure.Data.Specifications;
using BookShop.Api.Dtos;
using AutoMapper;
using BookShop.Api.Errors;
using Microsoft.AspNetCore.Http;
using BookShop.Api.Helpers;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;
        private readonly IGenericRepository<Genre> _genreRepository;
        private readonly IMapper _mapper;

        public BooksController(IGenericRepository<Book> bookRepository,
            IGenericRepository<Genre> genreRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<BookToReturnDto>>> GetBooks([FromQuery]BooksRetrievalDto booksRetrievalDto)
        {
            var bookSpecificationParameters = _mapper.Map<BooksRetrievalDto, BookSpecificationParameters>(booksRetrievalDto);
            var specification = new BookWithGenreSpecification(bookSpecificationParameters);
            var countSpecification = new BookWithFilterForCountSpecification(bookSpecificationParameters);
            var totalItems = await _bookRepository.CountAsync(countSpecification);
            var books = await _bookRepository.ListAllAsync(specification);
            var booksToReturn = _mapper.Map<IReadOnlyList<Book>, IReadOnlyList<BookToReturnDto>>(books.ToList());
            return Ok(new Pagination<BookToReturnDto>(bookSpecificationParameters.PageIndex,bookSpecificationParameters.PageSize, totalItems, booksToReturn));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BookToReturnDto>> GetBook(int id)
        {
            var specification = new BookWithGenreSpecification(id);
            var book = await _bookRepository.GetBySpecAsync(specification);

            if (book == null)
                return NotFound(new ApiResponse(404));

            var bookToReturnDto = _mapper.Map<Book, BookToReturnDto>(book);
            return Ok(bookToReturnDto);
        }

        [HttpGet("genres")]
        public async Task<ActionResult<IReadOnlyList<Genre>>> GetGenres()
        {
            var genres = await _genreRepository.ListAllAsync();
            return Ok(genres);
        }
    }
}