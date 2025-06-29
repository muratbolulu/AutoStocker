namespace AutoStocker.Infrastructure.Models
{
    public class FakeStoreProduct
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        //public Rate Rate { get; set; } = null;

        // Bunlar bizim sistemde ekleniyor
        public int Stock { get; set; } = 10;
        public int Threshold { get; set; } = 5;

    }

}
