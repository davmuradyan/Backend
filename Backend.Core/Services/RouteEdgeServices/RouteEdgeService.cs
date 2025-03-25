using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Core.Services.RouteEdgeServices {
    public class RouteEdgeService : IRouteEdgeService {
        private readonly MainDBContext _context;
        private readonly ILogger<RouteEdgeService> _logger;

        public RouteEdgeService(MainDBContext context, ILogger<RouteEdgeService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEdgeEntity> CreateRouteEdgeAsync(int routeId, int edgeId, int order) {
            try {
                var routeEdge = new RouteEdgeEntity {
                    Route_id = routeId,
                    Edge_id = edgeId,
                    Order = order,
                };

                await _context.RouteEdges.AddAsync(routeEdge);
                await _context.SaveChangesAsync();

                _logger.LogInformation("RouteEdge added successfully with Route ID {RouteId} and Edge ID {EdgeId}.", routeId, edgeId);
                return routeEdge;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create RouteEdge.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEdgeEntity> GetRouteEdgeAsync(int id) {
            var routeEdge = await _context.RouteEdges.FindAsync(id);
            if (routeEdge == null) {
                throw new KeyNotFoundException($"RouteEdge with ID {id} was not found.");
            }
            return routeEdge;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<RouteEdgeEntity>> GetRouteEdgesAsync() {
            return await _context.RouteEdges.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEdgeEntity?> UpdateRouteEdgeAsync(int id, int? routeId, int? edgeId, int? order) {
            try {
                var routeEdge = await _context.RouteEdges.FindAsync(id);
                if (routeEdge == null) {
                    _logger.LogWarning("RouteEdge with ID {RouteEdgeId} wasn't found.", id);
                    return null;
                }

                if (routeId.HasValue) routeEdge.Route_id = routeId.Value;

                if (edgeId.HasValue) routeEdge.Edge_id = edgeId.Value;

                if (order.HasValue) routeEdge.Order = order.Value;

                await _context.SaveChangesAsync();
                _logger.LogInformation("RouteEdge with ID {RouteEdgeId} updated successfully.", id);

                return routeEdge;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update RouteEdge with ID {RouteEdgeId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteRouteEdgeAsync(int routeEdgeId) {
            try {
                var routeEdge = await _context.RouteEdges.FindAsync(routeEdgeId);
                if (routeEdge == null) {
                    _logger.LogWarning("RouteEdge with ID {RouteEdgeId} not found, cannot delete.", routeEdgeId);
                    return false;
                }

                _context.RouteEdges.Remove(routeEdge);
                await _context.SaveChangesAsync();
                _logger.LogInformation("RouteEdge with ID {RouteEdgeId} was deleted successfully.", routeEdgeId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete RouteEdge with ID {RouteEdgeId}.", routeEdgeId);
                return false;
            }
        }
    }
}