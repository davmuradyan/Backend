using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Backend.Hubs {
    public class ConnectionUserHub : Hub {
        private readonly BusLocationService _busLocationService;

        public ConnectionUserHub(BusLocationService busLocationService) {
            _busLocationService = busLocationService;
        }

        public override async Task OnConnectedAsync() {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Hub");
            await Clients.Caller.SendAsync("UserConnected");
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Hub");
        }
    }
}