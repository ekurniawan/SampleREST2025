using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(IProduct product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _product.GetAll();
            var productsDto = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return productsDto;
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(int id)
        {
            var product = await _product.GetById(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            return productDto;
        }

        [HttpPost]
        public async Task<ProductDTO> Post(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            var result = await _product.Add(product);
            var productDto = _mapper.Map<ProductDTO>(result);
            return productDto;
        }

        [HttpPut("{id}")]
        public async Task<ProductDTO> Put(int id, UpdateProductDTO updateProductDTO)
        {
            var product = _mapper.Map<Product>(updateProductDTO);

            var result = await _product.Update(product);

            var productWithCat = await _product.GetById(id);
            var productDto = _mapper.Map<ProductDTO>(productWithCat);
            return productDto;
        }

    }
}
