using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.VehicleRelated.VehicleServices
{
    public class VehicleService : IVehicleService
    {
        private readonly MainDBContext _context;

        public VehicleService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)
                .Include(v => v.Driver)
                .Include(v => v.GPS)
                .Include(v => v.City)
                .Include(v => v.Route)
                .ToListAsync();
        }

        public async Task<VehicleEntity?> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles
                .Include(v => v.VehicleType)
                .Include(v => v.Driver)
                .Include(v => v.GPS)
                .Include(v => v.City)
                .Include(v => v.Route)
                .FirstOrDefaultAsync(v => v.VehicleID == id);
        }

        public async Task<VehicleEntity> CreateVehicleAsync(CreateVehicleDto dto)
        {
            var vehicle = new VehicleEntity
            {
                PlateNum = dto.PlateNum,
                VehicleTypeID = dto.VehicleTypeID,
                DriverID = dto.DriverID,
                GpsID = dto.GpsID,
                CityID = dto.CityID,
                RouteID = dto.RouteID
            };

            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return vehicle;
        }

        public async Task<bool> UpdateVehicleAsync(int id, UpdateVehicleDto dto)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            if (dto.PlateNum != null) vehicle.PlateNum = dto.PlateNum;
            if (dto.VehicleTypeID.HasValue) vehicle.VehicleTypeID = dto.VehicleTypeID.Value;
            if (dto.DriverID.HasValue) vehicle.DriverID = dto.DriverID;
            if (dto.GpsID.HasValue) vehicle.GpsID = dto.GpsID;
            if (dto.CityID.HasValue) vehicle.CityID = dto.CityID.Value;
            if (dto.RouteID.HasValue) vehicle.RouteID = dto.RouteID;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null) return false;

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
