using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.DTO;
using SampleREST.Services.ModelEF;
using SampleREST.Services.Services;

namespace SampleREST.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _product;
        public ProductsController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _product.GetAll();
            var productsDto = products.Select(x => new ProductDTO
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Stock = x.Stock,
                Price = x.Price,
                Category = new CategoryDTO
                {
                    CategoryName = x.Category.CategoryName
                }
            });
            return productsDto;
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            var product = await _product.GetById(id);
            var productDto = new ProductDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Stock = product.Stock,
                Price = product.Price,
                Category = new CategoryDTO
                {
                    CategoryName = product.Category.CategoryName
                }
            };
            return productDto;
        }

        [HttpPost]
        public async Task<ProductDTO> Post(CreateProductDTO createProductDTO)
        {
            var product = new Product
            {
                ProductName = createProductDTO.ProductName,
                Stock = createProductDTO.Stock,
                Price = createProductDTO.Price,
                CategoryId = createProductDTO.CategoryId
            };
            var result = await _product.Add(product);
            var productDto = new ProductDTO
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                Stock = result.Stock,
                Price = result.Price,
            };
            return productDto;
        }

    }
}
