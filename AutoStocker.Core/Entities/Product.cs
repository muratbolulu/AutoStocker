namespace AutoStocker.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ProductCode { get; set; }
        public int Stock { get; set; }
        public int Threshold { get; set; }
        public decimal Price { get; set; }
    }
}
