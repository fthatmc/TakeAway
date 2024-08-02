using Newtonsoft.Json;
using TakeAway.WebUI.Dtos.CatalogDtos.ProductDtos;

namespace TakeAway.WebUI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:6001/api/Product");
            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata);
            return values;
        }
    }
}
