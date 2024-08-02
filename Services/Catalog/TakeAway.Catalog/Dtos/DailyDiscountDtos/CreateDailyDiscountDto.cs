namespace TakeAway.Catalog.Dtos.DailyDiscountDtos
{
	public class CreateDailyDiscountDto
	{
		public string MailTitle { get; set; }
		public string SubTitle { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public bool Status { get; set; }
	}
}
