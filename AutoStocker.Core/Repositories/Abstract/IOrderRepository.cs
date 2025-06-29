using AutoStocker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        Task PlaceOrderAsync(Order order);
    }

}
