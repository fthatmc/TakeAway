using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.ProductDtos;
using TakeAway.Catalog.Services.ProductServices;

namespace TakeAway.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _ProductService;
		public ProductController(IProductService ProductService)
		{
			_ProductService = ProductService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var values = await _ProductService.GetAllProductAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _ProductService.CreateProductAsync(createProductDto);
			return Ok("Ürün Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _ProductService.DeleteProductAsync(id);
			return Ok("Ürün Silindi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(string id)
		{
			var value = await _ProductService.GetByIdProductAsync(id);
			return Ok(value);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _ProductService.UpdateProductAsync(updateProductDto);
			return Ok("Ürün başarıyla güncellendi");
		}
	}
}
