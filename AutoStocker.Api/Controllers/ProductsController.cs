using AutoStocker.Application.Dtos;
using AutoStocker.Application.Services.Abstracts;
using AutoStocker.Domain.Dtos;
using AutoStocker.Domain.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;

namespace AutoStocker.Api.Controllers
{
    // örnek ProductsController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: /api/products/low-stock
        [HttpGet("low-stock")]
        public async Task<ActionResult<List<ProductDto>>> GetLowStockProducts()
        {
            var products = await _productService.GetLowStockAsync();
            return Ok(products);
        }


        //buraya api den ürünler gelir. html kısmına daha sonra bakılacak.


        [HttpGet("csrf-token")]
        public IActionResult GetCsrfToken([FromServices] IAntiforgery antiforgery)
        {
            if (antiforgery == null)
            {
                throw new ArgumentNullException("Antiforgery service is not available.");
            }

            var tokens = antiforgery.GetAndStoreTokens(HttpContext);
            return Ok(new { token = tokens.RequestToken });
        }


        [HttpPost("add-or-update-product")]
        public async Task<IActionResult> AddProduct([FromBody] Product dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.ProductCode))
                return BadRequest("Geçersiz ürün bilgisi.");

            var product = new Product
            {
                ProductCode = dto.ProductCode,
                Name = dto.Name,
                Stock = dto.Stock,
                Threshold = dto.Threshold,
                //Price = dto.Price
            };

            await _productService.AddOrUpdateAsync(product);

            return Ok(new { message = "Ürün başarıyla eklendi.", productCode = product.ProductCode });
        }

    }
}
