using Backend.Data.Entities;

namespace Backend.Core.Services.LocationRelated.RegionServices
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionEntity>> GetAllRegionsAsync();
        Task<RegionEntity?> GetRegionByIdAsync(int id);
        Task<RegionEntity> CreateRegionAsync(CreateRegionDto dto);
        Task<bool> UpdateRegionAsync(int id, UpdateRegionDto dto);
        Task<bool> DeleteRegionAsync(int id);
    }
}