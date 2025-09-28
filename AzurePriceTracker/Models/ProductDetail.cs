namespace AzurePriceTracker.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string ServiceFamily { get; set; }
        public string ServiceName { get; set; }
        public string ProductName { get; set; }
        public string SkuName { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Type { get; set; }
    }
}