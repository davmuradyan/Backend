using Microsoft.AspNetCore.SignalR;

namespace Backend.Hubs {
    public class ConnectionUserHub : Hub {
        public override async Task OnConnectedAsync() {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Hub");
            await Clients.Caller.SendAsync("UserConnected");
        }
    }
}
