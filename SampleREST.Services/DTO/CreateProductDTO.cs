namespace SampleREST.Services.DTO
{
    public class CreateProductDTO
    {
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
