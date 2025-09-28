namespace AzurePriceTracker.Models
{
    public class AzurePriceApiResponse
    {
        public string BillingCurrency { get; set; }
        public string CustomerEntityId { get; set; }
        public string CustomerEntityType { get; set; }
        public List<AzurePriceItem> Items { get; set; }
        public string NextPageLink { get; set; }
    }
}