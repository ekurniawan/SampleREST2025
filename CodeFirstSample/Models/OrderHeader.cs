using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstSample.Models
{
    public class OrderHeader
    {
        public int OrderHeaderId { get; set; }

        public DateTime TransactionDate { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
