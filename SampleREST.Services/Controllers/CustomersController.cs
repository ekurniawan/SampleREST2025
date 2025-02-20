using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.ModelEF;
using SampleREST.Services.Services;

namespace SampleREST.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _customer;
        public CustomersController(ICustomer customer)
        {
            _customer = customer;
        }

        [Authorize(Roles = "readonlyuser,admin")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customer.GetAll();
        }

        [Authorize(Roles = "readonlyuser,admin")]
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _customer.GetById(id);
        }

        [HttpGet("name/{name}")]
        public async Task<IEnumerable<Customer>> Get(string name)
        {
            return await _customer.GetByName(name);
        }
    }
}
