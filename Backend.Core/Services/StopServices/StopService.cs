using Backend.Data.DAO;
using Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Core.Services.StopServices {
    public class StopService : IStopService {
        private readonly MainDBContext _context;
        private readonly ILogger<StopService> _logger;

        public StopService(MainDBContext context, ILogger<StopService> logger) {
            _context = context;
            _logger = logger;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<StopEntity> CreateStopAsync(string name, double latitude, double longitude) {
            try {
                var stopEntity = new StopEntity {
                    Name = name,
                    Latitude = latitude,
                    Longitude = longitude
                };

                await _context.Stops.AddAsync(stopEntity);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Stop {StopName} added successfully.", stopEntity.Name);
                return stopEntity;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to create stop.");
                throw;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<StopEntity> GetStopAsync(int id) {
            var stopEntity = await _context.Stops.FindAsync(id);

            if (stopEntity == null) {
                throw new KeyNotFoundException($"Stop with ID {id} was not found.");
            }

            return stopEntity;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<List<StopEntity>> GetStopsAsync() {
            return await _context.Stops.ToListAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<bool> DeleteStopAsync(int stopId) {
            try {
                var stop = await _context.Stops.FindAsync(stopId);

                if (stop == null) {
                    _logger.LogWarning("Stop with ID {StopId} not found, cannot delete.", stopId);
                    return false;
                }

                _context.Stops.Remove(stop);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Stop with ID {StopId} was deleted successfully.", stopId);
                return true;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to delete Stop with ID {StopId}.", stopId);
                return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<StopEntity?> UpdateStopAsync(int id, string? name = "", double? latitude = null, double? longitude = null) {
            try {
                var stop = await _context.Stops.FindAsync(id);

                if (stop == null) {
                    _logger.LogWarning("Stop with ID {StopId} wasn't found.", id);
                    return null;
                }

                if (!string.IsNullOrEmpty(name)) stop.Name = name;

                if (latitude.HasValue) stop.Latitude = latitude.Value;

                if (longitude.HasValue) stop.Longitude = longitude.Value;
                

                await _context.SaveChangesAsync();
                _logger.LogInformation("Stop with ID {StopId} updated successfully.", id);

                return stop;
            } catch (Exception ex) {
                _logger.LogError(ex, "Failed to update Stop with ID {StopId}.", id);
                return null;
            }
        }
    }
}