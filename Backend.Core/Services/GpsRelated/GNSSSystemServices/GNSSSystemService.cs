using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.GpsRelated.GNSSSystemServices
{
    public class GNSSSystemService : IGNSSSystemService
    {
        private readonly MainDBContext _context;

        public GNSSSystemService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GNSSSystemEntity>> GetAllGNSSSystemsAsync()
        {
            return await _context.GNSSSystems
                .Include(g => g.Country)
                .Include(g => g.GpsModelGNSS)
                .ToListAsync();
        }

        public async Task<GNSSSystemEntity?> GetGNSSSystemByIdAsync(int id)
        {
            return await _context.GNSSSystems
                .Include(g => g.Country)
                .Include(g => g.GpsModelGNSS)
                .FirstOrDefaultAsync(g => g.GNSSSystemID == id);
        }

        public async Task<GNSSSystemEntity> CreateGNSSSystemAsync(CreateGNSSSystemDto dto)
        {
            var gnss = new GNSSSystemEntity
            {
                Name = dto.Name,
                FrequencyBand = dto.FrequencyBand,
                CountryID = dto.CountryID
            };

            _context.GNSSSystems.Add(gnss);
            await _context.SaveChangesAsync();

            return gnss;
        }

        public async Task<bool> UpdateGNSSSystemAsync(int id, UpdateGNSSSystemDto dto)
        {
            var gnss = await _context.GNSSSystems.FindAsync(id);
            if (gnss == null) return false;

            if (dto.Name != null) gnss.Name = dto.Name;
            if (dto.FrequencyBand != null) gnss.FrequencyBand = dto.FrequencyBand;
            if (dto.CountryID.HasValue) gnss.CountryID = dto.CountryID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGNSSSystemAsync(int id)
        {
            var gnss = await _context.GNSSSystems.FindAsync(id);
            if (gnss == null) return false;

            _context.GNSSSystems.Remove(gnss);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
