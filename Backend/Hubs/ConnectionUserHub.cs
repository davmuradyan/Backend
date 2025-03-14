using Microsoft.AspNetCore.SignalR;
using System;
using System.Timers; // Make sure to use System.Timers explicitly
using System.Threading.Tasks;

namespace Backend.Hubs {
    public class ConnectionUserHub : Hub {
        private static readonly Random _random = new Random();
        private static System.Timers.Timer _timer; // Explicitly specify System.Timers.Timer

        public override async Task OnConnectedAsync() {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Hub");
            await Clients.Caller.SendAsync("UserConnected");

            // Start sending fake bus locations when a client connects
            if (_timer == null) {
                _timer = new System.Timers.Timer(2000); // Use System.Timers.Timer explicitly
                _timer.Elapsed += SendFakeBusLocation;
                _timer.AutoReset = true;
                _timer.Start();
            }
        }

        private async void SendFakeBusLocation(object sender, ElapsedEventArgs e) {
            double lat = 41.0963 + (_random.NextDouble() * 0.01); // Random movement
            double lng = 44.6527 + (_random.NextDouble() * 0.01);

            await Clients.Group("Hub").SendAsync("BusLocationUpdated", new { latitude = lat, longitude = lng });
        }
    }
}