namespace TakeAwaySignalR.Api.DAL
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
}
