using Backend.Data.Entities;

namespace Backend.Core.Services.RouteRelated.RouteServices
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteEntity>> GetAllRoutesAsync();
        Task<RouteEntity?> GetRouteByIdAsync(int id);
        Task<RouteEntity> CreateRouteAsync(CreateRouteDto dto);
        Task<bool> UpdateRouteAsync(int id, UpdateRouteDto dto);
        Task<bool> DeleteRouteAsync(int id);
    }
}
