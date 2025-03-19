using Backend.Data.Entities;

namespace Backend.Core.Services.StopServices
{
    public interface IStopService
    {
        public StopEntity AddStop(string name, double latitude, double longitude);
        public StopEntity RemoveStop(int Stop_id);
    }
}