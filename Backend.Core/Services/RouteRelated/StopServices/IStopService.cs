using Backend.Data.Entities;

namespace Backend.Core.Services.RouteRelated.StopServices
{
    public interface IStopService
    {
        Task<IEnumerable<StopEntity>> GetAllStopsAsync();
        Task<StopEntity?> GetStopByIdAsync(int id);
        Task<StopEntity> CreateStopAsync(CreateStopDto dto);
        Task<bool> UpdateStopAsync(int id, UpdateStopDto dto);
        Task<bool> DeleteStopAsync(int id);
    }
}
