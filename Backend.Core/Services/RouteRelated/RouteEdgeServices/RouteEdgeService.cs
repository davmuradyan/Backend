using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Core.Services.RouteRelated.RouteEdgeServices
{
    public class RouteEdgeService : IRouteEdgeService
    {
        private readonly MainDBContext _context;

        public RouteEdgeService(MainDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RouteEdgeEntity>> GetAllRouteEdgesAsync()
        {
            return await _context.RouteEdges
                .Include(re => re.Route)
                .Include(re => re.Edge)
                .ToListAsync();
        }

        public async Task<RouteEdgeEntity?> GetRouteEdgeByIdAsync(int id)
        {
            return await _context.RouteEdges
                .Include(re => re.Route)
                .Include(re => re.Edge)
                .FirstOrDefaultAsync(re => re.REID == id);
        }

        public async Task<RouteEdgeEntity> CreateRouteEdgeAsync(CreateRouteEdgeDto dto)
        {
            var routeEdge = new RouteEdgeEntity
            {
                RouteID = dto.RouteID,
                EdgeID = dto.EdgeID,
                Order = dto.Order,
                Direction = dto.Direction
            };

            _context.RouteEdges.Add(routeEdge);
            await _context.SaveChangesAsync();

            return routeEdge;
        }

        public async Task<bool> UpdateRouteEdgeAsync(int id, UpdateRouteEdgeDto dto)
        {
            var routeEdge = await _context.RouteEdges.FindAsync(id);
            if (routeEdge == null) return false;

            if (dto.RouteID.HasValue) routeEdge.RouteID = dto.RouteID.Value;
            if (dto.EdgeID.HasValue) routeEdge.EdgeID = dto.EdgeID.Value;
            if (dto.Order.HasValue) routeEdge.Order = dto.Order.Value;
            if (dto.Direction.HasValue) routeEdge.Direction = dto.Direction.Value;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRouteEdgeAsync(int id)
        {
            var routeEdge = await _context.RouteEdges.FindAsync(id);
            if (routeEdge == null) return false;

            _context.RouteEdges.Remove(routeEdge);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
