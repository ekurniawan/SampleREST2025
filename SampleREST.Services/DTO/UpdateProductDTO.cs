namespace SampleREST.Services.DTO
{
    public class UpdateProductDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
