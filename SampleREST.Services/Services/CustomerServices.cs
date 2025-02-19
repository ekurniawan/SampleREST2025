using Microsoft.EntityFrameworkCore;
using SampleREST.Services.ModelEF;

namespace SampleREST.Services.Services
{
    public class CustomerServices : ICustomer
    {
        private readonly RapidDbContext _rapidDbContext;

        public CustomerServices(RapidDbContext rapidDbContext)
        {
            _rapidDbContext = rapidDbContext;
        }

        public Task<Customer> Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var results = await _rapidDbContext.Customers.ToListAsync();
            return results;
        }

        public async Task<Customer> GetById(int id)
        {
            var result = await _rapidDbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == id);
            if (result == null)
            {
                throw new Exception("Customer not found");
            }
            return result;
        }

        public async Task<IEnumerable<Customer>> GetByName(string name)
        {
            var results = await _rapidDbContext.Customers.Where(x => x.CustomerName.Contains(name)).ToListAsync();
            return results;
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
