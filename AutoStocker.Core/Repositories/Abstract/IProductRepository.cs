using AutoStocker.Domain.Entities;

namespace AutoStocker.Domain.Repositories.Abstract
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetLowStockAsync();
        Task AddOrUpdateAsync(Product product);
        Task<Product?> GetByCodeAsync(string productCode);
    }
}
