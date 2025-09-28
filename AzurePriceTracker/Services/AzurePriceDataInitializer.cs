using AzurePriceTracker.Data;
using AzurePriceTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace AzurePriceTracker.Services
{
    public class AzurePriceDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public AzurePriceDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
             await FetchAndStoreAzurePrices();
             await GroupAndSaveData();
        }

        private async Task FetchAndStoreAzurePrices()
        {
            var httpClient = new HttpClient();
            var url = "https://prices.azure.com/api/retail/prices?currencyCode='INR'";

            try
            {
                var response = await httpClient.GetFromJsonAsync<AzurePriceApiResponse>(url);
                if (response?.Items != null)
                {
                    foreach (var item in response.Items)
                    {
                        var price = new AzurePrice
                        {
                            CurrencyCode = item.currencyCode,
                            RetailPrice = item.retailPrice,
                            UnitPrice = item.unitPrice,
                            ArmRegionName = item.armRegionName,
                            Location = item.location,
                            EffectiveStartDate = DateTime.Parse(item.effectiveStartDate),
                            MeterId = item.meterId,
                            MeterName = item.meterName,
                            ProductId = item.productId ?? "N/A",
                            SkuId = item.skuId ?? "N/A",
                            ProductName = item.productName,
                            SkuName = item.skuName,
                            ServiceName = item.serviceName,
                            ServiceId = item.serviceId ?? "N/A",
                            ServiceFamily = item.serviceFamily,
                            UnitOfMeasure = item.unitOfMeasure,
                            Type = item.type,
                            IsPrimaryMeterRegion = item.isPrimaryMeterRegion,
                            ArmSkuName = item.armSkuName
                        };
                        _context.AzurePrices.Add(price);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }

        private async Task GroupAndSaveData()
        {
            _context.ServiceGroups.RemoveRange(_context.ServiceGroups);
            _context.ProductDetails.RemoveRange(_context.ProductDetails);
            await _context.SaveChangesAsync();

            var serviceGroups = await _context.AzurePrices
                .GroupBy(p => new { p.ServiceFamily, p.ServiceName })
                .Select(g => new ServiceGroup
                {
                    ServiceFamily = g.Key.ServiceFamily,
                    ServiceName = g.Key.ServiceName,
                    ProductCount = g.Count(),
                    Expanded = false
                })
                .ToListAsync();

            await _context.ServiceGroups.AddRangeAsync(serviceGroups);
            await _context.SaveChangesAsync();

            foreach (var group in serviceGroups)
            {
                var products = await _context.AzurePrices
                    .Where(p => p.ServiceFamily == group.ServiceFamily && p.ServiceName == group.ServiceName)
                    .Select(p => new ProductDetail
                    {
                        ServiceFamily = p.ServiceFamily,
                        ServiceName = p.ServiceName,
                        ProductName = p.ProductName,
                        SkuName = p.SkuName,
                        Price = p.RetailPrice.ToString("C2"),
                        Location = p.Location,
                        UnitOfMeasure = p.UnitOfMeasure,
                        Type = p.Type
                    })
                    .ToListAsync();

                await _context.ProductDetails.AddRangeAsync(products);
            }
            await _context.SaveChangesAsync();
        }
    }
}