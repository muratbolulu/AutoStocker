using AutoStocker.Application.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace AutoStocker.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // POST: /api/orders/check-and-place
        [HttpPost("check-and-place")]
        [EnableRateLimiting("fixed")] // 🔐 rate limit uygulanıyor
        public async Task<IActionResult> PlaceOrdersForLowStock()
        {
            await _orderService.PlaceOrdersForLowStockAsync();
            return Ok(new { Message = "Siparişler başarıyla oluşturuldu (düşük stoklara göre)." });
        }
    }

}
