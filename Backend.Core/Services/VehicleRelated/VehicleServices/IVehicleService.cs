using Backend.Data.Entities;

namespace Backend.Core.Services.VehicleRelated.VehicleServices
{
    public interface IVehicleService
    {
        Task<IEnumerable<VehicleEntity>> GetAllVehiclesAsync();
        Task<VehicleEntity?> GetVehicleByIdAsync(int id);
        Task<VehicleEntity> CreateVehicleAsync(CreateVehicleDto dto);
        Task<bool> UpdateVehicleAsync(int id, UpdateVehicleDto dto);
        Task<bool> DeleteVehicleAsync(int id);
    }
}
