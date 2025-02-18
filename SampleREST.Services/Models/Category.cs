using SampleREST.Services.DAL;

namespace SampleREST.Services.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
