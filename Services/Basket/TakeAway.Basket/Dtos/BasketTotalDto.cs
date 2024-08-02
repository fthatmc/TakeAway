namespace TakeAway.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public List<BasketItemDto> BasketItemDtos { get; set; }
        public decimal TotalPrice { get => BasketItemDtos.Sum(x => x.Price * x.Quantity); }
    }
}
