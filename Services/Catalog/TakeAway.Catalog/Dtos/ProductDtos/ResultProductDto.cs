namespace TakeAway.Catalog.Dtos.ProductDtos
{
	public class ResultProductDto
	{
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public string ShortDescription { get; set; }
		public string MainDescription { get; set; }
		public decimal Price { get; set; }
		public string ImageUrl { get; set; }
	}
}
