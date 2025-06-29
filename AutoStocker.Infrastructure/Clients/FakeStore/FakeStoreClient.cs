using AutoStocker.Domain.Entities;
using AutoStocker.Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace AutoStocker.Infrastructure.Clients.FakeStore
{
    public class FakeStoreClient : IFakeStoreClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FakeStoreClient> _logger;

        public FakeStoreClient(HttpClient httpClient, ILogger<FakeStoreClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                //burayı options pattern ile inject edeceğim. urli
                var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<FakeStoreProduct>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new();

                return products.Select(fp => new Product
                {
                    ProductCode = $"{fp.Id}",
                    Name = fp.Title,
                    Stock = Random.Shared.Next(1, 20),
                    Threshold = 5,
                    Price = fp.Price //fiyata göre algoritma için eklendi.
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "FakeStore API'den ürünler alınamadı.");
                return new List<Product>();
            }
        }
    }

}
