using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoStocker.Application.Services.Abstracts
{
    public interface IOrderService
    {
        Task PlaceOrdersForLowStockAsync();
    }
}
