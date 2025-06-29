using AutoStocker.Domain.Entities;
using AutoStocker.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Infrastructure.Clients.FakeStore
{
    public interface IFakeStoreClient
    {
        Task<List<Product>> GetProductsAsync();
    }
}
