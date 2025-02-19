using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.ModelEF;
using SampleREST.Services.Services;

namespace SampleREST.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customer.GetAll();
        }
    }
}
