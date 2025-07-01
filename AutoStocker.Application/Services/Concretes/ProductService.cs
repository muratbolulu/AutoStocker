using AutoStocker.Application.Services.Abstracts;
using AutoStocker.Domain.Dtos;
using AutoStocker.Domain.Entities;
using AutoStocker.Domain.Repositories.Abstract;
using AutoStocker.Infrastructure.Clients.FakeStore;

namespace AutoStocker.Application.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IFakeStoreClient _fakeStoreClient;
        private readonly IProductRepository _productRepository;

        public ProductService(IFakeStoreClient fakeStoreClient, IProductRepository productRepository)
        {
            _fakeStoreClient = fakeStoreClient;
            _productRepository = productRepository;
        }

        public async Task SyncProductsAsync()
        {
            var externalProducts = await _fakeStoreClient.GetProductsAsync();

            foreach (var p in externalProducts)
            {
                var product = new Product
                {
                    ProductCode = $"fake-{p.Id}",
                    Name = p.Name,
                    Stock = Random.Shared.Next(1, 20),
                    Threshold = 5
                };

                await _productRepository.AddOrUpdateAsync(product);
            }
        }

        public async Task<List<ProductDto>> GetLowStockAsync()
        {
            var products = await _productRepository.GetLowStockAsync();
            return products.Select(p => new ProductDto(p)).ToList();
        }

        public async Task AddOrUpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _productRepository.AddOrUpdateAsync(product);
        }
    }


}
