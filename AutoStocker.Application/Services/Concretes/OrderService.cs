using AutoStocker.Application.Services.Abstracts;
using AutoStocker.Domain.Entities;
using AutoStocker.Domain.Repositories.Abstract;
using AutoStocker.Infrastructure.Clients.FakeStore;

namespace AutoStocker.Application.Services.Concretes
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IFakeStoreClient _fakeStoreClient;

        public OrderService(
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            IFakeStoreClient fakeStoreClient)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _fakeStoreClient = fakeStoreClient;
        }

        public async Task PlaceOrdersForLowStockAsync()
        {
            var lowStockProducts = await _productRepository.GetLowStockAsync();

            foreach (var product in lowStockProducts)
            {
                var offers = await _fakeStoreClient.GetProductsAsync();
                var matched = offers
                    .Where(p => $"{p.ProductCode}" == product.ProductCode)
                    .OrderBy(p => p.Price)
                    .FirstOrDefault();

                if (matched is not null)
                {
                    var order = new Order
                    {
                        ProductCode = product.ProductCode,
                        Vendor = "FakeStore",
                        Price = matched.Price
                    };

                    await _orderRepository.PlaceOrderAsync(order);
                }
            }
        }
    }

}
