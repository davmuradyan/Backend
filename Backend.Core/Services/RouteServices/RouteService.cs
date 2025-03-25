using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Core.Services.RouteServices {
    public class RouteService : IRouteService {
        private readonly MainDBContext _context;
        private readonly ILogger<RouteService> _logger;

        public RouteService(MainDBContext context, ILogger<RouteService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEntity> CreateRouteAsync(string name) {
            try {
                var route = new RouteEntity {
                    Name = name
                };

                await _context.Routes.AddAsync(route);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Route {RouteName} added successfully.", name);
                return route;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create route.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEntity> GetRouteAsync(int id) {
            var route = await _context.Routes.FindAsync(id);
            if (route == null) {
                throw new KeyNotFoundException($"Route with ID {id} was not found.");
            }
            return route;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<RouteEntity>> GetRoutesAsync() {
            return await _context.Routes.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<RouteEntity?> UpdateRouteAsync(int id, string name) {
            try {
                var route = await _context.Routes.FindAsync(id);
                if (route == null) {
                    _logger.LogWarning("Route with ID {RouteId} wasn't found.", id);
                    return null;
                }

                route.Name = name;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Route with ID {RouteId} updated successfully.", id);

                return route;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Route with ID {RouteId}.", id);
                return null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteRouteAsync(int routeId) {
            try {
                var route = await _context.Routes.FindAsync(routeId);
                if (route == null) {
                    _logger.LogWarning("Route with ID {RouteId} not found, cannot delete.", routeId);
                    return false;
                }

                _context.Routes.Remove(route);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Route with ID {RouteId} was deleted successfully.", routeId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Route with ID {RouteId}.", routeId);
                return false;
            }
        }
    }
}