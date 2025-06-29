using AutoStocker.Domain.Entities;
using AutoStocker.Domain.Repositories.Abstract;
using System.Collections.Concurrent;

namespace AutoStocker.Infrastructure.InMemories.Concretes
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<string, Product> _products = new();

        public Task AddOrUpdateAsync(Product product)
        {
            _products.AddOrUpdate(product.ProductCode, product, (_, _) => product);
            return Task.CompletedTask;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return Task.FromResult(_products.Values.ToList());
        }

        public Task<List<Product>> GetLowStockAsync()
        {
            var lowStock = _products.Values
                .Where(p => p.Stock < p.Threshold)
                .ToList();

            return Task.FromResult(lowStock);
        }

        public Task<Product?> GetByCodeAsync(string productCode)
        {
            _products.TryGetValue(productCode, out var product);
            return Task.FromResult(product);
        }
    }

}
