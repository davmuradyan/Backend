using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.CityServices {
    public class CityServices : ICityServices {
        private readonly MainDBContext _context;

        public CityServices(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<CityEntity>> GetAllCitiesAsync() {
            return await _context.Cities.Include(c => c.Region).ToListAsync();
        }

        public async Task<CityEntity?> GetCityByIdAsync(int id) {
            return await _context.Cities.Include(c => c.Region).FirstOrDefaultAsync(c => c.CityID == id);
        }

        public async Task<CityEntity> CreateCityAsync(CreateCityDto dto) {
            var city = new CityEntity {
                Name = dto.Name,
                Population = dto.Population,
                Area = dto.Area,
                RegionID = dto.RegionID,
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return city;
        }

        public async Task<bool> UpdateCityAsync(int id, UpdateCityDto dto) {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return false;

            if (dto.Name != null) city.Name = dto.Name;
            if (dto.Population.HasValue) city.Population = dto.Population.Value;
            if (dto.Area.HasValue) city.Area = dto.Area.Value;
            if (dto.RegionID.HasValue) city.RegionID = dto.RegionID.Value;

            city.Updated = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCityAsync(int id) {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return false;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}