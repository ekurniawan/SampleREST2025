using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstSample.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Stock { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
