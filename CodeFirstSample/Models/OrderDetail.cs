using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstSample.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public string OrderHeaderId { get; set; } = null!;

        public int ProductId { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public virtual OrderHeader? OrderHeader { get; set; }

        public virtual Product? Product { get; set; }
    }
}
