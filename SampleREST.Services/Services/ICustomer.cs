using SampleREST.Services.ModelEF;

namespace SampleREST.Services.Services
{
    public interface ICustomer : ICrud<Customer>
    {
        Task<IEnumerable<Customer>> GetByName(string name);
    }
}
