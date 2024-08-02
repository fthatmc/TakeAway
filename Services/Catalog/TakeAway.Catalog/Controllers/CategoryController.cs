using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Catalog.Dtos.CategoryDtos;
using TakeAway.Catalog.Services.CategoryServices;

namespace TakeAway.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> CategoryList()
		{
			var values = await _categoryService.GetAllCategoryAsync();
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
		{
			await _categoryService.CreateCategoryAsync(createCategoryDto);
			return Ok("Kategori Eklendi");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteCategory(string id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			return Ok("Kategori Silindi");
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetCategory(string id)
		{
			var value = await _categoryService.GetByIdCategoryAsync(id);
			return Ok(value);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateCategoryAsync(updateCategoryDto);
			return Ok("Kategori başarıyla güncellendi");
		}
	}
}
