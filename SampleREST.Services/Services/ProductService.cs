using Microsoft.EntityFrameworkCore;
using SampleREST.Services.ModelEF;

namespace SampleREST.Services.Services
{
    public class ProductService : IProduct
    {
        private readonly RapidDbContext _rapidDbContext;
        public ProductService(RapidDbContext rapidDbContext)
        {
            _rapidDbContext = rapidDbContext;
        }

        public async Task<Product> Add(Product entity)
        {
            try
            {
                var result = await _rapidDbContext.Products.AddAsync(entity);
                await _rapidDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            //get products with category
            var results = await _rapidDbContext.Products.Include(x => x.Category).ToListAsync();
            return results;
        }

        public Task<IEnumerable<Product>> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetById(int id)
        {
            var result = await _rapidDbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ProductId == id);
            if (result == null)
            {
                throw new Exception("Product not found");
            }
            return result;
        }

        public Task<IEnumerable<Product>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
