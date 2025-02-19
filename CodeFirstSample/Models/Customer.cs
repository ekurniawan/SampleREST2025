using System.ComponentModel.DataAnnotations;

namespace CodeFirstSample.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<OrderHeader> OrderHeaders { get; set; } = new List<OrderHeader>();
    }
}
