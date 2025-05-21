using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.GPSModelServices {
    public class GPSModelService : IGPSModelService {
        private readonly MainDBContext _context;

        public GPSModelService(MainDBContext context) {
            _context = context;
        }

        public async Task<IEnumerable<GPSModelEntity>> GetAllGPSModelsAsync() {
            return await _context.GPSModels
                .Include(g => g.Manufacturer)
                .Include(g => g.GNSSSystems)
                .ToListAsync();
        }

        public async Task<GPSModelEntity?> GetGPSModelByIdAsync(int id) {
            return await _context.GPSModels
                .Include(g => g.Manufacturer)
                .Include(g => g.GNSSSystems)
                .FirstOrDefaultAsync(g => g.GPSModelID == id);
        }

        public async Task<GPSModelEntity> CreateGPSModelAsync(CreateGPSModelDto dto) {
            var model = new GPSModelEntity {
                Model = dto.Model,
                ManufacturerID = dto.ManufacturerID,
                ApiSupportLevel = dto.ApiSupportLevel,
                AccuracyMeters = dto.AccuracyMeters,
                UpdateIntervalSec = dto.UpdateIntervalSec
            };

            _context.GPSModels.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> UpdateGPSModelAsync(int id, UpdateGPSModelDto dto) {
            var model = await _context.GPSModels.FindAsync(id);
            if (model == null) return false;

            if (dto.Model != null) model.Model = dto.Model;
            if (dto.ManufacturerID.HasValue) model.ManufacturerID = dto.ManufacturerID.Value;
            if (dto.ApiSupportLevel.HasValue) model.ApiSupportLevel = dto.ApiSupportLevel.Value;
            if (dto.AccuracyMeters.HasValue) model.AccuracyMeters = dto.AccuracyMeters.Value;
            if (dto.UpdateIntervalSec.HasValue) model.UpdateIntervalSec = dto.UpdateIntervalSec.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGPSModelAsync(int id) {
            var model = await _context.GPSModels.FindAsync(id);
            if (model == null) return false;

            _context.GPSModels.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
