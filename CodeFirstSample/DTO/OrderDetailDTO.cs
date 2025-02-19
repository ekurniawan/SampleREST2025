namespace CodeFirstSample.DTO
{
    public class OrderDetailDTO
    {
        public int OrderDetailId { get; set; }

        public int Qty { get; set; }

        public decimal Price { get; set; }

        public OrderHeaderDTO? OrderHeader { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
