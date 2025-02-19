using Microsoft.EntityFrameworkCore;
using SampleREST.Services.Models;

/*namespace SampleREST.Services.DAL
{
    public class CategoryEF : ICategory
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryEF(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Category AddCategory(Category category)
        {
            try
            {
                _applicationDbContext.Categories.Add(category);
                _applicationDbContext.SaveChanges();
                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                var result = GetCategoryById(id);
                if (result == null)
                {
                    throw new Exception("Category not found");
                }
                _applicationDbContext.Categories.Remove(result);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            //var categories = _applicationDbContext.Categories.OrderBy(c => c.Name).ToList();
            var categories = from c in _applicationDbContext.Categories.AsNoTracking()
                             orderby c.Name descending
                             select c;
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            //ef raw sql
            //var category = _applicationDbContext.Categories.FromSqlRaw("SELECT * FROM Categories WHERE CategoryId = {0}", id).FirstOrDefault();
            //ef raw sql sp
            //var category = _applicationDbContext.Categories.FromSqlRaw("EXEC GetCategoryById {0}", id).FirstOrDefault();

            //var category = _applicationDbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
            var category = (from c in _applicationDbContext.Categories
                            where c.CategoryId == id
                            select c).FirstOrDefault();

            if (category == null)
            {
                throw new Exception("Category not found");
            }
            return category;
        }

        public Category UpdateCategory(Category category)
        {
            try
            {
                var result = GetCategoryById(category.CategoryId);
                if (result == null)
                {
                    throw new Exception("Category not found");
                }

                result.Name = category.Name;
                result.Description = category.Description;
                _applicationDbContext.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}*/
