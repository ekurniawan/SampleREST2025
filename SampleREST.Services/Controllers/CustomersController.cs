﻿using Microsoft.AspNetCore.Http;
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
