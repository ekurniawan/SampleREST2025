using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.DAL;
using SampleREST.Services.Models;


namespace SampleREST.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return _employee.GetAll();
        }

        [HttpGet("ByName")]
        public IEnumerable<Employee> GetByName(string name, string city)
        {
            return _employee.GetByName(name, city);
        }


        [HttpGet("{id}")]
        public Employee GetEmployee(string id)
        {
            return _employee.GetEmployee(id);
        }

        //HTTP POST
        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _employee.Insert(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            try
            {
                _employee.Update(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _employee.Delete(id);
                return Ok("Employee deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
