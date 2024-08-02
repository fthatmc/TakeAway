namespace TakeAway.WebUI.Dtos.CatalogDtos.ProductDtos
{
    public class ResultProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string MainDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
