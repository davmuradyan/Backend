using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.ManufacturerServices {
    public class ManufacturerService : IManufacturerService {
        private readonly MainDBContext _context;

        public ManufacturerService(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<ManufacturerEntity>> GetAllManufacturersAsync() {
            return await _context.Manufacturers
                .Include(m => m.Country)
                .Include(m => m.GPSModels)
                .Include(m => m.VehicleTypes)
                .ToListAsync();
        }

        public async Task<ManufacturerEntity?> GetManufacturerByIdAsync(int id) {
            return await _context.Manufacturers
                .Include(m => m.Country)
                .Include(m => m.GPSModels)
                .Include(m => m.VehicleTypes)
                .FirstOrDefaultAsync(m => m.ManufacturerID == id);
        }

        public async Task<ManufacturerEntity> CreateManufacturerAsync(CreateManufacturerDto dto) {
            var manufacturer = new ManufacturerEntity {
                Name = dto.Name,
                CountryID = dto.CountryID
            };

            _context.Manufacturers.Add(manufacturer);
            await _context.SaveChangesAsync();

            return manufacturer;
        }

        public async Task<bool> UpdateManufacturerAsync(int id, UpdateManufacturerDto dto) {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null) return false;

            if (dto.Name != null) manufacturer.Name = dto.Name;
            if (dto.CountryID.HasValue) manufacturer.CountryID = dto.CountryID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteManufacturerAsync(int id) {
            var manufacturer = await _context.Manufacturers.FindAsync(id);
            if (manufacturer == null) return false;

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
