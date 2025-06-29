using AutoStocker.Domain.Dtos;
using AutoStocker.Domain.Entities;

namespace AutoStocker.Application.Services.Abstracts
{
    public interface IProductService
    {
        //Task<ProductDto> AddProductAsync(ProductCreateDto dto);
        //Task<List<ProductDto>> GetAllAsync();
        Task SyncProductsAsync();
        Task<List<ProductDto>> GetLowStockAsync();
    }
}
