﻿using Backend.Hubs;
using Microsoft.AspNetCore.SignalR;

public class BusLocationService {
    private readonly IHubContext<ConnectionUserHub> _hubContext;
    private Timer _timer;

    public BusLocationService(IHubContext<ConnectionUserHub> hubContext) {
        _hubContext = hubContext;
        _timer = new Timer(SendFakeBusLocation, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
    }
    
    private async void SendFakeBusLocation(object state) {
        await _hubContext.Clients.All.SendAsync("ReceiveFakeBusLocation", "Bus location update");
    }
}