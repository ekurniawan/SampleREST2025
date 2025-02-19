using SampleREST.Services.ModelEF;

namespace SampleREST.Services.Services
{
    public interface IProduct : ICrud<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(int categoryId);
        Task<IEnumerable<Product>> GetByName(string name);
    }
}
