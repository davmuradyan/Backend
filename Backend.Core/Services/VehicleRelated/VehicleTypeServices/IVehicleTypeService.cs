using Backend.Data.Entities;

namespace Backend.Core.Services.VehicleRelated.VehicleTypeServices
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeEntity>> GetAllVehicleTypesAsync();
        Task<VehicleTypeEntity?> GetVehicleTypeByIdAsync(int id);
        Task<VehicleTypeEntity> CreateVehicleTypeAsync(CreateVehicleTypeDto dto);
        Task<bool> UpdateVehicleTypeAsync(int id, UpdateVehicleTypeDto dto);
        Task<bool> DeleteVehicleTypeAsync(int id);
    }
}
