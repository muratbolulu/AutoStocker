using AutoStocker.Application.Dtos;
using AutoStocker.Application.Services.Abstracts;
using AutoStocker.Domain.Dtos;
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
        //[HttpPost]
        //public async Task<IActionResult> Products([FromBody] ProductCreateDto dto)
        //{
        //    var result = await _productService.AddProductAsync(dto);
        //    return Ok(result);
        //}
    }

}
