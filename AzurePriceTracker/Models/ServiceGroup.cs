namespace AzurePriceTracker.Models
{
    public class ServiceGroup
    {
        public int Id { get; set; }
        public string ServiceFamily { get; set; }
        public string ServiceName { get; set; }
        public int ProductCount { get; set; }
        public bool Expanded { get; set; }
    }
}