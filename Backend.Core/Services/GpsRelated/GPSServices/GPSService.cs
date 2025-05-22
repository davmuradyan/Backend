using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.GpsRelated.GPSServices
{
    public class GPSService : IGPSService
    {
        private readonly MainDBContext _context;

        public GPSService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GPSEntity>> GetAllGPSAsync()
        {
            return await _context.GPS
                .Include(g => g.GPSModel)
                .ToListAsync();
        }

        public async Task<GPSEntity?> GetGPSByIdAsync(int id)
        {
            return await _context.GPS
                .Include(g => g.GPSModel)
                .FirstOrDefaultAsync(g => g.GpsID == id);
        }

        public async Task<GPSEntity> CreateGPSAsync(CreateGPSDto dto)
        {
            var gps = new GPSEntity
            {
                ID = dto.ID,
                GPSModelID = dto.GPSModelID
            };

            _context.GPS.Add(gps);
            await _context.SaveChangesAsync();

            return gps;
        }

        public async Task<bool> UpdateGPSAsync(int id, UpdateGPSDto dto)
        {
            var gps = await _context.GPS.FindAsync(id);
            if (gps == null) return false;

            if (dto.ID != null) gps.ID = dto.ID;
            if (dto.GPSModelID.HasValue) gps.GPSModelID = dto.GPSModelID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGPSAsync(int id)
        {
            var gps = await _context.GPS.FindAsync(id);
            if (gps == null) return false;

            _context.GPS.Remove(gps);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
