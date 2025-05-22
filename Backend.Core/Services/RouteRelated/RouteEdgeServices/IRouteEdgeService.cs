using Backend.Data.Entities;

namespace Backend.Core.Services.RouteRelated.RouteEdgeServices
{
    public interface IRouteEdgeService
    {
        Task<IEnumerable<RouteEdgeEntity>> GetAllRouteEdgesAsync();
        Task<RouteEdgeEntity?> GetRouteEdgeByIdAsync(int id);
        Task<RouteEdgeEntity> CreateRouteEdgeAsync(CreateRouteEdgeDto dto);
        Task<bool> UpdateRouteEdgeAsync(int id, UpdateRouteEdgeDto dto);
        Task<bool> DeleteRouteEdgeAsync(int id);
    }
}
