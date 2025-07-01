using AutoStocker.Domain.Dtos;
using AutoStocker.Domain.Entities;

namespace AutoStocker.Application.Services.Abstracts
{
    public interface IProductService
    {
        Task AddOrUpdateAsync(Product product);
        //Task<List<ProductDto>> GetAllAsync();
        Task SyncProductsAsync();
        Task<List<ProductDto>> GetLowStockAsync();
    }
}
