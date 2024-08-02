using TakeAway.WebUI.Dtos.CatalogDtos.ProductDtos;

namespace TakeAway.WebUI.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductsAsync();
    }
}
