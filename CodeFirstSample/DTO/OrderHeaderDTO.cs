namespace CodeFirstSample.DTO
{
    public class OrderHeaderDTO
    {
        public int OrderHeaderId { get; set; }

        public DateTime TransactionDate { get; set; }

        public CustomerDTO Customer { get; set; } = null!;
    }
}
