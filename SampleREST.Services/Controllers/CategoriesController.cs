using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.DAL;
using SampleREST.Services.Models;
using System.Formats.Tar;

namespace SampleREST.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _category;
        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = _category.GetAllCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public Category Get(int id)
        {
            var category = _category.GetCategoryById(id);
            return category;
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            try
            {
                var newCategory = _category.AddCategory(category);
                return CreatedAtAction(nameof(Get), new { id = newCategory.CategoryId }, newCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            try
            {
                if (id != category.CategoryId)
                {
                    return BadRequest("Category ID mismatch");
                }
                var updatedCategory = _category.UpdateCategory(category);
                return Ok(updatedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _category.DeleteCategory(id);
                return Ok("Category deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
