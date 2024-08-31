using Microsoft.AspNetCore.SignalR;
using TakeAwaySignalR.Api.DAL;

namespace TakeAwaySignalR.Api.Hubs
{
   

    public class SignalRHub : Hub
    {
        private readonly Context _context;

        public SignalRHub(Context context)
        {
            _context = context;
        }
        public async Task SendStatistics()
        {
            var value1 = _context.Deliveries.Where(x => x.Status == "Yolda").Count();
            await Clients.All.SendAsync("ReceiveStatusYoldaCount", value1);

            var value2 = _context.Deliveries.Sum(x => x.TotalPrice);
            await Clients.All.SendAsync("ReceiveStatusTotalPrice", value2);

            var value3 = _context.Deliveries.Count();
            await Clients.All.SendAsync("ReceiveStatusTotalDelivery", value3);
        }
    }
}
