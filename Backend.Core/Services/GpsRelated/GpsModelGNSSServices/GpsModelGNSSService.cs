using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.GpsRelated.GpsModelGNSSServices
{
    public class GpsModelGNSSService : IGpsModelGNSSService
    {
        private readonly MainDBContext _context;

        public GpsModelGNSSService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GpsModelGNSSEntity>> GetAllLinksAsync()
        {
            return await _context.GpsModelGNSS
                .Include(g => g.GPSModel)
                .Include(g => g.GNSSSystem)
                .ToListAsync();
        }

        public async Task<GpsModelGNSSEntity?> GetLinkByIdAsync(int id)
        {
            return await _context.GpsModelGNSS
                .Include(g => g.GPSModel)
                .Include(g => g.GNSSSystem)
                .FirstOrDefaultAsync(g => g.ID == id);
        }

        public async Task<GpsModelGNSSEntity> CreateLinkAsync(CreateGpsModelGNSSDto dto)
        {
            var link = new GpsModelGNSSEntity
            {
                GPSModelID = dto.GPSModelID,
                GNSSSystemID = dto.GNSSSystemID
            };

            _context.GpsModelGNSS.Add(link);
            await _context.SaveChangesAsync();

            return link;
        }

        public async Task<bool> DeleteLinkAsync(int id)
        {
            var link = await _context.GpsModelGNSS.FindAsync(id);
            if (link == null) return false;

            _context.GpsModelGNSS.Remove(link);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
