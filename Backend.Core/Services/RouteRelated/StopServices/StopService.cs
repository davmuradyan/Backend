using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.RouteRelated.StopServices
{
    public class StopService : IStopService
    {
        private readonly MainDBContext _context;

        public StopService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StopEntity>> GetAllStopsAsync()
        {
            return await _context.Stops.ToListAsync();
        }

        public async Task<StopEntity?> GetStopByIdAsync(int id)
        {
            return await _context.Stops.FirstOrDefaultAsync(s => s.StopID == id);
        }

        public async Task<StopEntity> CreateStopAsync(CreateStopDto dto)
        {
            var stop = new StopEntity
            {
                StopName = dto.StopName,
                StopAddress = dto.StopAddress,
                Longitude = dto.Longitude,
                Latitude = dto.Latitude,
                IsTerminal = dto.IsTerminal,
                CreationDate = DateTime.UtcNow
            };

            _context.Stops.Add(stop);
            await _context.SaveChangesAsync();
            return stop;
        }

        public async Task<bool> UpdateStopAsync(int id, UpdateStopDto dto)
        {
            var stop = await _context.Stops.FindAsync(id);
            if (stop == null) return false;

            if (dto.StopName != null) stop.StopName = dto.StopName;
            if (dto.StopAddress != null) stop.StopAddress = dto.StopAddress;
            if (dto.Longitude.HasValue) stop.Longitude = dto.Longitude.Value;
            if (dto.Latitude.HasValue) stop.Latitude = dto.Latitude.Value;
            if (dto.IsTerminal.HasValue) stop.IsTerminal = dto.IsTerminal.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStopAsync(int id)
        {
            var stop = await _context.Stops.FindAsync(id);
            if (stop == null) return false;

            _context.Stops.Remove(stop);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
