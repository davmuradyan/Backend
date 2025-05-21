using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.RegionServices {
    public class RegionService : IRegionService {
        private readonly MainDBContext _context;

        public RegionService(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<RegionEntity>> GetAllRegionsAsync() {
            return await _context.Regions
                .Include(r => r.Country)
                .ToListAsync();
        }

        public async Task<RegionEntity?> GetRegionByIdAsync(int id) {
            return await _context.Regions
                .Include(r => r.Country)
                .FirstOrDefaultAsync(r => r.RegionID == id);
        }

        public async Task<RegionEntity> CreateRegionAsync(CreateRegionDto dto) {
            var region = new RegionEntity {
                Name = dto.Name,
                Population = dto.Population,
                Area = dto.Area,
                CountryID = dto.CountryID,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return region;
        }

        public async Task<bool> UpdateRegionAsync(int id, UpdateRegionDto dto) {
            var region = await _context.Regions.FindAsync(id);
            if (region == null) return false;

            if (dto.Name != null) region.Name = dto.Name;
            if (dto.Population.HasValue) region.Population = dto.Population.Value;
            if (dto.Area.HasValue) region.Area = dto.Area.Value;
            if (dto.CountryID.HasValue) region.CountryID = dto.CountryID.Value;

            region.Updated = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRegionAsync(int id) {
            var region = await _context.Regions.FindAsync(id);
            if (region == null) return false;

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
