namespace Report.Models
{
    public class Sale
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTimeOffset DateSale {  get; set; }
    }
}
