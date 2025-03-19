using Backend.Data.DAO;
using Backend.Data.Entities;

namespace Backend.Core.Services.StopServices
{
    public class StopService : IStopService
    {
        private MainDBContext _context;

        public StopService(MainDBContext context)
        {
            _context = context;
        }

        // Add new stop entity
        public StopEntity AddStop(string name, double latitude, double longitude)
        {
            StopEntity stopEntity = new StopEntity();
            stopEntity.Name = name;
            stopEntity.Latitude = latitude;
            stopEntity.Longitude = longitude;
            _context.Stops.Add(stopEntity);
            _context.SaveChanges();
            Console.WriteLine($"Stop  {stopEntity.Name} added");
            return stopEntity;
        }

        // Remove stop entity
        public StopEntity RemoveStop(int Stop_id)
        {
            StopEntity? stop = _context.Stops.FirstOrDefault(s => s.Stop_id == Stop_id);

            if (stop != null)
            {
                _context.Stops.Remove(stop);
                _context.SaveChanges();
                Console.WriteLine($"Stop {stop.Stop_id}");
            }

            return stop;
        }
    }
}
