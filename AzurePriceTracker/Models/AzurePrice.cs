﻿namespace AzurePriceTracker.Models
{
    public class AzurePrice
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public double RetailPrice { get; set; }
        public double UnitPrice { get; set; }
        public string ArmRegionName { get; set; }
        public string Location { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public string MeterId { get; set; }
        public string MeterName { get; set; }
        public string ProductId { get; set; }
        public string SkuId { get; set; }
        public string ProductName { get; set; }
        public string SkuName { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
        public string ServiceFamily { get; set; }
        public string UnitOfMeasure { get; set; }
        public string Type { get; set; }
        public bool IsPrimaryMeterRegion { get; set; }
        public string ArmSkuName { get; set; }
    }
}