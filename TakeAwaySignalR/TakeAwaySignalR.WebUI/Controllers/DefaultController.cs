using Microsoft.AspNetCore.Mvc;

namespace TakeAwaySignalR.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7010/api/Deliveries/GetTotalDelivery");
            var jsonData = await responseMesage.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData;

            var client1 = _httpClientFactory.CreateClient();
            var responseMesage1 = await client1.GetAsync("https://localhost:7010/api/Deliveries/GetTotalPrice");
            var jsonData1 = await responseMesage1.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData1;

            return View();
        }
    }
}
