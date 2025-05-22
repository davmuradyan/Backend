using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.VehicleRelated.VehicleTypeServices
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly MainDBContext _context;

        public VehicleTypeService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleTypeEntity>> GetAllVehicleTypesAsync()
        {
            return await _context.VehicleTypes
                .Include(vt => vt.Manufacturer)
                .ToListAsync();
        }

        public async Task<VehicleTypeEntity?> GetVehicleTypeByIdAsync(int id)
        {
            return await _context.VehicleTypes
                .Include(vt => vt.Manufacturer)
                .FirstOrDefaultAsync(vt => vt.VehicleTypeID == id);
        }

        public async Task<VehicleTypeEntity> CreateVehicleTypeAsync(CreateVehicleTypeDto dto)
        {
            var vt = new VehicleTypeEntity
            {
                Model = dto.Model,
                Sits = dto.Sits,
                MaxCapacity = dto.MaxCapacity,
                IsElectric = dto.IsElectric,
                ManufacturerID = dto.ManufacturerID
            };

            _context.VehicleTypes.Add(vt);
            await _context.SaveChangesAsync();
            return vt;
        }

        public async Task<bool> UpdateVehicleTypeAsync(int id, UpdateVehicleTypeDto dto)
        {
            var vt = await _context.VehicleTypes.FindAsync(id);
            if (vt == null) return false;

            if (dto.Model != null) vt.Model = dto.Model;
            if (dto.Sits.HasValue) vt.Sits = dto.Sits.Value;
            if (dto.MaxCapacity.HasValue) vt.MaxCapacity = dto.MaxCapacity.Value;
            if (dto.IsElectric.HasValue) vt.IsElectric = dto.IsElectric.Value;
            if (dto.ManufacturerID.HasValue) vt.ManufacturerID = dto.ManufacturerID.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleTypeAsync(int id)
        {
            var vt = await _context.VehicleTypes.FindAsync(id);
            if (vt == null) return false;

            _context.VehicleTypes.Remove(vt);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
