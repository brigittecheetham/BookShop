using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Shop.Core.Entities;
using System.Linq;
using System.Threading.Tasks;
using Shop.Infrastructure.Data.Interfaces;
using Shop.Infrastructure.Data.Specifications;
using Shop.Api.Dtos;
using AutoMapper;
using Shop.Api.Errors;
using Microsoft.AspNetCore.Http;
using Shop.Api.Helpers;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<Category> categoryRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductsToReturnDto>>> GetProducts([FromQuery]ProductsRetrievalDto productsRetrievalDto)
        {
            var productSpecificationParameters = _mapper.Map<ProductsRetrievalDto, ProductsSpecificationParameters>(productsRetrievalDto);
            var specification = new ProductsWithGenreSpecification(productSpecificationParameters);
            var countSpecification = new ProductsWithFilterForCountSpecification(productSpecificationParameters);
            var totalItems = await _productRepository.CountAsync(countSpecification);
            var GetProducts = await _productRepository.ListAllAsync(specification);
            var GetProductsToReturn = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDto>>(GetProducts.ToList());
            return Ok(new Pagination<ProductsToReturnDto>(productSpecificationParameters.PageIndex, productSpecificationParameters.PageSize, totalItems, GetProductsToReturn));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductsToReturnDto>> GetProducts(int id)
        {
            var specification = new ProductsWithGenreSpecification(id);
            var product = await _productRepository.GetBySpecAsync(specification);

            if (product == null)
                return NotFound(new ApiResponse(404));

            var GetProductsToReturnDto = _mapper.Map<Product, ProductsToReturnDto>(product);
            return Ok(GetProductsToReturnDto);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
        {
            var categories = await _categoryRepository.ListAllAsync();
            return Ok(categories);
        }
    }
}