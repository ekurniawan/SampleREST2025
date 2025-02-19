using System.ComponentModel.DataAnnotations;

namespace CodeFirstSample.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
