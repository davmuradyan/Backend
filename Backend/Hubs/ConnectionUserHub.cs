using Microsoft.AspNetCore.SignalR;
using System;
using System.Timers;
using System.Threading.Tasks;

namespace Backend.Hubs {
    public class ConnectionUserHub : Hub {
        private static readonly Random _random = new Random();
        private static readonly object _lock = new object();
        private static System.Timers.Timer _timer;
        private static int _connectionCount = 0;

        public override async Task OnConnectedAsync() {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Hub");
            await Clients.Caller.SendAsync("UserConnected");

            lock (_lock) {
                _connectionCount++;
                if (_timer == null) {
                    _timer = new System.Timers.Timer(2000);
                    _timer.Elapsed += async (sender, e) => await SendFakeBusLocation();
                    _timer.AutoReset = true;
                    _timer.Start();
                }
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception) {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Hub");

            lock (_lock) {
                _connectionCount--;
                if (_connectionCount == 0 && _timer != null) {
                    _timer.Stop();
                    _timer.Dispose();
                    _timer = null;
                }
            }
        }

        private async Task SendFakeBusLocation() {
            double lat = 41.0963 + (_random.NextDouble() * 0.01);
            double lng = 44.6527 + (_random.NextDouble() * 0.01);

            await Clients.Group("Hub").SendAsync("BusLocationUpdated", new { latitude = lat, longitude = lng });
        }
    }
}
