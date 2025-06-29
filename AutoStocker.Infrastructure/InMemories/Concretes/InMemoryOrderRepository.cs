using AutoStocker.Domain.Entities;
using AutoStocker.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Infrastructure.InMemories.Concretes
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public Task PlaceOrderAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task<List<Order>> GetAllAsync()
        {
            return Task.FromResult(_orders.ToList());
        }
    }

}
